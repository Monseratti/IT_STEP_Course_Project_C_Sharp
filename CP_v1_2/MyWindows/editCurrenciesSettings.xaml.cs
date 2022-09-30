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

namespace CP_v1_2.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для edinCurrenciesSettings.xaml
    /// </summary>
    public partial class editCurrenciesSettings : Window
    {
        bool IsEdit { get; set; }
        Currency Currency { get; set; }
        public editCurrenciesSettings(int ID, bool IsEdit)
        {
            this.IsEdit = IsEdit;
            InitializeComponent();
            if (IsEdit)
            {
                using (HBContext db = new HBContext())
                {
                    Currency = db.Currencies.Where(cur => cur.CurrensyID == ID).First();
                }
            }
            else Currency = new Currency();
            DataContext = Currency;
        }

        private void _Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Currency.CurrencyName != string.Empty)
            {
                using (HBContext db = new HBContext())
                {
                    if (IsEdit)
                    {
                        db.Currencies.Where(cur => cur.CurrensyID == Currency.CurrensyID).First().CurrencyName = Currency.CurrencyName;
                        db.Currencies.Where(cur => cur.CurrensyID == Currency.CurrensyID).First().CurrencyCode = Currency.CurrencyCode;
                    }
                    else
                        db.Currencies.Add(Currency);
                    db.SaveChanges();
                }
                DialogResult = true;
            }
            else MessageBox.Show("Set name of currency");
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
