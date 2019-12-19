using System;
using System.Collections.Generic;
using System.Linq;

namespace wire_sorting
{
    public static class Wires
    {
        public static List<(int x, int y, int steps)> Locations(List<string> wire)
        {
            var locations = new List<(int x, int y, int steps)>();
            var start = (x: 0, y: 0, steps: 0);
            foreach (string path in wire)
            {
                int i = 0;
                var direction = path.Substring(0, 1);
                var number = int.Parse(path.Substring(1));
                if (direction == "U")
                {    i = 0;
                    while (i < number)
                    {
                        start.y++;
                        start.steps++;
                        locations.Add(start);
                        i++;
                    }
                }
                if (direction == "D")
                {
                    i = 0;
                    while (i < number)
                    {
                        start.y--;
                        start.steps++;
                        locations.Add(start);
                        i++;
                    }
                }
                if (direction == "R")
                {
                    i = 0;
                    while (i < number)
                    {
                        start.x++;
                        start.steps++;
                        locations.Add(start);
                        i++;
                    }
                }
                if (direction == "L")
                {
                    i = 0;
                    while (i < number)
                    {
                        start.x--;
                        start.steps++;
                        locations.Add(start);
                        i++;
                    } 
                }  
            }    
            return locations;   
        }
        public static (List<(int x, int y, int steps)> locations1, List<(int x, int y, int steps)> locations2) AllLocations(List<string> listInput)
        {
            var wire1 = listInput[0].Split(',').ToList();
            var wire2 = listInput[1].Split(',').ToList();
            var locations1 = Locations(wire1);
            var locations2 = Locations(wire2);
            return (locations1: locations1, locations2: locations2);
        }
        public static List<(int x, int y, int steps)> Intersections(List<string> input)
        {
            var allLocations = AllLocations(input);
            var wire2Intersections = allLocations.locations2.Where(stop => allLocations.locations1.Exists(otherStop => stop.x == otherStop.x && stop.y == otherStop.y)).ToList();
            var intersectingLocations = allLocations.locations1.Where(stop => allLocations.locations2.Exists(otherStop => stop.x == otherStop.x && stop.y == otherStop.y)).ToList();
            return intersectingLocations.Select(x => (x: x.x, y: x.y, steps: x.steps + wire2Intersections.Where(y => x.x == y.x && x.y == y.y).ToList()[0].steps)).ToList();
        }
        public static List<int> ManhattanDistance(List<string> input)
        {
            var intersections = Intersections(input);
            return intersections.Select(x => Math.Abs(x.x) + Math.Abs(x.y)).ToList();
        }
        public static int MinDistance(List<string> input)
        {
            var distances = ManhattanDistance(input);
            return distances.Min();
        }
        public static int Steps(List<string> input)
        {
            var allDistances = ManhattanDistance(input);
            var allLocations = AllLocations(input);
            var intersections = Intersections(input);
            var intersectionSteps = new List<int>();
            foreach((int x, int y, int steps) stop in intersections)
            {
                intersectionSteps.Add(stop.steps);
            }

            return intersectionSteps.Min();
        }

    }
}