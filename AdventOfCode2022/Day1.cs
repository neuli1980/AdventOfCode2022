namespace AdventOfCode2022
{
    public class Day1
    {
        [Fact]
        public void Introduction1()
        {
            SolvePart1(File.ReadAllText("Day1_Introduction.txt"), 24000);
        }

        [Fact]
        public void PuzzlePart1()
        {
            SolvePart1(File.ReadAllText("Day1_Puzzle.txt"), 71300);
        }

        private void SolvePart1(string input, int result)
        {
            string[] eachCarry = input.Split("\r\n");

            int maxSum = 0;
            int curSum = 0;
            foreach (var item in eachCarry)
            {
                if (item.Length > 0)
                    curSum += Int32.Parse(item);
                else
                {
                    if (maxSum < curSum)
                        maxSum = curSum;
                    curSum = 0;
                }
            }
            if (maxSum < curSum)
                maxSum = curSum;

            Xunit.Assert.Equal(result, maxSum);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(File.ReadAllText("Day1_Introduction.txt"), 45000);
        }

        [Fact]
        public void PuzzlePart2()
        {
            SolvePart2(File.ReadAllText("Day1_Puzzle.txt"), 209691);
        }

        private void SolvePart2(string input, int result)
        {
            string[] eachCarry = input.Split("\r\n");

            List<int> firstThree = new List<int>();
            int curSum = 0;
            foreach (var item in eachCarry)
            {
                if (item.Length > 0)
                    curSum += Int32.Parse(item);
                else
                {
                    if (firstThree.Count() < 3)
                    {
                        firstThree.Add(curSum);
                        firstThree.Sort();
                    }
                    else
                    {
                        if (firstThree[0] < curSum)
                        {
                            firstThree.RemoveAt(0);
                            firstThree.Add(curSum);
                            firstThree.Sort();
                        }
                    }
                    curSum = 0;
                }
            }
            if (firstThree.Count() < 3)
            {
                firstThree.Add(curSum);
                firstThree.Sort();
            }
            else
            {
                if (firstThree[0] < curSum)
                {
                    firstThree.RemoveAt(0);
                    firstThree.Add(curSum);
                    firstThree.Sort();
                }
            }

            Xunit.Assert.Equal(result, firstThree.Sum());
        }

    }
}