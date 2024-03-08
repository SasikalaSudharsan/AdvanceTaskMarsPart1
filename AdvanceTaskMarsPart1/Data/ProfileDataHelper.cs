using Newtonsoft.Json;

namespace AdvanceTaskMarsPart1.Data
{
    public class ProfileDataHelper
    {
        public static ProfileData ReadProfileData(string jsonFileName)
        {
            string currentDirectory = "D:\\Sasikala\\MVP_Studio\\AdvanceTaskPart1\\AdvanceTaskMarsPart1\\AdvanceTaskMarsPart1";
            string filePath = Path.Combine(currentDirectory, "Data", jsonFileName);
            string jsonContent = File.ReadAllText(filePath);
            
            return JsonConvert.DeserializeObject<ProfileData>(jsonContent);
        }
    }
}
