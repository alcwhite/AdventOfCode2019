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
        public static List<int> IntList(string input)
        {
            var stringList = input.Split(',').ToList();
            return stringList.Select(x => int.Parse(x.Trim())).ToList();
        }
        public static List<int> findResult(List<int> intList)
        {
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
            return intList;
        }
        public static int AlarmResultTest(string input)
        {
            var intList = IntList(input);
            var finalList = findResult(intList);
            return finalList[0];
        }
        public static int AlarmResult(string input)
        {
            var intList = IntList(input);
            intList[1] = 12;
            intList[2] = 2;
            var finalList = findResult(intList);
            return finalList[0];
        }
        public static (int result, int noun, int verb) LongResult(string input)
        {
            var intList = IntList(input);
            var newList = intList;
            var finalList = findResult(newList);
            for (var noun = newList[1]; newList[1] <= 99; newList[1]++)
            {
                
                for (var verb = newList[2]; newList[2] <= 99; newList[2]++)
                {
                    
                    finalList = findResult(newList); 
                    if (finalList[0] == 19690720) break;
                }
                if (finalList[0] == 19690720) break;
                finalList = findResult(newList);
            }
            
            return (result: finalList[0], noun: finalList[1], verb: finalList[2]);

        }
        public static int FinalOutput(string input)
        {
            var longResult = LongResult(input);
            return (100 * longResult.noun) + longResult.verb;
        }
    }
}