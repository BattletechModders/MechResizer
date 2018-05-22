using System.Collections.Generic;
using BattleTech;

namespace MechResizer
{
    // the properties in in here are to be a deserializer step from JSON format
    // into the C# variables used by the mod.
    public class Settings
    {

        public float defaultMechSizeMultiplier = -1f;
        public float DefaultMechSizeMultiplier { set => defaultMechSizeMultiplier = value; }

        public Dictionary<string, float> mechSizeMultipliers { private get; set; }
        public float MechSizeMultiplier(string mechIdentifier)
        {
            return mechSizeMultipliers.TryGetValue(mechIdentifier, out var t) ? t : defaultMechSizeMultiplier;
        }
        
    }
}