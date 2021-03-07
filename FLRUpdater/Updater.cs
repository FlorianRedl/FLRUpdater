using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLRUpdater
{
    public class Updater
    {

        /// <summary>
        /// Logo to use for all Windows
        /// </summary>
        public static string Logo { get; set; }




        /// <summary>
        /// Checking for a new version and display the StartUpWindow if update is available.
        /// </summary>
        /// <param name="xml"></param>
        public void OnStartUp(string xml)
        {
            //Check ob XML vorhanden
            //Check ob update benötigt

            if (true)
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
    }
}
