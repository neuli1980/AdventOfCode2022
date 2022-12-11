namespace AdventOfCode2022
{
    public class Day2
    {
        /*
         * shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors) plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won)
         * */

        private void SolvePart1(string input, int result)
        {
            string[] eachCarry = input.Split("\r\n");

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
            string[] eachCarry = input.Split("\r\n");

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
            SolvePart1(introductionString, 15);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(introductionString, 12);
        }

        string introductionString = @"A Y
B X
C Z";

        string puzzleString = @"A Z
B X
A Y
B X
C Y
C X
B Z
C Z
A Y
C Z
B Z
B X
B X
C X
C X
B X
B Z
C X
B Y
B Z
B X
C Z
A Z
B X
A Y
B Y
C Y
B X
B Y
B Z
B Y
B Z
A Y
C Y
B X
A Z
B X
C Y
C Y
C Y
A Y
B X
B Y
C Y
B Z
C Y
A Z
B Y
A X
B X
C X
B Y
B Y
B Y
B Y
C X
A Y
A Y
C Z
C Y
B Y
B Y
B X
A Y
C Z
B Y
B Z
B Y
A Y
C X
B Y
B X
C Z
C Z
B X
A Y
C X
B Z
C Z
C Y
C X
B Z
B X
A Z
B X
C Z
C Y
C Y
B Y
B Z
B Y
A Y
A Y
C Y
C Y
C Z
C X
B X
B Z
B X
C Z
A Y
A X
B Y
A Z
B Y
B X
C Z
C Z
B Y
B Z
B Y
B Z
C X
C X
A Y
C Y
C Z
B Z
C Y
B Z
C X
B Y
B X
C X
A Z
B Y
C Y
C X
C Y
C Z
B Z
B X
C X
A Y
B X
B Z
C X
C Z
B Y
B Y
C X
B Z
A Y
B Y
C Y
C X
C Z
C Y
A Z
C Y
C X
C Y
B X
C X
B Y
C X
B X
B X
B Y
B X
A Z
B Y
B Y
C X
C Y
B X
B X
C Y
A Y
A Z
C X
B X
A Z
A Z
A Y
C X
C Z
C X
B X
C X
C X
B Y
B X
B X
B X
B Y
A Y
C X
C Y
B X
C X
A Y
B Z
C Z
B X
C Y
B Y
C Y
B Z
C X
C Y
C Y
B Y
C X
C X
B Z
B Y
B X
C Z
B Y
B X
B Z
B Z
C Y
B Z
A X
C X
B Z
B Z
B Z
B Y
C Z
C X
C X
C Y
B Z
B Y
B X
A Y
B Y
A Y
C X
C Z
C X
B Z
B Z
C X
C Y
A Y
B Y
C X
C Z
C X
C X
C Z
C Z
C X
B Y
C X
A Y
C Y
C Z
B X
B Y
B Z
A Y
B X
B Z
B Z
B Y
B X
C Y
A Y
B Z
C X
B Z
B Z
B Y
B Z
B X
C Y
C X
C X
B Z
B Y
C Z
B Y
B X
C Z
C Z
B X
A Z
B Z
A Z
C Y
C X
B Y
C Y
C X
C Y
C X
A Z
C Y
B Z
B X
C X
C Z
C X
C Z
B Z
B Y
B Z
B Y
C X
B Z
B Z
B Y
B Z
C Z
B Y
B Z
C Z
C Z
C X
B X
C Y
B X
C Y
B X
B X
C Y
A Z
B X
B X
C Z
C X
C X
C X
C Z
C Z
C Y
C X
A Y
B Z
C Z
C Y
C X
B Y
B Y
A Z
B X
B Y
B Y
C Z
C Z
B X
C X
A Z
B X
C Z
B Z
C X
A Z
B X
C X
C X
A Y
B Z
B Z
B X
C Y
C Z
C X
A Z
B Y
C Y
C Y
C Y
C X
B Y
B X
B X
C X
B Z
C X
B Z
B Z
B X
C X
A Y
B Y
C Z
C X
B Y
B Y
C Z
B X
C X
C Z
B Z
A Y
B X
B Z
B Y
C X
C Z
A Y
A Y
B X
B X
B Z
B Z
C Y
C X
B Y
B X
B X
B Y
B Y
C X
B X
B X
A Y
B Y
B Z
B Z
C Y
B Z
C Z
C X
C X
C Y
C X
C Z
C Z
B X
C X
B X
C Y
C Y
B Z
B Y
C X
B Z
C X
B Z
A Y
C X
B X
B Y
C X
C Y
B X
B Z
B X
C Y
B Z
B Y
B Z
C X
C X
C X
C Y
B X
B X
B X
C X
B X
B X
B Y
B Z
B Y
C X
B Y
B X
B X
A Y
C Y
B Z
A X
C Z
C Z
B Z
A Y
C Y
B Y
B Y
C Z
C Y
C X
A Y
C Y
B Y
C X
A Z
C Z
A Y
C Z
C Z
A Z
B Y
C Z
C Z
B Z
A Y
C X
C Y
B X
B Z
B X
C X
B X
C Z
B X
B X
B Y
C X
B Z
C X
A Z
C X
B Z
C X
C Z
B X
C X
B Y
B X
B Y
B Y
C X
B Y
C Z
C X
B Y
A Y
C Y
B Z
A Z
A Z
C X
C Y
C Y
B Y
B Y
C Z
C X
A X
B X
C Y
B Z
B X
B Y
A Z
A Z
A Z
C Z
C X
B Y
B Z
C X
B X
B X
B Z
A X
C X
A Y
C X
B X
C Y
C X
B Y
B Y
B Y
C X
C Y
C Y
B Z
B X
C Z
A Y
B Y
C Y
C X
C X
C Y
A Z
C Z
C Y
C Y
C Y
C Y
B Z
B Z
C X
B Y
C Y
B X
C X
C X
C Y
C Y
C Y
C X
B X
B Y
A Y
A Y
B X
B X
C Y
B Z
C X
A Y
A Y
C Z
B Z
C Z
C Z
A Z
B Z
A Y
B Z
B X
C X
A Y
B X
B Z
B X
C X
C Z
B Z
A X
B Z
B Y
B Z
B X
C Z
B X
B Y
B Y
B X
B Z
C X
A Y
B Z
B Y
C Y
A Y
C Z
B Z
C X
B Y
C Y
A Y
C Y
A Y
C X
B X
B Y
A Y
B X
B X
A Y
B X
B Y
B X
B X
C X
B Z
B Z
B Y
A X
C X
B X
C X
B Y
C X
C Y
C Y
C X
A Y
A Y
B Y
C X
B Y
C Y
B Y
C Z
C X
C X
C X
B Y
C Y
C Z
B Y
C X
B X
B Y
A Y
C X
B Y
B Z
A X
B Z
B Y
C Y
C X
B X
C X
C Y
B X
C Y
B Y
C X
B X
A Y
C Y
C X
A Y
B Y
C Y
C X
B Y
B Z
B X
B X
C Y
C Y
C X
B X
C Y
B Z
C Z
B Z
B Z
B Y
A Z
A Z
C Z
C Z
A X
A Y
B Z
C Y
A Y
B Y
C Z
B Z
C X
C Z
B Z
B Z
B Y
A Y
B Y
C X
C X
A Z
B X
C X
C Z
C Y
B X
B X
C Z
C X
C Y
C X
B Y
B Y
C X
C Y
C Z
B Z
C Z
B X
B Z
C Y
A X
A X
B Y
B X
B Z
C X
C X
A Y
C X
C X
C Z
C Y
C X
B X
C X
B X
B X
A Y
A Y
C X
B X
B Y
C X
C X
C Z
C Y
A X
C X
B Z
B X
C Y
B Y
A Z
C Y
C Z
B X
B Y
C Z
C Y
C Z
C Y
C X
C Z
B Z
A Z
B X
C X
B Z
B Z
A Y
C X
B X
C X
B X
C X
B Z
A Y
C X
B X
C Y
C Y
C X
C Y
B Z
C Z
C X
B Z
C Z
C Z
C Z
B Z
C Z
B Y
B Y
C Z
A Z
A X
B Z
C X
B X
C Y
A Y
C X
C X
A Y
C X
C Y
B Y
C Z
B X
A Y
C X
C X
B X
B X
A Z
B Y
B Z
B X
B X
B Z
B X
B X
B Z
A Z
C Z
B X
B X
C Y
B Z
B Z
B X
B Y
B Z
C Y
B Z
C Z
C X
C Y
A Y
C Y
C X
B Y
C Y
C Z
B Y
C X
B Z
B Z
A Y
B Y
B Y
B X
C Y
C X
B X
C X
A Y
C X
C Y
B X
C X
C Y
C Y
B Z
C Z
B Y
B Z
A X
C Y
A Y
C X
B X
B X
B Y
C Y
C Y
C X
A Y
A Z
B X
A X
C Z
C X
B Z
C Y
B X
A Y
C Y
C Y
B X
A Z
A Y
B Z
B Y
B Z
B Y
C X
A X
A Y
B X
B Z
B X
C X
B Y
B X
B Y
B X
C Z
C X
A Y
C Y
B X
B Y
A Z
B Z
C X
C X
C X
A Y
C X
C Y
B Y
B Z
B Y
B X
A Y
C Y
C Y
C Y
C X
A Y
B Z
C Z
C Y
B X
C X
C X
B X
B Z
B Z
B Y
A Z
B X
A Y
B Y
C X
B Y
A Y
B X
C Y
C X
A Y
C Z
C X
B Z
C Y
B X
C X
A X
C Y
B X
B Y
B Y
C X
B Y
C Y
C X
B Y
A Y
C Z
C Y
B Z
C Z
B Y
C X
B Z
A Y
C Z
B X
B Z
C Y
B Z
C X
C X
A Z
B Z
A Y
B X
C X
C X
B Y
A Z
C Z
C X
B Z
C X
B Z
C Y
C X
C Z
C Z
C Y
C Y
C X
C X
C Y
B X
C X
B Z
C Z
C Y
C X
C Y
B Y
B Y
B Z
B X
C Y
C Y
C X
C Z
C Y
C Y
C X
A Y
B X
B Z
C Z
C Y
B X
C X
A Y
C Z
B Y
C Y
C X
C Y
C Y
B X
C Y
C Y
B Y
C X
A Z
B X
B X
B X
B X
B Z
C Y
B X
A Z
B Z
A Y
C X
B X
B Z
C Z
C X
B Z
B X
A Z
A Y
B Y
A Z
B X
C Y
B Y
C Y
C X
B Y
B Y
C Y
A Z
B X
B Z
B Y
B Y
B X
B Y
B Z
C Z
B Y
C X
A Y
C X
B Y
B X
A Y
C Y
C Y
B X
B Y
B Z
C Y
C Y
C Z
C Z
A Y
C X
B Z
C X
B Y
C Y
B Z
C X
C X
A Y
C Y
A Y
C X
C X
C Z
A Y
A X
B X
C Y
B Z
C X
B Y
C X
C Y
C X
B X
B Y
B Z
C Y
B Y
A Z
C Y
B X
C X
A Z
C Y
B X
B X
C Y
C Y
B X
C Y
C Z
C X
B X
C Y
B Z
B Z
A Y
C X
C X
C Y
B X
A X
A Y
A Y
C X
B Y
C X
C Z
B Y
C Y
B X
C Y
B Z
B Y
A Z
B X
B Z
B Y
B X
C X
B Y
C X
C Y
B Y
A Y
C X
C Z
B Y
C Y
C X
C X
C X
B X
C X
C Y
B Y
C X
C Y
C X
A Y
B Z
B X
C X
A Y
B Z
A Y
B Z
B Z
B Z
A Y
B X
C Y
C X
B Y
A Y
C X
C X
A Y
C X
C Z
B X
C Y
C X
B Z
B Y
A Y
C X
C X
B Y
B Z
B X
B Y
C X
B X
C Y
B X
A X
B Z
B Y
B Y
C X
B X
C X
C X
C X
C X
B X
B Z
B X
B Z
B X
C X
B X
C Z
B Y
B Z
B Y
C X
B X
B Z
A Y
B Z
C Y
B X
B Y
C Z
C X
B X
A Y
A Y
B X
A Y
C Y
C X
A X
C Y
C Y
C X
C X
C Z
C Y
B X
A Y
C X
B Y
B Z
B Z
C Y
B Y
B Y
B Y
C Y
B Y
B Z
B Z
B Z
A X
B X
C Y
C Y
C Y
C Z
B Z
B X
C Z
C Y
A Y
A Y
C Y
B Z
C Y
C Z
A Z
C Y
A Y
C Z
C X
B Z
B Y
B Y
A X
C X
B Z
B X
B Z
C Z
B X
A Y
B Z
C X
C Y
B Y
C X
B Z
B Z
B Z
C X
B Z
B Y
B Y
B Y
C Y
A Y
B X
A Y
C Z
C X
C X
C X
C X
C Y
B Y
B X
C X
C X
B Z
A Z
C X
C Z
B X
B Z
C Y
B X
B X
B Y
C Y
B Z
A Z
B X
C Y
B Z
B X
C Y
B Z
B X
C Z
C X
C Z
B Z
A Y
B Y
A Z
C Z
B Z
B Z
B Z
C Z
C X
A Y
C Z
B Z
B X
B X
B Y
A Y
B Y
C X
B Y
C Z
C Y
B Z
C X
A Z
B Z
C Y
C Z
B X
C Z
A Y
A Y
A Y
C Z
C Z
B Y
C X
C Z
C X
C Y
B Z
C Z
B Y
C Y
A Y
B X
B X
B X
B X
C Y
C Y
C X
B Z
B X
A Y
B X
B X
C Y
C Y
C Y
C Y
B Z
B Y
C X
B Y
B X
C X
C X
B X
C X
C X
B X
B Y
B X
B X
B Y
B X
C Y
B Y
C Y
C Z
C X
B Z
B Z
B Y
C Z
C Z
C Y
B X
B Y
B Z
B Z
A Z
C X
C Y
B X
B X
C X
B Z
C X
B Y
C X
C Y
B Y
B Y
A Z
B Y
B X
C Y
B Z
A Z
B Y
C Y
C X
B X
B X
B Z
C Z
C Z
C X
B Z
B X
A Y
C X
A Y
A Y
B Y
C Y
B X
C Z
B Z
B X
C X
A X
C Z
B Z
B X
C Y
C X
B X
C Z
C Y
B Z
C Y
B Y
C X
B Z
A Y
C X
C Y
A Y
B Y
B Y
C X
B X
B Y
B Y
B Y
A Y
A Y
C Z
C Y
B X
A Y
C X
C X
C Y
C X
A Y
B Y
C Y
B X
C Y
C X
C X
C X
A Y
A Y
B Y
B X
B Y
B X
C X
C Y
B Z
B Y
C Y
C Z
A Z
B X
B Z
C Z
A Y
C Y
B X
C X
B X
B Z
C Y
B X
B Y
B X
B Z
C Y
C Z
A Y
C Y
A Z
B Y
A Y
A Y
C X
A X
A X
C Y
C Z
C Y
B X
C X
B Z
B Y
C X
C X
A Y
C X
C Y
C X
C X
C X
C X
C Z
B X
A Y
C Y
B Z
B Z
C Z
B Y
B X
B Y
C X
C Y
B Y
B X
B Y
C X
B Z
B X
C Z
C Z
B Z
C Y
A X
C Z
C X
C X
A Y
B X
C X
B Z
C X
B Y
C Z
B X
B Y
C Y
B Z
B Z
C X
C X
B Z
C Z
B Y
B Y
B Z
B X
C Y
C Y
B X
B X
B X
B Y
B Z
B Y
C X
C Y
C Z
B X
B Y
C X
B X
A Z
A Z
C Z
C Z
C X
C Y
C X
B Y
C X
C X
B Z
B Z
B Y
C Y
B Y
B Y
B X
B X
C Y
A Z
C Y
B X
B Z
B Y
A Y
C Z
B Z
C Y
C Z
C Y
C Z
B Z
B Z
C X
C X
B X
B Y
B X
A Z
B X
B Z
B X
B Y
C Y
B Y
C Z
C X
A Y
A Y
C Y
B Y
C Y
B X
B Y
C Z
A Z
B X
B Y
B Y
B Y
B X
C X
C Y
C X
B X
B X
B X
B Y
B X
B Z
B Y
C Y
A Z
C Z
B Y
C Y
B Z
B Y
B Y
C X
B X
C Z
C X
B X
A Y
B Z
C Y
C Y
B Y
B Y
A Y
A Z
B X
B Z
B Z
B Z
B Z
A Y
B Z
B X
C X
C Y
B Y
C Y
B X
C X
A Y
C Z
B X
B X
B Y
A X
B X
C Y
B Z
A X
C Y
C Z
C Z
B X
C X
A X
C X
A Z
B X
B Y
C Z
B Z
B X
C X
B X
C Z
C X
B Z
A Z
A Y
C X
C Y
B X
C X
A Y
C X
B X
B Z
C Y
B X
C Y
C X
B X
C X
C Z
A Z
C Y
C Y
C X
C Z
A Y
C X
C X
C X
C X
B Y
B Z
C X
C Y
C X
B X
A Y
C Y
A Y
A Z
B X
C Y
C X
C Y
C X
B X
B Y
B X
C X
B Z
B Z
B Y
B X
B X
B Y
B Y
A Y
C Y
B Z
B X
C Y
C Y
C X
A X
B Z
C Y
B X
C Y
B Y
C X
C Y
C Z
A Y
C X
A Z
C X
B Y
C X
B X
B Z
B Z
B Y
B Z
B Z
B X
C X
B X
B Y
B X
B Z
C Y
B X
C X
C Y
C X
B Y
B X
C X
B X
C X
B Y
C Z
C X
B Z
A Y
B X
A Y
B Y
B X
C Y
B X
B Z
C Z
B Y
C X
A Y
B Y
C X
C X
B Y
C Y
B Z
C X
B Z
B X
C Y
C X
C Z
B X
C Z
B X
B X
C Y
B Y
C Y
B Y
C X
A Y
B X
C X
C Z
C X
A Y
B Z
A Y
B Z
B X
B Z
B Y
A Y
C X
B Y
C Z
A Y
B X
C X
C Z
C X
C X
B X
C X
C Z
B Z
C Z
B X
C Z
B Z
B Y
B X
B X
B X
C Z
C Y
A Y
B Z
B X
B X
C Z
A Y
B X
C Y
B Z
C X
B Y
C Y
B X
B X
B X
B Y
B Y
C X
C Z
B Z
C X
B Y
B Z
B Z
B Y
B Y
C X
B Y
B Y
B Z
A Y
C Y
C X
B X
C Y
C X
C X
B X
B Z
C X
A Y
B Y
C Z
C Y
B X
B X
B Z
C Z
C X
A Y
C Z
C X
C X
B Z
B X
C Y
B Y
B Y
C Z
B Z
A Z
C X
A Y
C Y
B X
C X
B X
A Y
C X
C Z
C Y
A Z
C X
B Z
B Y
A Y
C X
B X
C Z
C Y
C Y
B Z
C X
C Y
B Z
B Y
C X
C Z
B Z
A Z
C Z
B X
C X
C X
C Y
C X
B Z
C X
C Y
C X
B Z
B Z
A Z
B Z
B X
B X
C Y
C Z
B Z
C Y
C Z
B X
A Y
B X
C X
B Y
C X
B Y
B X
C X
B Z
C Y
C X
B X
B X
B X
B Y
B Y
B Y
A X
B X
C Y
C Z
B Z
C X
A Y
C X
C Y
B Y
C Y
C X
B Z
B Y
B Y
B Z
C Y
C Y
A X
C Z
B X
B Z
B Y
C X
C Y
B Y
C Z
B Z
C X
B Z
C X
B Y
B Z
C X
C X
B Y
B Y
B Y
C X
B Y
B Z
B Y
A Z
B Z
A X
C Y
A Y
C Y
B Z
B X
A Y
C X
B X
A Y
B Y
C X
B Y
C X
B X
B Z
A Y
B Z
B X
C Z
C X
B Z
C X
A Y
C Y
C Y
A Y
B Y
C X
C Y
C X
B X
C Y
B Z
B X
B Y
B X
C X
B X
C Y
C Y
B Y
B Z
C Z
B X
C Y
C X
A X
A Y
B Z
B Y
A Y
C X
C X
C Y
B X
C Z
C Z
B Y
B X
C X
A Y
B X
B X
C Z
C X
C Z
B X
B X
B Y
B Y
C Y
C X
A Z
C Z
B Y
C X
B Z
C X
B X
C X
B Z
C Z
B Y
B X
B Y
C Y
B Y
C Z
A Z
B X
C Z
B Y
C Z
C X
A X
B Z
B Z
C Y
C X
B Y
C Y
C Z
B X
B Z
C X
C Z
B Z
C Z
B X
C X
B Y
B Z
C Y
B Y
B X
B Y
B Z
B Z
A Z
B Y
C Y
A X
B X
C Y
A Y
C Y
B X
C X
B Z
C Y
C X
C Z
B Y
B X
C Z
A Y
C Y
C X
B X
B Z
B Z
B X
C Y
C Z
C Z
B Z
B X
C X
A Y
B X
B Z
C Y
C X
B X
C X
C X
B Y
A Y
A X
C Z
C Y
C Z
C Z
C Z
C X
A Z
C Y
B X
A X
B X
B X
A Y
B X
C X
B X
B X
B X
C Y
C X
A Y
B X
C X
C Y
A Y
C X
C Y
C Z
C X
C Z
C Z
B Y
B Y
C Y
A Y
C Y
B X
B Z
B Z
C Z
C X
B X
B Z
C X
B Z
B Z
C X
B Z
B Z
B X
B Y
C Z
B Y
B Z
A Y
C X
C X
B Z
C Y
C X
A X
B Z
C Y
C Z
B Z
B Z
C Y
A Y
C Z
C X
C X
C X
B Z
C X
B Y
C X
C X
B Z
C X
A Y
C Z
C X
A Z
B Y
A Y
B X
B X
C Y
B Y
B X
A Z
B Z
C Y
C X
B Y
B Y
B Y
B Z
C Y
C Y
A Y
C Y
C Z
B X
C X
B Y
C Y
A Z
C Y
C X
B Z
C Z
B Z
C X
C X
C X
B X
C Y
C Z
B X
C X
A Y
C Y
B Y
B Z
C Y
C X
C X
B X
C X
C Z
C Y
A Y
C X
B Y
B Z
C X
C Z
B Z
C Z
B Z
B X
B X
C X
C Z
B Y
B X
C Z
A Y
B X
B Y
C X
B X";
        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1(puzzleString, 12772);
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart2(puzzleString, 11618);
        }
    }
}