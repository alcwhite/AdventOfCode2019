using System;
using System.Collections.Generic;
using System.Linq;

namespace alarm_puzzle
{
    public static class Alarm
    {
         static Dictionary<int, string> opCodes = new Dictionary<int, string>()
    {
        {1, "+"},
        {2, "*"},
        {99, "End"}
    };
        public static int AlarmResult(string input)
        {
            var stringList = input.Split(',').ToList();
            var intList = stringList.Select(x => int.Parse(x.Trim())).ToList();
            int currentOpCode = intList[0];
            int currentIndex = 0;
            while (opCodes.Keys.Contains(currentOpCode) && currentOpCode != 99)
            {
                opCodes.TryGetValue(currentOpCode, out string op);
                if (op == "End") break;
                var num1Loc = intList[currentIndex + 1];
                var num2Loc = intList[currentIndex + 2];
                var outputLoc = intList[currentIndex + 3];
                var num1 = intList[num1Loc];
                var num2 = intList[num2Loc];
                int output = 0;
                if (op == "+") 
                    output = num1 + num2;
                if (op == "*")
                    output = num1 * num2;

                intList[outputLoc] = output;
                currentIndex += 4;
                currentOpCode = intList[currentIndex];
            }
            string result = string.Join(",", intList.Select(x => x.ToString()).ToArray());
            return intList[0];
        }
    }
}