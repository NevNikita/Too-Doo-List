using System.Windows.Controls;


namespace Too_Doo_List.Views
{
    /// <summary>
    /// Логика взаимодействия для ViewTasks.xaml
    /// </summary>
    public partial class ViewTasks : UserControl
    {
        public ViewTasks()
        {
            InitializeComponent();
           
            TaskListBox.ItemsSource = TaskList.loadedTasks;
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.model.CurrentContentVM = new ViewModels.TaskDeleteModel();
            ViewModels.TaskDeleteModel.chosenTask = TaskList.loadedTasks[TaskListBox.SelectedIndex];
        }
    }
}
