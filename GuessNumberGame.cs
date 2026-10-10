using System;

namespace GuessNumberGame
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGuessNumber();
        }

        /// <summary>
        /// 猜数字小游戏：生成一个 0-100 的随机整数作为目标数字，
        /// 用户有 5 次输入机会，偏大提示“偏大”，偏小提示“偏小”，
        /// 猜对输出 WIN!，5 次未猜对输出 GAME OVER。
        /// </summary>
        static void PlayGuessNumber()
        {
            // 生成 0 - 100 的随机整数作为目标数字
            Random random = new Random();
            int target = random.Next(0, 101); // 上限 exclusive，故填 101

            const int maxTries = 5;
            int tries = 0;

            while (tries < maxTries)
            {
                Console.Write($"请输入你猜的数字（剩余 {maxTries - tries} 次机会）：");
                string input = Console.ReadLine();

                // 处理无效输入（非数字 / 空输入）
                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("输入无效，请输入一个整数。");
                    continue; // 无效输入不消耗机会
                }

                tries++;

                if (guess == target)
                {
                    Console.WriteLine("WIN!");
                    return;
                }
                else if (guess > target)
                {
                    Console.WriteLine("偏大");
                }
                else
                {
                    Console.WriteLine("偏小");
                }
            }

            // 5 次机会用完仍未猜对
            Console.WriteLine("GAME OVER");
        }
    }
}
