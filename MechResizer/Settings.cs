using System.Collections.Generic;
using UnityEngine;

namespace MechResizer
{
    // the properties in in here are to be a deserializer step from JSON format
    // into the C# variables used by the mod.
    public class Settings
    {
        #region mech

        private Vector3 DefaultMechSizeMultiplierVector3;
        public float defaultMechSizeMultiplier = -1f;
        public float DefaultMechSizeMultiplier
        {
            get => defaultMechSizeMultiplier;
            set
            {
                defaultMechSizeMultiplier = value;
                DefaultMechSizeMultiplierVector3 = new Vector3(value, value, value);
            }
        }

        public Dictionary<string, float[]> mechSizeMultipliers { private get; set; }
        public Vector3 MechSizeMultiplier(string mechIdentifier)
        {
            return mechSizeMultipliers.TryGetValue(mechIdentifier, out var t)
                ? new Vector3(t[0], t[1], t[2])
                : DefaultMechSizeMultiplierVector3;
        }

        #endregion

        
        #region vehicle

        private Vector3 DefaultVehicleSizeMultiplierVector3;
        public float defaultVehicleSizeMultiplier = -1f;
        public float DefaultVehicleSizeMultiplier
        {
            get => defaultVehicleSizeMultiplier;
            set
            {
                defaultVehicleSizeMultiplier = value;
                DefaultVehicleSizeMultiplierVector3 = new Vector3(value, value, value);
            }
        }

        public Dictionary<string, float[]> vehicleSizeMultipliers { private get; set; }
        public Vector3 VehicleSizeMultiplier(string vehicleIdentifier)
        {
            return vehicleSizeMultipliers.TryGetValue(vehicleIdentifier, out var t)
                ? new Vector3(t[0], t[1], t[2])
                : DefaultVehicleSizeMultiplierVector3;
        }

        #endregion
    }
}