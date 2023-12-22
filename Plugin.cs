using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Logging;
using HarmonyLib;

namespace ModChecksumPlugin
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Lethal Company.exe")]
    public class Plugin : BaseUnityPlugin
    {
        private static ManualLogSource logger;
        private void Awake()
        {
            // Plugin startup logic
            logger = Logger;
            Harmony harmony = new Harmony(PluginInfo.PLUGIN_NAME);
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            Logger.LogInfo(GetModCode());
        }

        private static string GetModCode()
        {
            string code = "";
            foreach (var plugin in Chainloader.PluginInfos)
            {
                code += plugin.ToString();
            }
            return code;
        }
    }
}
