using System;
using System.Collections.Generic;

namespace lab_3
{
    class TestClass1 : IDisposable
    {
        private bool _disposed = false;

        // реализация интерфейса IDisposable.
        void IDisposable.Dispose()
        {
            Dispose();
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        ~TestClass1()
        {
            Dispose();
            Console.WriteLine($"Disposed {GetType().Name}");
        }

        public void Dispose()
        {
            _disposed = false ? true : false;
        }
    }

    class TestClass2 : IDisposable
    {
        private bool _disposed = false;

        // реализация интерфейса IDisposable.
        void IDisposable.Dispose()
        {
            Dispose();
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        ~TestClass2()
        {
            Dispose();
            Console.WriteLine($"Disposed {GetType().Name}");
        }

        public void Dispose()
        {
            _disposed = false ? true : false;
        }
    }

    internal class GC_Program : IDisposable
    {
        private bool _disposed = false;

        // реализация интерфейса IDisposable.
        void IDisposable.Dispose()
        {
            Dispose();
            // подавляем финализацию
            GC.SuppressFinalize(this);
        }

        ~GC_Program()
        {
            Dispose();
            Console.WriteLine($"Disposed {GetType().Name}");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        private const short MaxGarbage = 1000;

        static void Main()
        {
            string selector = default;

            TestClass1 testClass1 = null;
            TestClass2 testClass2 = null;
            GC_Program gcProgram = new GC_Program();
            List<IDisposable> list = new List<IDisposable>();

            Console.WriteLine("\nПервая часть программы:");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine($"The highest generation is {GC.MaxGeneration}");
            gcProgram.MakeSomeGarbage(testClass1, testClass2, list);
            list.Add(gcProgram);
            Console.WriteLine($"Generation: {GC.GetGeneration(gcProgram)}");
            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false)}");
            GC.Collect(0);
            Console.WriteLine($"Generation: {GC.GetGeneration(gcProgram)}");
            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false)}");
            GC.Collect(2);
            Console.WriteLine($"Generation: {GC.GetGeneration(gcProgram)}");
            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false)}");
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("\nВторая часть программы:");
            do
            {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("|1.| Вызвать сборщика мусора.                      |");
                Console.WriteLine("|2.| Удалить объекты из списка.                    |");
                Console.WriteLine("|3.| Вызвать метод 'Dispose' для объектов списка.  |");
                Console.WriteLine("|4.| Вывести поколения для всех объектов в списке. |");
                Console.WriteLine("|q.| Выход из программ.                            |");
                Console.WriteLine("----------------------------------------------------");
                Console.Write("Введите пункт меню: ");

                selector = Console.ReadLine();

                switch (selector)
                {
                    case "1":
                        {
                            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false)}");
                            GC.Collect();
                            Console.WriteLine("Вызван сборщик мусора.");
                            Console.WriteLine($"Total Memory: {GC.GetTotalMemory(false)}");
                            Console.ReadLine();

                            break;
                        }
                    case "2":
                        {
                            if (list.Count == 1)
                            {
                                Console.WriteLine($"В списке только экземпляр программы <{gcProgram.GetType().Name}>.");
                            }
                            else
                            {
                                ClearGarbage(list);
                                Console.WriteLine("Удаление прошло успешно.");
                            }
                            Console.ReadLine();

                            break;
                        }
                    case "3":
                        {
                            if (list.Count == 1)
                            {
                                Console.WriteLine($"В списке только экземпляр программы <{gcProgram.GetType().Name}>.");
                            }
                            else
                            {
                                foreach (var disposable in list)
                                {
                                    disposable.Dispose();
                                }

                                Console.WriteLine("Вызван метод 'Dispose'.");
                            }
                            Console.ReadLine();

                            break;
                        }
                    case "4":
                        {
                            if (list.Count == 1)
                            {
                                Console.WriteLine($"В списке только экземпляр программы <{gcProgram.GetType().Name}>.");
                            }
                            else
                            {
                                foreach (var disposable in list)
                                {
                                    Console.WriteLine(
                                        $"{disposable.GetType().Name}. Generation: {GC.GetGeneration(disposable)}");
                                }
                            }
                            Console.ReadLine();

                            break;
                        }
                    case "q":
                        {
                            Console.WriteLine("Завершение работы программы.");
                            Console.ReadLine();

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод.");
                            Console.ReadLine();

                            break;
                        }
                }
            } while (selector != "q");
        }

        private static void ClearGarbage(List<IDisposable> list)
        {
            for (int i = 0; i < MaxGarbage; ++i)
            {
                list.RemoveAt(0);
                list.RemoveAt(0);
            }
        }

        private void MakeSomeGarbage(TestClass1 testClass1, TestClass2 testClass2, List<IDisposable> list)
        {
            for (int i = 0; i < MaxGarbage; ++i)
            {
                testClass1 = new TestClass1();
                list.Add(testClass1);

                testClass2 = new TestClass2();
                list.Add(testClass2);
            }
        }
    }
}

