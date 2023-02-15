using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Operator_overloading
{
    internal class Program
    {
        class Dollar
        {
            public int doll { get; set; }
            public int cent { get; set; }

        }

        class Money
        {
            public int rubl { get; set; }
            public int penny { get; set; }

            public static implicit operator Money(Dollar money)
            {
                return new Money { rubl = money.doll * 60, penny = money.cent * 38 };
            }
            public static implicit operator Money(int number)
            {
                return new Money { rubl = number*3, penny = number*7 };
            }
            public static explicit operator int(Money money)
            {
                return money.rubl;
            }
            public override string ToString()
            {
                if (penny > 100)
                {
                    rubl = rubl + penny / 100;
                    do
                    {
                        penny -= 100;
                    } while (penny >= 100);
                }

                if (penny < 0)
                {
                    penny += 100;
                    --rubl;
                }
                if (rubl < 0)
                    return "action is not allowed";
                return $" {rubl} {"rub"} {penny} {"pen"}";
            }

            public static Money operator +(Money d1, Money d2)
            {
                return new Money { rubl = d1.rubl + d2.rubl, penny = d1.penny + d2.penny };
            }
            public static Money operator -(Money d1, Money d2)
            {
                return new Money { rubl = d1.rubl - d2.rubl, penny = d1.penny - d2.penny };
            }
            public static Money operator *(Money d1, Money d2)
            {
                return new Money { rubl = d1.rubl * d2.rubl, penny = d1.penny * d2.penny };
            }
            public static Money operator /(Money d1, Money d2)
            {
                double rub = (double)d1.rubl / (double)d2.rubl;
                double pen = (double)d1.penny / (double)d2.penny;
                return new Money { rubl = (int)rub, penny = (int)pen };
            }
            public static Money operator ++(Money d1)
            {
                d1.rubl++;
                return d1;
            }
            public static Money operator --(Money d1)
            {
                d1.penny--;
                return d1;
            }

            public override bool Equals(object obj)
            {
                return this.ToString() == obj.ToString();
            }

            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }

            public static bool operator ==(Money d1, Money d2)
            {
                return d1.Equals(d2);
            }
            public static bool operator !=(Money d1, Money d2)
            {
                return !(d1 == d2);
            }

            public static bool operator >(Money d1, Money d2)
            {
                if (d1.rubl == 0 && d2.rubl == 0)
                {
                    return d1.penny > d2.penny;
                }
                else
                    return d1.rubl > d2.rubl;

            }
            public static bool operator <(Money d1, Money d2)
            {
                if (d1.rubl == 0 && d2.rubl == 0)
                {
                    return d1.penny < d2.penny;
                }
                else
                    return d1.rubl < d2.rubl;
            }

        }
        static void Main(string[] args)
        {
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.DarkBlue;
            do
            {
                Clear();
                WriteLine("Enter action: 1 - mathematical functions, 2 - class conversion");
                ConsoleKey key = ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        {
                            Clear();
                            int rub1, pen1;
                            try
                            {
                                Write("Enter RUB 1 object ");
                                rub1 = int.Parse(ReadLine());
                                Write("Enter penny 1 object ");
                                pen1 = int.Parse(ReadLine());
                            }
                            catch (Exception)
                            {
                                WriteLine("Error, input just number!!!");
                                WriteLine("Press Enter");
                                ReadLine();
                                continue;
                            }
                           
                            Money cash = new Money { rubl = rub1, penny = pen1 };
                            WriteLine("---------------------------");
                            Write("Enter RUB 2 object ");
                            int rub2 = int.Parse(ReadLine());
                            Write("Enter penny 2 object ");
                            int pen2 = int.Parse(ReadLine());
                            Money cash2 = new Money { rubl = rub2, penny = pen2 };
                            WriteLine($"{"First cash = "} {cash} {"Second cash = "} {cash2}");
                            WriteLine("***************************");

                            WriteLine("Sum of two objects");
                            WriteLine(cash + cash2);
                            WriteLine("***************************");

                            WriteLine("Subtraction  of two objects");
                            WriteLine(cash - cash2);
                            WriteLine("***************************");

                            WriteLine("Multiplication of two objects");
                            WriteLine(cash * cash2);
                            WriteLine("***************************");

                            WriteLine("Dividing of two objects");
                            WriteLine(cash / cash2);
                            WriteLine("***************************");

                            WriteLine("Decrement");
                            WriteLine(cash--);
                            WriteLine("***************************");

                            WriteLine("Increment");
                            WriteLine(cash2++);
                            WriteLine("***************************");

                            WriteLine("equality operator");
                            WriteLine(cash == cash2);
                            WriteLine("***************************");

                            WriteLine("inequality operator");
                            WriteLine(cash != cash2);
                            WriteLine("***************************");

                            WriteLine("operator first more second?");
                            WriteLine(cash > cash2);
                            WriteLine("***************************");

                            WriteLine("operator first less second?");
                            WriteLine(cash < cash2);
                            WriteLine("***************************");
                            ReadLine();
                        }
                        break;
                    case ConsoleKey.D2:
                    {
                            Clear();
                            int rub1, pen1;
                            try
                            {
                                WriteLine("operator class to class");
                                WriteLine("***************************");
                                Write("Enter RUB ");
                                rub1 = int.Parse(ReadLine());
                                Write("Enter penny ");
                                pen1 = int.Parse(ReadLine());
                            }
                            catch (Exception)
                            {
                                WriteLine("Error, input just number!!!");
                                WriteLine("Press Enter");
                                ReadLine();
                                continue;
                            }
                            
                            Money cash = new Money { rubl = rub1, penny = pen1 };
                            WriteLine(cash);
                            Dollar dol = new Dollar { doll = rub1, cent = pen1 };
                            cash = dol;
                            WriteLine($"{rub1} {"$"} {pen1} {"cent"} {"="} {cash}");
                            WriteLine("***************************");
                            WriteLine("operator type to class");
                            WriteLine("***************************");
                            WriteLine("Enter number for converse type to class"); 
                            Money cash1 = new Money { rubl = 78, penny = 9 };
                            WriteLine(cash1);
                            int number;
                            try
                            {
                                number = int.Parse(ReadLine());
                            }
                            catch (Exception)
                            {
                                WriteLine("Error, input just number!!!");
                                WriteLine("Press Enter");
                                ReadLine();
                                continue;
                            }
                            
                            cash1 = number;
                            WriteLine($" {"After inflation you have"} {cash1}");
                            WriteLine("***************************");
                            WriteLine("enter number for converse class to type");
                            WriteLine("operator class to type");
                            WriteLine("***************************");
                            Money cash3 = new Money { rubl = 78, penny = 9 };
                            WriteLine(cash3);
                            int number2 = int.Parse(ReadLine());
                            number2 = (int)cash3;
                            WriteLine($"{"Now your numbers = "} {number2}");
                            WriteLine("***************************");
                            ReadLine();
                        }
                        break;
                    default:
                        WriteLine("This number error");
                        ReadLine();
                        break;
                }

            } while (true);

        }
    }
}
