using System;
using System.Collections.Generic;
using System.Linq;
using BackpackApp.Debugging;
using BackpackApp.Models;

namespace BackpackApp
{
    public class BackpackSolver
    {
        public List<Item> Solve(List<Item> items, int maxWeight)
        {
            using (var timer = new ExecutionTimer($"Решение задачи о рюкзаке (вес до {maxWeight} кг)"))
            {
                DebugLogger.Log($"Поиск оптимального набора из {items.Count} предметов");

                var bestCombination = new List<Item>();
                int maxCost = 0;
                int combinationsChecked = 0;

                int totalCombinations = (int)Math.Pow(2, items.Count);
                DebugLogger.Log($"Всего комбинаций для проверки: {totalCombinations}");

                for (int i = 0; i < totalCombinations; i++)
                {
                    var currentCombination = new List<Item>();
                    int totalWeight = 0;
                    int totalCost = 0;

                    for (int j = 0; j < items.Count; j++)
                    {
                        if ((i & (1 << j)) != 0)
                        {
                            currentCombination.Add(items[j]);
                            totalWeight += items[j].Weight;
                            totalCost += items[j].Cost;
                        }
                    }

                    combinationsChecked++;

                    if (totalWeight <= maxWeight && totalCost > maxCost)
                    {
                        maxCost = totalCost;
                        bestCombination = new List<Item>(currentCombination);
                        DebugLogger.Log($"Найдено лучшее решение: стоимость {maxCost}, вес {totalWeight}");
                    }

                    if (combinationsChecked % 20 == 0)
                    {
                        DebugLogger.Log($"Проверено комбинаций: {combinationsChecked}/{totalCombinations}");
                    }
                }

                DebugLogger.LogItems(bestCombination, "Оптимальный набор");
                DebugLogger.Log($"Всего проверено комбинаций: {combinationsChecked}");

                return bestCombination;
            }
        }
    }
}