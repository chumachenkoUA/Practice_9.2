using System.Globalization;
using Practice_9._2;

string filePath = "/home/kirito/Документи/holidays.txt";

if (!File.Exists(filePath))
{
    using (StreamWriter writer = new StreamWriter(filePath))
    {
        writer.WriteLine("Новий Рік;01.01.2025");
        writer.WriteLine("Різдво;07.01.2025");
        writer.WriteLine("День Незалежності;24.08.2025");
        writer.WriteLine("Всесвітній день жінок;08.03.2025");
        writer.WriteLine("Святий Миколоай;19.12.2025");
    }
}

List<Holiday> holidays = new List<Holiday>();

using (StreamReader reader = new StreamReader(filePath))
{
    string? line;

    while ((line = reader.ReadLine()) != null)
    {
        string[] parts = line.Split(';');

        if (parts.Length == 2)
        {
            if (DateTime.TryParseExact(parts[1], "dd.MM.yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out DateTime date))
            {
                Holiday holiday = new Holiday(parts[0], date);
                holidays.Add(holiday);
            }
        }
    }
}

Console.WriteLine("Зимові свята:");
foreach (var holiday in holidays)
{
    if (holiday.IsWinter())
    {
        Console.WriteLine(holiday);
    }
}

Holiday? closest = null;
DateTime now = DateTime.Now;

foreach (var holiday in holidays)
{
    if (holiday.GetDate() >= now)
    {
        if (closest == null || holiday.GetDate() < closest.GetDate())
        {
            closest = holiday;
        }
    }
}

Console.WriteLine();
if (closest != null)
{
    Console.WriteLine("Найближче свято:");
    Console.WriteLine(closest);
}