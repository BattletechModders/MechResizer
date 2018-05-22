using System;
using System.Reflection;
using Harmony;
using Newtonsoft.Json;

namespace MechResizer
{
    public class MechResizer
    {
        internal static Settings ModSettings = new Settings();
        internal static string ModDirectory;
        public static void Init(string directory, string settingsJSON)
        {
            var harmony = HarmonyInstance.Create("com.joelmeador.MechResizer");
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            ModDirectory = directory;
            try
            {
                ModSettings = JsonConvert.DeserializeObject<Settings>(settingsJSON);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
                ModSettings = new Settings();
            }
        }
    }
}