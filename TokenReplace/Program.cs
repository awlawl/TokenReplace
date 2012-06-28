
using System;
using System.Configuration;
using System.IO;
using System.Security;

namespace TokenReplace
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("usage: TokenReplace <tokenized file> <output file>");
                Console.WriteLine("");
                return -1;
            }

            //read tokenized file
            var tokenizedFile = File.ReadAllText(args[0]);

            if (ConfigurationManager.AppSettings.AllKeys.Length == 0)
            {
                Console.WriteLine("FYI, there were no settings in the TokenReplace.exe.config.");
                return -1;
            }
            else
            {
                //enumerate over the appSettings
                foreach (var settingName in ConfigurationManager.AppSettings.AllKeys)
                {
                    var setting = ConfigurationManager.AppSettings[settingName];

                    //replace all instances of the token with the setting
                    tokenizedFile = tokenizedFile.Replace("@" + settingName + "@", setting);
                    tokenizedFile = tokenizedFile.Replace("%" + settingName + "%", SecurityElement.Escape(setting));
                }


                //write the output to the file
                File.WriteAllText(args[1], tokenizedFile);


            }

            return 0;
        }
    }
}
