using BattleTech;
using Harmony;
using UnityEngine;
using static MechResizer.MechResizer;

namespace MechResizer
{
    [HarmonyPatch(typeof(MechRepresentation), "Init", new[] {typeof(Mech), typeof(Transform), typeof(bool)})]
    public static class MechRepresentationInitPatch
    {
        static void Postfix(
            ref Mech mech,
            ref Transform parentTransform,
            ref bool isParented,
            MechRepresentation __instance)
        {
            if (ModSettings.DefaultMechSizeMultiplier == -1f)
            {
                var settingFromJSON = mech.Combat.Constants.CombatValueMultipliers.TEST_MechScaleMultiplier;
                ModSettings.DefaultMechSizeMultiplier = settingFromJSON;
            }

            Vector3 mechSizeMultiplier = ModSettings.MechSizeMultiplier(mech.MechDef.ChassisID);
            Traverse.Create(__instance.thisTransform).Property("localScale").SetValue(mechSizeMultiplier);
        }
    }

//    [HarmonyPatch(typeof(CameraControl), "ForceMovingToGroundPos")]
//    public static class CameraControl_ForceMovingToGroundPos_Patch
//    {
//        public static bool Prefix(ref Vector3 i_dest, ref float screenRatio, CameraControl __instance)
//        {
//            var magicThis = Traverse.Create(__instance);
//            var cameraState = magicThis.Field("state").GetValue <CameraControl.CameraState>();
//            if (cameraState != CameraControl.CameraState.PlayerControlled) return false;
//            magicThis.Field("smoothToGroundRatio").SetValue(screenRatio);
//            i_dest.y = magicThis.Field("Combat").GetValue<CombatGameState>().MapMetaData.GetCellAt(i_dest).height;
//            magicThis.Field("isMovingToGroundPos").SetValue(true);
//            magicThis.Field("smoothToGroundPosDest").SetValue(i_dest);
//            var newSmoothToGroundPosCamDest = 
//                i_dest - 
//                magicThis.Field("cTrans").GetValue<Transform>().forward * 
//                ((magicThis.Field("MinHeightAboveTerrain").GetValue<float>() + 
//                  magicThis.Field("MaxHeightAboveTerrain").GetValue<float>()) * 0.8f);
//            magicThis.Field("smoothToGroundPosCamDest").SetValue(newSmoothToGroundPosCamDest);
//            return false;
//        }
//    }
    
//    [HarmonyPatch(typeof(SimGameState), "SetExpenditureLevel")]
//    public static class Adjust_Techs_Financial_Report_Patch
//    {
//        public static void Postfix(EconomyScale value, bool updateMorale, SimGameState __instance)
//        {
//            {
//                Logger.Debug($"we doin it!\n{value}\n{updateMorale}");
//                int valuee = __instance.CompanyStats.GetValue<int>("ExpenseLevel");
//                Logger.Debug($"valuee {valuee}");
//                if (valuee < 0)
//                {
//                    valuee = valuee * 2;
//                }
//                int num = valuee * 1000;
//                int num2 = valuee;
//                Logger.Debug($"valuee {valuee}\nnum2: {num2}");
//                __instance.CompanyStats.ModifyStat<int>("SimGame", 0, "MechTechSkill", StatCollection.StatOperation.Set, 25, -1, true);
//                __instance.CompanyStats.ModifyStat<int>("SimGame", 0, "MedTechSkill", StatCollection.StatOperation.Int_Add, 25, -1, true);
//            }
//
//        }
//    }
}

//        // Token: 0x06004ED4 RID: 20180 RVA: 0x001B5364 File Offset: 0x001B3764
//        public void ForceMovingToGroundPos(Vector3 i_dest, float screenRatio = 0.95f)
//        {
//            if (this.state == CameraControl.CameraState.PlayerControlled)
//            {
//                this.smoothToGroundRatio = screenRatio;
//                i_dest.y = this.Combat.MapMetaData.GetCellAt(i_dest).height;
//                this.isMovingToGroundPos = true;
//                this.smoothToGroundPosDest = i_dest;
//                this.smoothToGroundPosCamDest = i_dest - this.cTrans.forward *
//                                                ((this.MinHeightAboveTerrain + this.MaxHeightAboveTerrain) * 0.8f);
//            }
//}