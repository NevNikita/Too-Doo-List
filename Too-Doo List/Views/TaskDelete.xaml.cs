using System.Windows;
using System.Windows.Controls;
using Too_Doo_List.ViewModels;

namespace Too_Doo_List.Views
{
    /// <summary>
    /// Логика взаимодействия для TaskDelete.xaml
    /// </summary>
    public partial class TaskDelete : UserControl
    {
        Task thisTask = TaskDeleteModel.chosenTask;
        public TaskDelete()
        {
             InitializeComponent();
            DataContext = this;

            Name.Text = thisTask.name;
            Description.Text = thisTask.description;
            Path.Text = thisTask.filePath;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            TaskDeleteModel.DeleteTaskDatabase(thisTask.datetime);
            MainWindow.model.CurrentContentVM = new ViewModels.ViewTaskModel();
        }
    }
}
