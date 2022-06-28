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
                        Array.Resize(ref fullName, fullName.Length + 1);
                        Array.Resize(ref job, job.Length + 1);
                        Console.WriteLine("Введите ФИО:");
                        fullName[number] = Console.ReadLine();
                        Console.WriteLine("Введите должность:");
                        job[number] = Console.ReadLine();
                        number++;
                        break;
                    case 2:

                        for (int i = 0; i < fullName.Length; i++)
                        {
                            Console.WriteLine($"{index}.{fullName[i]} - {job[i]}");
                            index++;
                        }

                        break;
                    case 3:
                        Console.WriteLine("Для использования этой функции меню следует сначала использовaть функцию меню 2.");
                        Console.WriteLine("Продолжить?\nYes No");
                        string userInput = Console.ReadLine().ToLower();

                        if (userInput == "no")
                            break;
                        else
                        {
                            Console.WriteLine("Введите номер досье по индексу:");
                            index = int.Parse(Console.ReadLine()) - 1;

                            for (int i = 0; i < fullName.Length + 1; i++)
                            {
                                if (index == i)
                                {
                                    fullName[i] = null;
                                    job[i] = null;
                                    if (index < fullName.Length - 1)
                                    {
                                        fullName[i] = fullName[i + 1];
                                        job[i] = job[i + 1];
                                        Array.Resize(ref fullName, fullName.Length - 1);
                                        Array.Resize(ref job, job.Length - 1);
                                    }
                                    else
                                    {
                                        Array.Resize(ref fullName, fullName.Length - 1);
                                        Array.Resize(ref job, job.Length - 1);
                                    }

                                    Console.WriteLine("Досье успешно удаленно!");
                                }
                                if (index > fullName.Length)
                                {
                                    Console.WriteLine("Такого досье нет!");
                                    break;
                                }
                            }
                        }
                        break;
                    case 4:
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
                        break;
                    case 5:
                        Console.Clear();
                        isWork = false;
                        break;

                }

                Console.WriteLine();
            }
        }
    }
}