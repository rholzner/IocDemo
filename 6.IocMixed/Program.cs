// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");


var serviceProvider = new ServiceCollection()
    .AddSingleton<FirstLevel>()
    .AddTransient<SecondLevel>()
    .BuildServiceProvider();



using (var lvls = serviceProvider.GetService<FirstLevel>())
{
    Console.WriteLine("halloo");
}

using (var lvls = serviceProvider.GetService<FirstLevel>())
{
    Console.WriteLine("halloo 1");
}

Console.WriteLine("Bye, World!");


public class FirstLevel : IDisposable
{
    public FirstLevel()
    {
        Console.WriteLine("FirstLevel created");
    }
    public void Dispose()
    {
        Console.WriteLine("FirstLevel disposed");
    }
}

public class SecondLevel : IDisposable
{
    public SecondLevel()
    {
        Console.WriteLine("SecondLevel created");
    }
    public void Dispose()
    {
        Console.WriteLine("SecondLevel disposed");
    }
}