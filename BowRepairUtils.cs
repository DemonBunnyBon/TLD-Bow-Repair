using UnityEngine;
using Il2Cpp;
using MelonLoader;
using Il2CppTLD.OptionalContent;





namespace BowRepairMod
{
    internal static class BowRepairUtils
    {

        public static bool IsScenePlayable(string scene)
        {
            return !(string.IsNullOrEmpty(scene) || scene.Contains("MainMenu") || scene == "Boot" || scene == "Empty");
        }
        public static bool PlayerHasDLC()
        {
            return OptionalContentManager.Instance.InstalledContent.ContainsKey("2091330");
            
        }



    }






}


