using System.Text;

namespace AdventOfCode2022
{
    public class Day5
    {
        public class Crate
        {
            public Crate(string name) 
            {
                Name = name;
            }

            public string Name { get; set; }
        }
        public class CrateStack
        {
            public CrateStack()
            {
                TheList = new List<Crate>();
            }
            public List<Crate> TheList { get; set; }
        }
        public class Stacks
        {
            public Stacks(int stackCount)
            {
                CrateStacks = new List<CrateStack>(stackCount);
                for (int i = 0; i < stackCount; i++)
                {
                    CrateStacks.Add(new CrateStack());
                }
            }
            public List<CrateStack> CrateStacks { get; set; }
        }

        private void SolvePart1(string input, int stackCount, string result)
        {
            string[] eachCarry = input.Split("\n");

            Stacks theStacks = new Stacks(stackCount);

            bool initializeMode = true;
            foreach (var item in eachCarry)
            {
                if (item.Length == 0)
                {
                    initializeMode = false;
                }
                else
                {

                    if (initializeMode)
                    {
                        for (int p = 0; p < stackCount; p++)
                        {
                            if (item.Substring(p * 4, 1) == "[")
                                theStacks.CrateStacks[p].TheList.Insert(0, new Crate((item.Substring(p * 4 + 1, 1))));
                        }
                    }
                    else
                    {
                        string[] action = item.Split(" ");

                        for (int moveCount = Int32.Parse(action[1]); moveCount > 0; moveCount--)
                        {
                            var topCrate = theStacks.CrateStacks[Int32.Parse(action[3])-1].TheList.Last();
                            theStacks.CrateStacks[Int32.Parse(action[3])-1].TheList.Remove(topCrate);
                            theStacks.CrateStacks[Int32.Parse(action[5])-1].TheList.Add(topCrate);
                        }
                    }
                }
            }

            //List<ElvePair> pairs = new List<ElvePair>();
            string actual = "";
            foreach (var item in theStacks.CrateStacks)
            {
                actual += item.TheList.Last().Name;
            }

            Xunit.Assert.Equal(result, actual);
        }

        private void SolvePart2(string input, int stackCount, string result)
        {
            string[] eachCarry = input.Split("\n");

            Stacks theStacks = new Stacks(stackCount);

            bool initializeMode = true;
            foreach (var item in eachCarry)
            {
                if (item.Length == 0)
                {
                    initializeMode = false;
                }
                else
                {

                    if (initializeMode)
                    {
                        for (int p = 0; p < stackCount; p++)
                        {
                            if (item.Substring(p * 4, 1) == "[")
                                theStacks.CrateStacks[p].TheList.Insert(0, new Crate((item.Substring(p * 4 + 1, 1))));
                        }
                    }
                    else
                    {
                        string[] action = item.Split(" ");
                        List<Crate> tempList = new List<Crate>();

                        for (int moveCount = Int32.Parse(action[1]); moveCount > 0; moveCount--)
                        {
                            var topCrate = theStacks.CrateStacks[Int32.Parse(action[3]) - 1].TheList.Last();
                            theStacks.CrateStacks[Int32.Parse(action[3]) - 1].TheList.Remove(topCrate);
                            tempList.Add(topCrate);
                        }
                        for (int moveCount = Int32.Parse(action[1]); moveCount > 0; moveCount--)
                        {
                            var topCrate = tempList.Last();
                            tempList.Remove(topCrate);
                            theStacks.CrateStacks[Int32.Parse(action[5]) - 1].TheList.Add(topCrate);
                        }

                    }
                }
            }

            //List<ElvePair> pairs = new List<ElvePair>();
            string actual = "";
            foreach (var item in theStacks.CrateStacks)
            {
                actual += item.TheList.Last().Name;
            }

            Xunit.Assert.Equal(result, actual);
        }

        [Fact]
        public void Introduction1()
        {
            SolvePart1(File.ReadAllText("Day5_Introduction.txt"), 3, "CMZ");
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(File.ReadAllText("Day5_Introduction.txt"), 3, "MCD");
        }

        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1(File.ReadAllText("Day5_Puzzle.txt"), 9, "ZWHVFWQWW");
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart2(File.ReadAllText("Day5_Puzzle.txt"), 9, "HZFZCCWWV");
        }
    }
}