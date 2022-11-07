using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenSiretVerification2022
{
    public class KeyValidation
    {
        //Using Lhun Algorithm to Check the validity of the siret or siren number
        public bool KeyLhunAlgorithm(string inputStr)
        {
            int result = LhunSum(inputStr);
            if (result % 10 == 0)
                return true;
            return false;
        }

        public int LhunSum(string inputStr)
        {
            int result = 0;
            int iter = 1;
            for (int i = inputStr.Length - 1; i >= 0; i--)
            {
                if (iter % 2 == 0)
                {

                    int temp = Convert.ToInt32(inputStr[i].ToString()) * 2;
                    if (temp >= 10)
                    {
                        result += temp / 10;
                        result += temp % 10;
                    }
                    else
                    {
                        result += temp;
                    }
                }
                else
                {
                    result += Convert.ToInt32(inputStr[i].ToString());
                }
                iter++;
            }
            return result;
        }
    }
}
