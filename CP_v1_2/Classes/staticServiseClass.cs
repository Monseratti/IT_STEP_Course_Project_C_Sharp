using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace CP_v1_2.Classes
{
    public static class staticServiseClass
    {
        public static decimal TryParseSum(string _sum)
        {
            decimal sum;
            if (decimal.TryParse(_sum, out sum))
            {
                return sum;
            }
            else
            {
                string __sum = _sum.Replace('.', ',');
                if (__sum != _sum)
                    return TryParseSum(__sum);
                else return 0;
            }
        }
        public static string getFullMonthName(int month)
        {
            return CultureInfo.CurrentCulture.
                DateTimeFormat.GetMonthName
                (month);
        }

        public static byte[] UserPhoto_ToByteArray(BitmapImage MyImage)
        {
            byte[] _img = null;
            Image img = Image.FromFile(MyImage.UriSource.OriginalString);
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                _img = mStream.ToArray();
            }
            return _img;
        }
        public static byte[] UserPhoto_ToByteArray(Image img)
        {
            byte[] _img = null;
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                _img = mStream.ToArray();
            }
            return _img;
        }
        public static byte[] UserPhoto_ToByteArray(string sourse)
        {
            byte[] _img = null;
            Image img = Image.FromFile(sourse);
            using (MemoryStream mStream = new MemoryStream())
            {
                img.Save(mStream, img.RawFormat);
                _img = mStream.ToArray();
            }
            return _img;
        }
        public static User GetTemporaryUser()
        {
            User user = new User();
            using (HBContext db = new HBContext())
            {
                int userID = db.TemporaryUsers.Where(tmp => tmp.TemporaryUserID == 1).First().UserId;
                user = db.Users.Where(u => u.UserID == userID).First();
                using (MemoryStream mStream = new MemoryStream(user.UserPhoto))
                {
                    user.photo = BitmapFrame.Create(mStream,
                                BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }
            return user;
        }
    }

    public class BolleanToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (bool.Parse(parameter.ToString()))
            {
                if ((bool)value) return Visibility.Visible;
                else return Visibility.Collapsed;
            }
            else
            {
                if ((bool)value) return Visibility.Collapsed;
                else return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }

    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(parameter!=null) return ((DateTime)value).ToString("HH:mm");
            return ((DateTime)value).ToString("ddd, d.MM.yyyy, HH:mm");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
