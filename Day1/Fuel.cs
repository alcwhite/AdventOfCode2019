using System;
using System.Collections.Generic;
using System.Linq;

namespace rocket_equations
{
    public static class Rocket
    {
        public static IEnumerable<double> MassAsDouble(string[] massInput)
        {
            return massInput.ToList().Select(x => {
                double.TryParse(x, out double i); 
                return i;});

        }
        public static double FuelReqs(double massInput)
        {
            return Math.Floor(massInput / 3) - 2;
        }
        public static double FuelReqs(string[] massInput)
        {
            IEnumerable<double> massAsDouble = MassAsDouble(massInput);

            return massAsDouble.Sum(x => FuelReqs(x));
        }
        public static double FuelFuelReqs(double massInput)
        {
            double reqs = 0;
            var fuelReqs = FuelReqs(massInput);
            while (fuelReqs > 0) {
                reqs += fuelReqs;
                var lastFuelReqs = fuelReqs; 
                fuelReqs = FuelReqs(lastFuelReqs);
            }
            return reqs;
        }
        public static double FuelFuelReqs(string[] massInput)
        {
            var massAsDouble = MassAsDouble(massInput);
            double reqs = 0;
            foreach (double mass in massAsDouble)
            {
                var thisReq = FuelFuelReqs(mass);
                reqs += thisReq;
            }
            return reqs;
        }
        public static double FullReqs(double massInput)
        {
            var fuelReqs = FuelReqs(massInput);
            return fuelReqs + FuelFuelReqs(fuelReqs);
        }
        public static double FullReqs(string[] massInput)
        {
            double fuelFuelReqs = 0;
            var massAsDouble = MassAsDouble(massInput);
            foreach (double mass in massAsDouble) 
            {
                var fuelReqs = FuelReqs(mass);
                var thisReq = FuelFuelReqs(fuelReqs);
                fuelFuelReqs += thisReq + fuelReqs;
            }
            return  fuelFuelReqs;   
        }
    }
}