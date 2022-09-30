using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using CP_v1_2.Classes;

namespace CP_v1_2.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для editCashFlow.xaml
    /// </summary>
    public partial class editCashFlow : Window
    {
        private CashFlow CashFlow { get; set; }
        private bool Edit { get; set; }
        public editCashFlow(int ID, bool edit)
        {
            InitializeComponent();
            Edit = edit;
            if (Edit)
            {
                using (HBContext db = new HBContext())
                {
                    CashFlow = db.CashFlows.Where(o => o.ID == ID).First();
                }
            }
            else
            {
                CashFlow = new CashFlow(); ;
            }
            FillCashFlow();
        }

        private void FillCashFlow()
        {
            using (HBContext db = new HBContext())
            {
                int userID = db.TemporaryUsers.Where(tmp => tmp.TemporaryUserID == 1).Select(w => w.UserId).First();

                cbxWallets.ItemsSource = db.Wallets.Where(w => w.UserID == userID).Select(w => w.WalletName).ToList();
                cbxNom.ItemsSource = db.Nomenclatures.Select(o => o.NomenclatureName).ToList();

                if (Edit)
                {

                    cbxWallets.SelectedItem = db.Wallets.Where(w => w.WalletID == CashFlow.WalletID).
                                                         Select(w => w.WalletName).First();


                    cbxNom.SelectedItem = db.Nomenclatures.Where(n => n.NomenclatureID == CashFlow.NomenclatureID).
                                                           Select(n => n.NomenclatureName).First();

                    tblSum.Text = CashFlow.Sum.ToString();
                    dtPick.SelectedDate = CashFlow.DateTime;
                    tblDesc.Text = CashFlow.Description;
                }
                else
                {
                    dtPick.SelectedDate = DateTime.Now;
                    cbxNom.SelectedIndex = 0;
                    cbxWallets.SelectedIndex = 0;

                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void _Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void _Edit_Click(object sender, RoutedEventArgs e)
        {
            using (HBContext db = new HBContext())
            {
                //sum: try parse
                decimal sum = staticServiseClass.TryParseSum(tblSum.Text);
                if (sum == 0)
                {
                    MessageBox.Show("Wrong sum value");
                    return;
                }
                //wallet and planning: change sum
                if (Edit)
                {
                    bool currCategoryType = db.Nomenclatures.Where(n => n.NomenclatureID == CashFlow.NomenclatureID).

                                                Join(db.Categories, n => n.CategoryID, c => c.CategoryID,
                                                (n, c) => new { c.CategoryType }).Select(o => o.CategoryType).First();
                    db.Wallets.Where(w => w.WalletID == CashFlow.WalletID).First().WalletSum += currCategoryType ? (CashFlow.Sum * -1) : CashFlow.Sum;

                    Wallet old_wallet = db.Wallets.Where(w => w.WalletID == CashFlow.WalletID).First();
                    int old_categoryID = db.Nomenclatures.Where(nom => nom.NomenclatureID == CashFlow.NomenclatureID).First().CategoryID;
                    try
                    {
                        db.PlanningCashFlows.Where(pl => pl.UserID == old_wallet.UserID
                        && pl.Period_month == CashFlow.DateTime.Month && pl.Period_year == CashFlow.DateTime.Year
                        && pl.CurrencyID == old_wallet.CurrencyID && pl.CategoryID == old_categoryID).
                        First().CashFlowSum -= CashFlow.Sum;
                    }
                    catch (Exception) { }
                }
                //write new parametres
                CashFlow.WalletID = db.Wallets.Where(w => w.WalletName == cbxWallets.SelectedItem.ToString()).Select(w => w.WalletID).First();
                CashFlow.NomenclatureID = db.Nomenclatures.Where(w => w.NomenclatureName == cbxNom.SelectedItem.ToString()).Select(w => w.NomenclatureID).First();
                CashFlow.Description = tblDesc.Text;
                CashFlow.DateTime = dtPick.SelectedDate;
                CashFlow.Sum = sum;
                //new wallet: change sum
                bool newCategoryType = db.Nomenclatures.Where(n => n.NomenclatureID == CashFlow.NomenclatureID).
                                                Join(db.Categories, n => n.CategoryID, c => c.CategoryID,
                                                (n, c) => new { c.CategoryType }).Select(o => o.CategoryType).First();
                decimal newWalletSum = db.Wallets.Where(w => w.WalletID == CashFlow.WalletID).First().WalletSum;
                newWalletSum += newCategoryType ? CashFlow.Sum : (CashFlow.Sum * -1);
                if (newWalletSum < 0)
                {
                    MessageBox.Show("Too more spend for this wallet. You must change sum or wallet");
                    return;
                }
                db.Wallets.Where(w => w.WalletID == CashFlow.WalletID).First().WalletSum = newWalletSum;
                //add new row...
                if (!Edit)
                {
                    db.CashFlows.Add(CashFlow);
                }
                //...or edit current
                else
                {
                    db.CashFlows.Where(o => o.ID == CashFlow.ID).First().WalletID = CashFlow.WalletID;
                    db.CashFlows.Where(o => o.ID == CashFlow.ID).First().NomenclatureID = CashFlow.NomenclatureID;
                    db.CashFlows.Where(o => o.ID == CashFlow.ID).First().Description = CashFlow.Description;
                    db.CashFlows.Where(o => o.ID == CashFlow.ID).First().DateTime = CashFlow.DateTime;
                    db.CashFlows.Where(o => o.ID == CashFlow.ID).First().Sum = CashFlow.Sum;

                }
                //check and change planning cashflow sum
                Wallet wallet = db.Wallets.Where(w => w.WalletID == CashFlow.WalletID).First();
                int categoryID = db.Nomenclatures.Where(nom => nom.NomenclatureID == CashFlow.NomenclatureID).First().CategoryID;
                try
                {
                    db.PlanningCashFlows.Where(pl => pl.UserID == wallet.UserID
                    && pl.Period_month == CashFlow.DateTime.Month && pl.Period_year == CashFlow.DateTime.Year
                    && pl.CurrencyID == wallet.CurrencyID && pl.CategoryID == categoryID).
                    First().CashFlowSum += CashFlow.Sum;
                }
                catch (Exception)
                {              }
                //save changes
                db.SaveChanges();
            }
            DialogResult = true;
        }
    }
}
