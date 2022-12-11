using System.Text;

namespace AdventOfCode2022
{
    public class Day3
    {
        /*
         * shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors) plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won)
         * */

        private void SolvePart1(string input, int result)
        {
            string[] eachCarry = input.Split("\n");

            int sum = 0;
            foreach (var item in eachCarry)
            {
                string strLeft = item.Substring(0, item.Length / 2);
                string strRight = item.Substring(item.Length / 2);
                var sameChar = strLeft.Intersect(strRight).ToArray();

                var xy = (int)Encoding.ASCII.GetBytes(sameChar)[0];
                if (xy < 97)
                    sum += (xy - 64 + 26);
                else
                    sum += (xy - 96);
//                sum += 0;

            }

            Xunit.Assert.Equal(result, sum);
        }

        private void SolvePart2(string input, int result)
        {
            string[] eachCarry = input.Split("\n");

            string intersectedRucksacks = String.Empty;
            int sum = 0;
            for (int i = 0; i < eachCarry.Length; i++)
            {
                switch (i%3)
                {
                    case 0: // kein Rest -> initialisieren
                        intersectedRucksacks = eachCarry[i];
                        break;
                    case 1:
                        intersectedRucksacks = new string(intersectedRucksacks.Intersect(eachCarry[i]).ToArray());
                        break;
                    case 2:
                        intersectedRucksacks = new string(intersectedRucksacks.Intersect(eachCarry[i]).ToArray());

                        var xy = (int)Encoding.ASCII.GetBytes(intersectedRucksacks)[0];
                        if (xy < 97)
                            sum += (xy - 64 + 26);
                        else
                            sum += (xy - 96);
                        break;
                    default:
                        break;
                }
            }

            Xunit.Assert.Equal(result, sum);
        }

        [Fact]
        public void Introduction1()
        {
            SolvePart1(File.ReadAllText("Day3_Introduction.txt"), 157);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(File.ReadAllText("Day3_Introduction.txt"), 70);
        }

        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1(File.ReadAllText("Day3_Puzzle.txt"), 8085);
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart2(File.ReadAllText("Day3_Puzzle.txt"), 2515);
        }

    }
}