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
            //TodayCashFlow();
            TodayListCashFlow();
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

        //private void TodayCashFlow()
        //{
        //    using (HBContext db = new HBContext())
        //    {
        //        var today = DateTime.Today.Date;
        //        var cashflow = db.Wallets.Where(w => w.UserID == User.UserID).
        //            Join(db.CashFlows, w => w.WalletID, cf => cf.WalletID,
        //            (w, cf) => new { cf.DateTime, cf.Sum, cf.NomenclatureID, w.CurrencyID }).
        //            Where(cf => DbFunctions.TruncateTime(cf.DateTime) == today).
        //            Join(db.Currencies, cf => cf.CurrencyID, cu => cu.CurrensyID,
        //            (cf, cu) => new { cf.Sum, cf.NomenclatureID, cu.CurrencyName }).
        //            Join(db.Nomenclatures, cf => cf.NomenclatureID, n => n.NomenclatureID,
        //            (cf, n) => new { cf.Sum, n.CategoryID, cf.CurrencyName }).
        //            Join(db.Categories, cf => cf.CategoryID, c => c.CategoryID,
        //            (cf, c) => new { Sum = cf.Sum, CatType = c.CategoryType, Curr = cf.CurrencyName }).GroupBy(o => o.CatType);

        //        foreach (var catType in cashflow)
        //        {
        //            var el = catType.GroupBy(o => o.Curr);
        //            foreach (var cur in el)
        //            {
        //                decimal _sum = 0;
        //                foreach (var sum in cur)
        //                {
        //                    _sum += sum.Sum;
        //                    if (catType.Key == true)
        //                    {
        //                        tblTodayCashFlowIn.Text = $"{cur.Key}: {_sum}\n ";
        //                    }
        //                    else
        //                    {
        //                        tblTodayCashFlowOut.Text = $"{cur.Key}: {_sum}\n ";
        //                    }
        //                }
        //            }
        //        }
        //        if (cashflow.Count() == 0)
        //        {
        //            tblTodayCashFlowIn.Text = $"0";
        //            tblTodayCashFlowOut.Text = $"0";
        //        }
        //    }
        //}

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
    }
}
