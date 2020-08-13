using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Too_Doo_List
{
    public static class TaskList
    {
        
        public static List<Task> loadedTasks = new List<Task>();

        public static void SaveListJSON()
        {
            string jsonFile = JsonConvert.SerializeObject(loadedTasks);
            File.WriteAllText("tasklist.json", JsonConvert.SerializeObject(loadedTasks));
            //using (StreamWriter file = File.CreateText("movie.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file, jsonFile);
            //}
        }

        public static void LoadListJSON()
        {

            loadedTasks = JsonConvert.DeserializeObject<List<Task>>(File.ReadAllText("tasklist.json"));


            //using (FileStream fileStream = new FileStream("user.json", FileMode.OpenOrCreate))
            //{
            //    loadedTasks = await JsonSerializer.DeserializeAsync<List<Task>>(fileStream);
            //}
        }

    }

  
}