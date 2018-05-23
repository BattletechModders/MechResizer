using System.Collections.Generic;
using UnityEngine;

namespace MechResizer
{
    // the properties in in here are to be a deserializer step from JSON format
    // into the C# variables used by the mod.
    public class Settings
    {
        #region mech

        public float defaultMechSizeMultiplier = -1f;
        public float DefaultMechSizeMultiplier
        {
            get => defaultMechSizeMultiplier;
            set => defaultMechSizeMultiplier = value;
        }

        public Dictionary<string, float[]> mechSizeMultipliers { private get; set; }
        public Vector3 MechSizeMultiplier(string mechIdentifier)
        {
            return mechSizeMultipliers.TryGetValue(mechIdentifier, out var t)
                ? new Vector3(t[0], t[1], t[2])
                : new Vector3(defaultMechSizeMultiplier, defaultMechSizeMultiplier, defaultMechSizeMultiplier);
        }

        #endregion

        
        #region vehicle

        public float defaultVehicleSizeMultiplier = -1f;
        public float DefaultVehicleSizeMultiplier
        {
            get => DefaultVehicleSizeMultiplier;
            set => defaultVehicleSizeMultiplier = value;
        }

        public Dictionary<string, float[]> vehicleSizeMultipliers { private get; set; }
        public Vector3 VehicleSizeMultiplier(string vehicleIdentifier)
        {
            return vehicleSizeMultipliers.TryGetValue(vehicleIdentifier, out var t)
                ? new Vector3(t[0], t[1], t[2])
                : new Vector3(defaultVehicleSizeMultiplier, defaultVehicleSizeMultiplier, defaultVehicleSizeMultiplier);
        }

        #endregion
    }
}