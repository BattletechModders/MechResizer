using System;
using System.Globalization;
using HBS.Collections;
using UnityEngine;

namespace MechResizer
{
    static class TagUnderstander
    {
        public static bool ReadSizeFromTags(TagSet tags, out Vector3? size, out string rawTag)
        {
            size = null;
            rawTag = null;
            try
            {
                rawTag = FindSizeTag(tags);
                if (string.IsNullOrEmpty(rawTag)) return false;

                var parts = rawTag.Split('-');

                // for tags of style 'MR-Resize-N`
                if (parts.Length == 3)
                {
                    var resizeNumber = float.Parse(parts[2]);
                    size = new Vector3(resizeNumber, resizeNumber, resizeNumber);
                    Logger.Debug($"size from singular tag: [{size.Value.x},{size.Value.y},{size.Value.z}]");
                    return true;
                }

                // for tags of style 'MR-Resize-X-Y-Z`
                if (parts.Length == 5)
                {
                    var resizeX = float.Parse(parts[2]);
                    var resizeY = float.Parse(parts[3]);
                    var resizeZ = float.Parse(parts[4]);
                    size = new Vector3(resizeX, resizeY, resizeZ);
                    Logger.Debug($"size from multi-tag: [{size.Value.x},{size.Value.y},{size.Value.z}]");
                    return true;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e);
            }

            return false;
        }

        private static string FindSizeTag(TagSet tags)
        {
            if (tags == null || tags.Count == 0)
            {
                Logger.Debug("Found no tags");
                return null;
            }
            foreach (var t in tags)
            {
                if (!t.StartsWith("MR-Resize-", ignoreCase: true, culture: CultureInfo.InvariantCulture)) continue;
                Logger.Debug($"found a tag in for loop: {t}");
                return t;
            }

            return null;
        }
    }
}