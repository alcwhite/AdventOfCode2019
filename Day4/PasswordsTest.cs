using Xunit;
using System.Collections.Generic;
using System.Linq;

public class PasswordsTest
{
    static string inputString = ("387638-919123");
    static List<string> inputList = inputString.Split('-').ToList();
    (int lowerBound, int upperBound) input = (lowerBound: int.Parse(inputList[0]), upperBound: int.Parse(inputList[1]));
    [Fact]
    public void Part1_Puzzle() 
    {
        Assert.Equal(466, password_puzzle.Passwords.PasswordCount(input));
    }
    [Fact]
    public void Part1_Test1() 
    {
        Assert.True(password_puzzle.Passwords.PasswordPasses(111111));
    }
    [Fact]
    public void Part1_Test2() 
    {
        Assert.False(password_puzzle.Passwords.PasswordPasses(223450));
    }
    [Fact]
    public void Part1_Test3() 
    {
        Assert.False(password_puzzle.Passwords.PasswordPasses(123789));
    }
    [Fact]
    public void Part2_Puzzle() 
    {
        Assert.Equal(292, password_puzzle.Passwords.PasswordCountForReal(input));
    }
    [Fact]
    public void Part2_Test1() 
    {
        Assert.True(password_puzzle.Passwords.PasswordPassesForReal(112233));
    }
    [Fact]
    public void Part2_Test2() 
    {
        Assert.False(password_puzzle.Passwords.PasswordPassesForReal(123444));
    }
    [Fact]
    public void Part2_Test3() 
    {
        Assert.True(password_puzzle.Passwords.PasswordPassesForReal(111122));
    }
    [Fact]
    public void Part2_Test4() 
    {
        Assert.True(password_puzzle.Passwords.PasswordPassesForReal(223333));
    }
    [Fact]
    public void Part2_Test5() 
    {
        Assert.True(password_puzzle.Passwords.PasswordPassesForReal(122333));
    }
    [Fact]
    public void Part2_Test6() 
    {
        Assert.True(password_puzzle.Passwords.PasswordPassesForReal(111223));
    }
}
