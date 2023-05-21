using Gestion_du_temps_cse_axe_system_.net_5._0;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.IO;
using System.Windows.Forms;

namespace projet_gestion_temps_cse_axe_system
{
    internal class jsonManagement
    {
    }
    public class ImportJsonFromFile
    {
        public static string GetJsonFromFile()
        {
            string json = "";
            string file = "Data";
            string filePath = "Data/personneList.json";

            if (!Directory.Exists(file))
            {
                Directory.CreateDirectory(file);
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.Write(json);
                }
            }
            return File.ReadAllText("Data/personneList.json");
        }
        public static void Send(List<Personnes> personnes)
        {
            string json = JsonConvert.SerializeObject(personnes);
            string file = "Data";
            string filePath = "Data/personneList.json";

            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, json);
            }
            else
            {
                if (!Directory.Exists(file))
                {
                    Directory.CreateDirectory(file);
                }
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.Write(json);
                }
            }
        }
    }
}