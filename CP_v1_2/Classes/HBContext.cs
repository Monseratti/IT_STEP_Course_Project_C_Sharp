using System;
using System.Drawing;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CP_v1_2.Classes;

namespace CP_v1_2
{
    public class HBContext : DbContext
    {
        public HBContext() : base("HBConnection")  
        {
            Database.SetInitializer<HBContext>(new HBInitializer());
        }
        public DbSet <User> Users { get; set; }
        public DbSet<TemporaryUser> TemporaryUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Nomenclature> Nomenclatures { get; set; }
        public DbSet<CashFlow> CashFlows { get; set; }
        public DbSet <PlanningCashFlow> PlanningCashFlows { get; set; }
        public DbSet <Wallet> Wallets { get; set; }
    }

    public class HBInitializer: DropCreateDatabaseAlways<HBContext>
    {
        protected override void Seed(HBContext db)
        {
            Image img = Image.FromFile(@"D:\Учеба\IT_STEP_Course_Project_C_Sharp\CP_v1_2\Images\user1_icon.png");
            byte[] _img = staticServiseClass.UserPhoto_ToByteArray(img);

            db.Users.Add(new User() { Password = "admin", Login = "admin", UsersRole = User.Role.root, UserPhoto = _img });
            db.Users.Add(new User() { Password = "test", Login = "test", UsersRole = User.Role.user });
            db.Users.Add(new User() { Password = "guest", Login = "guest", UsersRole = User.Role.guest });

            db.Currencies.Add(new Currency() { CurrencyName = "UAN", CurrencyCode = 980 });

            db.Categories.Add(new Category() { CategoryName = "Incomes", CategoryType = true });
            db.Categories.Add(new Category() { CategoryName = "Spents", CategoryType = false });
            db.Nomenclatures.Add(new Nomenclature() { CategoryID = 1, NomenclatureName = "_income_" });
            db.Nomenclatures.Add(new Nomenclature() { CategoryID = 2, NomenclatureName = "_spent_" });
            db.SaveChanges();

            //add data for guest
            db.Wallets.Add(new Wallet() { UserID = 3, WalletName = "TestWallet", CurrencyID = 1, WalletSum = 100 });
            db.SaveChanges();

            db.Categories.Add(new Category() { CategoryName = "Gifts", CategoryType = true });
            db.Categories.Add(new Category() { CategoryName = "Foods", CategoryType = false });
            db.Nomenclatures.Add(new Nomenclature() { CategoryID = 3, NomenclatureName = "B-Day Gift" });
            db.Nomenclatures.Add(new Nomenclature() { CategoryID = 4, NomenclatureName = "Bread" });

            db.PlanningCashFlows.Add(new PlanningCashFlow() {UserID = 3, CategoryID = 3, Period_month = DateTime.Today.Month, 
                Period_year = DateTime.Today.Year, Sum = 25000 });
            db.PlanningCashFlows.Add(new PlanningCashFlow() {UserID = 3, CategoryID = 4, Period_month = DateTime.Today.Month,
                Period_year = DateTime.Today.Year, Sum = 5000 });
            db.SaveChanges();

            db.CashFlows.Add(new CashFlow() { WalletID = 1, NomenclatureID = 3, Sum = 10000, DateTime = DateTime.Today.AddDays(-1), 
                Description = "The Gift! Uh!" });
            db.CashFlows.Add(new CashFlow() { WalletID = 1, NomenclatureID = 4, Sum = 30, DateTime = DateTime.Today,
                Description = "I want to eat..."});
            db.SaveChanges();
            //
        }
    }
}
