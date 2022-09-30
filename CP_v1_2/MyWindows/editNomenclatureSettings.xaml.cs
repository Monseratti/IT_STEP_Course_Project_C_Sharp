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
    /// Логика взаимодействия для editNomenclatureSettings.xaml
    /// </summary>
    public partial class editNomenclatureSettings : Window
    {
        bool IsEdit { get; set; }
        Nomenclature Nomenclature { get; set; }

        public editNomenclatureSettings(int ID, bool isEdit)
        {
            InitializeComponent();
            IsEdit = isEdit;
            cbxCategory.Items.Clear();
            using (HBContext db = new HBContext())
            {
                cbxCategory.ItemsSource = db.Categories.Select(cat => cat.CategoryName).ToList();
                if (IsEdit)
                {
                    Nomenclature = db.Nomenclatures.Where(n => n.NomenclatureID == ID).First();
                    cbxCategory.SelectedItem = db.Categories.Where(cat => cat.CategoryID == Nomenclature.CategoryID).First().CategoryName;
                }
                else
                {
                    Nomenclature = new Nomenclature();
                    cbxCategory.SelectedIndex = 0;
                }
            }
            DataContext = Nomenclature;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void _Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Nomenclature.NomenclatureName != string.Empty)
            {
                using (HBContext db = new HBContext())
                {
                    Nomenclature.CategoryID = db.Categories.Where(cat => cat.CategoryName.Equals(cbxCategory.SelectedItem.ToString())).
                        First().CategoryID;
                    if (IsEdit)
                    {
                        db.Nomenclatures.Where(n => n.NomenclatureID == Nomenclature.NomenclatureID).
                            First().NomenclatureName = Nomenclature.NomenclatureName;
                        db.Nomenclatures.Where(n => n.NomenclatureID == Nomenclature.NomenclatureID).
                            First().CategoryID = Nomenclature.CategoryID;
                    }
                    else
                        db.Nomenclatures.Add(Nomenclature);
                    db.SaveChanges();
                    DialogResult = true;
                }
            }
            else
                MessageBox.Show("Set nomenclature name");
        }

        private void _Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
