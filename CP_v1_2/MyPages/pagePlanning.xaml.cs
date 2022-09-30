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
    /// Логика взаимодействия для pagePlanning.xaml
    /// </summary>
    public partial class pagePlanning : Page
    {
        User User { get; set; }
        public pagePlanning()
        {
            InitializeComponent();
            User = staticServiseClass.GetTemporaryUser();
            ViewPlanning();
        }

        private void ViewPlanning()
        {
            using (HBContext db = new HBContext())
            {
                var planningList = db.PlanningCashFlows.Where(pl => pl.UserID == User.UserID)
                    .Join(db.Currencies, pl => pl.CurrencyID, cur => cur.CurrensyID,
                    (pl, cur) => new { pl.PcfID, pl.CategoryID, pl.Sum, pl.CashFlowSum, pl.Period_month, pl.Period_year, cur.CurrencyName })
                    .Join(db.Categories, pl => pl.CategoryID, cat => cat.CategoryID,
                    (pl, cat) => new { ID = pl.PcfID, Year = pl.Period_year, Month = pl.Period_month, Category = cat.CategoryName, Sum = pl.Sum, CashFlowSum = pl.CashFlowSum, Currency = pl.CurrencyName }).ToList();
 
                dataPlanning.ItemsSource = planningList;
            }
        }

        private void btnAddRow_Click(object sender, RoutedEventArgs e)
        {
            editPlanning editPlanning = new editPlanning(0, false);
            editPlanning.ShowDialog();
            ViewPlanning();
        }

        private void btnDeleteRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataPlanning.SelectedItem.GetType().GetProperty("ID").GetValue(dataPlanning.SelectedItem).ToString());
            using (HBContext db = new HBContext())
            {
                db.PlanningCashFlows.Remove(db.PlanningCashFlows.Where(pl => pl.PcfID == itemID).First());
                db.SaveChanges();
            }
            ViewPlanning();
        }

        private void btnEditRow_Click(object sender, RoutedEventArgs e)
        {
            int itemID = int.Parse(dataPlanning.SelectedItem.GetType().GetProperty("ID").GetValue(dataPlanning.SelectedItem).ToString());
            editPlanning editPlanning = new editPlanning(itemID, true);
            editPlanning.ShowDialog();
            ViewPlanning();
        }

    }
}
