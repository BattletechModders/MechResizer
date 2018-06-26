using BattleTech;
using Harmony;
using UnityEngine;
using static MechResizer.MechResizer;

namespace MechResizer
{
    [HarmonyPatch(typeof(VehicleRepresentation), "Init", new[] {typeof(Vehicle), typeof(Transform), typeof(bool)})]
    public static class GameRepresentationInitPatch
    {
        static void Postfix(
            Vehicle vehicle,
            Transform parentTransform,
            bool isParented,
            VehicleRepresentation __instance)
        {
            Logger.Debug("vehicle size initialization ");
            if (ModSettings.DefaultVehicleSizeMultiplier == -1f)
            {
                var settingFromJSON = vehicle.Combat.Constants.CombatValueMultipliers.TEST_MechScaleMultiplier;
                ModSettings.DefaultVehicleSizeMultiplier = settingFromJSON;
                Logger.Debug($"loaded default size for vehicle: {settingFromJSON}");
            }
            var identifier = vehicle.VehicleDef.ChassisID;
            var sizeMultiplier = ModSettings.VehicleSizeMultiplier(identifier);
            Logger.Debug($"{identifier}: {sizeMultiplier}");
            var originalLOSSourcePositions = Traverse.Create(vehicle).Field("originalLOSSourcePositions").GetValue<Vector3[]>();
            var originalLOSTargetPositions = Traverse.Create(vehicle).Field("originalLOSTargetPositions").GetValue<Vector3[]>();
            var newSourcePositions = ModSettings.LOSSourcePositions(identifier, originalLOSSourcePositions, sizeMultiplier);
            var newTargetPositions = ModSettings.LOSTargetPositions(identifier, originalLOSTargetPositions, sizeMultiplier);
            Traverse.Create(vehicle).Field("originalLOSSourcePositions").SetValue(newSourcePositions);
            Traverse.Create(vehicle).Field("originalLOSTargetPositions").SetValue(newTargetPositions);
            Traverse.Create(__instance.thisTransform).Property("localScale").SetValue(sizeMultiplier);
        }
    }
}