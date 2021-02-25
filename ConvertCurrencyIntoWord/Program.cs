using System;

namespace ConvertCurrencyIntoWord
{
    public static class Program
    {
        static string[] ones = new string[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static string[] teens = new string[] { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] tens = new string[] { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

        static int dolars = 0;
        static int cents = 0;
        static string dolarsWord = "";
        static string centsWord = "";

        public static string LessThanHoundred(int dolars)
        {
            if (dolars < 10)
            { 
                if (dolars == 1) dolarsWord = ones[dolars] + " dolar";
                else dolarsWord = ones[dolars] + " dolars";
            }
            else if (dolars >= 10 && dolars < 20)
            {
                dolarsWord = teens[dolars - 10] + " dolars";
            }
            else if (dolars >= 20 && dolars < 100)
            {
                if (int.Parse(dolars.ToString().Substring(1,1)) == 0) dolarsWord = tens[int.Parse(dolars.ToString().Substring(0, 1)) - 2] + " dolars";
                else dolarsWord = tens[int.Parse(dolars.ToString().Substring(0, 1)) - 2] + "-" + ones[int.Parse(dolars.ToString().Substring(1, 1))] + " dolars";
            }
            return dolarsWord;
        }
        public static string Cents(int cents)
        {
            if (cents < 10)
            {
                if (cents == 0) centsWord = " and zero cents";
                else if (cents == 1) centsWord = " and " + ones[cents] + " cent";
                else centsWord = " and " + ones[cents] + " cents";
            }
            else if (cents >= 10 && cents < 20)
            {
                centsWord = " and " + teens[cents - 10] + " cents";
            }
            else if (cents >= 20 && cents < 100)
            {
                if (int.Parse(cents.ToString().Substring(1, 1)) == 0) centsWord = " and " + tens[int.Parse(cents.ToString().Substring(0, 1)) - 2] + " cents";
                else centsWord = " and " + tens[int.Parse(cents.ToString().Substring(0, 1)) - 2] + "-" + ones[int.Parse(cents.ToString().Substring(1, 1))] + " cents";
            }

            return centsWord;
        }

        public static string showHoundredWord(int isItHoundred)
        {
            return isItHoundred==0? "":" houndred ";
        }
        public static string BetweenHoundredAndHoundredThousand(int dolars)
        {
            if (dolars >= 100 && dolars < 1000)
            {
                int houndredX = int.Parse(dolars.ToString().Substring(0, 1));
                int tensX = int.Parse(dolars.ToString().Substring(1, 2));

                dolarsWord = ones[houndredX] + " houndred " + LessThanHoundred(tensX);
            }
            else if (dolars >= 1000 && dolars < 10000)
            {
                int thousandX = int.Parse(dolars.ToString().Substring(0, 1));
                int houndredX = int.Parse(dolars.ToString().Substring(1, 1));
                int tensX = int.Parse(dolars.ToString().Substring(2, 2));

                dolarsWord = ones[thousandX] + " thousand " + (houndredX==0? "": ones[houndredX] + " houndred ") + LessThanHoundred(tensX);
            }
            else if (dolars >= 10000 && dolars < 20000)
            {
                int thousandX = int.Parse(dolars.ToString().Substring(0, 2));
                int houndredX = int.Parse(dolars.ToString().Substring(2, 1));
                int tensX = int.Parse(dolars.ToString().Substring(3, 2));

                dolarsWord = teens[thousandX - 10] + " thousand " + (houndredX == 0 ? "" : ones[houndredX] + " houndred ") + LessThanHoundred(tensX);
            }
            else if (dolars >= 20000 && dolars < 100000)
            {
                string tensThousandX = tens[int.Parse(dolars.ToString().Substring(0, 1)) - 2] + "-" + ones[int.Parse(dolars.ToString().Substring(1, 1))];
                int houndredX = int.Parse(dolars.ToString().Substring(2, 1));
                int tensX = int.Parse(dolars.ToString().Substring(3, 2));

                dolarsWord = tensThousandX + " thousand " + (houndredX == 0 ? "" : ones[houndredX] + " houndred ") + LessThanHoundred(tensX);
            }
            return dolarsWord;
        }

        public static string BetweenHoundredThousandAndHoundredMilions(int dolars) 
        {
            if (dolars >= 100000 && dolars < 1000000)
            {
                int houndredThousandX = int.Parse(dolars.ToString().Substring(0, 1));
                int thousandX = int.Parse(dolars.ToString().Substring(1, 5));

                dolarsWord = ones[houndredThousandX] + " houndred " + (thousandX == 0 ? " thousand " : BetweenHoundredAndHoundredThousand(thousandX));
            }
            else if (dolars >= 1000000 && dolars < 10000000)
            {
                int millionX = int.Parse(dolars.ToString().Substring(0, 1));
                int houndredThousandX = int.Parse(dolars.ToString().Substring(1, 1));
                int thousandX = int.Parse(dolars.ToString().Substring(2, 5));

                dolarsWord = ones[millionX] + " million " + (houndredThousandX == 0 ? " dolars" : ones[houndredThousandX] + " houndred ") + (thousandX == 0 ? "" : "thousand " + BetweenHoundredAndHoundredThousand(thousandX));

            }
            else if (dolars >= 10000000 && dolars < 20000000)
            {
                int millionX = int.Parse(dolars.ToString().Substring(0, 2)) - 10;
                int houndredThousandX = int.Parse(dolars.ToString().Substring(2, 1));
                int thousandX = int.Parse(dolars.ToString().Substring(3, 5));

                dolarsWord = teens[millionX] + " million " + (houndredThousandX == 0 ? " dolars" : ones[houndredThousandX] + " houndred ") + (thousandX == 0 ? "" : "thousand " + BetweenHoundredAndHoundredThousand(thousandX));

            }
            else if (dolars >= 20000000 && dolars < 100000000)
            {
                string tensMillionX = tens[int.Parse(dolars.ToString().Substring(0, 1)) - 2] + "-" + ones[int.Parse(dolars.ToString().Substring(1, 1))];
                int houndredThousandX = int.Parse(dolars.ToString().Substring(2, 1));
                int thousandX = int.Parse(dolars.ToString().Substring(3, 5));

                dolarsWord = tensMillionX + " million " + (houndredThousandX == 0 ? "" : ones[houndredThousandX] + " houndred ") + (thousandX == 0 ? "" : "thousand " + BetweenHoundredAndHoundredThousand(thousandX));

            }
            else dolarsWord = " million ";
            return dolarsWord;
        }

        public static string BetweenHoundredMillionsAndBillion(int dolars)
        {
            int houndredMillionX = int.Parse(dolars.ToString().Substring(0, 1));
            int hugeValue = int.Parse(dolars.ToString().Substring(1, 8));

            return ones[houndredMillionX] + " houndred " + BetweenHoundredThousandAndHoundredMilions(hugeValue);
        }

        static void Main()
        {
            try
            {
                           
            do
            {
                centsWord = "";
                dolarsWord = "";
                Console.Clear();
                Console.Write("Put x if you want to exit");
                Console.Write("\nEnter a number to convert to dolars:"+ "\n \n");

                string value = Console.ReadLine();

                if(value.Contains('x'))
                {
                    Environment.Exit(0);
                }
                else if (value.Contains(","))
                {
                    dolars = int.Parse(value.Substring(0, value.IndexOf(",")));                   
                    cents = int.Parse(value.Substring(value.IndexOf(",") + 1, 2));
                }
                else
                {
                    dolars = int.Parse(value);
                    cents = 0;
                }

                //dolars
                if (dolars == 0) dolarsWord = "zero dolars";
                else if (dolars < 100)
                {
                    LessThanHoundred(dolars);
                }
                else if (dolars >= 100 && dolars < 100000)
                {
                    BetweenHoundredAndHoundredThousand(dolars);
                }
                else if (dolars >= 100000 && dolars < 100000000)
                {
                    BetweenHoundredThousandAndHoundredMilions(dolars);
                }
                else if (dolars >= 100000000 && dolars < 1000000000)
                {
                    BetweenHoundredMillionsAndBillion(dolars);
                }
                //cents
                Cents(cents);

                Console.Write("\n" + "\n" + dolarsWord + centsWord + "\n" + "\n" + "\n" + "\n");
                Console.Write("Click any key to continue");


            } while (Console.ReadKey().KeyChar != 'x');

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
