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
using System.Reflection;

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
            VersionData versionData;

            WebClient webClient = new WebClient();
            string xml = webClient.DownloadString(versionDB);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(VersionData));
            XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(xml)) { XmlResolver = null };
            versionData = (VersionData)xmlSerializer.Deserialize(xmlTextReader);

            string mainAssembly = Assembly.GetEntryAssembly().GetCustomAttribute<AssemblyFileVersionAttribute>().Version;

            versionData.InstalledVersion = InstalledVersion != null ? InstalledVersion : new Version(mainAssembly);

            if (versionData.IsUpdateAvailable)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
