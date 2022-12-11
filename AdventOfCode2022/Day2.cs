namespace AdventOfCode2022
{
    public class Day2
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
                switch (item) // outcome of the round
                {
                    case "A X":
                    case "B Y":
                    case "C Z": // draw
                        sum += 3;
                        break;
                    case "A Y":
                    case "B Z":
                    case "C X": // won
                        sum += 6;
                        break;
                    case "A Z":
                    case "B X":
                    case "C Y": // loss
                        sum += 0;
                        break;
                }
                switch (item.Substring(2)) // selected shape
                {
                    case "X": // rock
                        sum += 1;
                        break;
                    case "Y": // paper
                        sum += 2;
                        break;
                    case "Z": // scissor
                        sum += 3;
                        break;
                }

            }

            Xunit.Assert.Equal(result, sum);
        }

        private void SolvePart2(string input, int result)
        {
            string[] eachCarry = input.Split("\n");

            int sum = 0;
            foreach (var item in eachCarry)
            {
                switch (item) // outcome of the round
                {
                    case "A Y": 
                    case "B X":
                    case "C Z": // rock
                        sum += 1;
                        break;
                    case "A Z":
                    case "B Y": 
                    case "C X": // paper
                        sum += 2;
                        break;
                    case "A X":
                    case "B Z":
                    case "C Y": // scissor
                        sum += 3;
                        break;
                }
                switch (item.Substring(2)) // selected shape
                {
                    case "X": // loss
                        sum += 0;
                        break;
                    case "Y": // draw
                        sum += 3;
                        break;
                    case "Z": // won
                        sum += 6;
                        break;
                }

            }

            Xunit.Assert.Equal(result, sum);
        }

        [Fact]
        public void Introduction1()
        {
            SolvePart1(File.ReadAllText("Day2_Introduction.txt"), 15);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(File.ReadAllText("Day2_Introduction.txt"), 12);
        }

        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1(File.ReadAllText("Day2_Puzzle.txt"), 12772);
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart2(File.ReadAllText("Day2_Puzzle.txt"), 11618);
        }
    }
}