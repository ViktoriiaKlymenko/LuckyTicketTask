using System;
using System.Threading;
using System.Linq;
using System.Text.RegularExpressions;

namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            // greeting to user
            string messageHello = "Hello! Let's check your ticket number, whether it's lucky.";
            foreach (char str in messageHello)
            {
                Console.Write(str);
                Thread.Sleep(50);
            }
            Console.WriteLine();

            while (true)
            {
                int i = 0; // variable for counter in foreach loop
                Regex rgx = new Regex("^[0-9]{4,8}$"); // regular expression variable to check, whether the number is 4 to 8 digits long
                string messageNum = "Number of the ticket (4 to 8 digits long): ";
                foreach (char str in messageNum)
                {
                    Console.Write(str);
                    Thread.Sleep(50);
                }

                string num = Console.ReadLine();

                if (rgx.IsMatch(num) == true)
                {
                    // check, whether the number is 4 to 8 digits long and go on
                    if (num.Length % 2 != 0)
                    {
                        // add 0 to the start of a ticket number, if it was odd
                        num = "0" + num;
                    }

                    int[] numsofticket = new int[num.Length];

                    foreach (char str in num)
                    {
                        // add all characters in string to int array
                        numsofticket[i] = Convert.ToInt32(Char.GetNumericValue(str));
                        i++;
                    }

                    var firstArray = numsofticket.Take(numsofticket.Length / 2).ToArray();
                    var secondArray = numsofticket.Skip(numsofticket.Length / 2).ToArray();
                    int firstPart = 0;  // variable for summation numbers of the first ticket number half
                    int secondPart = 0; // variable for summation numbers of the second ticket number half

                    for (i = 0; i < firstArray.Length; i++)
                    {
                        // summation numbers of the first ticket number half
                        firstPart += firstArray[i];
                    }

                    for (i = 0; i < secondArray.Length; i++)
                    {
                        // summation numbers of the second ticket number half
                        secondPart += secondArray[i];
                    }

                    if (firstPart == secondPart)
                    {
                        string messageCongrats = "Congrats! It's lucky ticket!";
                        foreach (char str in messageCongrats)
                        {
                            Console.Write(str);
                            Thread.Sleep(50);
                        }
                        Console.WriteLine();
                        Thread.Sleep(1000);
                    }

                    else
                    {
                        string messageSorry = "Oh, sorry! Your ticket isn't lucky!";
                        foreach (char str in messageSorry)
                        {
                            Console.Write(str);
                            Thread.Sleep(50);
                        }
                        Console.WriteLine();
                        Thread.Sleep(1000);
                    }
                }

                else
                {
                    // display an error if the quantity of numbers isn't between 4 and 8
                    string messageFormat = "Wrong format of the number! Try again!";
                    foreach (char str in messageFormat)
                    {
                        Console.Write(str);
                        Thread.Sleep(50);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
    }
}
