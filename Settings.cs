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

        [Section("DLC Content")]

        [Name("Enable DLC items")]
        [Description("Specifies whether the mod should affect DLC items. (Turning this on without having the DLC installed will cause issues!) [Requires scene transition or reload to update].")]
        public bool DLCEnable = false;

        [Name("Sports Bow Repair Mode")]
        [Description("Specifies where the Sports Bow can be repaired [Requires scene transition or reload to update].")]
        [Choice("Hand", "Milling Machine", "Hand And Machine", "None")]
        public int SportBowRepairMode = 1;

        [Name("Woodwright's Bow Repair Mode")]
        [Description("Specifies where the Woodwright's Bow can be repaired [Requires scene transition or reload to update].")]
        [Choice("Hand", "Milling Machine", "Hand And Machine", "None")]
        public int WoodBowRepairMode = 2;

        protected override void OnChange(FieldInfo field, object? oldValue, object? newValue) => RefreshFields();
        internal static void OnLoad()
        {
            instance.RefreshFields();
        }
        internal void RefreshFields()
        {
            if (DLCEnable)
            {
                SetFieldVisible(nameof(SportBowRepairMode), true);
                SetFieldVisible(nameof(WoodBowRepairMode), true);
            }
            else
            {
                SetFieldVisible(nameof(SportBowRepairMode), false);
                SetFieldVisible(nameof(WoodBowRepairMode), false);
            }

        }

    }
}
