using MySql.Data.MySqlClient;
using System;

namespace Too_Doo_List.ViewModels
{
    public class TaskDeleteModel
    {
        public static Task chosenTask = null;
        public static void DeleteTaskDatabase(DateTime dateTime)
        {
            Database database = new Database();
            MySqlCommand command = new MySqlCommand("DELETE FROM tasks WHERE datetime = @dateTime", database.getConnection());
            command.Parameters.Add("@dateTime", MySqlDbType.DateTime).Value = dateTime;
            try
            {
                database.openConnect();
                command.ExecuteNonQuery();
                database.closeConnect();
            }
            catch { }

            foreach(Task task in TaskList.loadedTasks)
            {
                if (task.datetime == dateTime)
                {
                    TaskList.loadedTasks.Remove(task);
                    return;
                }
            }

        }
    }
}
