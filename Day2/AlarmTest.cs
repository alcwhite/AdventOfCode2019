using Xunit;
using System.Collections.Generic;
using System.Text;
using System.IO;

public class AlarmTest
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
    public void Part1_Test_1()
    {
        Assert.Equal(testResult1, alarm_puzzle.Alarm.AlarmResultTest(testInput1));
    }
    [Fact]
    public void Part1_Test_2()
    {
        Assert.Equal(testResult2, alarm_puzzle.Alarm.AlarmResultTest(testInput2));
    }
    [Fact]
    public void Part1_Test_3()
    {
        Assert.Equal(testResult3, alarm_puzzle.Alarm.AlarmResultTest(testInput3));
    }
    [Fact]
    public void Part1_Test_4()
    {
        Assert.Equal(testResult4, alarm_puzzle.Alarm.AlarmResultTest(testInput4));
    }
    [Fact]
    public void Part1_Test_5()
    {
        Assert.Equal(testResult5, alarm_puzzle.Alarm.AlarmResultTest(testInput5));
    }
    [Fact]
    public void Part1_Puzzle()
    {
        Assert.Equal(9706670, alarm_puzzle.Alarm.AlarmResult(puzzleInput));
    }
    [Fact]
    public void Part2_Puzzle()
    {
        Assert.Equal(19690720, alarm_puzzle.Alarm.LongResult(puzzleInput).result);
    }
    [Fact]
    public void Part2_Puzzle_Final()
    {
        Assert.Equal(3530, alarm_puzzle.Alarm.FinalOutput(puzzleInput));
    }
}