using System;

namespace lab_1_3
{
    public class Black : Tea
    {
        private bool _theaflavin;

        public bool Theaflavin
        {
            get => _theaflavin;
            set
            {
                _theaflavin = value;
            }
        }

        public Black(string name = "Black", string countryProducer = null, bool bergamot = false, double volume = 0, int seconds = 0, int minutes = 0, int hours = 0, int day = 0, int month = 0, int year = 0, int choice = 0, bool theaflavin = false) : base(name, countryProducer, bergamot, volume, seconds, minutes, hours, day, month, year, choice)
        {
            _theaflavin = theaflavin;
        }

        public override string ToString()
        {
            return $"\nСтрана-производитель: {CountryProducer}\nСодержание бергамота: {Bergamot}\nОбъем: {Volume}\nСодержание теафлавина: {Theaflavin}\nВремя изготовления: {Hours}:{Minutes}:{Seconds}\nДата изготовления: {Day}.{Month}.{Year} г.";
        }

        public void UsefulProperties()
        {
            Console.WriteLine("\nПолезные свойства черного чая\n------------------------------------------------\n1) Укрепляет иммунитет\n2) Профилактика онкологических заболеваний\n3) Снижение уровня 'плохого' холестерина\n4) Профилактиа сердечно-сосудистых заболеваний\n5) Нормализация пищеварения\n6) Снижение уровня сахара в крови\n7) Повышение концентрации\n------------------------------------------------");
        }

        /*public new static void ShowClassName()
        {
            Console.WriteLine("\nИмя класса: 'Black'.");
            Tea.ShowClassName();
        }*/

        public override void FiveOClock()
        {
            Console.WriteLine("\nВремя пить черный чай!");
        }

        public override void InputData()
        {
            base.InputData();
            Console.WriteLine("Содержание теафлавина (0 - нет/ 1 - да): ");
            var inputTheaflavin = Console.ReadLine();
            switch (inputTheaflavin)
            {
                case "0":
                    if (_theaflavin)
                    {
                        _theaflavin = false;
                    }
                    break;

                case "1":
                    if (!_theaflavin)
                    {
                        _theaflavin = true;
                    }
                    break;

                default:
                    Console.WriteLine("Некорректный ввод.");
                    break;
            }
            Console.WriteLine("------------------------------------------------");
        }
    }
}
