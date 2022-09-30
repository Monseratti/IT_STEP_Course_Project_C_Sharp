using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace CP_v1_2.MyPages
{
    /// <summary>
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        User User { get; set; }
        public Dashboard()
        {
            InitializeComponent();
            User = staticServiseClass.GetTemporaryUser();
            WalletInfo();
            PlanningImplementation();
            TodayListCashFlow();
            ExchangeCourseInfo();
        }
        private void WalletInfo()
        {
            using (HBContext db = new HBContext())
            {
                var money = db.Wallets.Where(w => w.UserID == User.UserID).Join(db.Currencies,
                    w => w.CurrencyID,
                    c => c.CurrensyID,
                    (w, c) => 
                    new { 
                        Wallet = w.WalletName,
                        Sum = w.WalletSum.ToString() + ", " + c.CurrencyName.ToString() }).ToList();


                dtg_InfoWallet.ItemsSource = money;

            }
        }

        private void TodayListCashFlow()
        {
            using (HBContext db = new HBContext())
            {
                var today = DateTime.Today.Date;
                var Data = db.Wallets.Where(w => w.UserID == User.UserID).
                    Join(db.CashFlows, w => w.WalletID, cf => cf.WalletID,
                    (w, cf) => new { cf.DateTime, cf.Sum, cf.NomenclatureID, w.CurrencyID }).
                    Where(cf => DbFunctions.TruncateTime(cf.DateTime) == today).
                    Join(db.Currencies, cf => cf.CurrencyID, cu => cu.CurrensyID,
                    (cf, cu) => new { cf.Sum, cf.DateTime, cf.NomenclatureID, cu.CurrencyName }).
                    Join(db.Nomenclatures, cf => cf.NomenclatureID, n => n.NomenclatureID,
                    (cf, n) => new { cf.Sum, cf.DateTime, n.NomenclatureName, n.CategoryID, cf.CurrencyName }).
                    Join(db.Categories, cf => cf.CategoryID, c => c.CategoryID,
                    (cf, c) => new
                    {
                        CatType = c.CategoryType,
                        Nom = cf.NomenclatureName,
                        Sum = cf.Sum.ToString() + ", " + cf.CurrencyName.ToString(),
                        Date = cf.DateTime
                    }).OrderByDescending(o => o.Date).ToList();

                dtg_Info.ItemsSource = Data;
            }
        }

        private void PlanningImplementation()
        {
            using (HBContext db = new HBContext())
            {
                var month = DateTime.Today.Month;
                var year = DateTime.Today.Year;

                var Data = db.PlanningCashFlows.Where(pl => pl.UserID == User.UserID&&pl.Period_month == month&&pl.Period_year==year)
                   .Join(db.Currencies, pl => pl.CurrencyID, cur => cur.CurrensyID,
                   (pl, cur) => new { pl.PcfID, pl.CategoryID, pl.Sum, pl.CashFlowSum, pl.Period_month, pl.Period_year, cur.CurrencyName })
                   .Join(db.Categories, pl => pl.CategoryID, cat => cat.CategoryID,
                   (pl, cat) => new { 
                       Category = cat.CategoryName, 
                       Sum = pl.CashFlowSum.ToString() + " / " + pl.Sum.ToString(),
                       Percent = pl.CashFlowSum/pl.Sum,
                       Currency = pl.CurrencyName }).ToList();

                dtg_PlansInfo.ItemsSource = Data;
            }
        }

        delegate void Combodelegate(List<Course> courses);

        private async void ExchangeCourseInfo()
        {
            using (HttpClient client = new HttpClient())
            using (HttpRequestMessage reqw = new HttpRequestMessage())
            {
                reqw.RequestUri = new Uri(" https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5");
                reqw.Method = HttpMethod.Get;
                HttpResponseMessage httpResponse = await client.SendAsync(reqw).ConfigureAwait(false);
                string resp = await httpResponse.Content.ReadAsStringAsync();
                List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(resp);
                await dtg_CursInfo.Dispatcher.BeginInvoke(new Combodelegate(AddInfo), courses);
            }
        }
        private void AddInfo(List<Course> courses)
        {
            dtg_CursInfo.ItemsSource = courses;
        }
    }
}
