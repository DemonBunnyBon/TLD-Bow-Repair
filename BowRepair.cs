using BowRepairMod;
using Il2Cpp;
using Il2CppNewtonsoft.Json.Utilities;
using Il2CppRewired.ComponentControls.Data;
using Il2CppRewired.Utils;
using Il2CppTLD.BigCarry;
using Il2CppTLD.Gear;
using System.Runtime.InteropServices;


namespace BowRepairMod
{
	public class BowRepair : MelonMod
	{
		public override void OnInitializeMelon()
		{
			Settings.instance.AddToModSettings("Bow Repair");
			Settings.OnLoad();
		}
		private static bool Done;
		public static bool SceneLoaded;

		public override void OnSceneWasLoaded(int buildIndex, string sceneName) //When scene is loaded
		{
			if(BowRepairUtils.IsScenePlayable(sceneName))  //Checks if it's not a menu scene
			{
				SceneLoaded = true;

				ChangeItemProperties();
			}


		}



		private static void ChangeItemProperties()
		{


			GameObject gear;
			ToolsItem Tool;
			ToolsItem Secondary_Tool;
			ToolsItem[] available_tools;
			GearItem[] needed_gear;
            int[] gear_counts = [0];

            //Set Up Needed Tools
            Tool = GearItem.LoadGearItemPrefab("GEAR_SimpleTools").m_ToolsItem;
			Secondary_Tool = GearItem.LoadGearItemPrefab("GEAR_HighQualityTools").m_ToolsItem;
			available_tools = [Tool, Secondary_Tool];

			//Set Up Needed Material
			needed_gear = [GearItem.LoadGearItemPrefab("GEAR_Softwood"), GearItem.LoadGearItemPrefab("GEAR_GutDried")];
            switch (Settings.instance.BowMaterialNeed)
            {
                case 0:
                    gear_counts = [1, 1];
                    break;
                case 1:
                    gear_counts = [2, 1];
                    break;
                case 2:
                    gear_counts = [2, 2];
                    break;
            }

            //Regular Bow
            gear = GearItem.LoadGearItemPrefab("Gear_Bow").gameObject;

            if (Settings.instance.BowRepairMode == 0)
			{
				gear.AddComponent<Repairable>();
				gear.GetComponent<Repairable>().m_RepairToolChoices = available_tools;
				gear.GetComponent<Repairable>().m_DurationMinutes = 60;
				gear.GetComponent<Repairable>().m_ConditionIncrease = 40;
				gear.GetComponent<Repairable>().m_RequiredGear = needed_gear;
				gear.GetComponent<Repairable>().m_RequiredGearUnits = gear_counts;
				gear.GetComponent<Repairable>().m_RequiresToolToRepair = true;
				gear.GetComponent<Repairable>().m_RepairAudio = "Play_CraftingWood";
				GameManager.DestroyImmediate(gear.GetComponent<Millable>());
			}
			else if (Settings.instance.BowRepairMode == 1)
			{
				needed_gear = [GearItem.LoadGearItemPrefab("GEAR_Softwood"), GearItem.LoadGearItemPrefab("GEAR_ScrapMetal")];
                switch (Settings.instance.BowMaterialNeed)
                {
                    case 0:
                        gear_counts = [1, 1];
                        break;
                    case 1:
                        gear_counts = [1, 2];
                        break;
                    case 2:
                        gear_counts = [2, 2];
                        break;
                }

                GameManager.DestroyImmediate(gear.GetComponent<Repairable>());

				gear.AddComponent<Millable>();
				gear.GetComponent<Millable>().m_CanRestoreFromWornOut = true;
				gear.GetComponent<Millable>().m_RecoveryDurationMinutes = 60;
				gear.GetComponent<Millable>().m_RepairDurationMinutes = 30;
				gear.GetComponent<Millable>().m_RepairRequiredGear = needed_gear;
				gear.GetComponent<Millable>().m_RepairRequiredGearUnits = gear_counts;
                switch (Settings.instance.BowMaterialNeed)
                {
                    case 0:
                        gear_counts = [1, 1];
                        break;
                    case 1:
                        gear_counts = [2, 2];
                        break;
                    case 2:
                        gear_counts = [3, 3];
                        break;
                }
                gear.GetComponent<Millable>().m_RestoreRequiredGear = needed_gear;
				gear.GetComponent<Millable>().m_RestoreRequiredGearUnits = gear_counts;
				gear.GetComponent<Millable>().m_Skill = SkillType.Archery;

			}
			else if (Settings.instance.BowRepairMode == 2)
			{
				needed_gear = [GearItem.LoadGearItemPrefab("GEAR_Softwood"), GearItem.LoadGearItemPrefab("GEAR_GutDried")];
                switch (Settings.instance.BowMaterialNeed)
                {
                    case 0:
                        gear_counts = [1, 1];
                        break;
                    case 1:
                        gear_counts = [2, 1];
                        break;
                    case 2:
                        gear_counts = [2, 2];
                        break;
                }
                gear.AddComponent<Repairable>();
				gear.GetComponent<Repairable>().m_RepairToolChoices = available_tools;
				gear.GetComponent<Repairable>().m_DurationMinutes = 60;
				gear.GetComponent<Repairable>().m_ConditionIncrease = 40;
				gear.GetComponent<Repairable>().m_RequiredGear = needed_gear;
				gear.GetComponent<Repairable>().m_RequiredGearUnits = gear_counts;
				gear.GetComponent<Repairable>().m_RequiresToolToRepair = true;
				gear.GetComponent<Repairable>().m_RepairAudio = "Play_CraftingArrows";

				needed_gear = [GearItem.LoadGearItemPrefab("GEAR_Softwood"), GearItem.LoadGearItemPrefab("GEAR_ScrapMetal")];
                switch (Settings.instance.BowMaterialNeed)
                {
                    case 0:
                        gear_counts = [1, 1];
                        break;
                    case 1:
                        gear_counts = [1, 2];
                        break;
                    case 2:
                        gear_counts = [2, 2];
                        break;
                }

                gear.AddComponent<Millable>();
                gear.GetComponent<Millable>().m_CanRestoreFromWornOut = true;
                gear.GetComponent<Millable>().m_RecoveryDurationMinutes = 60;
                gear.GetComponent<Millable>().m_RepairDurationMinutes = 30;
                gear.GetComponent<Millable>().m_RepairRequiredGear = needed_gear;
				gear.GetComponent<Millable>().m_RepairRequiredGearUnits = gear_counts;
                switch (Settings.instance.BowMaterialNeed)
                {
                    case 0:
                        gear_counts = [1, 1];
                        break;
                    case 1:
                        gear_counts = [2, 2];
                        break;
                    case 2:
                        gear_counts = [3, 3];
                        break;
                }
                gear.GetComponent<Millable>().m_RestoreRequiredGear = needed_gear;
                gear.GetComponent<Millable>().m_RestoreRequiredGearUnits = gear_counts;
                gear.GetComponent<Millable>().m_Skill = SkillType.Archery;

            }
			else
			{
				GameManager.DestroyImmediate(gear.GetComponent<Repairable>());
				GameManager.DestroyImmediate(gear.GetComponent<Millable>());
			}

			//DLC Only

			if (Settings.instance.DLCEnable == true)
			{

				//Sport Bow

				gear = GearItem.LoadGearItemPrefab("Gear_Bow_Manufactured").gameObject;
				if (Settings.instance.SportBowRepairMode == 0)
				{
					needed_gear = [GearItem.LoadGearItemPrefab("GEAR_ScrapLead"), GearItem.LoadGearItemPrefab("Gear_ScrapMetal")];
                    switch (Settings.instance.SportBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [2, 1];
                            break;
                        case 2:
                            gear_counts = [3, 3];
                            break;
                    }

                    gear.AddComponent<Repairable>();
					gear.GetComponent<Repairable>().m_RepairToolChoices = available_tools;
					gear.GetComponent<Repairable>().m_DurationMinutes = 65;
					gear.GetComponent<Repairable>().m_ConditionIncrease = 35;
					gear.GetComponent<Repairable>().m_RequiredGear = needed_gear;
					gear.GetComponent<Repairable>().m_RequiredGearUnits = gear_counts;
					gear.GetComponent<Repairable>().m_RequiresToolToRepair = true;
					gear.GetComponent<Repairable>().m_RepairAudio = "Play_CraftingGeneric";
					GameManager.DestroyImmediate(gear.GetComponent<Millable>());
				}
				else if (Settings.instance.SportBowRepairMode == 1)
				{
					needed_gear = [GearItem.LoadGearItemPrefab("GEAR_ScrapLead"), GearItem.LoadGearItemPrefab("Gear_ScrapMetal")];
                    switch (Settings.instance.SportBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [2, 1];
                            break;
                        case 2:
                            gear_counts = [3, 3];
                            break;
                    }

                    gear.AddComponent<Millable>();
					gear.GetComponent<Millable>().m_CanRestoreFromWornOut = true;
					gear.GetComponent<Millable>().m_RecoveryDurationMinutes = 145;
					gear.GetComponent<Millable>().m_RepairDurationMinutes = 50;
					gear.GetComponent<Millable>().m_RepairRequiredGear = needed_gear;
					gear.GetComponent<Millable>().m_RepairRequiredGearUnits = gear_counts;
                    switch (Settings.instance.SportBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [2, 2];
                            break;
                        case 2:
                            gear_counts = [3, 4];
                            break;
                    }
                    gear.GetComponent<Millable>().m_RestoreRequiredGear = needed_gear;
					gear.GetComponent<Millable>().m_RestoreRequiredGearUnits = gear_counts;
					gear.GetComponent<Millable>().m_Skill = SkillType.Archery;
					GameManager.DestroyImmediate(gear.GetComponent<Repairable>());
				}

				else if (Settings.instance.SportBowRepairMode == 2)
				{

					needed_gear = [GearItem.LoadGearItemPrefab("GEAR_ScrapLead"), GearItem.LoadGearItemPrefab("Gear_ScrapMetal")];
					switch(Settings.instance.SportBowMaterialNeed)
					{
						case 0:
                            gear_counts = [1, 1];
                            break;
						case 1:
							gear_counts = [2, 1];
							break;
						case 2:
							gear_counts = [3, 3];
							break;
					}
					
					gear.AddComponent<Repairable>();
					gear.GetComponent<Repairable>().m_RepairToolChoices = available_tools;
					gear.GetComponent<Repairable>().m_DurationMinutes = 65;
					gear.GetComponent<Repairable>().m_ConditionIncrease = 35;
					gear.GetComponent<Repairable>().m_RequiredGear = needed_gear;
					gear.GetComponent<Repairable>().m_RequiredGearUnits = gear_counts;
					gear.GetComponent<Repairable>().m_RequiresToolToRepair = true;
					gear.GetComponent<Repairable>().m_RepairAudio = "Play_CraftingGeneric";


					gear.AddComponent<Millable>();
					gear.GetComponent<Millable>().m_CanRestoreFromWornOut = true;
					gear.GetComponent<Millable>().m_RecoveryDurationMinutes = 145;
					gear.GetComponent<Millable>().m_RepairDurationMinutes = 50;
					gear.GetComponent<Millable>().m_RepairRequiredGear = needed_gear;
					gear.GetComponent<Millable>().m_RepairRequiredGearUnits = gear_counts;
                    switch (Settings.instance.SportBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [2, 2];
                            break;
                        case 2:
                            gear_counts = [3, 4];
                            break;
                    }
                    gear.GetComponent<Millable>().m_RestoreRequiredGear = needed_gear;
					gear.GetComponent<Millable>().m_RestoreRequiredGearUnits = gear_counts;
					gear.GetComponent<Millable>().m_Skill = SkillType.Archery;
				}
				else
				{
					GameManager.DestroyImmediate(gear.GetComponent<Repairable>());
					GameManager.DestroyImmediate(gear.GetComponent<Millable>());
				}

				//Woodwright Bow

				gear = GearItem.LoadGearItemPrefab("Gear_Bow_Woodwrights").gameObject;
				if (Settings.instance.WoodBowRepairMode == 0)
				{
					needed_gear = [GearItem.LoadGearItemPrefab("GEAR_Hardwood"), GearItem.LoadGearItemPrefab("Gear_ScrapMetal")];
                    switch (Settings.instance.WoodBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [1, 2];
                            break;
                        case 2:
                            gear_counts = [2, 2];
                            break;
                    }
                    gear.AddComponent<Repairable>();
					gear.GetComponent<Repairable>().m_RepairToolChoices = available_tools;
					gear.GetComponent<Repairable>().m_DurationMinutes = 60;
					gear.GetComponent<Repairable>().m_ConditionIncrease = 35;
					gear.GetComponent<Repairable>().m_RequiredGear = needed_gear;
					gear.GetComponent<Repairable>().m_RequiredGearUnits = gear_counts;
					gear.GetComponent<Repairable>().m_RequiresToolToRepair = true;
					gear.GetComponent<Repairable>().m_RepairAudio = "Play_CraftingWood";
					GameManager.DestroyImmediate(gear.GetComponent<Millable>());
				}
				else if (Settings.instance.WoodBowRepairMode == 1)
				{
					needed_gear = [GearItem.LoadGearItemPrefab("GEAR_Hardwood"), GearItem.LoadGearItemPrefab("Gear_ScrapMetal")];
                    switch (Settings.instance.WoodBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [1, 2];
                            break;
                        case 2:
                            gear_counts = [2, 2];
                            break;
                    }

                    gear.AddComponent<Millable>();
					gear.GetComponent<Millable>().m_CanRestoreFromWornOut = true;
					gear.GetComponent<Millable>().m_RecoveryDurationMinutes = 115;
					gear.GetComponent<Millable>().m_RepairDurationMinutes = 45;
					gear.GetComponent<Millable>().m_RepairRequiredGear = needed_gear;
					gear.GetComponent<Millable>().m_RepairRequiredGearUnits = gear_counts;
                    switch (Settings.instance.WoodBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [1, 2];
                            break;
                        case 2:
                            gear_counts = [2, 2];
                            break;
                    }
                    gear.GetComponent<Millable>().m_RestoreRequiredGear = needed_gear;
					gear.GetComponent<Millable>().m_RestoreRequiredGearUnits = gear_counts;
					gear.GetComponent<Millable>().m_Skill = SkillType.Archery;
					GameManager.DestroyImmediate(gear.GetComponent<Repairable>());
				}

				else if (Settings.instance.WoodBowRepairMode == 2)
				{

					needed_gear = [GearItem.LoadGearItemPrefab("GEAR_Hardwood"), GearItem.LoadGearItemPrefab("Gear_ScrapMetal")];
                    switch (Settings.instance.WoodBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [2, 2];
                            break;
                        case 2:
                            gear_counts = [3, 3];
                            break;
                    }
                    gear.AddComponent<Repairable>();
					gear.GetComponent<Repairable>().m_RepairToolChoices = available_tools;
					gear.GetComponent<Repairable>().m_DurationMinutes = 60;
					gear.GetComponent<Repairable>().m_ConditionIncrease = 35;
					gear.GetComponent<Repairable>().m_RequiredGear = needed_gear;
					gear.GetComponent<Repairable>().m_RequiredGearUnits = gear_counts;
					gear.GetComponent<Repairable>().m_RequiresToolToRepair = true;
					gear.GetComponent<Repairable>().m_RepairAudio = "Play_CraftingWood";

					needed_gear = [GearItem.LoadGearItemPrefab("GEAR_Hardwood"), GearItem.LoadGearItemPrefab("Gear_ScrapMetal")];
                    switch (Settings.instance.WoodBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [1, 2];
                            break;
                        case 2:
                            gear_counts = [2, 2];
                            break;
                    }
                    gear.AddComponent<Millable>();
					gear.GetComponent<Millable>().m_CanRestoreFromWornOut = true;
					gear.GetComponent<Millable>().m_RecoveryDurationMinutes = 115;
					gear.GetComponent<Millable>().m_RepairDurationMinutes = 45;
					gear.GetComponent<Millable>().m_RepairRequiredGear = needed_gear;
					gear.GetComponent<Millable>().m_RepairRequiredGearUnits = gear_counts;
                    switch (Settings.instance.WoodBowMaterialNeed)
                    {
                        case 0:
                            gear_counts = [1, 1];
                            break;
                        case 1:
                            gear_counts = [2, 2];
                            break;
                        case 2:
                            gear_counts = [3, 3];
                            break;
                    }
                    gear.GetComponent<Millable>().m_RestoreRequiredGear = needed_gear;
					gear.GetComponent<Millable>().m_RestoreRequiredGearUnits = gear_counts;
					gear.GetComponent<Millable>().m_Skill = SkillType.Archery;
				}
				else
				{
					GameManager.DestroyImmediate(gear.GetComponent<Repairable>());
					GameManager.DestroyImmediate(gear.GetComponent<Millable>());
				}

			}




		}
	}
}