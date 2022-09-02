//#define LOGIN
//#define GUEST
#define ADMIN
//#define USER

using System;
using System.Drawing;
using System.Configuration;
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
using System.IO;
using System.Data.Entity;
using CP_v1_2.MyPages;
using CP_v1_2.Classes;
using CP_v1_2.MyWindows;
using CP_v1_2.CustomButton;

namespace CP_v1_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        User User { get; set; }

        public MainWindow()
        {
            MaxWidth = SystemParameters.WorkArea.Width;
            MaxHeight = SystemParameters.WorkArea.Height;
            InitializeComponent();
            LogIn();
        }

        private void LogIn()
        {
#if LOGIN
            UserLogReg logReg = new UserLogReg();
            if (logReg.ShowDialog() == true)
            {
                MessageBox.Show("Connection sucsess");
                User = logReg.User;
            }
            else Application.Current.Shutdown();
#endif
            using (HBContext db = new HBContext())
            {
#if ADMIN
                User = db.Users.Where(o => o.Login == "admin").FirstOrDefault();
#endif
#if GUEST
                User = db.Users.Where(o => o.Login == "guest").FirstOrDefault();
#endif
#if USER
                User = db.Users.Where(o => o.Login == "user").FirstOrDefault();
#endif
                using (MemoryStream mStream = new MemoryStream(User.UserPhoto))
                {
                    User.photo = BitmapFrame.Create(mStream,
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
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

                imgUser.Fill = new ImageBrush(User.photo);
                tblUser.Text = $"{User.UserName ?? User.Login}";
                Visibility = Visibility.Visible;
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                WindowState = WindowState.Normal;
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception) { }
        }
        private void menuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var btn = menuList.SelectedItem as NavButton;
            panelDesktop.Navigate(btn.NavLink);
            User = staticServiseClass.GetTemporaryUser();
            imgUser.Fill = new ImageBrush(User.photo);
            tblUser.Text = $"{User.UserName ?? User.Login}";
        }

        private void bnt_Logout_Click(object sender, RoutedEventArgs e)
        {
            User = null;
            Visibility = Visibility.Collapsed;
            LogIn();
        }
    }
}
