using System;

namespace ConvertCurrencyIntoWord
{
    public static class Program
    {
        static string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

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
                if (cents == 1) centsWord = ones[cents] + " cent";
                else centsWord = ones[cents] + " cents";
            }
            else if (cents >= 10 && cents < 20)
            {
                centsWord = teens[cents - 10] + " cents";
            }
            else if (cents >= 20 && cents < 100)
            {
                if (int.Parse(cents.ToString().Substring(1, 1)) == 0) centsWord = tens[int.Parse(cents.ToString().Substring(0, 1)) - 2] + " cents";
                else centsWord = tens[int.Parse(cents.ToString().Substring(0, 1)) - 2] + "-" + ones[int.Parse(cents.ToString().Substring(1, 1))] + " cents";
            }
            return centsWord;
        }

        public static string showHoundredWord(int isItHoundred)
        {
            return isItHoundred==0? "":" Houndred ";
        }
        public static string BetweenHoundredAndHoundredThousand(int dolars)
        {
            if (dolars >= 100 && dolars < 1000)
            {
                int houndredX = int.Parse(dolars.ToString().Substring(0, 1));
                int tensX = int.Parse(dolars.ToString().Substring(1, 2));
                dolarsWord = ones[houndredX] + " Houndred " + LessThanHoundred(tensX);
            }
            else if (dolars >= 1000 && dolars < 10000)
            {
                int thousandX = int.Parse(dolars.ToString().Substring(0, 1));
                int houndredX = int.Parse(dolars.ToString().Substring(1, 1));
                int tensX = int.Parse(dolars.ToString().Substring(2, 2));
                dolarsWord = ones[thousandX] + " Thousand " + ones[houndredX] + " Houndred " + LessThanHoundred(tensX);
            }
            else if (dolars >= 10000 && dolars < 20000)
            {
                int thousandX = int.Parse(dolars.ToString().Substring(0, 2));
                int houndredX = int.Parse(dolars.ToString().Substring(2, 1));
                int tensX = int.Parse(dolars.ToString().Substring(3, 2));
                dolarsWord = teens[thousandX - 10] + " Thousand " + ones[houndredX] + " Houndred " + LessThanHoundred(tensX);
            }
            else if (dolars >= 20000 && dolars < 100000)
            {
                string tensThousandX = tens[int.Parse(dolars.ToString().Substring(0, 1)) - 2] + "-" + ones[int.Parse(dolars.ToString().Substring(1, 1))];
                int houndredX = int.Parse(dolars.ToString().Substring(2, 1));
                int tensX = int.Parse(dolars.ToString().Substring(3, 2));
                dolarsWord = tensThousandX + " Thousand " + ones[houndredX] + " Houndred " + LessThanHoundred(tensX);
            }
            return dolarsWord;
        }

        public static string BetweenHoundredThousandAndHoundredMilions(int dolars) 
        {
            if (dolars >= 100000 && dolars < 1000000)
            {
                int houndredThousandX = int.Parse(dolars.ToString().Substring(0, 1));
                int thousandX = int.Parse(dolars.ToString().Substring(1, 5));
                dolarsWord = ones[houndredThousandX] + " Houndred " + (thousandX==0 ? " Thousand ":BetweenHoundredAndHoundredThousand(thousandX));
            }
            else if (dolars >= 1000000 && dolars < 10000000)
            {
                int millionX = int.Parse(dolars.ToString().Substring(0, 1));
                int houndredThousandX = int.Parse(dolars.ToString().Substring(1, 1));
                int thousandX = int.Parse(dolars.ToString().Substring(2, 5));

                dolarsWord = ones[millionX] + " Million " + ones[houndredThousandX] + " Houndred " + (thousandX == 0 ? " Thousand " : BetweenHoundredAndHoundredThousand(thousandX));

            }
            else if (dolars >= 10000000 && dolars < 20000000)
            {
                int millionX = int.Parse(dolars.ToString().Substring(0, 2)) - 10;
                int houndredThousandX = int.Parse(dolars.ToString().Substring(2, 1));
                int thousandX = int.Parse(dolars.ToString().Substring(3, 5));

                dolarsWord = teens[millionX] + " Million " + ones[houndredThousandX] + " Houndred " + (thousandX == 0 ? " Thousand " : BetweenHoundredAndHoundredThousand(thousandX));

            }
            else if (dolars >= 20000000 && dolars < 100000000)
            {
                string tensMillionX = tens[int.Parse(dolars.ToString().Substring(0, 1)) - 2] + "-" + ones[int.Parse(dolars.ToString().Substring(1, 1))];
                int houndredThousandX = int.Parse(dolars.ToString().Substring(2, 1));
                int thousandX = int.Parse(dolars.ToString().Substring(3, 5));

                dolarsWord = tensMillionX + " Million " + ones[houndredThousandX] + " Houndred " + (thousandX == 0 ? " Thousand " : BetweenHoundredAndHoundredThousand(thousandX));

            }
            return dolarsWord;
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
                    centsWord = " Zero cents";
                }

                //dolars
                if (dolars == 0) dolarsWord = "Zero dolars";
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
                    int houndredMillionX = int.Parse(dolars.ToString().Substring(0, 1));

                    int hugeValue = int.Parse(dolars.ToString().Substring(1, 8));

                    dolarsWord = ones[houndredMillionX] + " Houndred " + BetweenHoundredThousandAndHoundredMilions(hugeValue);

                }

                if (cents != 0) Cents(cents);


                Console.Write("\n" + "\n" + dolarsWord + " and "+ centsWord + "\n" + "\n" + "\n" + "\n");
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
