using System;
using System.Windows;
using System.Windows.Controls;
using Too_Doo_List.ViewModels;
using Xceed.Wpf.Toolkit;
using MessageBox = System.Windows.MessageBox;

namespace Too_Doo_List.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateTask.xaml
    /// </summary>
    public partial class CreateTask : UserControl
    {
        int lastCaretIndex;
        public CreateTask()
        {
            InitializeComponent();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DateTimePicker.Text == "")
            {
                MessageBox.Show("Выберите дату и время");
                return;
            }
            string dateTimeString = DateTimePicker.Text;
            DateTime dateTime = Convert.ToDateTime(dateTimeString);

            if (!CreateTaskModel.CheckUniqueDateTime(dateTime))
            {
                MessageBox.Show("Время уже занято");
                return;  
            }
            CreateTaskModel.SaveTask(nameField.Text, descriptionField.Text, dateTime, FilePath.Text);
        }
        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            string choosenFilePath;
            choosenFilePath = CreateTaskModel.SelectFileReturnPath();
            if (choosenFilePath != "")
                FilePath.Text = choosenFilePath;
            else
                MessageBox.Show("Ошибка выбора файла");
        }
    }
}
