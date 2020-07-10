using System;
using System.Collections.Generic;
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
using Too_Doo_List.VeiwModels;
using Too_Doo_List.Views;

namespace Too_Doo_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateTaskView_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CreateTaskModel();
        }

        private void ViewTask_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ViewTaskModel();
        }
    }
}
