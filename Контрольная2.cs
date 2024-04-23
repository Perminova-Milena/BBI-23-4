using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp123
{


    #region общие элементы для 2-х заданий по строкам должны быть в базовом классе
    abstract class Task
    {
        protected static string text = "История науки – это история процесса накопления знаний многими поколениями людей, их осмысления и оформления в теориях ученых-одиночек, их пересмотра и применения в практике. Она давно выстроена историками, отшлифована ими и растиражирована в тысячах книг.\r\n\r\nНаверное, никто не скажет наверняка, кто первый открыл огонь, изобрел орудия труда, оружие и кто изобрел колесо. Неизвестно, кто первый пытался объяснить восход и закат солнца.";

        public string Text
        {
            get => text;
            protected set => text = value;
        }
        public Task()
        {

        }

        public abstract string ToString();

    }

    class Task1 : Task // На вход подается текст. На выход - целое число . Посчитать, сколько в тексте уникальных ( не повторяющихся слов)
    {

        public Task1() : base() { }
        public override string ToString()
        {

            string[] words = text.Split(new[] { ' ', ',', '.', '!', '?', ';', ':', '"', '\'', '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            // Подсчет уникальных слов
            var uniqueWords = new HashSet<string>(words, StringComparer.OrdinalIgnoreCase);

            return "Кол-во уникальных слов: " + uniqueWords.Count;
        }


    }
    class Task2 : Task // На вход подается текст. На выход - дробное число . Подсчитать среднюю длину слов в текстею
    {
        private double avarageValue = 1;
        public double AarageValue
        {
            get => avarageValue;
            private set => avarageValue = value;
        }

        public Task2() : base()
        {

        }


        public override string ToString()
        {
            string[] words = text.Split(new[] { ' ', ',', '.', '!', '?', ';', ':', '"', '\'', '-', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;
            foreach (string word in words)
            {
                sum += word.Length;
            }
            avarageValue = sum / words.Length;

            return "Средняя длина слова: " + avarageValue;
        }
    }
    #endregion

    class Program
    {
        static void Main()
        {
            #region 
            Task[] tasks = {
            new Task1(),
            new Task2()

            };
            Console.WriteLine(tasks[0].ToString());
            Console.WriteLine(tasks[1].ToString());
            #endregion

            #region 
            string path = @"C:\Загрузки"; // Исходная папка на компьютере
            string folderName = "Test";


            string solutionFolder = Path.Combine(path, folderName);

            if (!Directory.Exists(solutionFolder))
            {

                Directory.CreateDirectory(solutionFolder);
            }


            string fileName1 = Path.Combine(solutionFolder, "cw2_1.json");
            string fileName2 = Path.Combine(solutionFolder, "cw2_2.json");

            if (!File.Exists(fileName1))
            {

                File.Create(fileName1).Close();
            }

            if (!File.Exists(fileName2))
            {

                File.Create(fileName2).Close();
            }

            Console.WriteLine("Подпапка и файлы успешно созданы.");

            #endregion

        }
    }
}
