
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SirenSiretVerification2022
{
    class SirenSiretVerif
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Siren-Siret Verification Program. Please enter your Siren or Siret number.");
            SirenSiretVerification();
        }

        private static void SirenSiretVerification()
        {
            Input Userinput = new Input();
            KeyValidation keyValidation = new KeyValidation();
            Userinput.input = Console.ReadLine();
            if (Userinput.CheckGlobalCorrect(Userinput.input) == false)
            {
                Console.WriteLine($"{Userinput.input} is a wrong format. Please Enter your Siren/Siret number");
                SirenSiretVerification();
            }
            else
            {
                if (keyValidation.KeyLhunAlgorithm(Userinput.number.ToString()) == true)
                {
                    Console.WriteLine($"Congratulation ! {Userinput.input} is a Valid Siren/Siret !");
                }
                else
                {
                    Console.WriteLine($"Sorry, it appears {Userinput.input} is a not Valid Siren/Siret.");
                }
            }
        }

    }
}
