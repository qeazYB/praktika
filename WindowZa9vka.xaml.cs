using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using static System.Collections.Specialized.BitVector32;
using static WpfApplProject.PageMain;

namespace WpfApplProject
{
    /// <summary>
    /// Логика взаимодействия для WindowZa9vka.xaml
    /// </summary>
    public partial class WindowZa9vka : Window
    {
        public WindowZa9vka()
        {
            InitializeComponent();

            this.ResizeMode = ResizeMode.NoResize;
            List<Request> items = RequestSensorsEntities.GetContext().Request.ToList();
            var context = RequestSensorsEntities.GetContext();
            var reasonCB = context.Request.Select(u => u.Reason).ToList();
            var priorityCB = context.Request.Select(u => u.Priority).ToList();
            var uniqueReasons = reasonCB.Distinct().ToList();
            var uniquePriorities = priorityCB.Distinct().ToList();
            uniqueReasons.Insert(0, "Выберите причину");
            uniquePriorities.Insert(0, "Выберите приоритет");

            ComboReason.ItemsSource = uniqueReasons;
            ComboReason.SelectedIndex = 0;

            ComboPriority.ItemsSource = uniquePriorities;
            ComboPriority.SelectedIndex = 0;
        }
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new RequestSensorsEntities())
            {
                int maxId = context.Request.ToList().Max(i => i.RequestID);
                var sensorName = context.Request.FirstOrDefault(r => r.Sensor.Name == SensorTextBox.Text);
                int id = sensorName?.SensorID ?? 0;
               
                var Request = new Request
                {
                    RequestID = maxId + 1,
                    Client = NameTextBox.Text,
                    SensorID = id,
                    Reason = ComboReason.SelectedItem.ToString(),
                    Priority = ComboPriority.SelectedItem.ToString(),
                    TechName = TechTextBox.Text,
                    RequestDate = System.DateTime.Now,
                    Status = "В ожидании",
                    
                };
                context.Request.Add(Request);
                context.SaveChanges();
               
            }
            
                RequestSensorsEntities.GetContext().SaveChanges();
                MessageBox.Show("Данные успешно сохранены");

        }
    }
}
