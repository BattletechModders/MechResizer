using System.Collections.Generic;
using UnityEngine;

namespace MechResizer
{
    // the properties in in here are to be a deserializer step from JSON format
    // into the C# variables used by the mod.
    public class Settings
    {
        #region mech settings
        public float defaultMechSizeMultiplier = -1f;
        public float DefaultMechSizeMultiplier { 
            set => defaultMechSizeMultiplier = value;
            get => defaultMechSizeMultiplier;
        }

        public Dictionary<string, float> mechSizeMultipliers { private get; set; }
        public Dictionary<string, Vector3> mechSizeMultiplierVectors { private get; set; }
        public Vector3 MechSizeMultiplier(string mechIdentifier)
        {
            return mechSizeMultiplierVectors.TryGetValue(mechIdentifier, out var mVector) ? mVector :
                mechSizeMultipliers.TryGetValue(mechIdentifier, out var mSimple) ? new Vector3(mSimple, mSimple, mSimple) :
                new Vector3(defaultMechSizeMultiplier, defaultMechSizeMultiplier, defaultMechSizeMultiplier);
        }
        #endregion
        
        #region vehicle settings
        public float defaultVehicleSizeMultiplier = -1f;
        public float DefaultVehicleSizeMultiplier
        {
            set => defaultVehicleSizeMultiplier = value;
            get => defaultVehicleSizeMultiplier;
        }

        public Dictionary<string, float> vehicleSizeMultipliers { private get; set; }
        public Dictionary<string, Vector3> vehicleSizeMultiplierVectors { private get; set; }
        public Vector3 VehicleSizeMultiplier(string vehicleIdentifier)
        {
            return vehicleSizeMultiplierVectors.TryGetValue(vehicleIdentifier, out var mVector) ? mVector :
                vehicleSizeMultipliers.TryGetValue(vehicleIdentifier, out var mSimple) ? new Vector3(mSimple, mSimple, mSimple) :
                new Vector3(defaultVehicleSizeMultiplier, defaultVehicleSizeMultiplier, defaultVehicleSizeMultiplier);
        }
        #endregion
    }
}