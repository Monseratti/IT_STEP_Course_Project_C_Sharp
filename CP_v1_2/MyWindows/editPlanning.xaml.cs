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
    /// Логика взаимодействия для editPlanning.xaml
    /// </summary>
    public partial class editPlanning : Window
    {
        private PlanningCashFlow Planning { get; set; }
        private bool IsEdit { get; set; }
        public editPlanning(int ID, bool Edit)
        {
            IsEdit = Edit;
            InitializeComponent();
            if (IsEdit)
            {
                using (HBContext db = new HBContext())
                {
                    Planning = db.PlanningCashFlows.Where(pl => pl.PcfID == ID).First();
                }
            }
            else
            {
                Planning = new PlanningCashFlow();
            }
            FillPlanning();
        }

        private void FillPlanning()
        {
            using (HBContext db = new HBContext())
            {
                List<int> yearList = new List<int>();
                List<string> monthList = new List<string>();

                for (int i = DateTime.Today.Year-10; i < DateTime.Today.Year; i++)      yearList.Add(i);
                for (int i = DateTime.Today.Year; i < DateTime.Today.Year + 11; i++)    yearList.Add(i);
                for (int i = 1; i < 13; i++)                                            monthList.Add(staticServiseClass.getFullMonthName(i));

                cbxYears.ItemsSource = yearList;
                cbxMonth.ItemsSource = monthList;

                cbxCategory.ItemsSource = db.Categories.Select(cat => cat.CategoryName).ToList();
                cbxCurrency.ItemsSource = db.Currencies.Select(cur => cur.CurrencyName).ToList();

                if (IsEdit)
                {
                    cbxYears.SelectedItem = Planning.Period_year;
                    cbxMonth.SelectedItem = staticServiseClass.getFullMonthName(Planning.Period_month);
                    cbxCategory.SelectedItem = db.Categories.Where(cat => cat.CategoryID == Planning.CategoryID).Select(cat => cat.CategoryName).First();
                    cbxCurrency.SelectedItem = db.Currencies.Where(cur => cur.CurrensyID == Planning.CurrencyID).Select(cur => cur.CurrencyName).First();
                    tblSum.Text = Planning.Sum.ToString();
                }
                else
                {
                    cbxYears.SelectedItem = DateTime.Today.Year;
                    cbxMonth.SelectedItem = staticServiseClass.getFullMonthName(DateTime.Today.Month);
                    cbxCategory.SelectedIndex = 0;
                    cbxCurrency.SelectedIndex = 0;
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void _Edit_Click(object sender, RoutedEventArgs e)
        {
            using (HBContext db = new HBContext())
            {
                Planning.Period_month = cbxMonth.SelectedIndex+1;
                Planning.Period_year = int.Parse(cbxYears.SelectedItem.ToString());
                Planning.CategoryID = db.Categories.Where(cat => cat.CategoryName == cbxCategory.SelectedItem.ToString()).Select(cat => cat.CategoryID).First();
                Planning.CurrencyID = db.Currencies.Where(cur => cur.CurrencyName == cbxCurrency.SelectedItem.ToString()).Select(cur => cur.CurrensyID).First();
                Planning.Sum = staticServiseClass.TryParseSum(tblSum.Text);
                Planning.UserID = db.TemporaryUsers.Where(tmp => tmp.TemporaryUserID == 1).Select(tmp => tmp.UserId).First();
                if (IsEdit)
                {
                    db.PlanningCashFlows.Where(pl => pl.PcfID == Planning.PcfID).First().Period_year = Planning.Period_year;
                    db.PlanningCashFlows.Where(pl => pl.PcfID == Planning.PcfID).First().Period_month = Planning.Period_month;
                    db.PlanningCashFlows.Where(pl => pl.PcfID == Planning.PcfID).First().CategoryID = Planning.CategoryID;
                    db.PlanningCashFlows.Where(pl => pl.PcfID == Planning.PcfID).First().CurrencyID = Planning.CurrencyID;
                    db.PlanningCashFlows.Where(pl => pl.PcfID == Planning.PcfID).First().Sum = Planning.Sum;
                }
                else
                {
                    db.PlanningCashFlows.Add(Planning);
                }
                db.SaveChanges();
                DialogResult = true;
            }
        }

        private void _Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
