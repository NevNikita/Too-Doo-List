using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;

namespace Too_Doo_List.ViewModels
{
    public class CreateTaskModel
    {
        public static void SendTaskDatabase(string name, string description, DateTime dateTime, string filePath)
        {
            Database database = new Database();
            MySqlCommand command = new MySqlCommand("INSERT INTO tasks (name, description, datetime, path) VALUES (@name, @description, @dateTime, @path)", database.getConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@description", MySqlDbType.VarChar).Value = description;
            command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = dateTime;
            command.Parameters.Add("@path", MySqlDbType.VarChar).Value = filePath;
            try
            {
                database.openConnect();
            }
            catch
            {
                return;
            }
            command.ExecuteNonQuery();
            database.closeConnect();
            
        }

        public static void SaveTask(string name, string description, DateTime dateTime, string filePath)
        {
            TaskList.loadedTasks.Add(new Task(name, description, dateTime, filePath));
            TaskList.SaveListJSON();
            SendTaskDatabase(name, description, dateTime, filePath);
        }

        public static bool CheckUniqueDateTime(DateTime dateTime)
        {
            bool isUnique = true;
            foreach (Task task in TaskList.loadedTasks)
            {
                if (dateTime == task.datetime)
                {
                    isUnique = false;
                }
            }
            return isUnique;
        }

        public static string SelectFileReturnPath()
        {
            string filePath = "";
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            Nullable<bool> dialogContinue = fileDialog.ShowDialog();
            if (dialogContinue == true)
                 filePath = fileDialog.FileName;
            return filePath;
        }


    }
}
