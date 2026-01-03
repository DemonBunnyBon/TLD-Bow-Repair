
using UnityEngine.AddressableAssets;

namespace BowRepairMod
{
	public class BowRepair: MelonMod
	{
		public static ToolsItem simpletools;
		public static ToolsItem qualitytools;
		public static GearItem driedgut;
		public static GearItem scrapmetal;
		public static GearItem scraplead;
		public static GearItem softwood;
		public static GearItem hardwood;
		public static GearItem cloth;
		private static bool initialized = false;
		
		
		public override void OnInitializeMelon()
		{
			Settings.instance.AddToModSettings("Bow Repair");
			Settings.OnLoad();
		}

		public override void OnSceneWasInitialized(int buildIndex, string sceneName)
		{
			if (!initialized)
			{
				LoadItems();
				initialized = true;
			}
		}


		static void LoadItems()
		{
			simpletools = Addressables.LoadAssetAsync<GameObject>("GEAR_SimpleTools").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem;
			qualitytools = Addressables.LoadAssetAsync<GameObject>("GEAR_HighQualityTools").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem;
			driedgut = Addressables.LoadAssetAsync<GameObject>("GEAR_GutDried").WaitForCompletion().GetComponent<GearItem>();
			scrapmetal = Addressables.LoadAssetAsync<GameObject>("GEAR_ScrapMetal").WaitForCompletion().GetComponent<GearItem>();
			scraplead = Addressables.LoadAssetAsync<GameObject>("GEAR_ScrapLead").WaitForCompletion().GetComponent<GearItem>();
			softwood = Addressables.LoadAssetAsync<GameObject>("GEAR_Softwood").WaitForCompletion().GetComponent<GearItem>();
			hardwood = Addressables.LoadAssetAsync<GameObject>("GEAR_Hardwood").WaitForCompletion().GetComponent<GearItem>();
			cloth = Addressables.LoadAssetAsync<GameObject>("GEAR_Cloth").WaitForCompletion().GetComponent<GearItem>();
		}
	}
}