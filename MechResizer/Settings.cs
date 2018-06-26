using System.Collections.Generic;
using System.Text;
using BattleTech;
using Harmony;
using UnityEngine;

namespace MechResizer
{
    // the properties in in here are to be a deserializer step from JSON format
    // into the C# variables used by the mod.
    public class Settings
    {
        public Settings()
        {
            losSourcePositions = new Dictionary<string, Vector3[]>();
            losTargetPositions = new Dictionary<string, Vector3[]>();
        }

        #region LOS settings
        public Dictionary<string, Vector3[]> losSourcePositions { private get; set; }

        public Vector3[] LOSSourcePositions(string identifier, Vector3[] originalSourcePositions, Vector3 scaleFactor)
        {
            if (losSourcePositions.ContainsKey(identifier))
            {
                return losSourcePositions[identifier];
            }
            var newSourcePositions = new Vector3[originalSourcePositions.Length];
            StringBuilder foo = new StringBuilder();
            foo.AppendLine($"SourcePositions\nid: {identifier}");
            for (var i = 0; i < originalSourcePositions.Length; i++)
            {
                newSourcePositions[i] = Vector3.Scale(originalSourcePositions[i], scaleFactor);
                foo.AppendLine(
                    $"{i} orig: [{originalSourcePositions[i].x},{originalSourcePositions[i].y},{originalSourcePositions[i].z}] | scaled: [{newSourcePositions[i].x},{newSourcePositions[i].y},{newSourcePositions[i].z}]");
            }
            Logger.Debug(foo.ToString());
            losSourcePositions[identifier] = newSourcePositions;
            return losSourcePositions[identifier];
        }

        public Dictionary<string, Vector3[]> losTargetPositions { private get; set; }
        public Vector3[] LOSTargetPositions(string identifier, Vector3[] originalTargetPositions, Vector3 scaleFactor)
        {
            if (losTargetPositions.ContainsKey(identifier))
            {
                return losTargetPositions[identifier];
            }
            StringBuilder foo = new StringBuilder();
            foo.AppendLine($"TargetPositions\nid: {identifier}");
            var newTargetPositions = new Vector3[originalTargetPositions.Length];
            for (var i = 0; i < originalTargetPositions.Length; i++)
            {
                newTargetPositions[i] = Vector3.Scale(originalTargetPositions[i], scaleFactor);
                foo.AppendLine(
                    $"{i} orig: [{originalTargetPositions[i].x},{originalTargetPositions[i].y},{originalTargetPositions[i].z}] | scaled: [{newTargetPositions[i].x},{newTargetPositions[i].y},{newTargetPositions[i].z}]");
            }
            Logger.Debug(foo.ToString());
            losTargetPositions[identifier] = newTargetPositions;
            return losTargetPositions[identifier];
        }
        #endregion

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
        
        #region turret settings
        public float defaultTurretSizeMultiplier = -1f;
        public float DefaultTurretSizeMultiplier
        {
            set => defaultTurretSizeMultiplier = value;
            get => defaultTurretSizeMultiplier;
        }

        public Dictionary<string, float> turretSizeMultipliers { private get; set; }
        public Dictionary<string, Vector3> turretSizeMultiplierVectors { private get; set; }
        public Vector3 TurretSizeMultiplier(string turretIdentifier)
        {
            return turretSizeMultiplierVectors.TryGetValue(turretIdentifier, out var mVector) ? mVector :
                turretSizeMultipliers.TryGetValue(turretIdentifier, out var mSimple) ? new Vector3(mSimple, mSimple, mSimple) :
                new Vector3(defaultTurretSizeMultiplier, defaultTurretSizeMultiplier, defaultTurretSizeMultiplier);
        }
        #endregion

        #region projectile settings
        public float defaultProjectileSizeMultiplier = -1f;
        public float DefaultProjectileSizeMultiplier
        {
            set => defaultProjectileSizeMultiplier = value;
            get => defaultProjectileSizeMultiplier;
        }

        public Dictionary<string, float> projectileSizeMultipliers { private get; set; }
        public Dictionary<string, Vector3> projectileSizeMultiplierVectors { private get; set; }
        public Vector3 ProjectileSizeMultiplier(string firingWeaponIdentifier)
        {
            return projectileSizeMultiplierVectors.TryGetValue(firingWeaponIdentifier, out var mVector) ? mVector :
                projectileSizeMultipliers.TryGetValue(firingWeaponIdentifier, out var mSimple) ? new Vector3(mSimple, mSimple, mSimple) :
                new Vector3(defaultProjectileSizeMultiplier, defaultProjectileSizeMultiplier, defaultProjectileSizeMultiplier);
        }
        #endregion

        #region debug settings
        public bool debug = false;
        #endregion
    }
}