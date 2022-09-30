using CP_v1_2.Classes;
using CP_v1_2.MyWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CP_v1_2.MyPages
{
    /// <summary>
    /// Логика взаимодействия для pageAdminSettings.xaml
    /// </summary>
    public partial class pageAdminSettings : Page
    {
        public pageAdminSettings()
        {
            InitializeComponent();
            UserData();
            NomData();
            CurrData();
            CatData();
        }
        #region Categories
        private void CatData()
        {
            using (HBContext db = new HBContext())
            {
                var catData = db.Categories.Select(cat => new { ID = cat.CategoryID, cat.CategoryName, cat.CategoryType }).ToList();
                dataCategory.ItemsSource = catData;
            }
        }
        private void btnAddRowCat_Click(object sender, RoutedEventArgs e)
        {
            editCategorySettings currenciesSettings = new editCategorySettings(0, false);
            currenciesSettings.ShowDialog();
            CatData();
        }
        private void btnEditCatRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataCategory.SelectedItem.GetType().GetProperty("ID").GetValue(dataCategory.SelectedItem).ToString());
            if (itemID == 1 || itemID == 2)
            {
                MessageBox.Show("It's administrative position. Removal is prohibited");
                return;
            }
            editCategorySettings currenciesSettings = new editCategorySettings(itemID, true);
            currenciesSettings.ShowDialog();
            CatData();
        }
        private void btnDeleteCatRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataCategory.SelectedItem.GetType().GetProperty("ID").GetValue(dataCategory.SelectedItem).ToString());
            if (itemID == 1 || itemID == 2)
            {
                MessageBox.Show("It's administrative position. Removal is prohibited");
                return;
            }
            using (HBContext db = new HBContext())
            {
                var usingcat = db.CashFlows.Join(db.Nomenclatures, cf => cf.NomenclatureID, n => n.NomenclatureID,
                (cf, n) => new { cf.ID, n.CategoryID }).Where(o => o.CategoryID == itemID).ToList();
                var usingcatnom = db.Nomenclatures.Where(o => o.CategoryID == itemID).ToList();
                if (usingcat.Count != 0 || usingcatnom.Count != 0)
                {
                    MessageBox.Show($"Categoty is used. Removal is prohibited");
                }
                else
                {
                    db.Categories.Remove(db.Categories.Where(cat=>cat.CategoryID == itemID).First());
                    db.SaveChanges();
                }
            }
            CatData();
        }
        #endregion

        #region Nomenclatures
        private void NomData()
        {
            using (HBContext db = new HBContext())
            {
                var nomData = db.Nomenclatures.Select(n => new { n.NomenclatureID, n.NomenclatureName, n.CategoryID }).
                    Join(db.Categories, n => n.CategoryID, cat => cat.CategoryID,
                    (n, cat) => new { ID = n.NomenclatureID, Name = n.NomenclatureName, Category = cat.CategoryName }).ToList();
                dataNom.ItemsSource = nomData;
            }
        }
        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            editNomenclatureSettings nomenclatureSettings = new editNomenclatureSettings(0, false);
            nomenclatureSettings.ShowDialog();
            NomData();
        }
        private void btnEditNomRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataNom.SelectedItem.GetType().GetProperty("ID").GetValue(dataNom.SelectedItem).ToString());
            if (itemID == 1 || itemID == 2)
            {
                MessageBox.Show("It's administrative position. Removal is prohibited");
                return;
            }
            editNomenclatureSettings nomenclatureSettings = new editNomenclatureSettings(itemID, true);
            nomenclatureSettings.ShowDialog();
            NomData();

        }
        private void btnDeleteNomRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataNom.SelectedItem.GetType().GetProperty("ID").GetValue(dataNom.SelectedItem).ToString());
            if (itemID == 1 || itemID == 2)
            {
                MessageBox.Show("It's administrative position. Removal is prohibited");
                return;
            }
            using (HBContext db = new HBContext())
            {
                List<CashFlow> cashFlows = new List<CashFlow>();
                try
                {
                    cashFlows = db.CashFlows.Where(cf => cf.NomenclatureID == itemID).ToList();
                }
                catch (Exception) { }
                if (cashFlows.Count != 0)
                {
                    MessageBox.Show($"Nomenclature is used. Removal is prohibited");
                }
                else
                {
                    db.Nomenclatures.Remove(db.Nomenclatures.Where(n => n.NomenclatureID == itemID).First());
                    db.SaveChanges();
                }
            }
            NomData();
        }
        #endregion

        #region Users
        private void UserData()
        {
            using (HBContext db = new HBContext())
            {
                var userData = db.Users.Select(u => new { ID = u.UserID, u.UserName, u.Login, u.Password, u.UsersRole, u.UserPhoto }).ToList();
                dataUser.ItemsSource = userData;
            }
        }
        private void btnAddRowUser_Click(object sender, RoutedEventArgs e)
        {
            editUsersSettings adminSettings = new editUsersSettings(0, false);
            adminSettings.ShowDialog();
            UserData();
        }
        private void btnEditUserRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataUser.SelectedItem.GetType().GetProperty("ID").GetValue(dataUser.SelectedItem).ToString());
            editUsersSettings userSettings = new editUsersSettings(itemID, true);
            userSettings.ShowDialog();
            UserData();
        }
        private void btnDeleteUserRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataUser.SelectedItem.GetType().GetProperty("ID").GetValue(dataUser.SelectedItem).ToString());
            using (HBContext db = new HBContext())
            {
                User tmp = db.Users.Where(u => u.UserID == itemID).First();
                if (staticServiseClass.GetTemporaryUser() == tmp)
                {
                    MessageBox.Show("You want to detete current user. Don't do it!");
                    return;
                }
                List<Wallet> wallets = new List<Wallet>();
                List<PlanningCashFlow> plannings = new List<PlanningCashFlow>();
                List<CashFlow> cashFlows = new List<CashFlow>();
                try
                {
                    wallets = db.Wallets.Where(w => w.UserID == tmp.UserID).ToList();
                }
                catch (Exception) { }
                try
                {
                    plannings = db.PlanningCashFlows.Where(w => w.UserID == tmp.UserID).ToList();
                }
                catch (Exception) { }
                if (wallets.Count != 0)
                {
                    foreach (Wallet wallet in wallets)
                    {
                        try
                        {
                            cashFlows.AddRange(db.CashFlows.Where(cf => cf.WalletID == wallet.WalletID).ToList());
                        }
                        catch (Exception) { }
                    }
                }
                string message = "";
                if (wallets.Count != 0 || plannings.Count != 0 || cashFlows.Count != 0)
                {
                    message += $" Will be deleted also:";
                }
                if (wallets.Count != 0)
                {
                    message += $"||{wallets.Count} wallet(s)||";
                }
                if (plannings.Count != 0)
                {
                    message += $"||{plannings.Count} plan(s)||";
                }
                if (cashFlows.Count != 0)
                {
                    message += $"||{cashFlows.Count} cashflow(s)||";
                }
                if (MessageBox.Show($"Do you want to delete user \"{tmp.Login}\"?{message}",
                    "Question", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    db.CashFlows.RemoveRange(cashFlows);
                    db.Wallets.RemoveRange(wallets);
                    db.PlanningCashFlows.RemoveRange(plannings);
                    db.Users.Remove(tmp);
                    db.SaveChanges();
                }
            }
            UserData();
        }
        #endregion

        #region Currencies
        private void CurrData()
        {
            using (HBContext db = new HBContext())
            {
                var currData = db.Currencies.Select(cur => new { ID = cur.CurrensyID, cur.CurrencyName, cur.CurrencyCode }).ToList();
                dataCurrency.ItemsSource = currData;
            }
        }
        private void btnAddRowCurr_Click(object sender, RoutedEventArgs e)
        {
            editCurrenciesSettings currenciesSettings = new editCurrenciesSettings(0, false);
            currenciesSettings.ShowDialog();
            CurrData();
        }
        private void btnEditCurrRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataCurrency.SelectedItem.GetType().GetProperty("ID").GetValue(dataCurrency.SelectedItem).ToString());
            editCurrenciesSettings currenciesSettings = new editCurrenciesSettings(itemID, true);
            currenciesSettings.ShowDialog();
            CurrData();
        }
        private void btnDeleteCurrRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataCurrency.SelectedItem.GetType().GetProperty("ID").GetValue(dataCurrency.SelectedItem).ToString());
            using (HBContext db = new HBContext())
            {
                List<Wallet> wallets = new List<Wallet>();
                List<PlanningCashFlow> plannings = new List<PlanningCashFlow>();
                try
                {
                    wallets = db.Wallets.Where(w => w.CurrencyID == itemID).ToList();
                }
                catch (Exception) { }
                try
                {
                    plannings = db.PlanningCashFlows.Where(w => w.CurrencyID == itemID).ToList();
                }
                catch (Exception) { }
                if (wallets.Count != 0 || plannings.Count != 0)
                {
                    MessageBox.Show($"Currency is used. Removal is prohibited");
                }
                else
                {
                    db.Currencies.Remove(db.Currencies.Where(c => c.CurrensyID == itemID).First());
                    db.SaveChanges();
                }
            }
            CurrData();
        }
        #endregion
    }
}
