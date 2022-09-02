using CP_v1_2.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CP_v1_2.MyPages
{
    /// <summary>
    /// Логика взаимодействия для pageCurrentUserSettings.xaml
    /// </summary>
    public partial class pageCurrentUserSettings : Page
    {
        User User { get; set; }
        BitmapImage MyImage { get; set; }
        public pageCurrentUserSettings()
        {
            InitializeComponent();
            using (HBContext db = new HBContext())
            {
                User = staticServiseClass.GetTemporaryUser();
                DataContext = User;
                ViewUserInfo();
            }
        }
        private void ViewUserInfo()
        {
            userPhoto.Fill = new ImageBrush(User.photo);
        }
        private void ViewButton()
        {
            btn_Edit.Visibility = Visibility.Visible;
            btn_Cancel.Visibility = Visibility.Visible;
        }
        private void HideButton()
        {
            btn_Edit.Visibility = Visibility.Hidden;
            btn_Cancel.Visibility = Visibility.Hidden;
        }

        private void btn_Edit_Click(object sender, RoutedEventArgs e)
        {
            byte[] photo = null;
            using (HBContext db = new HBContext())
            {
                if (MyImage != null)
                {
                    photo = staticServiseClass.UserPhoto_ToByteArray(MyImage);
                    db.Users.Where(o => o.UserID == User.UserID).First().UserPhoto = photo;
                }
                db.Users.Where(o => o.UserID == User.UserID).First().UserName = User.UserName;
                db.SaveChanges();
            }
            HideButton();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            ViewUserInfo();
            HideButton();
        }


        private void btn_ChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog()
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg"
            };
            if (opf.ShowDialog() == true)
            {
                MyImage = new BitmapImage
                (new Uri(opf.FileName, UriKind.Relative));
                userPhoto.Fill = new ImageBrush(MyImage);
                ViewButton();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewButton();
        }
    }
}
