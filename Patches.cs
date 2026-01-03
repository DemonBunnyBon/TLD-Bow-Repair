
namespace BowRepairMod;

[HarmonyPatch(typeof(GearItem), nameof(GearItem.Awake))]
internal static class BowItemPatch
{
	
    public static void Postfix(ref GearItem __instance)
    {
	    int[] gear_counts = [];


            //Regular Bow

			if (__instance.name.Contains("GEAR_Bow") && !__instance.name.ToLowerInvariant().Contains("gear_bow_manufactured") && !__instance.name.ToLowerInvariant().Contains("gear_bow_woodwrights") && !__instance.name.ToLowerInvariant().Contains("gear_bow_bushcraft"))
			{
				switch (Settings.instance.BowRepairMode)
				{
					case 0:
					{
						switch (Settings.instance.BowMaterialNeed)
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
						Repairable r = __instance.gameObject.AddComponent<Repairable>();
						__instance.m_Repairable = r;
						r.m_RepairToolChoices = Utilities.Tools();
						r.m_DurationMinutes = 65;
						r.m_ConditionIncrease = 35;
						r.m_RequiredGear = Utilities.MakeNeededItemList(BowRepair.softwood, BowRepair.driedgut);
						r.m_RequiredGearUnits = gear_counts;
						r.m_RequiresToolToRepair = true;
						r.m_RepairAudio = "Play_CraftingGeneric";
						break;
					}
					case 1:
					{
						switch (Settings.instance.BowMaterialNeed)
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

						Millable m = __instance.gameObject.AddComponent<Millable>();
						__instance.m_Millable = m;
						m.m_CanRestoreFromWornOut = true;
						m.m_RecoveryDurationMinutes = 145;
						m.m_RepairDurationMinutes = 50;
						m.m_RepairRequiredGear = Utilities.MakeNeededItemList(BowRepair.softwood, BowRepair.scrapmetal);
						m.m_RepairRequiredGearUnits = gear_counts;
						switch (Settings.instance.BowMaterialNeed)
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
						m.m_RestoreRequiredGear = Utilities.MakeNeededItemList(BowRepair.softwood, BowRepair.scrapmetal);
						m.m_RestoreRequiredGearUnits = gear_counts;
						m.m_Skill = SkillType.Archery;
						break;
					}
					case 2:
					{
						switch(Settings.instance.BowMaterialNeed)
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
						Repairable r = __instance.gameObject.AddComponent<Repairable>();
						__instance.m_Repairable = r;
						r.m_RepairToolChoices = Utilities.Tools();
						r.m_DurationMinutes = 65;
						r.m_ConditionIncrease = 35;
						r.m_RequiredGear = Utilities.MakeNeededItemList(BowRepair.softwood, BowRepair.driedgut);
						r.m_RequiredGearUnits = gear_counts;
						r.m_RequiresToolToRepair = true;
						r.m_RepairAudio = "Play_CraftingGeneric";
						
						Millable m = __instance.gameObject.AddComponent<Millable>();
						__instance.m_Millable = m;
						m.m_CanRestoreFromWornOut = true;
						m.m_RecoveryDurationMinutes = 145;
						m.m_RepairDurationMinutes = 50;
						m.m_RepairRequiredGear = Utilities.MakeNeededItemList(BowRepair.softwood, BowRepair.scrapmetal);
						m.m_RepairRequiredGearUnits = gear_counts;
						switch (Settings.instance.BowMaterialNeed)
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
						m.m_RestoreRequiredGear = Utilities.MakeNeededItemList(BowRepair.softwood, BowRepair.scrapmetal);
						m.m_RestoreRequiredGearUnits = gear_counts;
						m.m_Skill = SkillType.Archery;
						break;
					}
				}
			}
            
			//DLC Only
			if (!Settings.instance.DLCEnable) return;
			//Sport Bow

	    if (__instance.name.ToLowerInvariant().Contains("gear_bow_manufactured"))
	    {
		    switch (Settings.instance.SportBowRepairMode)
		    {
			    case 0:
			    {
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

				    Repairable r = __instance.gameObject.AddComponent<Repairable>();
				    __instance.m_Repairable = r;
				    r.m_RepairToolChoices = Utilities.Tools();
				    r.m_DurationMinutes = 65;
				    r.m_ConditionIncrease = 35;
				    r.m_RequiredGear = Utilities.MakeNeededItemList(BowRepair.scraplead, BowRepair.scrapmetal);
				    r.m_RequiredGearUnits = gear_counts;
				    r.m_RequiresToolToRepair = true;
				    r.m_RepairAudio = "Play_CraftingGeneric";
				    break;
			    }
			    case 1:
			    {
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

				    Millable m = __instance.gameObject.AddComponent<Millable>();
				    __instance.m_Millable = m;
				    m.m_CanRestoreFromWornOut = true;
				    m.m_RecoveryDurationMinutes = 145;
				    m.m_RepairDurationMinutes = 50;
				    m.m_RepairRequiredGear = Utilities.MakeNeededItemList(BowRepair.scraplead, BowRepair.scrapmetal);
				    m.m_RepairRequiredGearUnits = gear_counts;
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
				    m.m_RestoreRequiredGear = Utilities.MakeNeededItemList(BowRepair.scraplead, BowRepair.scrapmetal);
				    m.m_RestoreRequiredGearUnits = gear_counts;
				    m.m_Skill = SkillType.Archery;
				    break;
			    }
			    case 2:
			    {
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
					
				    Repairable r = __instance.gameObject.AddComponent<Repairable>();
				    __instance.m_Repairable = r;
				    r.m_RepairToolChoices = Utilities.Tools();
				    r.m_DurationMinutes = 65;
				    r.m_ConditionIncrease = 35;
				    r.m_RequiredGear = Utilities.MakeNeededItemList(BowRepair.scraplead, BowRepair.scrapmetal);
				    r.m_RequiredGearUnits = gear_counts;
				    r.m_RequiresToolToRepair = true;
				    r.m_RepairAudio = "Play_CraftingGeneric";


				    Millable m = __instance.gameObject.AddComponent<Millable>();
				    __instance.m_Millable = m;
				    m.m_CanRestoreFromWornOut = true;
				    m.m_RecoveryDurationMinutes = 145;
				    m.m_RepairDurationMinutes = 50;
				    m.m_RepairRequiredGear = Utilities.MakeNeededItemList(BowRepair.scraplead, BowRepair.scrapmetal);
				    m.m_RepairRequiredGearUnits = gear_counts;
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
				    m.m_RestoreRequiredGear = Utilities.MakeNeededItemList(BowRepair.scraplead, BowRepair.scrapmetal);
				    m.m_RestoreRequiredGearUnits = gear_counts;
				    m.m_Skill = SkillType.Archery;
				    break;
			    }
		    }
	    }
				

	    //Woodwright Bow

	    if (__instance.name.ToLowerInvariant().Contains("gear_bow_woodwrights"))
	    {
		    switch (Settings.instance.WoodBowRepairMode)
		    {
			    case 0:
			    {
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
				    Repairable r = __instance.gameObject.AddComponent<Repairable>();
				    __instance.m_Repairable = r;
				    r.m_RepairToolChoices = Utilities.Tools();
				    r.m_DurationMinutes = 60;
				    r.m_ConditionIncrease = 35;
				    r.m_RequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    r.m_RequiredGearUnits = gear_counts;
				    r.m_RequiresToolToRepair = true;
				    r.m_RepairAudio = "Play_CraftingWood";
				    break;
			    }
			    case 1:
			    {
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

				    Millable m = __instance.gameObject.AddComponent<Millable>();
				    __instance.m_Millable = m;
				    m.m_CanRestoreFromWornOut = true;
				    m.m_RecoveryDurationMinutes = 115;
				    m.m_RepairDurationMinutes = 45;
				    m.m_RepairRequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    m.m_RepairRequiredGearUnits = gear_counts;
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
				    m.m_RestoreRequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    m.m_RestoreRequiredGearUnits = gear_counts;
				    m.m_Skill = SkillType.Archery;
				    break;
			    }
			    case 2:
			    {
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
				    Repairable r = __instance.gameObject.AddComponent<Repairable>();
				    __instance.m_Repairable = r;
				    r.m_RepairToolChoices = Utilities.Tools();
				    r.m_DurationMinutes = 60;
				    r.m_ConditionIncrease = 35;
				    r.m_RequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    r.m_RequiredGearUnits = gear_counts;
				    r.m_RequiresToolToRepair = true;
				    r.m_RepairAudio = "Play_CraftingWood";
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
				    Millable m = __instance.gameObject.AddComponent<Millable>();
				    __instance.m_Millable = m;
				    m.m_CanRestoreFromWornOut = true;
				    m.m_RecoveryDurationMinutes = 115;
				    m.m_RepairDurationMinutes = 45;
				    m.m_RepairRequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    m.m_RepairRequiredGearUnits = gear_counts;
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
				    m.m_RestoreRequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    m.m_RestoreRequiredGearUnits = gear_counts;
				    m.m_Skill = SkillType.Archery;
				    break;
			    }
		    }
	    }
	

	    //Bushcraft Bow

	    if (__instance.name.ToLowerInvariant().Contains("gear_bow_bushcraft"))
	    {
		    switch (Settings.instance.BushBowMaterialNeed)
		    {
			    case 0:
				    gear_counts = [1, 2];
				    break;
			    case 1:
				    gear_counts = [1, 3];
				    break;
			    case 2:
				    gear_counts = [2, 3];
				    break;
		    }

		    switch (Settings.instance.BushBowRepairMode)
		    {
			    case 0:
			    {
				    Repairable r = __instance.gameObject.AddComponent<Repairable>();
				    __instance.m_Repairable = r;
				    r.m_RepairToolChoices = Utilities.Tools();
				    r.m_DurationMinutes = 60;
				    r.m_ConditionIncrease = 40;
				    r.m_RequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.cloth);
				    r.m_RequiredGearUnits = gear_counts;
				    r.m_RequiresToolToRepair = true;
				    r.m_RepairAudio = "Play_CraftingWood";
				    break;
			    }
			    case 1:
			    {
				    switch (Settings.instance.BushBowMaterialNeed)
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

				    Millable m = __instance.gameObject.AddComponent<Millable>();
				    __instance.m_Millable = m;
				    m.m_CanRestoreFromWornOut = true;
				    m.m_RecoveryDurationMinutes = 60;
				    m.m_RepairDurationMinutes = 30;
				    m.m_RepairRequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    m.m_RepairRequiredGearUnits = gear_counts;
				    switch (Settings.instance.BushBowMaterialNeed)
				    {
					    case 0:
						    gear_counts = [1, 1];
						    break;
					    case 1:
						    gear_counts = [2, 1];
						    break;
					    case 2:
						    gear_counts = [3, 2];
						    break;
				    }
				    m.m_RestoreRequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    m.m_RestoreRequiredGearUnits = gear_counts;
				    m.m_Skill = SkillType.Archery;
				    break;
			    }
			    case 2:
			    {
				    switch (Settings.instance.BushBowMaterialNeed)
				    {
					    case 0:
						    gear_counts = [1, 2];
						    break;
					    case 1:
						    gear_counts = [1, 3];
						    break;
					    case 2:
						    gear_counts = [2, 3];
						    break;
				    }
				    Repairable r = __instance.gameObject.AddComponent<Repairable>();
				    __instance.m_Repairable = r;
				    r.m_RepairToolChoices = Utilities.Tools();
				    r.m_DurationMinutes = 60;
				    r.m_ConditionIncrease = 40;
				    r.m_RequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.cloth);
				    r.m_RequiredGearUnits = gear_counts;
				    r.m_RequiresToolToRepair = true;
				    r.m_RepairAudio = "Play_CraftingArrows";
                    
				    switch (Settings.instance.BushBowMaterialNeed)
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

				    Millable m = __instance.gameObject.AddComponent<Millable>();
				    __instance.m_Millable = m;
				    m.m_CanRestoreFromWornOut = true;
				    m.m_RecoveryDurationMinutes = 60;
				    m.m_RepairDurationMinutes = 30;
				    m.m_RepairRequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    m.m_RepairRequiredGearUnits = gear_counts;
				    switch (Settings.instance.BushBowMaterialNeed)
				    {
					    case 0:
						    gear_counts = [1, 1];
						    break;
					    case 1:
						    gear_counts = [2, 1];
						    break;
					    case 2:
						    gear_counts = [3, 2];
						    break;
				    }
				    m.m_RestoreRequiredGear = Utilities.MakeNeededItemList(BowRepair.hardwood, BowRepair.scrapmetal);
				    m.m_RestoreRequiredGearUnits = gear_counts;
				    m.m_Skill = SkillType.Archery;
				    break;
			    }
		    }
	    }





    }
}