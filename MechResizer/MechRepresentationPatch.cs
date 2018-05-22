using BattleTech;
using Harmony;
using UnityEngine;
using static MechResizer.MechResizer;

namespace MechResizer
{
    [HarmonyPatch(typeof(MechRepresentation), "Init", new[] { typeof(Mech), typeof(Transform), typeof(bool) })]
    public static class MechRepresentationInitPatch
    {        
        static bool Prefix(
            ref Mech mech,
            ref Transform parentTransform,
            ref bool isParented,
            MechRepresentation __instance)
        {
            if (ModSettings.defaultMechSizeMultiplier == -1f)
            {
                ModSettings.DefaultMechSizeMultiplier =
                    mech.Combat.Constants.CombatValueMultipliers.TEST_MechScaleMultiplier;
            }            
            var mechScaleMultiplier = ModSettings.MechSizeMultiplier(mech.MechDef.ChassisID);
            var cvm = mech.Combat.Constants.CombatValueMultipliers;
            cvm.TEST_MechScaleMultiplier = mechScaleMultiplier;
            Traverse.Create(mech.Combat.Constants).Property("CombatValueMultipliers").SetValue(cvm);
            return true;
        }
    }
}