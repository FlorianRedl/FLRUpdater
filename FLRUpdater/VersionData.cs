using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace FLRUpdater
{

    [XmlRoot("app")]
    public class VersionData
    {
        /// <summary>
        /// If there is an error while checking for update then this property won't be null.
        /// </summary>
        [XmlIgnore]
        public Exception Error { get; set; }
        /// <summary>
        /// If new update is available then returns true otherwise false.
        /// </summary>
        [XmlIgnore]
        public bool IsUpdateAvailable
        {
            get { return  new Version(CurrentVersion) > InstalledVersion; }
           
        }
        /// <summary>
        ///    
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// Returns newest version of the application available to download.
        /// </summary>
        [XmlElement("version")]
        public string CurrentVersion { get; set; }

        /// <summary>
        /// Returns version of the application currently installed on the user's PC.
        /// </summary>
        public Version InstalledVersion { get; set; }
    }
}
