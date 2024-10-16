using System;
using System.Globalization;
using System.Text;

public enum TypMagazynu
{
    Prodyktovyi,
    Hospodarskyi,
    Odiag,
    Vzuttia
}

public class Magazin : IDisposable
{
    public string Nazva { get; set; }
    public string Adresa { get; set; }
    public TypMagazynu Typ { get; set; }
    private bool disposed = false;

    public Magazin(string nazva, string adresa, TypMagazynu typ)
    {
        Nazva = nazva;
        Adresa = adresa;
        Typ = typ;
        Console.WriteLine("Магазин створений.");
    }

    ~Magazin()
    {
        Dispose(false);
        Console.WriteLine("Деструктор магазину викликаний.");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Назва: {Nazva}, Адреса: {Adresa}, Тип: {Typ}");
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
                Console.WriteLine("Звільнення керованих ресурсів магазину.");
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

        Console.WriteLine("Тестування класу «Магазин»:");
        using (var magazin = new Magazin("АТБ", "вул. Соборна, 12", TypMagazynu.Prodyktovyi))
        {
            magazin.ShowInfo();
        }
        Console.WriteLine("Кінець програми.");
    }
}
