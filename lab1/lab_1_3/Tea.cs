using System;
using System.Threading;

namespace lab_1_3
{
    public abstract class Tea : IElement
    {
        private readonly string _name; // только для чтения
        private string _countryProducer;
        private bool _bergamot;
        private double _volume;
        private int _seconds;
        private int _minutes;
        private int _hours;
        private int _day;
        private int _month;
        private int _year;
        private int _choice;

        //свойства каждого из полей
        public string Name { get; set; }

        public string CountryProducer
        {
            get => _countryProducer;
            set
            {
                _countryProducer = value;
            }
        }

        public bool Bergamot
        {
            get => _bergamot;
            set
            {
                _bergamot = value;
            }
        }

        public double Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                if (_volume < 0) // объем не может быть отрицательным
                {
                    _volume = 0;
                }
            }
        }

        public int Seconds
        {
            get => _seconds;
            set
            {
                _seconds = value;
                if (_seconds < 0 || _seconds > 60) // значение не может быть отрицательным и больше 60
                {
                    _seconds = 0;
                }
            }
        }

        public int Minutes
        {
            get => _minutes;
            set
            {
                _minutes = value;
                if (_minutes < 0 || _minutes > 60) // значение не может быть отрицательным и больше 60
                {
                    _minutes = 0;
                }
            }
        }

        public int Hours
        {
            get => _hours;
            set
            {
                _hours = value;
                if (_hours < 0 || _minutes > 24) // значение не может быть отрицательным и больше 24
                {
                    _hours = 0;
                }
            }
        }

        public int Day
        {
            get => _day;
            set
            {
                _day = value;
                if (_day < 1 || (_day > 30 && (_month == 4 || _month == 6 || _month == 9 || _month == 11)) || (_day > 31 && (_month == 1 || _month == 3 || _month == 5 || _month == 7 || _month == 8 || _month == 10 || _month == 12)) || (_day > 29 && _month == 2 && (_year % 4 != 0)) || (_day > 30 && _month == 2 && (_year % 4 == 0))) // значение должно удовлетворять данным условиям
                {
                    _day = 0;
                }
            }
        }

        public int Month
        {
            get => _month;
            set
            {
                _month = value;
                if (_month < 1 || _month > 12) // значение не может быть быть меньше 1 и больше 12
                {
                    _month = 0;
                }
            }
        }

        public int Year
        {
            get => _year;
            set
            {
                _year = value;
                if (_year < 1 || _year > 2021) // значение не может быть меньше 1 и больше 2021
                {
                    _year = 0;
                }
            }
        }

        public int Choice
        {
            get => _choice;
            set
            {
                _choice = value;
                if (_choice < 0 || _choice > 2)
                {
                    Console.WriteLine("\nНеккоректный ввод. По умолчанию будет выбран первый пункт.");
                    _choice = 1;
                }
            }
        }

        // конструктор копирования
        public Tea(string name = "Tea", string countryProducer = null, bool bergamot = false, double volume = 0, int seconds = 0, int minutes = 0, int hours = 0, int day = 0, int month = 0, int year = 0, int choice = 0)
        {
            _name = name;
            _countryProducer = countryProducer;
            _bergamot = bergamot;
            _volume = volume;
            _seconds = seconds;
            _minutes = minutes;
            _hours = hours;
            _day = day;
            _month = month;
            _year = year;
            _choice = choice;
        }

        // конструктор копирования
        public Tea(Tea copy)
        {
            _name = copy._name;
            _countryProducer = copy._countryProducer;
            _bergamot = copy._bergamot;
            _volume = copy._volume;
            _seconds = copy._seconds;
            _minutes = copy._minutes;
            _hours = copy._hours;
            _day = copy._day;
            _month = copy._month;
            _year = copy._year;
            _choice = copy._choice;
        }

        // конструктор с некоторыми параметрами
        public Tea(string name, bool bergamot)
        {
            _name = "No name";
            _bergamot = bergamot;
        }

        //перегрузка метода ToString
        public override string ToString()
        {
            return $"\nСтрана-производитель: {_countryProducer}\nСодержание бергамота: {_bergamot}\nОбъем: {_volume}\nВремя изготовления: {_hours}:{_minutes}:{_seconds}\nДата изготовления: {_day}.{_month}.{_year} г.";
        }

        // статический метод
        public virtual void FiveOClock()
        {
            Console.WriteLine("\nВремя пить чай!");
        }

        // метод заварки чая
        public void BrewTea()
        {
            FiveOClock();
            Console.WriteLine("\nПодождите, пока вода закипит, это займет несколько минут.");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(".");
            }
            Thread.Sleep(1000);
            Console.WriteLine("\nПожалуйста, выберите способ заваривания чая:\n1) С помощью пакетика.\n2) С помощью заварочного чайника.\nВведите цифру: ");
            _choice = int.Parse(Console.ReadLine());
            if (_choice == 1)
            {
                Console.WriteLine("\nВ чашку положен чайный пакетик.");
            }
            else
            {
                Console.WriteLine("\nВ заварочный чайник была положена одна чайная ложка заварки.");
            }
            Console.WriteLine("\nПодождите, пока заварится чай, это займет несколько минут.");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(".");
            }
            Thread.Sleep(1000);
            Console.WriteLine("\nРазбавить чай холодной водой?\n1) Да.\n2) Нет.\nВведите цифру: ");
            _choice = int.Parse(Console.ReadLine());
            if (_choice == 1)
            {
                Console.WriteLine("\nРазбавляем холодной водой.");
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(".");
                }
                Thread.Sleep(1000);
                Console.WriteLine("\nРазбaвили!");
            }
            Console.WriteLine("\nДобавить молока в чай?\n1) Да.\n2) Нет.\nВведите цифру: ");
            _choice = int.Parse(Console.ReadLine());
            if (_choice == 1)
            {
                Console.WriteLine("\nДобавляем молоко в чай.");
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(".");
                }
                Thread.Sleep(1000);
                Console.WriteLine("\nДобавили!");
            }
            Console.WriteLine("\nБудете чай с сахаром?\n1) Да.\n2) Нет.\nВведите цифру: ");
            _choice = int.Parse(Console.ReadLine());
            if (_choice == 1)
            {
                Console.WriteLine("\nСколько ложек сахара кладем?");
                Console.ReadLine();
                Console.WriteLine("\nДобавляем сахар в чай.");
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(".");
                }
                Thread.Sleep(1000);
                Console.WriteLine("\nДобавили!");
            }
            Console.WriteLine("\nВаш чай готов, приятного чаепития!");
        }

        // метод ввода данных
        public virtual void InputData()
        {
            Console.WriteLine("\nДалее введите данные о чае.\n------------------------------------------------");
            Console.WriteLine("Страна-производитель: ");
            _countryProducer = Console.ReadLine();

            Console.WriteLine("Содержание бергамота (0 - нет/ 1 - да): ");
            var inputBergamot = Console.ReadLine();
            switch (inputBergamot)
            {
                case "0":
                    if (_bergamot)
                    {
                        ChangeBergamot();
                    }
                    break;

                case "1":
                    if (!_bergamot)
                    {
                        ChangeBergamot();
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
                _volume = volume;
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
                _year = year;
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
                _month = month;
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
                _day = day;
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
                _hours = hours;
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
                _minutes = minutes;
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
                _seconds = seconds;
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }

        // метод вывода названия чая
        public string PrintName()
        {
            return _name;
        }

        //метод изменения содержания бергамота
        public void ChangeBergamot()
        {
            _bergamot = !_bergamot;
        }

        public string ShowClassName()
        {
            var name = this.GetType().Name;
            return name;
        }
    }
}


