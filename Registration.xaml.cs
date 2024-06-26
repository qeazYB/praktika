using System;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для PageMain.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public class DataTransfer
        {
            public static int UserID { get; set; }
            public static string Username { get; set; }
            public static string role { get; set; }
            public static string Password { get; set; }

        }
        public static string GetHash(string input) 
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(hash);
        }
        public Registration()
        {
            InitializeComponent();
            UsernameLabel.Visibility = Visibility.Collapsed;
            Password1Label.Visibility = Visibility.Collapsed;
            Password2Label.Visibility = Visibility.Collapsed;

        }
        private bool IsUsernameExists(string username)
        {
            using (var context = RequestSensorsEntities.GetContext())
            {
                return context.User.Any(u => u.Name == username);
            }
        }
        private void Register_Click (object sender, RoutedEventArgs e)
        {
            UsernameLabel.Content = "";
            Password1Label.Content = "";
            Password2Label.Content = "";

            Regex usernameRegex = new Regex(@"^[a-zA-Zа-яА-Я]{3,20}$");
            Regex passwordRegex = new Regex(@"^.{5,10}$");
            
            if (!usernameRegex.IsMatch(UsernameTextBox.Text))
            {
                UsernameLabel.Content = "Имя пользователя должно содержать \nот 3 до 20 символов (латинские или русские буквы)";
                UsernameLabel.Visibility = Visibility.Visible;
                return;
            }
            if (!passwordRegex.IsMatch(Password1TextBox.Text))
            {
                Password1Label.Content = "Пароль должен содержать от 5 до 10 символов";
                Password1Label.Visibility = Visibility.Visible;
                return;
            }
            if (Password1TextBox.Text != Password2TextBox.Text)
            {
                Password2Label.Content = "Пароли должны совпадать";
                Password2Label.Visibility = Visibility.Visible;
                return;
            }
            if (RequestSensorsEntities.GetContext().User.ToList().Select(u => u.Name).Contains(UsernameTextBox.Text))
            {
                UsernameLabel.Content = "Имя пользователя уже существует";
                UsernameLabel.Visibility = Visibility.Visible;
                return;
            }

            int UserNumber = RequestSensorsEntities.GetContext().User.ToList().Max(i => i.UserID);

            if (UserNumber == 0)
            {
                UserNumber = 1;
            }
            else if (UserNumber == 1)
            {
                UserNumber++;
            }

            User user = new User()
            {
                UserID = UserNumber + 1,
                Name = UsernameTextBox.Text,
                Password = hashPassword(Password1TextBox.Text),
                Role = "user",
            };

            RequestSensorsEntities.GetContext().User.Add(user);
            try
            {

                try
                {

                    RequestSensorsEntities.GetContext().SaveChanges();

                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        MessageBox.Show(validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            MessageBox.Show(err.ErrorMessage.ToString());
                        }
                    }
                }
                MessageBox.Show("Вы успешно зарегестрированы!");
                DataTransfer.UserID = UserNumber + 1;
                DataTransfer.Username = UsernameTextBox.Text;
                DataTransfer.Password = Password1TextBox.Text;
                DataTransfer.role = "user";
                NavigationService.Navigate(new PageMain());
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
    }
}
