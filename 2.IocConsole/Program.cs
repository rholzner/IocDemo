// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

var serviceProvider = new ServiceCollection()
    .AddTransient<FirstLevel>()
    .AddTransient<SecondLevel>()
    .AddTransient<ThirdLevel>()
    .AddTransient<FourthLevel>()
    .BuildServiceProvider();


var lvls = serviceProvider.GetService<FirstLevel>();


public class FirstLevel
{
    public FirstLevel(SecondLevel secondLevel)
    {
        SecondLevel = secondLevel;
    }

    public SecondLevel SecondLevel { get; }
}

public class SecondLevel
{
    public SecondLevel(ThirdLevel thirdLevel)
    {
        ThirdLevel = thirdLevel;
    }

    public ThirdLevel ThirdLevel { get; }
}

public class ThirdLevel
{
    public ThirdLevel(FourthLevel fourthLevel)
    {
        FourthLevel = fourthLevel;
    }

    public FourthLevel FourthLevel { get; }
}

public class FourthLevel
{
    public FourthLevel()
    {

    }
}