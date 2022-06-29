using System;

namespace Task4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWork = true;
            int number = 0;
            string[] fullName = new string[number];
            string[] job = new string[number];

            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню: \n1.Добавить досье. \n2.Вывести досье. \n3.Удалить досье. \n4.Поиск по ФИО. \n5.Выход.");
                int state = int.Parse(Console.ReadLine());
                int index = 1;

                switch (state)
                {
                    case 1:
                        AddFile(ref fullName, ref job, number);
                        number++;
                        break;
                    case 2:
                        ViewFile(fullName, job, index);
                        break;
                    case 3:
                        DeleteFile(ref fullName, ref job, index);
                        break;
                    case 4:
                        SearchFullName(ref fullName);
                        break;
                    case 5:
                        isWork = false;
                        break;

                }

                Console.WriteLine();
            }
        }

        static void AddFile(ref string[] fullName, ref string[] job, int number)
        {
            Array.Resize(ref fullName, fullName.Length + 1);
            Console.WriteLine("Введите ФИО:");
            fullName[number] = Console.ReadLine();
            Array.Resize(ref job, job.Length + 1);
            Console.WriteLine("Введите должность:");
            job[number] = Console.ReadLine();
        }

        static void ViewFile(string[] fullName, string[] job, int index)
        {
            for (int i = 0; i < fullName.Length; i++)
            {
                Console.WriteLine($"{index}.{fullName[i]} - {job[i]}");
                index++;
            }
        }
        
        static void ReplacePlaceInArray(ref string[] fullName, ref string[] job, int index)
        {
            for (int i = 0; i < fullName.Length - 1; i++)
            {
                if (index == i && index < fullName.Length)
                {
                    fullName[i] = fullName[i + 1];
                    job[i] = job[i + 1];
                }
            }
            
            Array.Resize(ref fullName, fullName.Length - 1);
            Array.Resize(ref job, job.Length - 1);
        }


        static void DeleteFile(ref string[] fullName, ref string[] job, int index)
        {
            Console.WriteLine("Введите номер досье по индексу:");
            index = int.Parse(Console.ReadLine()) - 1;
            ReplacePlaceInArray(ref fullName, ref job, index);
            Console.WriteLine("Досье успешно удаленно!");

            if (index > fullName.Length)
            {
                Console.WriteLine("Такого досье нет!");
            }
        }

        static void SearchFullName(ref string[] fullName)
        {
            Console.WriteLine("Введите ФИО:");
            string userInputFullName = Console.ReadLine();

            for (int i = 0; i < fullName.Length; i++)
            {
                if (fullName[i] == userInputFullName)
                {
                    Console.WriteLine("Найдено!");
                    Console.WriteLine($"Индекс ФИО: {i + 1}");
                }
            }
        }
    }
}
