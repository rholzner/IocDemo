// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");



var lvls = new FirstLevel(new SecondLevel(new ThirdLevel(new FourthLevel())));



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