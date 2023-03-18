using System;
namespace lab_1_2
{
    public class LapsangSouchong : Tea
    {
        private double _proportion;

        public double Proportion
        {
            get => _proportion;
            set
            {
                if (_proportion < 0)
                {
                    _proportion = 0.1;
                }
                else
                {
                    _proportion = value;
                }
            }

        }

        public LapsangSouchong(string name = "Lapsang souchong", string countryProducer = null, bool bergamot = false, double volume = 0, int seconds = 0, int minutes = 0, int hours = 0, int day = 0, int month = 0, int year = 0, int choice = 0, double proportion = 0.1) : base(name, countryProducer, bergamot, volume, seconds, minutes, hours, day, month, year, choice)
        {
            _proportion = proportion;
        }

        public override string ToString()
        {
            return $"\nСтрана-производитель: {CountryProducer}\nСодержание бергамота: {Bergamot}\nОбъем: {Volume}\nПропорция для заварки чая: {Proportion}\nВремя изготовления: {Hours}:{Minutes}:{Seconds}\nДата изготовления: {Day}.{Month}.{Year} г.";
        }

        public void ProportionOfTea()
        {
            double volumeOfWater = 0;
            Console.WriteLine("\nВведите требуемый объем воды в миллилитрах для заварки чая.");
            volumeOfWater = double.Parse(Console.ReadLine());
            if (volumeOfWater < 0)
            {
                Console.WriteLine("Некорректный ввод.");
            }
            else
            {
                Console.WriteLine("Вам потребуется столько грамм чая: " + _proportion * volumeOfWater);
            }
        }

        public new static void ShowClassName()
        {
            Console.WriteLine("\nИмя класса: 'LapsangSouchong'.");
            Tea.ShowClassName();
        }

        public override void FiveOClock()
        {
            Console.WriteLine("\nВремя пить чай лапсанг сушонг!");
        }

        public override void InputData()
        {
            base.InputData();
            Console.WriteLine("Введите пропорцию (пример: 0.1): ");
            _proportion = double.Parse(Console.ReadLine());
            Console.WriteLine("------------------------------------------------");
        }
    }
}
