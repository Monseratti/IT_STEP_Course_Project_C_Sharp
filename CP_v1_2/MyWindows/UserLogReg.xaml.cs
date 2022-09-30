using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.IO;

namespace CP_v1_2.MyWindows
{
    /// <summary>
    /// Логика взаимодействия для UserLogReg.xaml
    /// </summary>
    public partial class UserLogReg : Window
    {

        public User User { get; set; }
        public UserLogReg()
        {
            InitializeComponent();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (HBContext db = new HBContext())
            {
                try
                {
                    User = db.Users.Where(u => u.Login.Equals(txtLogin.Text) && u.Password.Equals(txtPass.Password)).First();
                    if (User.UserPhoto != null)
                    {
                        using (MemoryStream mStream = new MemoryStream(User.UserPhoto))
                        {
                            User.photo = BitmapFrame.Create(mStream,
                                        BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                        }
                    }
                    try
                    {
                        var tmp = db.TemporaryUsers.Where(o => o.TemporaryUserID == 1).First();
                        tmp.UserId = User.UserID;
                        tmp.dateTime = DateTime.Now;
                        db.SaveChanges();
                    }
                    catch
                    {
                        db.TemporaryUsers.Add(new TemporaryUser() { UserId = User.UserID, dateTime = DateTime.Now });
                        db.SaveChanges();
                    }
                    DialogResult = true;
                }
                catch (Exception)
                {
                    tblError.Visibility = Visibility.Visible;
                    User = null;
                }

            }
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {

            using (HBContext db = new HBContext())
            {

                User = new User()
                {
                    Password = txtPass.Password,
                    Login = txtLogin.Text,
                    UsersRole = User.Role.user
                };
                db.Users.Add(User);
                try
                {
                    db.SaveChanges();
                    MessageBox.Show($"Registration by <{User.Login}> sucsess");
                }
                catch (Exception)
                {
                    User = null;
                }

            }
        }
    }
}
