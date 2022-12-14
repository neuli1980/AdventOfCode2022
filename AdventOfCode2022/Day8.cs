using System.Text;

namespace AdventOfCode2022
{
    public class Day8
    {
        public class Tree
{
public int Height {get;set;}
public int MaxLeft {get;set;}
public int MaxTop {get;set;}
public int MaxRight {get;set;}
public int MaxBottom {get;set;}
public bool IsVisible {get {return Height<=MaxLeft && Height<=MaxTop && Height<=MaxRight && Height<=MaxBottom;}}
}

        private void SolvePart1(string input, int result)
        {       
            string[] eachCarry = input.Split("\n");

int maxSize = eachCarry[0].Lenght;
Tree[,] trees = new Tree[0..massive,0..maxSize];
            
            int actual = 11111;

            Xunit.Assert.Equal(result, actual);
        }

        private void SolvePart2(string input, int result)
        {
            int actual = 11111;

            Xunit.Assert.Equal(result, actual);
        }

        [Fact]
        public void Introduction1()
        {
            SolvePart1(File.ReadAllText("Day8_Introduction.txt"), 95437);
        }

        [Fact]
        public void Introduction2()
        {
            SolvePart2(File.ReadAllText("Day8_Introduction.txt"), 0);
        }

        [Fact]
        public void PuzzlePart1()
        {

            SolvePart1(File.ReadAllText("Day8_Puzzle.txt"), 0);
        }

        [Fact]
        public void PuzzlePart2()
        {

            SolvePart2(File.ReadAllText("Day8_Puzzle.txt"), 0);
        }
    }
}
