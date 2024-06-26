using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using System.Xml.Linq;

namespace WpfApplProject
{
    /// <summary>
    /// Логика взаимодействия для PageEmployee.xaml
    /// </summary>
    public partial class PageSensors : Page
    {
        List<Sensor> items = null;
        public string action = "";
        public PageSensors()
        {
            InitializeComponent();

            var context = RequestSensorsEntities.GetContext();
            DataGridSensors.ItemsSource = context.Sensor.ToList();
            


        }

        public bool isDirty = true;



        private void Undo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var context = RequestSensorsEntities.GetContext();
            switch (action)
            {
                case "add":
                    var addedЗапчасти = context.Sensor.Local.Last();
                    if (addedЗапчасти != null)
                    {
                        context.Sensor.Remove(addedЗапчасти);
                        context.SaveChanges();
                        DataGridSensors.ItemsSource = null;
                        DataGridSensors.ItemsSource = context.Sensor.ToList();
                        
                    }
                    break;
                case "undo":
                    DataGridSensors.ItemsSource = null;
                    DataGridSensors.ItemsSource = RequestSensorsEntities.GetContext().Sensor.ToList();
                    break;
            }
            isDirty = true;
            MessageBox.Show("Последнее изменение было отменено");
            DataGridSensors.IsReadOnly = true;
        }

        private void Undo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
        }
        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridSensors.IsReadOnly = false;

            int maxId = RequestSensorsEntities.GetContext().Sensor.ToList().Max(i => i.SensorID);
            Sensor датчики = new Sensor()
            {
                SensorID = maxId + 1,
                Name = "Введите наименование датчика",
                Condition = "Введите состояние",
                Status = "Введите статус",
                Location = "Введите нахождение датчика",
                Company = "Барзасское товарищество",
                Commentary = "Введите комментарий",
                CreateDate = System.DateTime.Now

            };

            RequestSensorsEntities.GetContext().Sensor.Add(датчики);
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
                RequestSensorsEntities.GetContext().SaveChanges();
                DataGridSensors.ItemsSource = null;
                DataGridSensors.ItemsSource = RequestSensorsEntities.GetContext().Sensor.ToList();
                DataGridSensors.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            action = "add";
            isDirty = false;
        }
        private void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridSensors.IsReadOnly = false;
            DataGridSensors.BeginEdit();
            action = "undo";
            isDirty = false;
            //MessageBox.Show("Редактировать");
        }

        private void Edit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }
        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            RequestSensorsEntities.GetContext().SaveChanges();
            DataGridSensors.ItemsSource = RequestSensorsEntities.GetContext().Sensor.ToList();
            DataGridSensors.Items.Refresh();
            DataGridSensors.IsReadOnly = true;
            action = "";
            isDirty = true;


            isDirty = true;
            MessageBox.Show("Данные успешно сохранены");
        }
        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
        }




        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Sensor cook = DataGridSensors.SelectedItem as Sensor;
            if (cook != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные ",
                "Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    DataGridSensors.SelectedIndex =
                    DataGridSensors.SelectedIndex == 0 ? 1 :
                    DataGridSensors.SelectedIndex - 1;
                    RequestSensorsEntities.GetContext().Sensor.Remove(cook);
                    RequestSensorsEntities.GetContext().SaveChanges();
                    DataGridSensors.ItemsSource = RequestSensorsEntities.GetContext().Sensor.ToList();
                    DataGridSensors.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления");
            }
            action = "";
            isDirty = true;
        }
        private void Delete_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }


    }
}







