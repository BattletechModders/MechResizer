﻿using System;
using System.IO;

namespace MechResizer
{
    public class Logger
    {
        public static void Error(Exception ex)
        {
            var filePath = $"{MechResizer.ModDirectory}/MechResizer.log";
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Message: {ex.Message}");
                writer.WriteLine($"StackTrace: {ex.StackTrace}");
                WriteLogFooter(writer);
            }
        }

        public static void Debug(String line)
        {
            if (!MechResizer.ModSettings.debug) { return; }
            var filePath = $"{MechResizer.ModDirectory}/MechResizer.log";
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(line);
                WriteLogFooter(writer);
            }
        }

        private static void WriteLogFooter(StreamWriter writer)
        {
            writer.WriteLine($"Date: {DateTime.Now}");
            writer.WriteLine(new string(c: '-', count: 50));
        }
    }
}