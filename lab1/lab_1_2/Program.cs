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

namespace lab_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string selectorMain;
            string selectorInClass;
            var myBlack = new Black();
            var myGreen = new Green();
            var myKarkade = new Karkade();
            var myLapsangSouchong = new LapsangSouchong();

            Console.WriteLine("Демонстарция иерархии классов.");

            do
            {
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine("|           Г Л А В Н О Е   М Е Н Ю            |");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("|1.| Черный чай (класс Black).                 |");
                Console.WriteLine("|2.| Зеленый чай (класс Green).                |");
                Console.WriteLine("|3.| Чай каркаде (класс Karkade).              |");
                Console.WriteLine("|4.| Чай лапсанг сушонг (кл. LapsangSouchong). |");
                Console.WriteLine("|q.| Выход из программы.                       |");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Введите пункт меню: ");

                selectorMain = Console.ReadLine();

                switch (selectorMain)
                {
                    case "1":
                        do
                        {
                            Console.WriteLine("\n------------------------------------------------");
                            Console.WriteLine("|                 B L A C K                    |");
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("|1.| Задать параметры объекта.                 |");
                            Console.WriteLine("|2.| Вывести свойства объекта.                 |");
                            Console.WriteLine("|3.| Вывести текущее имя класса.               |");
                            Console.WriteLine("|4.| Вывести полезные свойства черного чая.    |");
                            Console.WriteLine("|5.| Five o'clock Tea.                         |");
                            Console.WriteLine("|b.| Вернуться в главное меню.                 |");
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("Введите пункт меню: ");

                            selectorInClass = Console.ReadLine();

                            switch (selectorInClass)
                            {
                                case "1":
                                    myBlack.InputData();
                                    break;

                                case "2":
                                    Console.WriteLine(myBlack);
                                    break;

                                case "3":
                                    Black.ShowClassName();
                                    break;

                                case "4":
                                    myBlack.UsefulProperties();
                                    break;

                                case "5":
                                    myBlack.FiveOClock();
                                    break;

                                case "b":
                                    break;

                                default:
                                    Console.WriteLine("Некорректный ввод.");
                                    break;
                            }
                        } while (selectorInClass != "b");
                        break;

                    case "2":
                        do
                        {
                            Console.WriteLine("\n------------------------------------------------");
                            Console.WriteLine("|                 G R E E N                    |");
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("|1.| Задать параметры объекта.                 |");
                            Console.WriteLine("|2.| Вывести свойства объекта.                 |");
                            Console.WriteLine("|3.| Вывести текущее имя класса.               |");
                            Console.WriteLine("|4.| Изменить вкус чая.                        |");
                            Console.WriteLine("|5.| Five o'clock Tea.                         |");
                            Console.WriteLine("|b.| Вернуться в главное меню.                 |");
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("Введите пункт меню: ");

                            selectorInClass = Console.ReadLine();

                            switch (selectorInClass)
                            {
                                case "1":
                                    myGreen.InputData();
                                    break;

                                case "2":
                                    Console.WriteLine(myGreen);
                                    break;

                                case "3":
                                    Green.ShowClassName();
                                    break;

                                case "4":
                                    myGreen.ChangeTaste();

                                    break;

                                case "5":
                                    myGreen.FiveOClock();
                                    break;

                                case "b":
                                    break;

                                default:
                                    Console.WriteLine("Некорректный ввод.");
                                    break;
                            }
                        } while (selectorInClass != "b");
                        break;

                    case "3":
                        do
                        {
                            Console.WriteLine("\n------------------------------------------------");
                            Console.WriteLine("|                 K A R K A D E                |");
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("|1.| Задать параметры объекта.                 |");
                            Console.WriteLine("|2.| Вывести свойства объекта.                 |");
                            Console.WriteLine("|3.| Вывести текущее имя класса.               |");
                            Console.WriteLine("|4.| Посмотреть код в десятиричном формате.    |");
                            Console.WriteLine("|5.| Five o'clock Tea.                         |");
                            Console.WriteLine("|b.| Вернуться в главное меню.                 |");
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("Введите пункт меню: ");

                            selectorInClass = Console.ReadLine();

                            switch (selectorInClass)
                            {
                                case "1":
                                    myKarkade.InputData();
                                    break;

                                case "2":
                                    Console.WriteLine(myKarkade);
                                    break;

                                case "3":
                                    Karkade.ShowClassName();
                                    break;

                                case "4":
                                    myKarkade.ConvertHexColorToDec();
                                    break;

                                case "5":
                                    myKarkade.FiveOClock();
                                    break;

                                case "b":
                                    break;

                                default:
                                    Console.WriteLine("Некорректный ввод.");
                                    break;
                            }
                        } while (selectorInClass != "b");
                        break;

                    case "4":
                        do
                        {
                            Console.WriteLine("\n------------------------------------------------");
                            Console.WriteLine("|       L A P S A N G   S O U C H O N G        |");
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("|1.| Задать параметры объекта.                 |");
                            Console.WriteLine("|2.| Вывести свойства объекта.                 |");
                            Console.WriteLine("|3.| Вывести текущее имя класса.               |");
                            Console.WriteLine("|4.| Вычислить нужную пропорцию чая.           |");
                            Console.WriteLine("|5.| Five o'clock Tea.                         |");
                            Console.WriteLine("|b.| Вернуться в главное меню.                 |");
                            Console.WriteLine("------------------------------------------------");
                            Console.WriteLine("Введите пункт меню: ");

                            selectorInClass = Console.ReadLine();

                            switch (selectorInClass)
                            {
                                case "1":
                                    myLapsangSouchong.InputData();
                                    break;

                                case "2":
                                    Console.WriteLine(myLapsangSouchong);
                                    break;

                                case "3":
                                    LapsangSouchong.ShowClassName();
                                    break;

                                case "4":
                                    myLapsangSouchong.ProportionOfTea();
                                    break;

                                case "5":
                                    myLapsangSouchong.FiveOClock();
                                    break;

                                case "b":
                                    break;

                                default:
                                    Console.WriteLine("Некорректный ввод.");
                                    break;
                            }
                        } while (selectorInClass != "b");
                        break;

                    case "q":
                        break;

                    default:
                        Console.WriteLine("Некорректный ввод.");
                        break;
                }
            } while (selectorMain != "q");
        }
    }
}
