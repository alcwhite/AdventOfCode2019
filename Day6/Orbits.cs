using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace orbit_counter
{
    public static class Orbits
    {
        public static Dictionary<string, string> OrbitDictionary(string mapFile)
        {
            string[] map = File.ReadAllLines(mapFile, Encoding.UTF8);
            var parsedMap = new Dictionary<string, string>();
            foreach (string orbit in map)
            {
                var splitOrbit = orbit.Split(')', 2);
                if (splitOrbit.Length == 2)
                    parsedMap.Add(splitOrbit[1], splitOrbit[0]);
            };
            return parsedMap;
        }
        public static int OrbitCount(this Dictionary<string, string> map, string moon)
        {
                int keyLinks = 0;
                while (moon != "COM")
                {
                    keyLinks++;
                    if (!map.TryGetValue(moon, out string newValue)) break;;
                    moon = newValue;
                }
            return keyLinks;
        }
        public static int OrbitCount(string mapFile)
        {
            var parsedMap = OrbitDictionary(mapFile);
            return parsedMap.Sum(kv => OrbitCount(parsedMap, kv.Key));
        }

        public static int YouToSantaCount(string mapFile)
        {
            int links = 0;
            var parsedMap = OrbitDictionary(mapFile);
            var youMap = new List<string>();
            var santaMap = new List<string>();
            string youValue = "YOU";
            string santaValue = "SAN";
                while (youValue != "COM")
                {
                    youMap.Add(youValue);
                    parsedMap.TryGetValue(youValue, out string newValue);
                    youValue = newValue;
                }
                while (santaValue != "COM" && !youMap.Contains(santaValue))
                {
                    santaMap.Add(santaValue);
                    parsedMap.TryGetValue(santaValue, out string newValue);
                    santaValue = newValue;
                }
            links = santaMap.Count + youMap.IndexOf(santaValue) - 2; 
            return links;
        }
    }
}