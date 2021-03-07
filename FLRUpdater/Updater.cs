using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Serialization;
using System.Xml;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace FLRUpdater
{
    static public class Updater
    {

        /// <summary>
        /// Logo to use for all Windows
        /// </summary>
        public static string Logo;
        /// <summary>
        ///     You can set this field to your current version if you don't want to determine the version from the assembly.
        /// </summary>
        public static Version InstalledVersion;



        /// <summary>
        /// Checking for a new version and display the StartUpWindow if update is available.
        /// </summary>
        /// <param name="xml"></param>
        public static void OnStartUp(string versionDB)
        {

            if (CheckForUpdate(versionDB))
            {
                StartUpWindow startUpWindow = new StartUpWindow();
                startUpWindow.Show();
            }

        }

        public static void OnRuntime()
        {
            
            //Sucht nach Updates

            //wenn verfügbar updaten und neu starten 
        }


        private static bool CheckForUpdate(string versionDB)
        {
            versionDB args;
            WebClient webClient = new WebClient();

            string xml = webClient.DownloadString(versionDB);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(versionDB));
            XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(xml)) { XmlResolver = null };
            args = (versionDB)xmlSerializer.Deserialize(xmlTextReader);

            Assembly mainAssembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(args.CurrentVersion);

            args.InstalledVersion = InstalledVersion != null ? InstalledVersion : mainAssembly.GetName().Version;
            args.IsUpdateAvailable = new Version(args.CurrentVersion) > args.InstalledVersion;

            if (args.IsUpdateAvailable)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        [XmlRoot("app")]
        public class versionDB : EventArgs
        {
            /// <summary>
            ///     If there is an error while checking for update then this property won't be null.
            /// </summary>
            [XmlIgnore]
            public Exception Error { get; set; }
            /// <summary>
            ///     If new update is available then returns true otherwise false.
            /// </summary>
            public bool IsUpdateAvailable { get; set; }
            /// <summary>
            ///    
            /// </summary>
            [XmlElement("name")]
            public string Name { get; set; }
            /// <summary>
            ///     Returns newest version of the application available to download.
            /// </summary>
            [XmlElement("version")]
            public string CurrentVersion { get; set; }

            /// <summary>
            ///     Returns version of the application currently installed on the user's PC.
            /// </summary>
            public Version InstalledVersion { get; set; }

           

        }
    }
}
