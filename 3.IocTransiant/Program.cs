// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");


var serviceProvider = new ServiceCollection()
    .AddTransient<FirstLevel>()
    .BuildServiceProvider();

using (var lvls = serviceProvider.GetService<FirstLevel>())
{
    Console.WriteLine("halloo");
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