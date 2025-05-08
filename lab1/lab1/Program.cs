/// <summary>
/// Основний клас програми.
/// </summary>
internal class Program
{
    /// <summary>
    /// Головна точка входу в програму.
    /// </summary>
    /// <param name="args">Аргументи командного рядка.</param>
    static void Main(string[] args)
    {
        Hello hello = new Hello();
        hello.Greet();
    }
}

/// <summary>
/// Клас для виведення привітання.
/// </summary>
public class Hello
{
    /// <summary>
    /// Виводить привітання у консоль.
    /// </summary>
    public void Greet()
    {
        Console.WriteLine("Hello, World!");
    }
}