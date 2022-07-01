using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace QmsCore.Model
{
 /// <summary>
    /// The config class provides a wrapper for the appsettings.json file. It's done as a singletone so that it can be statically called
    /// with no need to instantiate anyting
    /// 
    /// Example:  string dir = Config.Settings.BaseDirectory;
    /// </summary>
    public sealed class Config
    {
        private static readonly Config settings = new Config();

        public static Config Settings
        {
            get{return settings;}
            
        }
        public string LogDirectory {get;set;}

        private static IConfiguration AppSettings {get;set;}
        /// <summary>
        /// The base directory is where the OLU files will be picked up from to begin the loadig process.
        /// </summary>
        public string ReconDB = string.Empty;

        static Config()
        {}

        private Config()
        {
			//string logSnippet = "[Qms_Data][BLL][Config.cs][Config90] =>";
			
			//Console.WriteLine($"{logSnippet} (APPSETTINGS_DIRECTORY): '{Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY")}'");
			
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY"))
                             .AddJsonFile("qms_appsettings.json", optional: false, reloadOnChange: true);
            AppSettings = builder.Build();
			//Console.WriteLine($"{logSnippet} (DatabaseConnection)...: '{AppSettings["DatabaseConnection"]}'");		
 			ReconDB = AppSettings["DatabaseConnection"];
			
			//Console.WriteLine($"{logSnippet} (ReconDB)...: '{ReconDB}'");

            //LogDirectory = AppSettings.GetSection("AppSettings")["LogDirectory"];
            LogDirectory = Environment.GetEnvironmentVariable("LOGFILE_DIRECTORY");
            //Console.WriteLine($"{logSnippet} (LogDirectory)...: '{LogDirectory}'");
        }

        public void Rebuild(string configFileName)
        {
            var x = Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY");
            var builder = new ConfigurationBuilder()
                             .SetBasePath(Environment.GetEnvironmentVariable("APPSETTINGS_DIRECTORY"))
                             .AddJsonFile(configFileName, optional: false, reloadOnChange: true);
            AppSettings = builder.Build();
            ReconDB = AppSettings.GetConnectionString("DatabaseConnection");
        }
    }//end class    
}