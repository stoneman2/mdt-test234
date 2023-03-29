using System;

namespace mdt_singer
{
    class Program
    {
        static bool CheckFull(int gender, int k, int male_singers, int female_singers)
        {
            if (gender == 1) 
            {
                if (male_singers >= k)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (gender == 2)
            {
                if (female_singers >= k)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        static int GetResult(int gender, int male_score, int female_score, int i, int k, int male, int female)
        {
            // Get result.
            // The ID of the participant is the same as the order in which they were entered.
            // Accept with the following conditions:
            // 1) If the judge's score is 9 or 10.
            // 2) If that judge's participant number is not over K.
            // 3) If both judges want to accept, give priority to the judge with the same gender.
            // 4) If only one judge wants to accept, accept.
            // 5) If both judges do not want to accept, do not accept.
            if (male_score > 8)
            {
                // Check if female score is more than 8 too.
                if (female_score > 8)
                {
                    if (gender == 1)
                    {
                        if (CheckFull(1, k, male, female))
                        {
                            male++;
                            return (1);
                        }
                    }
                    else
                    {
                        if (CheckFull(2, k, male, female))
                        {
                            female++;
                            return (2);
                        }
                    }
                }
                else
                {
                    if (CheckFull(1, k, male, female))
                    {
                        male++;
                        return (1);
                    }
                }
            }

            if (female_score > 8)
            {
                if (male_score > 8)
                {
                    if (gender == 1)
                    {
                        if (CheckFull(1, k, male, female))
                        {
                            male++;
                            return (1);
                        }
                    }
                    else
                    {
                        if (CheckFull(2, k, male, female))
                        {
                            female++;
                            return (2);
                        }
                    }
                }
            }
            else
            {
                if (CheckFull(2, k, male, female))
                {
                    female++;
                    return (2);
                }
            }
            return (0);
        }
        static void Main(string[] args)
        {
            // Get N and K. N = number of participants. K = number of hosted singers
            int n = int.Parse(Console.ReadLine());

            int male_singers = 0;
            int female_singers = 0;

            if (n < 1 || n > 10001)
            {
                Console.WriteLine("N must be between 1 and 10000.");
                return;
            }

            int k = int.Parse(Console.ReadLine());

            if (k < 1 || k > 1001)
            {
                Console.WriteLine("K must be between 1 and 1000.");
                return;
            }

            // Loop and get data for each participant. First value is gender. Second is judge #1 score. Third is judge #2 score.
            for (int i = 1; i <= n; i++)
            {
                Console.Write("Input Gender: ");
                int gender = int.Parse(Console.ReadLine());
                Console.Write("Input Judge 1's Score: ");
                int judge1 = int.Parse(Console.ReadLine());
                Console.Write("Input Judge 2's Score: ");
                int judge2 = int.Parse(Console.ReadLine());

                int result1 = i;
                int result2 = GetResult(gender, judge1, judge2, i, k, male_singers, female_singers);

                if (result2 == 0)
                    continue;
                Console.WriteLine("Contestant Index: " + result1 + "Judge Number: " + result2);
            }
        }
    }
}
