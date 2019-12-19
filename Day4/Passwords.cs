using System;
using System.Collections.Generic;
using System.Linq;

namespace password_puzzle
{
    public static class Passwords
    {
        public static bool PasswordPasses(int password)
        {
            var doubleNums = false;
            var decrease = false;
            var passwordString = password.ToString();
            var passwordList = passwordString.ToList();
            int count = 0;
            foreach (char digit in passwordList)
            {
                int digitInt = int.Parse(digit.ToString());
                if (count != 0)
                {
                    string formerDigit = passwordList[count - 1].ToString();
                    var formerDigitInt = int.Parse(formerDigit);
                    if (digitInt < formerDigitInt && !decrease)
                        decrease = true;
                    if (digit == passwordList[count - 1] && !doubleNums)
                        doubleNums = true;
                }
                count++;
            }

            return !decrease && doubleNums;
        }
        public static int PasswordCount((int lowerBound, int upperBound) input)
        {
            int count = 0;
            for (int number = input.lowerBound; number <= input.upperBound; number++)
            {
                var doesItPass = PasswordPasses(number);
                if (doesItPass) count++;
            }
            return count;
        }
        public static bool PasswordPassesForReal(int password)
        {
            var passesFirstSet = PasswordPasses(password);
            bool largerSet = false;
            bool extraDouble = false;
            if (passesFirstSet)
            {
                var passwordString = password.ToString();
                var passwordList = passwordString.ToList();
                int count = 0;
                foreach (char digit in passwordList)
            {
                int digitInt = int.Parse(digit.ToString());
                if (count > 1 && count < passwordList.Count - 1)
                {
                    string formerDigit = passwordList[count - 2].ToString();
                    var formerDigitInt = int.Parse(formerDigit);
                    string nextDigit = passwordList[count + 1].ToString();
                    var nextDigitInt = int.Parse(nextDigit);
                    if (digitInt == int.Parse(passwordList[count - 1].ToString()))
                    {
                        if (digitInt == formerDigitInt || digitInt == nextDigitInt)
                            largerSet = true;
                        else
                            extraDouble = true;
                    }
                    
                }
                if (count == 1)
                {
                    string nextDigit = passwordList[count + 1].ToString();
                    var nextDigitInt = int.Parse(nextDigit);
                    if (digitInt == int.Parse(passwordList[count - 1].ToString()))
                    {
                        
                        if (digitInt != nextDigitInt)
                            extraDouble = true;
                    }
                    
                }
                if (count == passwordList.Count - 1)
                {
                    string formerDigit = passwordList[count - 2].ToString();
                    var formerDigitInt = int.Parse(formerDigit);
                    if (digitInt == int.Parse(passwordList[count - 1].ToString()))
                    {
                        if (digitInt == formerDigitInt)
                            largerSet = true;
                        else
                            extraDouble = true;
                    }
                }
                count++;
            }
            }

            return passesFirstSet && (extraDouble || !largerSet);
        }
        public static int PasswordCountForReal((int lowerBound, int upperBound) input)
        {
            int count = 0;
            for (int number = input.lowerBound; number <= input.upperBound; number++)
            {
                var doesItPass = PasswordPassesForReal(number);
                if (doesItPass) count++;
            }
            return count;
        }

    }
}