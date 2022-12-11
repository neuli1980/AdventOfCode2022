using System.Text;

namespace AdventOfCode2022
{
    public class Day4
    {
        public class Elve
        { 
            public Elve(string sectionList)
            {
                string[] sections = sectionList.Split("-");
                StartingSection = Int32.Parse(sections[0]);
                EndingSection = Int32.Parse(sections[1]);
            }
            public int StartingSection { get; set; }
            public int EndingSection { get; set; }
        }
        public class ElvePair
        {
            public ElvePair(string elveLine)
            {
                string[] elves = elveLine.Split(",");
                Elve1 = new Elve(elves[0]);
                Elve2 = new Elve(elves[1]);
            }
            public Elve Elve1 { get; set; }
            public Elve Elve2 { get; set; }
        }

        private void SolvePart1(string input, int result)
        {
            string[] eachCarry = input.Split("\r\n");

            List<ElvePair> pairs = new List<ElvePair>();
            int sum = 0;
            foreach (var item in eachCarry)
            {
                pairs.Add(new ElvePair(item));
            }

            foreach (var item in pairs)
            {
                if (item.Elve1.StartingSection <= item.Elve2.StartingSection && item.Elve1.EndingSection >= item.Elve2.EndingSection ||
                    item.Elve2.StartingSection <= item.Elve1.StartingSection && item.Elve2.EndingSection >= item.Elve1.EndingSection)
                    sum++;
            }

            Xunit.Assert.Equal(result, sum);
        }

        private void SolvePart2(string input, int result)
        {
            string[] eachCarry = input.Split("\r\n");

            List<ElvePair> pairs = new List<ElvePair>();
            int sum = 0;
            foreach (var item in eachCarry)
            {
                pairs.Add(new ElvePair(item));
            }

            foreach (var item in pairs)
            {
                if (item.Elve1.StartingSection <= item.Elve2.EndingSection && item.Elve1.EndingSection >= item.Elve2.StartingSection)
                    sum++;
            }

            Xunit.Assert.Equal(result, sum);
        }

        [Fact]
        public void Introduction1()
        {
            SolvePart1(File.ReadAllText("Day4_Introduction.txt"), 2);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(File.ReadAllText("Day4_Introduction.txt"), 4);
        }

        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1(File.ReadAllText("Day4_Puzzle.txt"), 413);
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart2(File.ReadAllText("Day4_Puzzle.txt"), 806);
        }

    }
}