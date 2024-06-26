using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace WpfApplProject
{
    /// <summary>
    /// Логика взаимодействия для PageEmployee.xaml
    /// </summary>
    public partial class PageEmployee : Page
    {
        List<Request> items = null;
        public string action = "";
        public PageEmployee()
        {
            InitializeComponent();
            
            DataGridEmployee.ItemsSource = RequestSensorsEntities.GetContext().Request.ToList();
            var context = RequestSensorsEntities.GetContext();

            
        }
        
        public bool isDirty = true;
        
        

        private void Undo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var context = RequestSensorsEntities.GetContext();
            switch (action)
            {
                case "add":
                    var addedЗапчасти = context.Request.Local.Last();
                    if (addedЗапчасти != null)
                    {
                        context.Request.Remove(addedЗапчасти);
                        context.SaveChanges();
                        DataGridEmployee.ItemsSource = null;
                        DataGridEmployee.ItemsSource = context.Request.ToList();
                       
                    }
                    break;
                case "undo":
                    DataGridEmployee.ItemsSource = null;
                    DataGridEmployee.ItemsSource = RequestSensorsEntities.GetContext().Request.ToList();
                    break;
            }
                isDirty = true;
                MessageBox.Show("Последнее изменение было отменено");
            DataGridEmployee.IsReadOnly = true;
        }

        private void Undo_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !isDirty;
        }
        private void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataGridEmployee.IsReadOnly = false;
            
            
            int maxId = RequestSensorsEntities.GetContext().Request.ToList().Max(i => i.RequestID);
            Request запчасти = new Request()
            {

                RequestID = maxId + 1,
                Client = "Введите ФИО заказчика",       
                Reason = "",
                TechName = "Введите вид техники",
                Priority = "",
                Status = "В ожидании",
                SensorID = 1,
                RequestDate = System.DateTime.Now

            };
           
            RequestSensorsEntities.GetContext().Request.Add(запчасти);
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
                DataGridEmployee.ItemsSource = null;
                DataGridEmployee.ItemsSource = RequestSensorsEntities.GetContext().Request.ToList();
                DataGridEmployee.Items.Refresh();
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
            DataGridEmployee.IsReadOnly = false;
            DataGridEmployee.BeginEdit();
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
            DataGridEmployee.ItemsSource = RequestSensorsEntities.GetContext().Request.ToList();
            DataGridEmployee.Items.Refresh();
            DataGridEmployee.IsReadOnly = true;
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
            Request cook = DataGridEmployee.SelectedItem as Request;
            if (cook != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные ",
                "Предупреждение", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.OK)
                {
                    DataGridEmployee.SelectedIndex =
                    DataGridEmployee.SelectedIndex == 0 ? 1 :
                    DataGridEmployee.SelectedIndex - 1;
                    RequestSensorsEntities.GetContext().Request.Remove(cook);
                    RequestSensorsEntities.GetContext().SaveChanges();
                    DataGridEmployee.ItemsSource = RequestSensorsEntities.GetContext().Request.ToList();
                    DataGridEmployee.Items.Refresh();
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
    

    
    



