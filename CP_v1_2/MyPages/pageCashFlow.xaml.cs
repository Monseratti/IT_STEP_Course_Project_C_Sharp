using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CP_v1_2.Classes;
using CP_v1_2.MyWindows;

namespace CP_v1_2.MyPages
{
    /// <summary>
    /// Логика взаимодействия для pageCashFlow.xaml
    /// </summary>
    public partial class pageCashFlow : Page
    {
        User User { get; set; }
        public pageCashFlow()
        {
            InitializeComponent();
            User = staticServiseClass.GetTemporaryUser();
            viewCashFlow(tblSearch.Text);
        }
        #region Cashflow view
        private void viewCashFlow(string find)
        {
            using (HBContext db = new HBContext())
            {
                var cashflow = db.CashFlows.

                    Join(db.Wallets, w => w.WalletID, cf => cf.WalletID,
                    (cf, w) => new { cf.DateTime, cf.ID, cf.Description, cf.NomenclatureID, cf.Sum, w.UserID, w.WalletName, w.CurrencyID }).

                    Where(cf => cf.UserID == User.UserID).

                    Join(db.Currencies, c => c.CurrencyID, cf => cf.CurrensyID,
                    (c, cf) => new { cf.CurrencyName, c.Sum, c.NomenclatureID, c.WalletName, c.DateTime, c.Description, c.ID }).

                    Join(db.Nomenclatures, cf => cf.NomenclatureID, n => n.NomenclatureID,
                    (cf, n) => new { cf.CurrencyName, cf.Sum, cf.ID, cf.Description, cf.WalletName, cf.DateTime, n.NomenclatureName, n.CategoryID }).

                    Join(db.Categories, cf => cf.CategoryID, cat => cat.CategoryID,
                    (cf, cat) => new
                    {
                        ID = cf.ID,
                        DateOfOp = cf.DateTime,
                        Wallet = cf.WalletName,
                        Nom = cf.NomenclatureName,
                        Categ = cat.CategoryName,
                        CatType = cat.CategoryType,
                        Sum = cf.Sum,
                        Curr = cf.CurrencyName,
                        Desc = cf.Description,
                    }).ToArray();
                if (tblSearch.Text != string.Empty)
                {
                    cashflow = cashflow.Where(o => o.Categ.Contains(tblSearch.Text)).ToArray();
                }

                dataCashFlow.ItemsSource = cashflow;
            }
        }
        #endregion

        #region Cashflow CRUD
        private void btnEditRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataCashFlow.SelectedItem.GetType().GetProperty("ID").GetValue(dataCashFlow.SelectedItem).ToString());
            editCashFlow editCash = new editCashFlow(itemID, true);
            editCash.ShowDialog();
            viewCashFlow(tblSearch.Text);
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataCashFlow.SelectedItem.GetType().GetProperty("ID").GetValue(dataCashFlow.SelectedItem).ToString());
            using (HBContext db = new HBContext())
            {
                try
                {
                    CashFlow tmp = db.CashFlows.Where(o => o.ID == itemID).FirstOrDefault();
                    bool currCategoryType = db.Nomenclatures.Where(n => n.NomenclatureID == tmp.NomenclatureID).

                                               Join(db.Categories, n => n.CategoryID, c => c.CategoryID,
                                               (n, c) => new { c.CategoryType }).Select(o => o.CategoryType).First();
                    decimal newWalletSum = db.Wallets.Where(w => w.WalletID == tmp.WalletID).First().WalletSum;
                    newWalletSum += currCategoryType ? (tmp.Sum * -1) : tmp.Sum;
                    if (newWalletSum < 0)
                    {
                        MessageBox.Show("Too more spend for this wallet. You must remove some spend before it");
                        return;
                    }
                    db.Wallets.Where(w => w.WalletID == tmp.WalletID).First().WalletSum = newWalletSum;
                    Wallet old_wallet = db.Wallets.Where(w => w.WalletID == tmp.WalletID).First();
                    int old_categoryID = db.Nomenclatures.Where(nom => nom.NomenclatureID == tmp.NomenclatureID).First().CategoryID;
                    try
                    {
                        db.PlanningCashFlows.Where(pl => pl.UserID == old_wallet.UserID
                        && pl.Period_month == tmp.DateTime.Month && pl.Period_year == tmp.DateTime.Year
                        && pl.CurrencyID == old_wallet.CurrencyID && pl.CategoryID == old_categoryID).
                        First().CashFlowSum -= tmp.Sum;
                    }
                    catch (Exception) { }

                    db.CashFlows.Remove(tmp);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            viewCashFlow(tblSearch.Text);
        }

        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            editCashFlow editCash = new editCashFlow(0, false);
            editCash.ShowDialog();
            viewCashFlow(tblSearch.Text);
        }
        #endregion

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            viewCashFlow(tblSearch.Text);
        }
    }
}
