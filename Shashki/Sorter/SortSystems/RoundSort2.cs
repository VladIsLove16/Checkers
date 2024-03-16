using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shashki
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Shashki
    {
        class RoundSort2
        {
            public static void RoundRobinTournament(string[] participants)
            {
                int n = participants.Length;

                // Матрица результатов
                int[,] results;
                if (n % 2 == 0)
                {
                    results = new int[n, n];
                }
                else
                {
                    results = new int[n + 1, n + 1];
                }

                // Проведение всех игр
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        // Игра между i-м и j-м игроком
                        int jScore;
                        int iScore = GetScore(participants[i], participants[j]);
                        if (iScore == 3)
                        {
                            jScore = 0;
                        }
                        else if (iScore == 1)
                        {
                            jScore = 1;
                        }
                        else
                        {
                            jScore = 3;
                        }

                        // Запись результата
                        results[i, j] = iScore;
                        results[j, i] = jScore;
                    }
                }

                // Вывод таблицы результатов
                PrintTable(participants, results);
            }

            // Получение очков игрока (заглушка)
            private static int GetScore(string participant1, string participant2)
            { // TODO: Реализовать логику получения очков игрока
                Console.WriteLine("Играют:" + " " + participant1 + " " + participant2);
                Console.WriteLine("Введите победителя");
                String name = Console.ReadLine();
                if (name == participant1)
                {
                    return 3;
                }
                else if (name == "Ничья")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            private static void PrintTable(string[] participants, int[,] results)
            { // Вывод таблицы результатов
                Console.WriteLine("Выигрывшие во вертикали" + "\n" + "Проигравшие по горизонтали");
                Console.WriteLine("    | {0}", string.Join(" | ", participants));
                Console.WriteLine("----" + new string('-', participants.Length * 4));

                for (int i = 0; i < participants.Length; i++)
                {
                    Console.Write("{0} | ", participants[i]);
                    for (int j = 0; j < participants.Length; j++)
                    {
                        Console.Write("  " + "{0} ", results[i, j]);
                    }
                    Console.WriteLine();
                }
            }

            static void Main()
            {
                String[] a = { "a", "b", "c", "d" };
                RoundRobinTournament(a);
            }
        }
    }
}
