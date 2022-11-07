using System;
using System.Collections.Generic;
using System.Text;

namespace SirenSiretVerification2022
{
    public class Input
    {

        public string input;
        public long number;

        //Check input length Checks if the input is the size of a Siren (9) or Siret (14)
        //Might be easier to parse directly into an array of <10 ints or a List

        public bool CheckInputLength(string inputStr)
        {
            if (inputStr.Length == 9 || inputStr.Length == 14)
            {
                return true;
            }
            return false;
        }

        //CheckParsing tries to Parse the string into a Long value to Check if the string is not empty nor with letters or special Characters
        public bool CheckParsing(string v)
        {
            try
            {
                number = long.Parse(v);
            }
            catch (FormatException)
            {
                Console.WriteLine("{0}: Bad Format", v);
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0}: Overflow", v);
                return false;
            }
            if (number <= 0)
            {
                Console.WriteLine("{0}: Negative Outcome", v);
                return false;
            }
            return true;
        }

        //If the User Input passes the Parsing and Length tests, it is good to go to the Validation Algorithm
        public bool CheckGlobalCorrect(string inputStr)
        {
            if (CheckParsing(inputStr) == true && CheckInputLength(number.ToString()) == true)
                return true;
            return false;
        }
    }

}