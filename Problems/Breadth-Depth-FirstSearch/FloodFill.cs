using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Problems.Breadth_Depth_FirstSearch
{
    [TestFixture]
    public sealed class FloodFill
    {
        private static IEnumerable<TestCaseData> TestCases()
        {
            yield return new TestCaseData(new[]
                {
                    new[] { 1, 1, 1 },
                    new[] { 1, 1, 0 },
                    new[] { 1, 0, 1 }
                }, 1, 1, 2)
                .SetName("{a} {m}")
                .Returns(new[]
                {
                    new[] { 2, 2, 2 },
                    new[] { 2, 2, 0 },
                    new[] { 2, 0, 1 }
                });
            
            yield return new TestCaseData(new[]
                {
                    new[] { 0, 0, 0 },
                    new[] { 0, 0, 0 }
                }, 0, 0, 0)
                .SetName("{a} {m}")
                .Returns(new[]
                {
                    new[] { 0, 0, 0 },
                    new[] { 0, 0, 0 }
                });
        }

        [TestCaseSource(nameof(TestCases))]
        public int[][] Mine_BFS(int[][] image, int sr, int sc, int color)
        {
            var queue = new Queue<Tuple<int, int>>();
            queue.Enqueue(Tuple.Create(sr, sc));
            var oldColor = image[sr][sc];

            if (oldColor == color)
            {
                return image;
            }

            while (queue.TryDequeue(out var pixel))
            {
                var up = Tuple.Create(pixel.Item1 - 1, pixel.Item2);
                var down = Tuple.Create(pixel.Item1 + 1, pixel.Item2);
                var left = Tuple.Create(pixel.Item1, pixel.Item2 - 1);
                var right = Tuple.Create(pixel.Item1, pixel.Item2 + 1);

                if (up.Item1 >= 0 && image[up.Item1][up.Item2] == oldColor)
                {
                    queue.Enqueue(up);
                }

                if (left.Item2 >= 0 && image[left.Item1][left.Item2] == oldColor)
                {
                    queue.Enqueue(left);
                }

                if (down.Item1 < image.Length && image[down.Item1][down.Item2] == oldColor)
                {
                    queue.Enqueue(down);
                }

                if (right.Item2 < image.First().Length && image[right.Item1][right.Item2] == oldColor)
                {
                    queue.Enqueue(right);
                }

                image[pixel.Item1][pixel.Item2] = color;
            }

            return image;
        }

        [TestCaseSource(nameof(TestCases))]
        public int[][] Mine_DFS(int[][] image, int sr, int sc, int color)
        {
            var queue = new Stack<Tuple<int, int>>();
            queue.Push(Tuple.Create(sr, sc));
            var oldColor = image[sr][sc];

            if (oldColor == color)
            {
                return image;
            }

            while (queue.TryPop(out var pixel))
            {
                var up = Tuple.Create(pixel.Item1 - 1, pixel.Item2);
                var down = Tuple.Create(pixel.Item1 + 1, pixel.Item2);
                var left = Tuple.Create(pixel.Item1, pixel.Item2 - 1);
                var right = Tuple.Create(pixel.Item1, pixel.Item2 + 1);

                if (up.Item1 >= 0 && image[up.Item1][up.Item2] == oldColor)
                {
                    queue.Push(up);
                }

                if (left.Item2 >= 0 && image[left.Item1][left.Item2] == oldColor)
                {
                    queue.Push(left);
                }

                if (down.Item1 < image.Length && image[down.Item1][down.Item2] == oldColor)
                {
                    queue.Push(down);
                }

                if (right.Item2 < image.First().Length && image[right.Item1][right.Item2] == oldColor)
                {
                    queue.Push(right);
                }

                image[pixel.Item1][pixel.Item2] = color;
            }

            return image;
        }
    }
}
