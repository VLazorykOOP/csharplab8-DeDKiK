// завдання 1

using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string filePath = @"C:\Users\deres\source\repos\lab8\lab8\file.txt"; // Замініть шлях до вашого файлу
        string newFilePath = @"C:\Users\deres\source\repos\lab8\lab8\newFile.txt"; // Замініть шлях до нового файлу
        string text = File.ReadAllText(filePath);
        string emailPattern = @"\b[A-Za-z0-9._%+-]+@gmail.com\b";

        // Знаходимо всі електронні адреси Gmail
        MatchCollection emailMatches = Regex.Matches(text, emailPattern);

        // Записуємо електронні адреси у новий файл і підраховуємо їх кількість
        int count = 0;
        using (StreamWriter sw = new StreamWriter(newFilePath))
        {
            foreach (Match emailMatch in emailMatches)
            {
                sw.WriteLine(emailMatch.Value);
                count++;
            }
        }

        Console.WriteLine($"Знайдено електронних адрес: {count}");

        // Вилучення та заміна електронних адрес (приклад)
        string toRemove = "example@gmail.com"; // Електронна адреса для вилучення
        string replacement = "newexample@gmail.com"; // Електронна адреса для заміни

        text = Regex.Replace(text, toRemove, replacement);
        File.WriteAllText(filePath, text); // Записуємо змінений текст назад у файл
    }
}
