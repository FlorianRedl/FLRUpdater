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

namespace FLRUpdater
{
    public class Updater
    {

        /// <summary>
        /// Logo to use for all Windows
        /// </summary>
        public static string Logo { get; set; }

        /// <summary>
        ///     You can set this field to your current version if you don't want to determine the version from the assembly.
        /// </summary>
        public static Version InstalledVersion;



        /// <summary>
        /// Checking for a new version and display the StartUpWindow if update is available.
        /// </summary>
        /// <param name="xml"></param>
        public void OnStartUp(string versionDB)
        {
            //Check ob XML vorhanden
            //Check ob update benötigt

            

            if (CheckForUpdate(versionDB))
            {
                StartUpWindow startUpWindow = new StartUpWindow();
                startUpWindow.Show();
            }
            

            //Öffnet fenster

            //sucht nach Updates

            

        }

        public void OnRuntime()
        {
            
            //Sucht nach Updates

            //wenn verfügbar updaten und neu starten 
        }


        private bool CheckForUpdate(string versionDB)
        {
            versionDB args;
            
            WebClient webClient = new WebClient();

            string xml = webClient.DownloadString(versionDB);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(versionDB));
            XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(xml)) { XmlResolver = null };
            args = (versionDB)xmlSerializer.Deserialize(xmlTextReader);

            Assembly mainAssembly = Assembly.GetExecutingAssembly();

            args.InstalledVersion = InstalledVersion != null ? InstalledVersion : mainAssembly.GetName().Version;

            args.IsUpdateAvailable = new Version(args.CurrentVersion) > args.InstalledVersion;

            return true;
        }

        public class versionDB : EventArgs
        {

            /// <summary>
            ///     If new update is available then returns true otherwise false.
            /// </summary>
            public bool IsUpdateAvailable { get; set; }
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
