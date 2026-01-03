
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using UnityEngine.AddressableAssets;

namespace BowRepairMod
{
    internal static class Utilities
    {
        public static Il2CppReferenceArray<GearItem> MakeNeededItemList(GearItem first_item, GearItem second_item)
        {
            GearItem[] list = [first_item,second_item];
            return list;
        }
        public static Il2CppReferenceArray<ToolsItem> Tools()
        {
            ToolsItem[] list = [Addressables.LoadAssetAsync<GameObject>("GEAR_SimpleTools").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem, Addressables.LoadAssetAsync<GameObject>("GEAR_HighQualityTools").WaitForCompletion().GetComponent<GearItem>().m_ToolsItem];
            return list;
        }
    }






}


