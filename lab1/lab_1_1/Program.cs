/*
Общая постановка задачи.
Работа состоит из последовательного выполнения трёх заданий: создание класса, иерархии классов и интерфейса.

    Первая часть.
В первой части необходимо разработать класс, согласно индивидуальному варианту, содержащий:
●	элементы разного уровня доступа (public и private);  
●	не менее 4 свойств;  
●	не менее 3 методов;  
●	перегрузку метода toString;  
●	статический метод;  
●	константное или поле только для чтения;  
●	не менее 3 конструкторов; 
    Рекомендуемые поля и методы указаны в варианте. Также необходимо написать программу с меню, позволяющую протестировать разработанный класс. Обязательные пункты меню:
●	Задание параметров конструируемого объекта
●	Вывод свойств объекта
●	Выполнение статического метода
●	Выполнение методов объекта

    Вторая часть
Во второй части необходимо разработать иерархию классов на основе созданного в первой части. В иерархию должно входить минимум пять классов. Корневой класс иерархии должен быть абстрактным, а хотя бы один класс из потомков – sealed. У каждого из классов должно быть хотя бы одно собственное свойство и метод. Также должны быть продемонстрированы виртуальные и переопределённые методы. Переопределенные методы должны также вызывать методы базового класса если это оправдано. В каждом классе должен быть метод, выводящий имя данного класса. Данный метод в объектах дочерних классов также должен вызывать аналогичный метод родительского класса.
Также необходимо написать программу с меню, позволяющую протестировать разработанную иерархию. Обязательные пункты меню:
●	Задание свойств каждого объекта. (хотя бы по одному объекту на не абстрактный класс)
●	Вывод свойств объекта
●	Выполнение методов объекта
●	Вывод имени класса объекта

    Третья часть
    В третьей части необходимо разработать общий интерфейс, для доступа к объектам классов разработанной иерархии. Интерфейс должен предоставлять доступ к общим для всех классов иерархии методам. Также необходимо добавить новый класс, не входящий в иерархию, однако так же реализующий разработанный интерфейс. Создать список объектов классов, реализующих разработанный интерфейс. Также создать функцию, принимающую в качестве параметра объект любого класса, реализующего интерфейс.
Также необходимо написать программу с меню, позволяющую протестировать работу списка. Обязательные пункты меню:
●	Добавление нового объекта выбранного пользователем класса в список
●	Вывод свойств объекта из списка
●	Выполнение методов объекта из списка
●	Вывод всех объектов в списке с указанием их классов
●	Выполнение созданной функции с указанным объектом из списка

Вариант 17
Чай..
Класс для первой части - эрл грей
Варианты свойств: страна-производитель, содержание бергамота, дата изготовления, объём
Варианты методов: заварить и выпить, заварить с молоком, microwave ,five o’clock(статический)
Возможные классы иерархии: чай(базовый), каркаде, зелёный, лапсанг сушонг.
Возможный интерфейс: IBreakfastDrink, дополнительный класс - кофе
*/


using System;

namespace lab_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string selector = null;
            var myEarlGrey = new EarlGrey();
            Console.WriteLine("Демонстарция класса 'EarGrey'.");
            do
            {
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine("|           Г Л А В Н О Е   М Е Н Ю            |");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("|1.| Задать параметры объекта.                 |");
                Console.WriteLine("|2.| Вывести свойства объекта.                 |");
                Console.WriteLine("|3.| Выполнить статический метод 'FiveOClock'. |");
                Console.WriteLine("|4.| Выполнить метод 'BrewTea'.                |");
                Console.WriteLine("|5.| Выполнить метод 'PrintTea'.               |");
                Console.WriteLine("|6.| Выполнить метод 'ChangeBergamot'.         |");
                Console.WriteLine("|q.| Выход из программы.                       |");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Введите пункт меню: ");

                selector = Console.ReadLine();

                switch (selector)
                {
                    case "1":
                        Console.WriteLine("\nДалее введите данные о чае.\n------------------------------------------------");
                        Console.WriteLine("Страна-производитель: ");
                        myEarlGrey.CountryProducer = Console.ReadLine();

                        Console.WriteLine("Содержание бергамота (0 - нет/ 1 - да): ");
                        var inputBergamot = Console.ReadLine();
                        switch (inputBergamot)
                        {
                            case "0":
                                if (myEarlGrey.Bergamot)
                                {
                                    myEarlGrey.ChangeBergamot();
                                }
                                break;

                            case "1":
                                if (!myEarlGrey.Bergamot)
                                {
                                    myEarlGrey.ChangeBergamot();
                                }
                                break;

                            default:
                                Console.WriteLine("Некорректный ввод.");
                                break;
                        }

                        Console.WriteLine("Объем: ");
                        var inputVolume = Console.ReadLine();
                        bool isVolumeConverted = int.TryParse(inputVolume, out var volume);
                        if (isVolumeConverted)
                        {
                            myEarlGrey.Volume = volume;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }

                        Console.WriteLine("Год изготовления: ");
                        var inputYear = Console.ReadLine();
                        bool isYearConverted = int.TryParse(inputYear, out var year);
                        if (isYearConverted)
                        {
                            myEarlGrey.Year = year;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }

                        Console.WriteLine("Месяц изготовления: ");
                        var inputMonth = Console.ReadLine();
                        bool isMonthConverted = int.TryParse(inputMonth, out var month);
                        if (isMonthConverted)
                        {
                            myEarlGrey.Month = month;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }

                        Console.WriteLine("День изготовления: ");
                        var inputDay = Console.ReadLine();
                        bool isDayConverted = int.TryParse(inputDay, out var day);
                        if (isDayConverted)
                        {
                            myEarlGrey.Day = day;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }

                        Console.WriteLine("Укажите количество часов на момент изготовления: ");
                        var inputHours = Console.ReadLine();
                        bool isHoursConverted = int.TryParse(inputHours, out var hours);
                        if (isHoursConverted)
                        {
                            myEarlGrey.Hours = hours;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }

                        Console.WriteLine("Укажите количество минут на момент изготовления: ");
                        var inputMinutes = Console.ReadLine();
                        bool isMinutesConverted = int.TryParse(inputMinutes, out var minutes);
                        if (isMinutesConverted)
                        {
                            myEarlGrey.Minutes = minutes;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }

                        Console.WriteLine("Укажите количество секунд на момент изготовления: ");
                        var inputSeconds = Console.ReadLine();
                        bool isSecondsConverted = int.TryParse(inputSeconds, out var seconds);
                        if (isSecondsConverted)
                        {
                            myEarlGrey.Seconds = seconds;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                        Console.WriteLine("------------------------------------------------");
                        break;

                    case "2":
                        Console.WriteLine(myEarlGrey.ToString());
                        break;

                    case "3":
                        EarlGrey.FiveOClock();
                        break;

                    case "4":
                        myEarlGrey.BrewTea();
                        break;

                    case "5":
                        Console.WriteLine("\nНазвание чая: " + myEarlGrey.PrintName());
                        break;

                    case "6":
                        myEarlGrey.ChangeBergamot();
                        Console.WriteLine("\nЗначение поля '_bergamot' изменено.");
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }

            } while (selector != "q");
        }
    }
}
