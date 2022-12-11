using System.Text;

namespace AdventOfCode2022
{
    public class Day6
    {
        private void SolvePart1And2(string input, int markerLength, int result)
        {
            int curPos = markerLength;
            int maxPos = input.Length;
            while (curPos < maxPos)
            {
                string fourCharMarker = input.Substring(curPos - markerLength, markerLength);
                var markerList = fourCharMarker.ToCharArray().ToList();
                markerList.Sort();
                int markerCheck = markerList.Count - 1;
                for (; markerCheck > 0; markerCheck--)
                {
                    if (markerList[markerCheck] == markerList[markerCheck - 1])
                        break;
                }
                if (markerCheck == 0)
                    break;
                curPos++;
            }

            Xunit.Assert.Equal(result, curPos);
        }

        [Fact]
        public void Introduction1()
        {
            SolvePart1And2(File.ReadAllText("Day6_Introduction.txt"),4, 7);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart1And2(File.ReadAllText("Day6_Introduction.txt"),14, 19);
        }

        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1And2(File.ReadAllText("Day6_Puzzle.txt"),4, 1647);
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart1And2(File.ReadAllText("Day6_Puzzle.txt"),14, 2447);
        }
    }
}