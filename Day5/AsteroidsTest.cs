using Xunit;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class AsteroidsTest
{
    string puzzleInput = File.ReadAllText("../../../input.txt", Encoding.UTF8);
    string testInput1 = "1,9,10,3,2,3,11,0,99,30,40,50";
    string testOutput1 = "3500,9,10,70,2,3,11,0,99,30,40,50";
    int testResult1 = 3500;
    string testInput2 = "1,0,0,0,99";
    string testOutput2 = "2,0,0,0,99";
    int testResult2 = 2;
    string testInput3 = "2,3,0,3,99";
    string testOutput3 = "2,3,0,6,99";
    int testResult3 = 2;
    string testInput4 = "2,4,4,5,99,0";
    string testOutput4 = "2,4,4,5,99,9801";
    int testResult4 = 2;
    string testInput5 = "1,1,1,4,99,5,6,0,99";
    string testOutput5 = "30,1,1,4,2,5,6,0,99";
    int testResult5 = 30;

    [Fact]
    public void Part1_Puzzle()
    {
        Assert.Equal(9706670, asteroid_puzzle.Asteroid.AlarmResult(puzzleInput));
    }
}