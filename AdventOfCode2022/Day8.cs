using System.Text;

namespace AdventOfCode2022
{
    public class Day8
    {
        public class AdventFile
        {
            public string Name { get; set; }
            public int Length { get; set; }
        }
        public class Directory
        {
            public Directory(string name, Directory parent)
            {
                Parent = parent;
                Name = name;
                Directories = new List<Directory>();
                Files = new List<AdventFile>();
            }
            public Directory Parent { get; set; }
            public string Name { get; set; }
            public List<Directory> Directories { get; set; }
            public List<AdventFile> Files { get; set; }
        }

        private void SolvePart1(string input, int result)
        {
            string[] eachCarry = input.Split("\n");

            Directory rootDir = new Directory("",null);
            Directory currentDir = null;
            foreach (string eachCarryItem in eachCarry)
            {
                if (eachCarryItem.StartsWith("$ cd /"))
                {
                    currentDir = rootDir;
                }
                else if (eachCarryItem == "$ ls")
                {
                }
                else if (eachCarryItem.StartsWith("$ cd"))
                {

                }
                else if (eachCarryItem.StartsWith("dir "))
                {
                    Directory newDir = new Directory(eachCarryItem.Substring(5), currentDir);
                    currentDir.Directories.Add(newDir);
                }
                else
                {
                    string[] splittedFile = eachCarryItem.Split(" ");
                    AdventFile newFile = new AdventFile { Name = splittedFile[1], Length = Int32.Parse(splittedFile[0]) };
                    currentDir.Files.Add(newFile);
                }
            }

            //foreach (Directory item in rootDir)
            //{

            //}
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
