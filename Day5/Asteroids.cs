using System;
using System.Collections.Generic;
using System.Linq;

namespace asteroid_puzzle
{
    public static class Asteroid
    {
        static Dictionary<int, string> opCodes = new Dictionary<int, string>()
        {
            {1, "+"},
            {2, "*"},
            {3, "save"},
            {4, "output"},
            {99, "End"}
        };
        static Dictionary<int, string> modes = new Dictionary<int, string>()
        {
            {1, "immediate"},
            {0, "position"}
        };
        public static List<int> IntList(string input)
        {
            var stringList = input.Split(',').ToList();
            return stringList.Select(x => int.Parse(x.Trim())).ToList();
        }
        public static int OpCode(string inputCodeString)
        {
            List<char> opCodeStringList = inputCodeString.ToList();
            int stringListCount = opCodeStringList.Count;
            string currentOpCodeString;
            if (stringListCount == 1) 
                currentOpCodeString = opCodeStringList[0].ToString();
            else 
                currentOpCodeString = inputCodeString.Substring(stringListCount - 2);

            return int.Parse(currentOpCodeString);
        }
        public static List<int> ParamTypes(string inputCodeString)
        {
            var inputList = inputCodeString.ToList();
            var resultList = new List<int>();
            var index = inputList.Count - 1;
            if (index > 0)
            {
                while (index > 0)
                {
                    resultList.Add(int.Parse(inputList[index].ToString()));
                }
            }
            return resultList;
        }
        public static List<int> FindResult(List<int> intList)
        {
            int inputNum = 1;
            int currentOpCode = OpCode(intList[0].ToString());
            List<int> parameterTypes = ParamTypes(intList[0].ToString());
            while (opCodes.Keys.Contains(currentOpCode))
            {
                int currentIndex = 0;
                opCodes.TryGetValue(currentOpCode, out string op);
                if (op == "End" || op == null) break;
                int num1Loc = intList[currentIndex + 1];
                int num2Loc = intList[currentIndex + 2];
                int outputLoc;
                int num1;
                int num2;
                if (parameterTypes.Count == 0)
                    parameterTypes.Add(0);
                if (parameterTypes.Count == 1)
                    parameterTypes.Add(0);
                if (parameterTypes[0] == 0)
                    num1 = intList[num1Loc];
                else
                    num1 = num1Loc;
                if (parameterTypes[1] == 1)
                    num2 = intList[num2Loc];
                else
                    num2 = num2Loc;
                int parameters = 1;
                int output = 0;
                if (op == "+") 
                    output = num1 + num2;
                    outputLoc = intList[currentIndex + 3];
                    parameters = 4;
                    intList[outputLoc] = output;
                if (op == "*")
                    output = num1 * num2;
                    outputLoc = intList[currentIndex + 3];
                    parameters = 4;
                    intList[outputLoc] = output;
                if (op == "save")
                    output = inputNum;
                    outputLoc = intList[currentIndex + 1];
                    parameters = 2;
                    intList[outputLoc] = output;
                if (op == "output")
                    output = num1;
                    parameters = 2;
                    Console.WriteLine(output);

                currentIndex += parameters;
                currentOpCode = OpCode(intList[currentIndex].ToString());
                parameterTypes = ParamTypes(intList[currentIndex].ToString());
            }
            return intList;
        }
        public static int AlarmResultTest(string input)
        {
            var intList = IntList(input);
            var finalList = FindResult(intList);
            return finalList[0];
        }
        public static int AlarmResult(string input)
        {
            var intList = IntList(input);
            intList[1] = 12;
            intList[2] = 2;
            var finalList = FindResult(intList);
            return finalList[0];
        }
        public static (int result, int noun, int verb) LongResult(string input)
        {
            var newList = IntList(input);
            var finalList = FindResult(newList);
            var noun = newList[1];
            var verb = newList[2];
            while (noun < 99)
            {
                bool reset = true;
                while (verb < 99)
                {
                    if (!reset)
                        verb = newList[2] + 1;
                        reset = false;
                    newList = IntList(input);
                    newList[1] = noun;
                    newList[2] = verb;
                    finalList = FindResult(newList);
                    if (finalList[0] == 19690720) break;
                }
                if (finalList[0] == 19690720) break;
                noun = newList[1] + 1;
                reset = true;
                verb = 0;   
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