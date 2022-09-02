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
    /// Логика взаимодействия для editWallet.xaml
    /// </summary>
    public partial class editWallet : Window
    {
        Wallet Wallet { get; set; }
        bool IsEdit { get; set; }

        public editWallet(int ID, bool Edit)
        {
            IsEdit = Edit;
            InitializeComponent();
            using (HBContext db = new HBContext())
            {
                if (IsEdit)
                {
                    Wallet = db.Wallets.Where(w => w.WalletID == ID).First();
                }
                else
                {
                    Wallet = new Wallet();
                }
                FillEdit();
            }
        }

        private void FillEdit()
        {
            using (HBContext db = new HBContext())
            {
                cbxCurrensies.ItemsSource = db.Currencies.Select(cur => cur.CurrencyName).ToList();
                if (IsEdit)
                {
                    cbxCurrensies.SelectedItem = db.Currencies.Where(cur => cur.CurrensyID == Wallet.CurrencyID).Select(cur => cur.CurrencyName).First();
                    tblWalletName.Text = Wallet.WalletName;
                    tblSum.Text = Wallet.WalletSum.ToString();
                }
                else cbxCurrensies.SelectedIndex = 0;
            }
        }

        private void _Edit_Click(object sender, RoutedEventArgs e)
        {
            using (HBContext db = new HBContext())
            {
                if (IsEdit)
                {
                    decimal walletsum = Wallet.WalletSum;
                    decimal newwalletsum = staticServiseClass.TryParseSum(tblSum.Text);
                    if (newwalletsum > walletsum)
                    {
                        CashFlow _income = new CashFlow()
                        {
                            NomenclatureID = 1,
                            DateTime = DateTime.Now,
                            Sum = newwalletsum - walletsum,
                            Description = "Income from change wallet sum value",
                            WalletID = Wallet.WalletID
                        };
                        db.CashFlows.Add(_income);
                    }
                    else if (newwalletsum < walletsum)
                    {
                        CashFlow _spent = new CashFlow()
                        {
                            NomenclatureID = 2,
                            DateTime = DateTime.Now,
                            Sum = -newwalletsum + walletsum,
                            Description = "Spent from change wallet sum value",
                            WalletID = Wallet.WalletID
                        };
                        db.CashFlows.Add(_spent);
                    }
                    db.Wallets.Where(w => w.WalletID == Wallet.WalletID).First().WalletSum = newwalletsum;
                    db.Wallets.Where(w => w.WalletID == Wallet.WalletID).First().WalletName = tblWalletName.Text;
                    db.Wallets.Where(w => w.WalletID == Wallet.WalletID).First().CurrencyID =
                        db.Currencies.Where(cur => cur.CurrencyName == cbxCurrensies.SelectedItem.ToString()).Select(cur => cur.CurrensyID).First();
                }
                else
                {
                    Wallet.CurrencyID = db.Currencies.Where(cur => cur.CurrencyName == cbxCurrensies.SelectedItem.ToString()).Select(cur => cur.CurrensyID).First();
                    Wallet.WalletSum = staticServiseClass.TryParseSum(tblSum.Text);
                    Wallet.UserID = db.TemporaryUsers.Where(tu => tu.TemporaryUserID == 1).Select(tu => tu.UserId).First();
                    Wallet.WalletName = tblWalletName.Text;
                    db.Wallets.Add(Wallet);
                }
                db.SaveChanges();
            }
            DialogResult = true;
        }

        private void _Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        
    }
}
