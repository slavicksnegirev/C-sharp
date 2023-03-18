using System;

namespace lab_1_3
{
    public sealed class Karkade : Tea
    {
        private string _color;

        // проверка на соответствие цвета нужному формату
        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                bool isColor = true;
                if (!(_color[0] == '#' && _color.Length == 7))
                {
                    isColor = false;
                    for (int i = 0; i < _color.Length; i++)
                    {
                        if (!(_color[i] >= '0' && _color[i] <= '9' && _color[i] >= 'A' && _color[i] <= 'F'))
                        {
                            isColor = false;
                            break;
                        }
                    }
                }

                if (!isColor)
                {
                    _color = "#ff0000";
                }
            }
        }

        public Karkade(string name = "Karkade", string countryProducer = null, bool bergamot = false, double volume = 0, int seconds = 0, int minutes = 0, int hours = 0, int day = 0, int month = 0, int year = 0, int choice = 0, string color = "#ff0000") : base(name, countryProducer, bergamot, volume, seconds, minutes, hours, day, month, year, choice)
        {
            _color = color;
        }

        public override string ToString()
        {
            return $"\nСтрана-производитель: {CountryProducer}\nСодержание бергамота: {Bergamot}\nОбъем: {Volume}\nЦвет: {Color}\nВремя изготовления: {Hours}:{Minutes}:{Seconds}\nДата изготовления: {Day}.{Month}.{Year} г.";
        }

        public void ConvertHexColorToDec()
        {
            //разделяем на подстроки по первым двум буквам цвета

            var substrArray = new int[3];// создаем массив на 3 цвета, после чего каждые 2 буквы преобразуются в десятичное число и записываются обратно в массив
            int offset = 0; // смещение по строке
            for (int i = 0; i < 3; i++)
            {
                var substructingString = Color.Substring(offset + 1, 2);
                substrArray[i] = int.Parse(substructingString, System.Globalization.NumberStyles.HexNumber);
                offset += 2;
            }

            Console.WriteLine($"\nКрасный цвет: {substrArray[0]}\n" +
                              $"Зелёный цвет: {substrArray[1]}\n" +
                              $"Синий цвет: {substrArray[2]}");
        }

        /*public new static void ShowClassName()
        {
            Console.WriteLine("\nИмя класса: 'Karkade'.");
            Tea.ShowClassName();
        }*/

        public override void FiveOClock()
        {
            Console.WriteLine("\nВремя пить чай каркаде!");
        }

        public override void InputData()
        {
            base.InputData();
            Console.WriteLine("Введите цвет в hex формате(#000000): ");
            _color = Console.ReadLine();
            Console.WriteLine("------------------------------------------------");
        }
    }
}
