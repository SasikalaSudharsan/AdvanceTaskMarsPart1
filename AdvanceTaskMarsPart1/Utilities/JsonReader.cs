using Newtonsoft.Json;

namespace AdvanceTaskMarsPart1.Utilities
{
    public class JsonReader
    {       
        public static List<T> LoadData<T>(string jsonFileName)
        {
            string currentDirectory = "D:\\Sasikala\\MVP_Studio\\AdvanceTaskPart1\\AdvanceTaskMarsPart1\\AdvanceTaskMarsPart1";
            string filePath = Path.Combine(currentDirectory, "Data", jsonFileName);
            using (StreamReader reader = new StreamReader(filePath))
            {
                var jsonContent = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(jsonContent);
            }
        }
    }
}
