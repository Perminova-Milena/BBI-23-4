using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сложныйуровень
{


    public abstract class Task
    {
        public abstract string ToString(string text);
    }

    public class Task8 : Task
    {
        public override string ToString(string text)
        {
            int maxLineLength = 50;
            string[] words = text.Split(' ');

            List<string> lines = new List<string>();
            StringBuilder currentLine = new StringBuilder();

            foreach (string word in words)
            {
                if (currentLine.Length + word.Length <= maxLineLength)
                {
                    currentLine.Append(word).Append(' ');
                }
                else
                {
                    lines.Add(currentLine.ToString().TrimEnd());
                    currentLine = new StringBuilder(word + ' ');
                }
            }
            lines.Add(currentLine.ToString().TrimEnd());

            string formattedText = FormatLines(lines, maxLineLength);
            return "Задача 8 \n" + formattedText;
        }

        private string FormatLines(List<string> lines, int maxLineLength)
        {
            StringBuilder formattedText = new StringBuilder();

            foreach (string line in lines)
            {
                string[] words = line.Split();
                int totalWordLength = words.Sum(word => word.Length);
                int totalSpacesToAdd = maxLineLength - totalWordLength;
                int spacePerWord = words.Length > 1 ? totalSpacesToAdd / (words.Length - 1) : 0;
                int extraSpaces = words.Length > 1 ? totalSpacesToAdd % (words.Length - 1) : 0;

                StringBuilder formattedLine = new StringBuilder();

                for (int i = 0; i < words.Length - 1; i++)
                {
                    formattedLine.Append(words[i]);
                    formattedLine.Append(' ', spacePerWord + (extraSpaces > 0 ? 1 : 0));
                    extraSpaces = Math.Max(0, extraSpaces - 1);
                }

                formattedLine.Append(words[words.Length - 1]);
                formattedText.AppendLine(formattedLine.ToString());
            }

            return formattedText.ToString();
        }
    }

    public class Task9 : Task
    {
        public override string ToString(string text)
        {
            Dictionary<string, int> pairCounts = new Dictionary<string, int>();
            List<string> frequentPairs = new List<string>();
            string compressedText = text;
            Dictionary<char, string> codeTable = new Dictionary<char, string>();
            // Поиск часто встречающихся пар символов
            for (int i = 0; i < text.Length - 1; i++)
            {
                string pair = text.Substring(i, 2);
                if (pairCounts.ContainsKey(pair))
                {
                    pairCounts[pair]++;
                }
                else
                {
                    pairCounts[pair] = 1;
                }
            }

            // Формирование списка часто встречающихся пар символов
            foreach (var pair in pairCounts)
            {
                if (pair.Value > 8)
                {
                    frequentPairs.Add(pair.Key);
                }
            }
            string result = "";

            // Сжатие текста
            char code = '#';
            foreach (var pair in frequentPairs)
            {
                codeTable.Add(code, pair);
                compressedText = compressedText.Replace(pair, code.ToString());
                code++;
            }
            result += "Таблица кодов\n";
            foreach (var kod in codeTable)
            {
                result += kod.Key + ": " + kod.Value + "\n";
            }
            result += compressedText + "\n";

            return "Задача 9:\n" + result;
        }
    }


    public class Task10 : Task
    {
        public override string ToString(string text)
        {
            Dictionary<string, int> pairCounts = new Dictionary<string, int>();
            List<string> frequentPairs = new List<string>();
            string compressedText = text;
            Dictionary<char, string> codeTable = new Dictionary<char, string>();
            // Поиск часто встречающихся пар символов
            for (int i = 0; i < text.Length - 1; i++)
            {
                string pair = text.Substring(i, 2);
                if (pairCounts.ContainsKey(pair))
                {
                    pairCounts[pair]++;
                }
                else
                {
                    pairCounts[pair] = 1;
                }
            }

            // Формирование списка часто встречающихся пар символов
            foreach (var pair in pairCounts)
            {
                if (pair.Value > 8)
                {
                    frequentPairs.Add(pair.Key);
                }
            }
            string result = "Декодированный текст \n";
            // Сж текста
            char code = '#';
            foreach (var pair in frequentPairs)
            {
                codeTable.Add(code, pair);
                compressedText = compressedText.Replace(pair, code.ToString());
                code++;
            }

            foreach (var kod in codeTable)
            {
                compressedText = compressedText.Replace(kod.Key.ToString(), kod.Value);
            }

            result += compressedText + "\n";
            return "Задача 10:\n" + result;
        }
    }

    public class Task12 : Task
    {
        public override string ToString(string text)
        {

            string result = "";
            Dictionary<string, string> codeTable = new Dictionary<string, string>(); // словр
            string[] words = text.Split(' ');
            codeTable.Add("морской", "***");
            codeTable.Add("водой", "@@@");
            codeTable.Add("происходит", "$$$");
            codeTable.Add("я", "##");
            codeTable.Add("добавил", "%%%");
            string newText = "";
            foreach (string word in words)
            {
                if (codeTable.ContainsKey(word))
                {
                    newText += codeTable[word] + " "; // зам  код  

                }
                else
                {
                    newText += word + " ";

                }
            }

            result += "Закодированный текст\n" + newText + "\n";

            foreach (var code in codeTable)
            {
                newText = newText.Replace(code.Value, code.Key); // заменяем наш код на слова  
            }
            result += "Декодированный текст\n" + newText + "\n";
            return "Задача 12:\n" + result;
        }
    }

    public class Task13 : Task
    {
        public override string ToString(string text)
        {
            string[] words = text.Split(' ');
            Dictionary<char, int> countOfFirsrLetters = new Dictionary<char, int>();

            for (int i = 0; i < words.Length; i++)
            {
                char firstLettr = words[i].ToLower()[0];// регистр и первая б

                if (countOfFirsrLetters.ContainsKey(firstLettr)) //  проверка
                {
                    countOfFirsrLetters[firstLettr]++;
                }
                else
                {
                    countOfFirsrLetters[firstLettr] = 1;
                }
            }
            int countWord = words.Length;// всего слов 
            string result = "";
            foreach (var letter in countOfFirsrLetters)
            {
                double procent = (double)letter.Value / countWord * 100;// количество повторений буквы 
                result += letter.Key + ": " + procent.ToString("0.00") + "% \n";
            }
            return "Задача 13:\n" + result;

        }
    }

    public class Task15 : Task
    {
        public override string ToString(string text)
        {
            string[] words = text.Split(' ');
            int sum = 0; for (int i = 0; i < words.Length; i++) // 
            {
                if (words[i].Length > 1)
                {
                    char poslednyuSimvol = (words[i][words[i].Length - 1]);
                    char pervuySimvol = (words[i][0]); if (Char.IsDigit(pervuySimvol) && !(Char.IsDigit(poslednyuSimvol))) //издиджит  пр сим чис 
                    {
                        words[i] = words[i].Substring(0, words[i].Length - 1); //убиарем последний симвлов 
                    }
                }
            }
            for (int i = 0; i < words.Length; i++)
            {
                if (int.TryParse(words[i], out int num)) // строку в число
                {
                    sum += num;
                }
            }
            return "Задача 15:\n" + sum.ToString();

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string text = "William Shakespeare, widely regarded as one of the greatest writers in the English language, authored a total of 37 plays, along with numerous poems and sonnets. He was born in Stratford-upon-Avon, England, in 1564, and died in 1616. Shakespeare's most famous works, including \"Romeo and Juliet,\" \"Hamlet,\" \"Macbeth,\" and \"Othello,\" were written during the late 16th and early 17th centuries. \"Romeo and Juliet,\" a tragic tale of young love, was penned around 1595. \"Hamlet,\" one of his most celebrated tragedies, was written in the early 1600s, followed by \"Macbeth,\" a gripping drama exploring themes of ambition and power, around 1606. \"Othello,\" a tragedy revolving around jealousy and deceit, was also composed during this period, believed to be around 1603.";
            Task[] tasks = new Task[] {
                    new Task8(),
                    new Task9(),
                    new Task10(),
                    new Task12(),
                    new Task13(),
                    new Task15()
                };

            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i] is Task12)
                {
                    Console.WriteLine("Введите текст для 12 задания (используйте какие-то из этих слов: морской, водой, происходит, я, добавил):");
                    Console.WriteLine(tasks[i].ToString(Console.ReadLine()));
                }
                else
                {
                    Console.WriteLine(tasks[i].ToString(text));
                }
                Console.WriteLine();
            }
        }
    }
}


