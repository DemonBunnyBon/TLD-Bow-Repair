using UnityEngine;
using Il2Cpp;
using MelonLoader;





namespace BowRepairMod
{
    internal static class BowRepairUtils
    {

        public static bool IsScenePlayable(string scene)
        {
            return !(string.IsNullOrEmpty(scene) || scene.Contains("MainMenu") || scene == "Boot" || scene == "Empty");
        }




    }






}


