using System;
using System.Linq;

namespace GSDevTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Average persons: " + GetAveragePerson(InputPeople()));
        }

        private static double GetAveragePerson(int[] peoples)
        {
            return peoples.Average();
        }

        #region Implementations

        private static int[] InputPeople()
        {
            var result = new int[] { };
            do
            {
                Console.Write("Please input person Age of Death: ");
                var ageOfDeath = Console.ReadLine();
                if (IsValidAgeOfDeath(ageOfDeath, out var ageOfDeathNum))
                {
                    Console.Write("Please input year of Death: ");
                    var yearOfDeath = Console.ReadLine();
                    if (IsValidYearOfDeath(yearOfDeath, out var yearOfDeathNum))
                    {
                        var calculate = yearOfDeathNum - ageOfDeathNum;
                        if (IsValidAgeCalculation(ageOfDeathNum, yearOfDeathNum))
                        {
                            var numberVillagerKills = GetVillagerKillSum(calculate);
                            Array.Resize(ref result, result.Length + 1);
                            result[result.GetUpperBound(0)] = numberVillagerKills;
                        }
                    }
                }

                Console.Write("Add another person? (Y/N)");
            } while (Console.ReadLine()?.ToLower() == "y");

            return result;
        }

        private static int GetVillagerKillSum(in int year)
        {
            int n1 = 1, n2 = 1, i;
            var resultArray = new[] { n1, n2 };
            for (i = 2; i < year; ++i)
            {
                var n3 = n1 + n2;
                Array.Resize(ref resultArray, resultArray.Length + 1);
                resultArray[resultArray.GetUpperBound(0)] = n3;
                n1 = n2;
                n2 = n3;
            }

            var result = resultArray.Sum();

            return result;
        }

        #endregion

        #region Validator

        private static bool IsValidYearOfDeath(in string yearOfDeath, out int ageOfDeathNum)
        {
            var parseResult = int.TryParse(yearOfDeath, out ageOfDeathNum);
            if (!parseResult)
            {
                Console.WriteLine("Invalid year of death, must be a number");
            }
            return parseResult;
        }

        private static bool IsValidAgeOfDeath(in string ageOfDeath, out int ageOfDeathNum)
        {
            var parseResult = int.TryParse(ageOfDeath, out ageOfDeathNum);
            if (!parseResult)
            {
                Console.WriteLine("Invalid age of death, must be a number");
            }
            return parseResult;
        }

        private static bool IsValidAgeCalculation(in int ageOfDeathNum, in int yearOfDeathNum)
        {
            bool isValid = (yearOfDeathNum - ageOfDeathNum) >= 0;
            if (!isValid)
            {
                Console.WriteLine("Invalid age");
            }
            return isValid;
        }

        #endregion
    }
}
