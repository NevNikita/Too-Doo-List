using System;
using System.Windows;
using System.Windows.Controls;
using Too_Doo_List.ViewModels;

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
        private void TimeInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((this.TimeInput.CaretIndex == 2))
            {
                if (lastCaretIndex == 3)
                {
                    this.TimeInput.Text += ":";
                    this.TimeInput.CaretIndex = 2;
                }
                else
                {
                    if (this.TimeInput.Text[this.TimeInput.Text.Length - 1] != ':')
                        this.TimeInput.Text += ':';
                    this.TimeInput.CaretIndex = 3;
                }
            }
            if (this.TimeInput.CaretIndex == 3)
            {
                if (lastCaretIndex == 2)
                    this.TimeInput.CaretIndex = 4;
                if (lastCaretIndex == 4)
                    this.TimeInput.CaretIndex = 2;
            }
            lastCaretIndex = this.TimeInput.CaretIndex;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DatePicker.Text == "")
            {
                MessageBox.Show("Выберите дату и время");
                return;
            }
            string dateTimeString = DatePicker.Text + " " + TimeInput.Text + ":00";
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
