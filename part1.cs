using System;
using System.Globalization;
using System.Text;

public class Piesa : IDisposable
{
    public string Nazva { get; set; }
    public string Avtor { get; set; }
    public string Zhanr { get; set; }
    public int Rik { get; set; }
    private bool disposed = false;

    public Piesa(string nazva, string avtor, string zhanr, int rik)
    {
        Nazva = nazva;
        Avtor = avtor;
        Zhanr = zhanr;
        Rik = rik;
        Console.WriteLine("П'єса створена.");
    }

    ~Piesa()
    {
        Dispose(false);
        Console.WriteLine("Деструктор викликаний.");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Назва: {Nazva}, Автор: {Avtor}, Жанр: {Zhanr}, Рік: {Rik}");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Console.WriteLine("Звільнення керованих ресурсів.");
            }
            disposed = true;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        CultureInfo.CurrentCulture = new CultureInfo("uk-UA");
        CultureInfo.CurrentUICulture = new CultureInfo("uk-UA");

        Console.WriteLine("Тестування класу «П'єса»:");
        using (var piesa = new Piesa("Гамлет", "Вільям Шекспір", "Трагедія", 1600))
        {
            piesa.ShowInfo();
        }
        Console.WriteLine("Кінець програми.");
    }
}
