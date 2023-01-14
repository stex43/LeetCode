using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Problems.Breadth_Depth_FirstSearch
{
    [TestFixture]
    public sealed class MaxAreaOfIsland
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new int[][]
                {
                    new[] { 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                    new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                    new[] { 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0 },
                    new[] { 0, 1, 0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 0 },
                    new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                    new[] { 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0 }
                }, 0)
                .SetName("{a} {m}")
                .Returns(6);

            yield return new TestCaseData(new int[][]
                {
                    new[] { 1, 1, 0, 0, 0 },
                    new[] { 1, 1, 0, 0, 0 },
                    new[] { 0, 0, 0, 1, 1 },
                    new[] { 0, 0, 0, 1, 1 }
                }, 0)
                .SetName("{a} {m}")
                .Returns(4);
        }

        [TestCaseSource(nameof(TestCases))]
        public int Mine_BFS(int[][] grid, int dull)
        {
            var max = 0;

            for (var i = 0; i < grid.Length; i++)
            {
                for (var j = 0; j < grid.First().Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        var area = 0;
                        var queue = new Queue<Tuple<int, int>>();
                        queue.Enqueue(Tuple.Create(i, j));

                        while (queue.TryDequeue(out var cell))
                        {
                            if (grid[cell.Item1][cell.Item2] != 1)
                            {
                                continue;
                            }
                            
                            var up = Tuple.Create(cell.Item1 - 1, cell.Item2);
                            var down = Tuple.Create(cell.Item1 + 1, cell.Item2);
                            var left = Tuple.Create(cell.Item1, cell.Item2 - 1);
                            var right = Tuple.Create(cell.Item1, cell.Item2 + 1);

                            if (up.Item1 >= 0 && grid[up.Item1][up.Item2] == 1)
                            {
                                queue.Enqueue(up);
                            }

                            if (left.Item2 >= 0 && grid[left.Item1][left.Item2] == 1)
                            {
                                queue.Enqueue(left);
                            }

                            if (down.Item1 < grid.Length && grid[down.Item1][down.Item2] == 1)
                            {
                                queue.Enqueue(down);
                            }

                            if (right.Item2 < grid.First().Length && grid[right.Item1][right.Item2] == 1)
                            {
                                queue.Enqueue(right);
                            }

                            area++;
                            grid[cell.Item1][cell.Item2] = 0;
                        }

                        max = Math.Max(max, area);
                    }
                }
            }

            return max;
        }
    }
}
