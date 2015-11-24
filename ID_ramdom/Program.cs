using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace ID_ramdom
{
    class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine(RandomIDmaker());

             string input =  Console .ReadLine();
             if (input.Length == 10)
             {
                 if (isIdentifiacationID(input))
                 {
                     Console.WriteLine("correct");
                     Console.Read();
                 }
                 else
                 {
                     Console.WriteLine("error");
                     Console.Read();
                 }
             }

        }

        static Boolean isIdentifiacationID(string input)
        {
            if (input.Length == 10)
            {
                if ((input[0] > 0x41 && input[0] <= 0x5A) || (input[0] > 0x61 && input[0] <= 0x7A) )
                {   //number represent  abc alphabet
                    //{a,b,c,d,e,.....}
                    string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    int[] a = { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
                    int[] Multiplier = {1, 9, 8, 7, 6, 5, 4, 3, 2, 1} ;
                    int[] final_input =new int[11];
                    int total=0;
                    string N1 = input.First().ToString().ToUpper();
                    int First_alphabet;
                    Array.Clear(final_input,0,11);
                     if (alpha.IndexOf(N1) < 0 ) 
                     {
                        return false ;
                     }
                     else
                     {
                         First_alphabet = a[Convert.ToInt16(alpha.IndexOf(N1))];  
                     }
                    //second number of the input should be 1 or 2 (gender male:1 femail:2)
                     if ((Convert.ToInt32(input[1]) != '1') && (Convert.ToInt32(input[1]) != '2'))
                         return false;

                    //get new array
                    final_input[0] = First_alphabet /10; // get first number of the reprecent number
                    final_input[1] = First_alphabet % 10; // get second number of the reprecent number

                    //sum for checksum
                    total = final_input[0] * 1 + final_input[1] * 9;

                    for (int i = 1; i < 9; i++)
                    { 
                        int cell = Convert.ToInt32(input[i].ToString()) ;
                        if (cell < 0 || cell > 9) //check number ascii 48~57 is number 0-9
                            return false;
                        final_input[i+1] = cell ;
                        total = cell * Multiplier[i+1] + total;
                    }
                    final_input[10] = Convert.ToInt32(input[9].ToString());
                    //the 10th number of the input should satify the checksum
                    //10-sum %10 = final number of the input
                    if ((10 - total % 10) != Convert.ToInt32(input[9].ToString()))
                        return false;
                    else
                        return true;
                }
            
            }

            return false;
        }

        static string RandomIDmaker()
        {
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int[] a = { 10, 11, 12, 13, 14, 15, 16, 17, 34, 18, 19, 20, 21, 22, 35, 23, 24, 25, 26, 27, 28, 29, 32, 30, 31, 33 };
            int[] Multiplier = { 1, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int[] final_input = new int[11];
            int total = 0;
            Random rnd = new Random();
            string output = alpha[rnd.Next(0, 25)].ToString ();

            int First_alphabet = a[alpha.IndexOf(output)];
            //get new array
            final_input[0] = First_alphabet / 10; // get first number of the reprecent number
            final_input[1] = First_alphabet % 10; // get second number of the reprecent number
            final_input[2] =rnd.Next(1, 2); //gender

            output += final_input[2].ToString();

            total = final_input[0] * 1;
            total += final_input[1] * 9;
            total += final_input[2] * 8;

            for (int i = 3; i < 10; i++)
            {
                final_input[i] = rnd.Next(0, 9);
                output += final_input[i].ToString();
                total += final_input[i] * Multiplier[i];
            }
            final_input[10] = 10 - total % 10;
            output += final_input[10].ToString();
            return output;
        }
    }
    
}
