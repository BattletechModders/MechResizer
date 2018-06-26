using BattleTech;
using Harmony;
using UnityEngine;
using static MechResizer.MechResizer;

namespace MechResizer
{
    [HarmonyPatch(typeof(TurretRepresentation), "Init", new[] {typeof(Turret), typeof(Transform), typeof(bool)})]
    public static class TurretRepresentationInitPatch
    {
        static void Postfix(
            Turret turret,
            Transform parentTransform,
            bool isParented,
            TurretRepresentation __instance)
        {
            Logger.Debug("turret size initialization");
            if (ModSettings.DefaultTurretSizeMultiplier == -1f)
            {
                var settingFromJSON = turret.Combat.Constants.CombatValueMultipliers.TEST_MechScaleMultiplier;
                ModSettings.DefaultTurretSizeMultiplier = settingFromJSON;
                Logger.Debug($"loaded default size for turret: {settingFromJSON}");
            }
            var identifier = turret.TurretDef.ChassisID;
            var sizeMultiplier = ModSettings.VehicleSizeMultiplier(identifier);
            Logger.Debug($"{identifier}: {sizeMultiplier}");
            var originalLOSSourcePositions = Traverse.Create(turret).Field("originalLOSSourcePositions").GetValue<Vector3[]>();
            var originalLOSTargetPositions = Traverse.Create(turret).Field("originalLOSTargetPositions").GetValue<Vector3[]>();
            var newSourcePositions = ModSettings.LOSSourcePositions(identifier, originalLOSSourcePositions, sizeMultiplier);
            var newTargetPositions = ModSettings.LOSTargetPositions(identifier, originalLOSTargetPositions, sizeMultiplier);
            Traverse.Create(turret).Field("originalLOSSourcePositions").SetValue(newSourcePositions);
            Traverse.Create(turret).Field("originalLOSTargetPositions").SetValue(newTargetPositions);
            Traverse.Create(__instance.thisTransform).Property("localScale").SetValue(sizeMultiplier);
        }
    }
}