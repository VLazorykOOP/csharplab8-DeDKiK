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
// завдання 2
using System;
using System.IO;
using System.Text.RegularExpressions;

class HexToPlusConverter
{
    public static void Main()
    {
        string sourceFilePath = @"C:\Users\deres\source\repos\lab8\lab8\task2file.txt"; // Вкажіть шлях до вашого вихідного файлу
        string destinationFilePath = @"C:\Users\deres\source\repos\lab8\lab8\task2newFile.txt"; // Вкажіть шлях до файлу результату

        // Читаємо вміст вихідного файлу
        string content = File.ReadAllText(sourceFilePath);

        // Замінюємо всі шістнадцяткові цифри на знак '+'
        string modifiedContent = Regex.Replace(content, "[0-9a-fA-F]", "+");

        // Записуємо змінений вміст у новий файл
        File.WriteAllText(destinationFilePath, modifiedContent);

        Console.WriteLine("Шістнадцяткові цифри були замінені на знак '+'.");
    }
}
//завдання 3
using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        string inputFilePath = @"C:\Users\deres\source\repos\lab8\lab8\task3in.txt"; // Вкажіть шлях до вашого вхідного файлу
        string outputFilePath = @"C:\Users\deres\source\repos\lab8\lab8\task3out.txt"; // Вкажіть шлях до файлу результату

        // Читаємо вміст вхідного файлу
        string text = File.ReadAllText(inputFilePath);

        // Розділяємо текст на слова
        string[] words = Regex.Split(text, @"\W+");

        using (StreamWriter writer = new StreamWriter(outputFilePath))
        {
            foreach (string word in words)
            {
                if (word.Length % 2 != 0) // Перевіряємо, чи є довжина слова непарною
                {
                    // Вилучаємо середню літеру
                    string newWord = word.Remove(word.Length / 2, 1);
                    writer.Write(newWord + " ");
                }
                else
                {
                    writer.Write(word + " ");
                }
            }
        }

        Console.WriteLine("Операція завершена. Перевірте файл результату.");
    }
}
// завдання 4

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Задана послідовність чисел
        double[] numbers = { 1.5, 2.3, 3.7, 4.2, 5.9, 6.1, 7.4 };
        // Задане число для порівняння
        double comparisonNumber = 4.0;

        // Шлях до файлу для запису
        string filePath = @"C:\Users\deres\source\repos\lab8\lab8\task4numbers.txt";

        // Запис чисел у файл
        File.WriteAllLines(filePath, numbers.Select(n => n.ToString()));

        // Виведення на екран чисел з непарними індексами, які більші за задане число
        for (int i = 0; i < numbers.Length; i += 2)
        {
            if (numbers[i] > comparisonNumber)
            {
                Console.WriteLine($"Число з непарним індексом {i + 1} та більше за {comparisonNumber}: {numbers[i]}");
            }
        }
    }
}
