using BattleTech;
using Harmony;
using UnityEngine;
using static MechResizer.MechResizer;

namespace MechResizer
{
    [HarmonyPatch(typeof(AbstractActor), "GetLOSSourcePositions")]
    public static class AbstractActor_GetLOSSourcePositions_Patch
    {
        static bool Prefix(Vector3 Position, Quaternion rotation, AbstractActor __instance, Vector3[] __result)
        {
            var original = Traverse.Create(__instance).Field("originalLOSSourcePositions").GetValue<Vector3[]>();
            __result = new Vector3[original.Length];
            var scale = new Vector3(1f, 1f, 1f);
            switch (__instance)
            {
                case Mech mech:
                    scale = ModSettings.MechSizeMultiplier(mech.MechDef.ChassisID);
                    break;
                case Vehicle vehicle:
                    scale = ModSettings.VehicleSizeMultiplier(vehicle.VehicleDef.ChassisID);
                    break;
                // else turret?
            }
            for (var i = 0; i < original.Length; i++)
            {
                var scaled = Vector3.Scale(original[i], scale);
                __result[i] = rotation * scaled + Position;
            }
            return false;
        }
    }
    
    [HarmonyPatch(typeof(AbstractActor), "GetLOSTargetPositions")]
    public static class AbstractActor_GetLOSTargetPositions_Patch
    {
        static bool Prefix(Vector3 Position, Quaternion rotation, AbstractActor __instance, Vector3[] __result)
        {
            var original = Traverse.Create(__instance).Field("originalLOSTargetPositions").GetValue<Vector3[]>();
            __result = new Vector3[original.Length];
            var scale = new Vector3(1f, 1f, 1f);
            switch (__instance)
            {
                case Mech mech:
                    scale = ModSettings.MechSizeMultiplier(mech.MechDef.ChassisID);
                    break;
                case Vehicle vehicle:
                    scale = ModSettings.VehicleSizeMultiplier(vehicle.VehicleDef.ChassisID);
                    break;
                // else turret?
            }
            for (var i = 0; i < original.Length; i++)
            {
                var scaled = Vector3.Scale(original[i], scale);
                __result[i] = rotation * scaled + Position;
            }
            return false;
        }
    }
}

//class Original
//{
//    public Vector3[] GetLOSSourcePositions(Vector3 position, Quaternion rotation)
//    {
//        Vector3[] array = new Vector3[this.originalLOSSourcePositions.Length];
//        for (int i = 0; i < this.originalLOSSourcePositions.Length; i++)
//        {
//            array[i] = rotation * this.originalLOSSourcePositions[i] + position;
//        }
//
//        return array;
//    }
//
//
//    public Vector3[] GetLOSTargetPositions(Vector3 position, Quaternion rotation)
//    {
//        Vector3[] array = new Vector3[this.originalLOSTargetPositions.Length];
//        for (int i = 0; i < this.originalLOSTargetPositions.Length; i++)
//        {
//            array[i] = rotation * this.originalLOSTargetPositions[i] + position;
//        }
//
//        return array;
//    }
//}