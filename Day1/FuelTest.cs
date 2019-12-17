using Xunit;
using System.Collections.Generic;
using System.IO;

public class FuelTest
{
    string[] input = File.ReadAllLines("../../../input.txt");
    [Fact]
    public void Puzzle_Input_All_Count() 
    {
        Assert.Equal(3386686, rocket_equations.Rocket.FuelReqs(input));
    }
    [Fact]
    public void Test_Input_All_Count() 
    {
        Assert.Equal(2, rocket_equations.Rocket.FuelReqs(12));
    }
    [Fact]
    public void Test_Input_Again() 
    {
        Assert.Equal(2, rocket_equations.Rocket.FuelReqs(14));
    }
    [Fact]
    public void Test_Input_Large() 
    {
        Assert.Equal(654, rocket_equations.Rocket.FuelReqs(1969));
    }
    [Fact]
    public void Test_Input_Larger() 
    {
        Assert.Equal(33583, rocket_equations.Rocket.FuelReqs(100756));
    }
    [Fact]
    public void Fuel_Test_Input()
    {
        Assert.Equal(2, rocket_equations.Rocket.FullReqs(14));
    }
    [Fact]
    public void Fuel_Test_Input_Large()
    {
        Assert.Equal(966, rocket_equations.Rocket.FullReqs(1969));
    }

    [Fact]
    public void Fuel_Test_Input_Larger()
    {
        Assert.Equal(50346, rocket_equations.Rocket.FullReqs(100756));
    }

    [Fact]
    public void Puzzle_Input()
    {
        Assert.Equal(5077155, rocket_equations.Rocket.FullReqs(input));
    }
}
