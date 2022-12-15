using System.Text;
using System.Linq;

namespace AdventOfCode2022
{
    public class Day8
    {
        public class Tree
        {
            public
                Tree()
            {
                MaxLeft = -1;
                MaxTop= -1;
                MaxBottom= -1;  
                MaxRight= -1;

            }
            public int Height { get; set; }
            public int MaxLeft { get; set; }
            public int MaxTop { get; set; }
            public int MaxRight { get; set; }
            public int MaxBottom { get; set; }
            public bool IsVisible { get { return Height > MaxLeft || Height > MaxTop || Height > MaxRight || Height > MaxBottom; } }
            public int VisibleTreesLeft { get; set; }

            public int VisibleTreesTop { get; set; }

            public int VisibleTreesRight { get; set; }
            public int VisibleTreesBottom { get; set; }
            public int ScenicScore { get { return VisibleTreesBottom * VisibleTreesLeft * VisibleTreesRight * VisibleTreesTop; } }
        }

        private void SolvePart1(string input, int result)
        {
            string[] eachCarry = input.Split("\n");

            int maxSize = eachCarry[0].Length;
            Tree[,] trees = new Tree[maxSize, maxSize];

            int curLine = 0;
            foreach (string carry in eachCarry)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    trees[curLine, i] = new Tree() { Height = Int32.Parse(carry.Substring(i, 1)) };
                }
                curLine++;
            }

            for (int i = 1; i < maxSize; i++)
            {
                for (int j = 0; j < maxSize; j++)
                {
                    trees[j, i].MaxLeft = Math.Max(trees[j, i - 1].MaxLeft, trees[j, i - 1].Height);
                    trees[j, maxSize - i - 1].MaxRight = Math.Max(trees[j, maxSize - i].MaxRight, trees[j, maxSize - i].Height);
                    trees[i, j].MaxTop = Math.Max(trees[i - 1, j].MaxTop, trees[i - 1, j].Height);
                    trees[maxSize - i - 1, j].MaxBottom = Math.Max(trees[maxSize - i, j].MaxBottom, trees[maxSize - i, j].Height);
                }
            }
            int actual = 0;// trees.SelectMany(array => array);
            for (int i = 0; i < maxSize; i++)
            {
                for (int j = 0; j < maxSize; j++)
                {
                    if (trees[i, j].IsVisible)
                        actual++;
                }
            }

            Xunit.Assert.Equal(result, actual);
        }

        private void SolvePart2(string input, int result)
        {
            string[] eachCarry = input.Split("\n");

            int maxSize = eachCarry[0].Length;
            Tree[,] trees = new Tree[maxSize, maxSize];

            int curLine = 0;
            foreach (string carry in eachCarry)
            {
                for (int i = 0; i < maxSize; i++)
                {
                    trees[curLine, i] = new Tree() { Height = Int32.Parse(carry.Substring(i, 1)) };
                }
                curLine++;
            }

            for (int i = 1; i < maxSize; i++)
            {
                for (int j = 0; j < maxSize; j++)
                {
                    trees[i, j].VisibleTreesLeft = GetVisibleTrees(trees, trees[i, j].Height, i, j, -1, 0);
                    trees[i, j].VisibleTreesRight = GetVisibleTrees(trees, trees[i, j].Height, i, j, 1, 0);
                    trees[i, j].VisibleTreesTop = GetVisibleTrees(trees, trees[i, j].Height, i, j, 0, -1);
                    trees[i, j].VisibleTreesBottom = GetVisibleTrees(trees, trees[i, j].Height, i, j, 0, 1);
                }
            }
            int actual = 0;// trees.SelectMany(array => array);
            for (int i = 0; i < maxSize; i++)
            {
                for (int j = 0; j < maxSize; j++)
                {
                    if (trees[i, j].IsVisible)
                        actual++;
                }
            }

            Xunit.Assert.Equal(result, actual);
        }

        private int GetVisibleTrees(Tree[,] trees, int height, int i, int j, int v1, int v2)
        {
            if (v1 != 0)
            {
                if (i + v1 <= 0 || i + v1 >= trees.GetLength(0))
                    return 1;
            }
            else
            {
                if (j + v2 <= 0 || j + v2 >= trees.GetLength(1))
                    return 1;
            }

            if (trees[i + v1, j + v2].Height <= height)
                return GetVisibleTrees(trees, height, i + v1, j + v2, v1, v2) + 1;
            else
                return 1;
        }

        [Fact]
        public void Introduction1()
        {
            SolvePart1(File.ReadAllText("Day8_Introduction.txt"), 21);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(File.ReadAllText("Day8_Introduction.txt"), 8);
        }

        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1(File.ReadAllText("Day8_Puzzle.txt"), 1776);
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart2(File.ReadAllText("Day8_Puzzle.txt"), 0);
        }
    }
}
