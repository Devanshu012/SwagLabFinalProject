using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace SwagLabFinalProject.Authentication
{
    public class DataDriven
    {
        public required string baseURL { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string WrongPassword { get; set; }
        public required string fromEmail { get; set; }
        public required string emailPassword { get; set; }
        public required string toEmail { get; set; }
        public required string subject { get; set; }
        public required string body { get; set; }
        public required string reportPath { get; set; }

        public static DataDriven LoadFromJson()
        {
            string path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Authentication", "authentication.json");

            string jsonData = File.ReadAllText(path);
            DataDriven data = JsonConvert.DeserializeObject<DataDriven>(jsonData);

            return data;
        }
    }
}
