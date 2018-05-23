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
            ref Vehicle vehicle,
            ref Transform parentTransform,
            ref bool isParented,
            VehicleRepresentation __instance)
        {
            if (ModSettings.DefaultVehicleSizeMultiplier == -1f)
            {
                var settingFromJSON = vehicle.Combat.Constants.CombatValueMultipliers.TEST_MechScaleMultiplier;
                ModSettings.DefaultVehicleSizeMultiplier = settingFromJSON;
            }
            Vector3 vehicleSizeMultiplier = ModSettings.VehicleSizeMultiplier(vehicle.VehicleDef.ChassisID);
            Traverse.Create(__instance.thisTransform).Property("localScale").SetValue(vehicleSizeMultiplier);
        }
    }
}