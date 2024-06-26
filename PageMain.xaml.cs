using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using static WpfApplProject.md5;

namespace WpfApplProject
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class PageMain : Page
    {
        public PageMain()
        {
            InitializeComponent();
            labelName.Visibility = Visibility.Hidden;
            labelPass1.Visibility = Visibility.Hidden;
        }
        
        public class DataTransfer
        {
            public static int UserID { get; set; }
            public static string Username { get; set; }
            public static string role { get; set; }
            public static string Password { get; set; }

        }
       
        private void BtEntry(object sender, RoutedEventArgs e)
        {
            string passw = hashPassword(inputPass1.Password);
            labelName.Content = "";
            labelPass1.Content = "";

            if (inputName.Text == "")
            {
                labelName.Content = "Введите имя";
                labelName.Visibility = Visibility.Visible;
            }
            if ((inputPass1.Password) == "")
            {
                labelPass1.Content = "Введите пароль";
                labelPass1.Visibility = Visibility.Visible;
            }

            
            User db = new User();
            db = RequestSensorsEntities.GetContext().User.Where(b => b.Name == inputName.Text
                                                          && b.Password == passw).FirstOrDefault();

            
            

            if (db == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            DataTransfer.Username = db.Name;
            DataTransfer.Password = db.Password;
            DataTransfer.role = db.Role;
            
            if (DataTransfer.role == "admin")
            {
                NavigationService.Navigate(new PageEmployee());
            }
            else
            {
                WindowZa9vka newWindow = new WindowZa9vka();
                newWindow.Show();
            }
        }

        private void BtExit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
    