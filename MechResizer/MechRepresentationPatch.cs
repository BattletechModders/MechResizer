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
            Mech mech,
            Transform parentTransform,
            bool isParented,
            MechRepresentation __instance)
        {
            Logger.Debug("mech size initialization");
            var identifier = mech.MechDef.ChassisID;
            var sizeMultiplier = SizeMultiplier.Get(mech.MechDef.Chassis);
            Logger.Debug($"{identifier}: {sizeMultiplier}");
            var originalLOSSourcePositions = Traverse.Create(mech).Field("originalLOSSourcePositions").GetValue<Vector3[]>();
            var originalLOSTargetPositions = Traverse.Create(mech).Field("originalLOSTargetPositions").GetValue<Vector3[]>();
            var newSourcePositions = ModSettings.LOSSourcePositions(identifier, originalLOSSourcePositions, sizeMultiplier);
            var newTargetPositions = ModSettings.LOSTargetPositions(identifier, originalLOSTargetPositions, sizeMultiplier);
            Traverse.Create(mech).Field("originalLOSSourcePositions").SetValue(newSourcePositions);
            Traverse.Create(mech).Field("originalLOSTargetPositions").SetValue(newTargetPositions);
            Traverse.Create(__instance.thisTransform).Property("localScale").SetValue(sizeMultiplier);
        }
    }
}