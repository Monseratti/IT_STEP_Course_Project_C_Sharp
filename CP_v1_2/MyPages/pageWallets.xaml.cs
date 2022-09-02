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
using CP_v1_2.Classes;
using CP_v1_2.MyWindows;

namespace CP_v1_2.MyPages
{
    /// <summary>
    /// Логика взаимодействия для pageWallets.xaml
    /// </summary>
    public partial class pageWallets : Page
    {
        User User { get; set; }
        public pageWallets()
        {
            InitializeComponent();
            User = staticServiseClass.GetTemporaryUser();
            ViewWallets();
        }

        private void ViewWallets()
        {
            using (HBContext db = new HBContext())
            {
                var walletList = db.Wallets.Where(w => w.UserID == User.UserID).
                                            Join(db.Currencies, w => w.CurrencyID, cur => cur.CurrensyID,
                                            (w, cur) => new { ID = w.WalletID, Wallet = w.WalletName, Sum = w.WalletSum, Curr = cur.CurrencyName }).ToList();
                dataWallet.ItemsSource = walletList;
            }
        }

        #region Wallet CRUD

        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            editWallet editWallet = new editWallet(0, false);
            editWallet.ShowDialog();
            ViewWallets();
        }

        private void btnEditRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataWallet.SelectedItem.GetType().GetProperty("ID").GetValue(dataWallet.SelectedItem).ToString());
            editWallet editWallet = new editWallet(itemID, true);
            editWallet.ShowDialog();
            ViewWallets();
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {

            int itemID = int.Parse(dataWallet.SelectedItem.GetType().GetProperty("ID").GetValue(dataWallet.SelectedItem).ToString());
            using (HBContext db = new HBContext())
            {
                Wallet tmp = db.Wallets.Where(w => w.WalletID == itemID).First();
                var cashflows = db.CashFlows.Where(cf => cf.WalletID == tmp.WalletID).ToArray();
                if (cashflows.Count() > 0)
                {
                    if (MessageBox.Show("Will be deleted all cash flows row. Are you shure?",
                                "Delete wallet",
                                MessageBoxButton.YesNo,
                                MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        foreach (var cashflow_item in cashflows)
                        {
                            db.CashFlows.Remove(cashflow_item);
                        }
                    }
                    else return;
                }
                db.Wallets.Remove(tmp);
                db.SaveChanges();
            }
            ViewWallets();
        }
        #endregion
    }
}
