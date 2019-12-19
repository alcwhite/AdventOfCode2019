using Xunit;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class WireTest
{
    static string[] testInput1Arr = {"R8,U5,L5,D3", "U7,R6,D4,L4"};
    List<string> testInput1 = testInput1Arr.ToList();
    static string[] testInput2Arr = {"R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83"};
    List<string> testInput2 = testInput2Arr.ToList();
    static string[] testInput3Arr = {"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"};
    List<string> testInput3 = testInput3Arr.ToList();
    static string[] inputArr = File.ReadAllLines("../../../input.txt");
    List<string> input = inputArr.ToList();
    [Fact]
    public void Part1_Puzzle() 
    {
        Assert.Equal(3247, wire_sorting.Wires.MinDistance(input));
    }
    [Fact]
    public void Part1_Test1() 
    {
        Assert.Equal(6, wire_sorting.Wires.MinDistance(testInput1));
    }
    [Fact]
    public void Part1_Test2() 
    {
        Assert.Equal(159, wire_sorting.Wires.MinDistance(testInput2));
    }
    [Fact]
    public void Part1_Test3() 
    {
        Assert.Equal(135, wire_sorting.Wires.MinDistance(testInput3));
    }

    [Fact]
    public void Part2_Puzzle() 
    {
        Assert.Equal(48054, wire_sorting.Wires.Steps(input));
    }
    [Fact]
    public void Part2_Test1() 
    {
        Assert.Equal(30, wire_sorting.Wires.Steps(testInput1));
    }
    [Fact]
    public void Part2_Test2() 
    {
        Assert.Equal(610, wire_sorting.Wires.Steps(testInput2));
    }
    [Fact]
    public void Part2_Test3() 
    {
        Assert.Equal(410, wire_sorting.Wires.Steps(testInput3));
    }
}
