using Il2CppSystem.Net.Configuration;
using ModSettings;

namespace BowRepairMod
{
    internal class Settings : JsonModSettings
    {
        internal static Settings instance = new Settings();
        [Section("Base Game Settings")]

        [Name("Bow Repair Mode")]
        [Description("Specifies where the Bow can be repaired [Requires scene transition or reload to update].")]
        [Choice("Hand","Milling Machine","Hand And Machine", "None")]
        public int BowRepairMode = 2;
        [Name("Material Requirement")]
        [Description("Specifies how many materials are needed for repair [Requires scene transition or reload to update].")]
        [Choice("Low", "Medium", "High")]
        public int BowMaterialNeed = 1;

        [Section("Optional Settings")]
        [Name("Enable DLC Content")]
        [Description("Enables settings for items from the TFTFT DLC. Only enable if you have the DLC installed. This will cause issues if you do not have it installed.")]
        public bool DLCEnable = false;

        [Section("DLC Content")]

        [Name("Sports Bow Repair Mode")]
        [Description("Specifies where the Sports Bow can be repaired [Requires scene transition or reload to update].")]
        [Choice("Hand", "Milling Machine", "Hand And Machine", "None")]
        public int SportBowRepairMode = 1;
        [Name("Sports Bow Material Requirement")]
        [Description("Specifies how many materials are needed for repair [Requires scene transition or reload to update].")]
        [Choice("Low", "Medium", "High")]
        public int SportBowMaterialNeed = 1;

        [Name("Woodwright's Bow Repair Mode")]
        [Description("Specifies where the Woodwright's Bow can be repaired [Requires scene transition or reload to update].")]
        [Choice("Hand", "Milling Machine", "Hand And Machine", "None")]
        public int WoodBowRepairMode = 2;
        [Name("Woodwright's Bow Material Requirement")]
        [Description("Specifies how many materials are needed for repair [Requires scene transition or reload to update].")]
        [Choice("Low", "Medium", "High")]
        public int WoodBowMaterialNeed = 0;



        [Section("Reset Settings")]
        [Name("Reset To Default")]
        [Description("Resets all settings to Default. (Confirm and scene reload/transition required.)")]
        public bool ResetSettings = false;


        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue) => RefreshFields();
        protected override void OnConfirm()
        {
           ApplyReset();
           instance.ResetSettings = false;
           base.OnConfirm();
        }
        internal static void OnLoad()
        {
            instance.RefreshFields();
        }
        internal void RefreshFields()
        {
            if (instance.DLCEnable == true)
            {
                SetFieldVisible(nameof(SportBowRepairMode), true);
                SetFieldVisible(nameof(WoodBowRepairMode), true);
                SetFieldVisible(nameof(WoodBowMaterialNeed), true);
                SetFieldVisible(nameof(SportBowMaterialNeed), true);
            }
            else
            {
                SetFieldVisible(nameof(SportBowRepairMode), false);
                SetFieldVisible(nameof(WoodBowRepairMode), false);
                SetFieldVisible(nameof(WoodBowMaterialNeed), false);
                SetFieldVisible(nameof(SportBowMaterialNeed), false);
            }

        }
        public static void ApplyReset()
        {
            if (instance.ResetSettings == true)
            {
                instance.BowRepairMode = 2;
                instance.BowMaterialNeed = 1;
                instance.SportBowRepairMode = 1;
                instance.SportBowMaterialNeed = 1;
                instance.WoodBowRepairMode = 2;
                instance.WoodBowMaterialNeed = 0;
                instance.ResetSettings = false;
                instance.DLCEnable = false;
                instance.RefreshFields();
                instance.RefreshGUI();
            }
        }

    }
}
