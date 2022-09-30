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
using Microsoft.Win32;

namespace CP_v1_2.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для editWallet.xaml
    /// </summary>
    
    public partial class editUsersSettings : Window
    {
        bool IsEdit { get; set; }
        User User { get; set; }
        BitmapImage MyImage { get; set; }

        public editUsersSettings(int ID, bool IsEdit)
        {
            InitializeComponent();
            this.IsEdit = IsEdit;
            FillUserFields(ID);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void _Close_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void FillUserFields(int ID)
        {
            if (IsEdit)
            {
                using (HBContext db = new HBContext())
                {
                    User = db.Users.Where(u => u.UserID == ID).First();
                    User.photo = staticServiseClass.SetUserPhotoFromByteArray(User.UserPhoto);
                }
            }
            else User = new User() { UsersRole = User.Role.user };
            DataContext = User;
            userPhoto.Fill = new ImageBrush(User.photo);
            cbxUserRole.Items.Add(User.Role.user);
            cbxUserRole.Items.Add(User.Role.root);
            cbxUserRole.Items.Add(User.Role.guest);
            cbxUserRole.SelectedItem = User.UsersRole;
            if (User.UsersRole == User.Role.root) cbxUserRole.IsEnabled = false;
        }
        
        private void btnChangePhoto_Click(object sender, RoutedEventArgs e)
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
            }
        } 
        
        private void _UserEdit_Click(object sender, RoutedEventArgs e)
        {
            byte[] photo = null;
            using (HBContext db = new HBContext())
            {
                if (MyImage != null)
                {
                    photo = staticServiseClass.UserPhoto_ToByteArray(MyImage);
                    User.UserPhoto = photo;
                }
                else User.UserPhoto = null;
                User.UsersRole = (User.Role)cbxUserRole.SelectedItem;
                if (User.Login != string.Empty && User.Password != string.Empty)
                {
                    if (IsEdit)
                    {
                        db.Users.Where(o => o.UserID == User.UserID).First().Login = User.Login;
                        db.Users.Where(o => o.UserID == User.UserID).First().Password = User.Password;
                        db.Users.Where(o => o.UserID == User.UserID).First().UserName = User.UserName;
                        db.Users.Where(o => o.UserID == User.UserID).First().UserPhoto = User.UserPhoto;
                    }
                    else db.Users.Add(User);
                    db.SaveChanges();
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Password and login must be filling!");
                }
            }
        }
 
    }
}
