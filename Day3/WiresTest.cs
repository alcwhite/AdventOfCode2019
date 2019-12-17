using Xunit;
using System.Collections.Generic;
using System.IO;

public class FuelTest
{
    string[] testInput1 = {"R8,U5,L5,D3", "U7,R6,D4,L4"};
    string[] testInput2 = {"R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83"};
    string[] testInput3 = {"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7"};
    string[] input = File.ReadAllLines("../../../input.txt");
    [Fact]
    public void Part1_Puzzle() 
    {
        Assert.Equal(12, wire_sorting.Wires.ManhattanDistance(input));
    }
    [Fact]
    public void Part1_Test1() 
    {
        Assert.Equal(6, wire_sorting.Wires.ManhattanDistance(testInput1));
    }
    public void Part1_Test2() 
    {
        Assert.Equal(159, wire_sorting.Wires.ManhattanDistance(testInput2));
    }
    public void Part1_Test3() 
    {
        Assert.Equal(135, wire_sorting.Wires.ManhattanDistance(testInput3));
    }
}
