using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceTaskMarsPart1.Data
{
    public class LanguageDataHelper
    {
        public static List<LanguageData> ReadLanguageData(string jsonFileName)
        {
            string currentDirectory = "D:\\Sasikala\\MVP_Studio\\AdvanceTaskPart1\\AdvanceTaskMarsPart1\\AdvanceTaskMarsPart1";
            string filePath = Path.Combine(currentDirectory, "Data", jsonFileName);
            string jsonContent = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<List<LanguageData>>(jsonContent) ?? new List<LanguageData>();
        }
    }
}
