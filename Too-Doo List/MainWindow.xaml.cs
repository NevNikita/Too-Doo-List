using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Threading;
using Too_Doo_List.ViewModels;



namespace Too_Doo_List
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 



    public partial class MainWindow : Window
    {
        public static MainWindowModel model = new MainWindowModel();
        private System.Windows.Forms.NotifyIcon m_notifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = model;

            DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background);
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.IsEnabled = true;
            timer.Tick += (s, e) =>
            {
                TimeCompare();
            };

            m_notifyIcon = new System.Windows.Forms.NotifyIcon();
            m_notifyIcon.BalloonTipText = "The app has been minimised. Click the tray icon to show.";
            m_notifyIcon.BalloonTipTitle = "Too-Doo";
            m_notifyIcon.Text = "Too-Doo";
            Icon getIcon = Properties.Resources.Application;
            m_notifyIcon.Icon = getIcon;
            m_notifyIcon.Click += new EventHandler(m_notifyIcon_Click);
        }

        private void CreateTaskView_Click(object sender, RoutedEventArgs e)
        {
            model.CurrentContentVM = new CreateTaskModel();
        }

        private void ViewTask_Click(object sender, RoutedEventArgs e)
        {
            model.CurrentContentVM = new ViewTaskModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            TaskList.LoadListJSON();
        }

        public void TimeCompare()
        {

            foreach (Task task in TaskList.loadedTasks)
            {
                if (!task.isDone)
                    if (MainWindowModel.CurrentTime.DayOfYear == task.datetime.DayOfYear && MainWindowModel.CurrentTime.Hour == task.datetime.Hour && MainWindowModel.CurrentTime.Minute == task.datetime.Minute)
                    {
                        MessageBox.Show("Now is " + task.name);
                        task.isDone = true;
                        if (task.filePath != "")
                        {
                            System.IO.FileInfo fileInfo = new System.IO.FileInfo(task.filePath);
                            if (fileInfo.Exists)
                            {
                                System.Diagnostics.Process file = new System.Diagnostics.Process();
                                file.StartInfo.FileName = task.filePath;
                                file.Start();
                            }

                        }
                    }
            }
        }

        void OnClose(object sender, CancelEventArgs args)
        {
            m_notifyIcon.Dispose();
            m_notifyIcon = null;
        }

        private WindowState m_storedWindowState = WindowState.Normal;
        void OnStateChanged(object sender, EventArgs args)
        {
            if (WindowState == WindowState.Minimized)
            {
                Hide();
                if (m_notifyIcon != null)
                    m_notifyIcon.ShowBalloonTip(2000);
            }
            else
                m_storedWindowState = WindowState;
        }
        void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs args)
        {
            CheckTrayIcon();
        }

        void m_notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = m_storedWindowState;
        }
        void CheckTrayIcon()
        {
            ShowTrayIcon(!IsVisible);
        }

        void ShowTrayIcon(bool show)
        {
            if (m_notifyIcon != null)
                m_notifyIcon.Visible = show;
        }

    }
}
