using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace lab_2
{
    internal class Program
    {
        public static List<Applicant> AddApplicant(List<Applicant> applicantsList, int index)
        {           
            Applicant myApplicant = new Applicant();
            
            Console.Write("Введите фамилию абитуриента: ");
            myApplicant.LastName = Console.ReadLine();

            Console.Write("Введите балл по математике: ");
            if (int.TryParse(Console.ReadLine(), out int MathScore))
            {
                myApplicant.MathScore = MathScore;
                myApplicant.SumScore += MathScore;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Будет присвоено значение по умолчанию: " + Applicant.DEFAULT_SCORE);
                myApplicant.MathScore = Applicant.DEFAULT_SCORE;
            }

            Console.Write("Введите балл по русскому языку: ");
            if (int.TryParse(Console.ReadLine(),out int RussianLanguageScore))
            {
                myApplicant.RussianLanguageScore = RussianLanguageScore;
                myApplicant.SumScore += RussianLanguageScore;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Будет присвоено значение по умолчанию: " + Applicant.DEFAULT_SCORE);
                myApplicant.RussianLanguageScore = Applicant.DEFAULT_SCORE;
            }

            Console.Write("Введите балл по английскому языку: ");
            if (int.TryParse(Console.ReadLine(), out int EnglishLanguageScore))
            {
                myApplicant.EnglishLanguageScore = EnglishLanguageScore;
                myApplicant.SumScore += EnglishLanguageScore;
            }
            else
            {
                Console.WriteLine("Неверный ввод. Будет присвоено значение по умолчанию: " + Applicant.DEFAULT_SCORE);
                myApplicant.EnglishLanguageScore = Applicant.DEFAULT_SCORE;
            }

            applicantsList.Insert(index, myApplicant);          
            Console.WriteLine("Абитуриент добавлен в список.");
            return applicantsList;
        }

        public static void Main(string[] args)
        {
            int index = 0;
            int applicantsCounter = 0;
            string selector = null;
            string filename = "applicants.dat";

            int MIN_SUM_SCORE = -1;
            int MIN_MATH_SCORE = -1;
            int MIN_RUSSIAN_LANGUAGE_SCORE = -1;
            int MIN_ENGLISH_LANGUAGE_SCORE = -1;

            int TOP_SUM_SCORES = 3;

            List<Applicant> applicantsList = new List<Applicant>();
            Console.WriteLine($"Название файла по умолчанию: {filename}");
            Console.Write("Введите название файла: ");
            filename = Console.ReadLine();

            if (File.Exists(filename)) //чтение объектов класса из бинарного файла
            {
                using (BinaryReader binaryReader = new BinaryReader(File.Open(filename, FileMode.OpenOrCreate)))
                {
                    while (binaryReader.PeekChar() != -1)
                    {
                        Applicant myApplicant = new Applicant();
                        myApplicant.LastName = binaryReader.ReadString();
                        myApplicant.MathScore = binaryReader.ReadInt32();
                        myApplicant.RussianLanguageScore = binaryReader.ReadInt32();
                        myApplicant.EnglishLanguageScore = binaryReader.ReadInt32();
                        myApplicant.SumScore = binaryReader.ReadInt32();
                        applicantsList.Add(myApplicant);
                    }
                }
            }

            do
            {
                selector = null;

                Console.Clear();
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("|                              Г Л А В Н О Е   М Е Н Ю                                  |");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.WriteLine("|1.| Добавить абитуриента в произвольное место списка.                                  |");
                Console.WriteLine("|2.| Вывести список абитуриентов.                                                       |");
                Console.WriteLine("|3.| Удаление абитуриента из произвольного места списка.                                |");
                Console.WriteLine("|4.| Выполнить сортировку по фамилии.                                                   |"); 
                Console.WriteLine("|5.| Задать минимальную сумму баллов и минимально кол-во баллов по каждой дисциплине.   |");
                Console.WriteLine($"|6.| Вывести список абитуриентов, имеющих наибольшую сумму баллов (топ {TOP_SUM_SCORES}).              |");
                Console.WriteLine("|7.| Вывести список абитуриентов, не выдержавших конкурс.                               |");
                Console.WriteLine("|q.| Выход.                                                                             |");
                Console.WriteLine("-----------------------------------------------------------------------------------------");
                Console.Write("Введите пункт меню: ");

                selector = Console.ReadLine();

                switch (selector)
                {
                    case "1":
                        {                           
                            if (applicantsList.Count == 0)
                            {
                                index = 0;
                            }
                            else
                            {
                                do
                                {
                                    Console.Write($"Введите номер от 0 до {applicantsList.Count} для вставки абитуриента в список: ");
                                    if (int.TryParse(Console.ReadLine(), out index) && (index >= 0 && index <= applicantsList.Count))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный ввод.");
                                        continue;
                                    }
                                } while (true);
                            }
                            AddApplicant(applicantsList, index);
                            Console.ReadLine();
                            break;
                        }

                    case "2":
                        {
                            applicantsCounter = 0;
                            if (applicantsList.Count != 0)
                            {
                                Console.WriteLine("-----------------------------------------------------------------------------------------");
                                Console.WriteLine("| №. |        Фамилия      |   Матем.   |    Рус. яз.   |   Англ. яз.   | Сумма баллов  |");
                                Console.WriteLine("-----------------------------------------------------------------------------------------");
                                foreach (Applicant applicant in applicantsList)
                                {
                                    Console.WriteLine($"| {applicantsCounter++}. {applicant}");
                                }
                                Console.WriteLine("-----------------------------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Список пуст.");
                            }
                            Console.ReadLine();
                            break;
                        }

                    case "3":
                        
                        if (applicantsList.Count != 0)
                        {
                            if (applicantsList.Count == 1)
                            {
                                index = 0;
                            }
                            else
                            {
                                do
                                {
                                    Console.Write($"Введите номер абитуриента от 0 до {applicantsList.Count - 1} для удаления его из списка: ");
                                    if (int.TryParse(Console.ReadLine(), out index) && (index >= 0 && index <= applicantsList.Count - 1))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Неверный ввод.");
                                        continue;
                                    }

                                } while (true);
                            }

                            applicantsList.RemoveAt(index);
                            Console.WriteLine($"Абитуриент с индексом {index} удален из списка.");
                        }
                        else
                        {
                            Console.WriteLine("Список пуст.");
                        }
                        Console.ReadLine();
                        break;
                    case "4":
                        {                           
                            if (applicantsList.Count != 0)
                            {
                                if (applicantsList.Count != 1)
                                {
                                    applicantsList.Sort(delegate (Applicant x, Applicant y)
                                    {
                                        if (x.LastName == null && y.LastName == null)
                                            return 0;
                                        else if (x.LastName == null)
                                            return -1;
                                        else if (y.LastName == null)
                                            return 1;
                                        else
                                            return x.LastName.CompareTo(y.LastName);
                                    });
                                }
                                Console.WriteLine("Список отсортирован.");
                            }
                            else
                            {
                                Console.WriteLine("Список пуст.");
                            }
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            do
                            {
                                Console.Write("Введите минимальную сумму баллов: ");
                                if (int.TryParse(Console.ReadLine(), out MIN_SUM_SCORE) && (MIN_SUM_SCORE >= 0 && MIN_SUM_SCORE <= 300))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Неверный ввод.");
                                    continue;
                                }
                            } while (true);

                            do
                            {
                                Console.Write("Введите минимальное количество баллов по математике: ");
                                if (int.TryParse(Console.ReadLine(), out MIN_MATH_SCORE) && (MIN_MATH_SCORE >= 0 && MIN_MATH_SCORE <= 100))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Неверный ввод.");
                                    continue;
                                }
                            } while (true) ;

                            do
                            {
                                Console.Write("Введите минимальное количество баллов по русскому языку: ");
                                if (int.TryParse(Console.ReadLine(), out MIN_RUSSIAN_LANGUAGE_SCORE) && (MIN_RUSSIAN_LANGUAGE_SCORE >= 0 && MIN_RUSSIAN_LANGUAGE_SCORE <= 100))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Неверный ввод.");
                                    continue;
                                }
                            } while (true);

                            do
                            {
                                Console.Write("Введите минимальное количество баллов по английскому языку: ");
                                if (int.TryParse(Console.ReadLine(), out MIN_ENGLISH_LANGUAGE_SCORE) && (MIN_ENGLISH_LANGUAGE_SCORE >= 0 && MIN_ENGLISH_LANGUAGE_SCORE <= 100))
                                {
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Неверный ввод.");
                                    continue;
                                }
                            } while (true);

                            Console.WriteLine("Данные успешно записаны.");
                            Console.ReadLine();
                            break;
                        }

                    case "6":
                        {
                            applicantsCounter = 0;
                            
                            if (applicantsList.Count != 0)
                            {
                                var result = applicantsList.OrderByDescending(temp => temp.SumScore);                                

                                Console.WriteLine("-----------------------------------------------------------------------------------------");
                                Console.WriteLine("| №. |        Фамилия      |   Матем.   |    Рус. яз.   |   Англ. яз.   | Сумма баллов  |");
                                Console.WriteLine("-----------------------------------------------------------------------------------------");
                                foreach (var item in result)
                                {
                                    Console.WriteLine($"| {applicantsCounter++}. {item}");
                                    if (applicantsCounter >= TOP_SUM_SCORES)
                                        break;
                                }
                                Console.WriteLine("-----------------------------------------------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine("Список пуст.");
                            }
                            Console.ReadLine();
                            break;
                        }
                    case "7":
                        {
                            if (applicantsList.Count != 0)
                            {
                                if (MIN_SUM_SCORE > 0)
                                {
                                    applicantsCounter = 0;
                                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                                    Console.WriteLine("| №. |        Фамилия      |   Матем.   |    Рус. яз.   |   Англ. яз.   | Сумма баллов  |");
                                    Console.WriteLine("-----------------------------------------------------------------------------------------");
                                    foreach (Applicant applicant in applicantsList)
                                    {
                                        if (applicant.SumScore < MIN_SUM_SCORE || applicant.MathScore < MIN_MATH_SCORE || applicant.EnglishLanguageScore < MIN_ENGLISH_LANGUAGE_SCORE  || applicant.RussianLanguageScore < MIN_RUSSIAN_LANGUAGE_SCORE)
                                            Console.WriteLine($"| {applicantsCounter++}. {applicant}");
                                    }
                                    Console.WriteLine("-----------------------------------------------------------------------------------------");

                                }
                                else
                                {
                                    Console.WriteLine("Сначала вам нужно задать минимальное количество баллов, для этого перейдите в пунтк меню '5'.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Список пуст.");
                            }
                            Console.ReadLine();
                            break;
                        }
                    case "q":
                        Console.WriteLine("Завершение работы программы.");                       
                        break;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        Console.ReadLine();
                        break;
                }
            } while (selector != "q");


            //запись в бинарный файл
            using (BinaryWriter binaryWriter = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                foreach (Applicant applicants in applicantsList)
                {
                    binaryWriter.Write(applicants.LastName);
                    binaryWriter.Write(applicants.MathScore);
                    binaryWriter.Write(applicants.RussianLanguageScore);
                    binaryWriter.Write(applicants.EnglishLanguageScore);
                    binaryWriter.Write(applicants.SumScore);
                }

                Console.WriteLine("Данные успешно записаны в файл.");
            }
        }
    }
}
