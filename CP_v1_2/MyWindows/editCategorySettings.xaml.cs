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
    /// Логика взаимодействия для editCategorySettings.xaml
    /// </summary>
    public partial class editCategorySettings : Window
    {
        bool IsEdit { get; set; }
        Category Category { get; set; }
        public editCategorySettings(int ID, bool isEdit)
        {
            InitializeComponent();
            IsEdit = isEdit;
            using (HBContext db = new HBContext())
            {
                if (isEdit)
                {
                    Category = db.Categories.Where(cat => cat.CategoryID == ID).First();
                    var usingcat = db.CashFlows.Join(db.Nomenclatures, cf => cf.NomenclatureID, n => n.NomenclatureID,
               (cf, n) => new { cf.ID, n.CategoryID }).Where(o => o.CategoryID == ID).ToList();
                    var usingcatnom = db.Nomenclatures.Where(o => o.CategoryID == ID).ToList();
                    if (usingcat.Count != 0 || usingcatnom.Count != 0)
                    {
                        cbxIsIncome.IsEnabled = false;
                    }
                }
                else Category = new Category();
            }
            DataContext = Category;
        }

        private void _Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Category.CategoryName != string.Empty)
            {
                using (HBContext db = new HBContext())
                {
                    List<Category> categories = db.Categories.Where(cat => cat.CategoryName.Equals(Category.CategoryName)).ToList();
                    if ((categories.Count == 1 && !IsEdit) || (categories.Count > 1 && IsEdit))
                    {
                        MessageBox.Show("This categoty already exist");
                        return;
                    }
                    if (IsEdit)
                    {
                        db.Categories.Where(cat => cat.CategoryID == Category.CategoryID).First().CategoryName = Category.CategoryName;
                    }
                    else
                        db.Categories.Add(Category);
                    db.SaveChanges();
                    DialogResult = true;
                }
            }
            else
            {
                MessageBox.Show("Set category name");
            }
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
