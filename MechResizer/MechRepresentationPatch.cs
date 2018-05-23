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
}