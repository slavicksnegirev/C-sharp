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
using System.Collections.Generic;

namespace lab_1_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<IElement> objectList = new List<IElement>();
            string selectorMain;
            string selectClassObj;

            do
            {
                Console.WriteLine("\n------------------------------------------------");
                Console.WriteLine("|           Г Л А В Н О Е   М Е Н Ю            |");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("|1.| Добавить новый объект класса в список.    |");
                Console.WriteLine("|2.| Вывести все объекты из списка.            |");
                Console.WriteLine("|3.| Выполнить метод для объекта класса.       |");
                Console.WriteLine("|q.| Выход из программы.                       |");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Введите пункт меню: ");

                selectorMain = Console.ReadLine();

                switch(selectorMain)
                {
                    case "1":
                        {
                            do
                            {
                                Console.WriteLine("\nВыберите объект класса для добавления в список.");
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("|1.| Черный чай (класс Black).                 |");
                                Console.WriteLine("|2.| Зеленый чай (класс Green).                |");
                                Console.WriteLine("|3.| Чай каркаде (класс Karkade).              |");
                                Console.WriteLine("|4.| Чай лапсанг сушонг (кл. LapsangSouchong). |");
                                Console.WriteLine("|5.| Кофе (класс Coffee).                      |");
                                Console.WriteLine("|b.| Вернуться в меню.                         |");
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("Введите пункт меню: ");

                                selectClassObj = Console.ReadLine();

                                switch (selectClassObj)
                                {
                                    case "1":
                                        {
                                            Black myBlack = new Black();
                                            myBlack.InputData();
                                            objectList.Add(myBlack);
                                            break;
                                        }
                                    case "2":
                                        {
                                            Green myGreen = new Green();
                                            myGreen.InputData();
                                            objectList.Add(myGreen);
                                            break;
                                        }
                                    case "3":
                                        {
                                            Karkade myKarkade = new Karkade();
                                            myKarkade.InputData();
                                            objectList.Add(myKarkade);
                                            break;
                                        }
                                    case "4":
                                        {
                                            LapsangSouchong myLapsangSouchong = new LapsangSouchong();
                                            myLapsangSouchong.InputData();
                                            objectList.Add(myLapsangSouchong);
                                            break;
                                        }
                                    case "5":
                                        {
                                            Coffee myCoffee = new Coffee();
                                            Console.WriteLine("\nДалее введите данные о кофе.\n------------------------------------------------");
                                            Console.WriteLine("Название кофе: ");
                                            myCoffee.Name = Console.ReadLine();
                                            Console.WriteLine("Название сиропа: ");
                                            myCoffee.Syrop = Console.ReadLine();
                                            Console.WriteLine("Цена: ");
                                            myCoffee.Price = double.Parse(Console.ReadLine());
                                            Console.WriteLine("Вес: ");
                                            myCoffee.Weight = double.Parse(Console.ReadLine());
                                            Console.WriteLine("Наличие скидки (0 - нет/ 1 - да): ");
                                            string checkBool = Console.ReadLine();
                                            if (checkBool == "0")
                                            {
                                                myCoffee.IsDiscount = false;
                                            }
                                            else
                                            {
                                                myCoffee.IsDiscount = true;
                                            }
                                            if (myCoffee.IsDiscount)
                                            {
                                                Console.WriteLine("Скидка: ");
                                                myCoffee.Discount = int.Parse(Console.ReadLine());
                                            }
                                            Console.WriteLine("------------------------------------------------");
                                            objectList.Add(myCoffee);
                                            break;
                                        }
                                    case "b":
                                        break;

                                    default:
                                        Console.WriteLine("Некорректный ввод.");
                                        break;
                                }
                            } while (selectClassObj != "b");

                        }
                            break;

                    case "2":
                        if (objectList.Count == 0)
                        {
                            Console.WriteLine("\nСписок объектов пуст.");
                        }
                        else
                        {
                            foreach (var thisObject in objectList)
                            {
                                Console.WriteLine("\n" + thisObject.ShowClassName());
                                Console.WriteLine(thisObject);
                            }
                        }

                        break;

                    case "3":
                        if (objectList.Count == 0)
                        {
                            Console.WriteLine("\nСписок объектов пуст.");
                        }
                        else
                        {
                            string demonstrateMethod = null;
                            do
                            {
                                Console.WriteLine("\nВыберите объект из списка для тестирования методов.");
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("|1.| Черный чай (класс Black).                 |");
                                Console.WriteLine("|2.| Зеленый чай (класс Green).                |");
                                Console.WriteLine("|3.| Чай каркаде (класс Karkade).              |");
                                Console.WriteLine("|4.| Чай лапсанг сушонг (кл. LapsangSouchong). |");
                                Console.WriteLine("|5.| Кофе (класс Coffee).                      |");
                                Console.WriteLine("|b.| Вернуться в меню.                         |");
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("Введите пункт меню: ");

                                demonstrateMethod = Console.ReadLine();

                                if (objectList.Count != 0)
                                {
                                    foreach (var currentObj in objectList)
                                    {
                                        if (currentObj.ShowClassName() is "Black" && demonstrateMethod is "1")
                                        {
                                            var myBlack = (Black)currentObj; // приводим объект интерфейса к объекту черного чая
                                            myBlack.FiveOClock();
                                            myBlack.UsefulProperties();
                                        }
                                        else if (currentObj.ShowClassName() is "Green" && demonstrateMethod is "2")
                                        {
                                            var myGreen = (Green)currentObj; // приводим объект интерфейса к объекту зеленого чая
                                            myGreen.FiveOClock();
                                            myGreen.ChangeTaste();
                                        }
                                        else if (currentObj.ShowClassName() is "Karkade" && demonstrateMethod is "3")
                                        {
                                            var myKarkade = (Karkade)currentObj; // приводим объект интерфейса к объекту каркаде
                                            myKarkade.FiveOClock();
                                            myKarkade.ConvertHexColorToDec();
                                        }
                                        else if (currentObj.ShowClassName() is "LapsangSouchong" && demonstrateMethod is "4")
                                        {
                                            var myLapsangSouchong = (LapsangSouchong)currentObj; // приводим объект интерфейса к объекту лапсанг сушонг
                                            myLapsangSouchong.FiveOClock();
                                            myLapsangSouchong.ProportionOfTea();
                                        }
                                        else if (currentObj.ShowClassName() is "Coffee" && demonstrateMethod is "5")
                                        {
                                            var myCoffee = (Coffee)currentObj; // приводим объект интерфейса к объекту кофе
                                            myCoffee.FiveOClock();
                                            double price = myCoffee.CountDiscount();
                                            Console.WriteLine("\nС учетом скидки стоимость кофе составит: " + price + " $");
                                        }
                                    } 
                                }
                                else
                                {
                                    Console.WriteLine("\nСписок пуст.");
                                }

                            } while (demonstrateMethod != "b");
                        }
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
