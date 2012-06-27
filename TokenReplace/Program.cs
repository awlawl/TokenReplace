
using System.Configuration;
using System.IO;

namespace TokenReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            //read tokenized file
            var tokenizedFile = File.ReadAllText(args[0]);

            //enumerate over the appSettings
            foreach (var settingName in ConfigurationManager.AppSettings.AllKeys)
            {
                var setting = ConfigurationManager.AppSettings[settingName];

                //replace all instances of the token with the setting
                tokenizedFile = tokenizedFile.Replace("@" + settingName + "@", setting);
            }

            
            //write the output to the file
            File.WriteAllText(args[1],tokenizedFile);

        }
    }
}
