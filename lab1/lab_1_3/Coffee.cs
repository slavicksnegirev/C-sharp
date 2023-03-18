using System;

namespace lab_1_3
{
    public class Coffee : IBreakfastDrink
    {
        private string _name;
        private string _syrop;
        private double _price;
        private double _weight;
        private bool _isDiscount;
        private int _discount;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        public string Syrop
        {
            get => _syrop;
            set
            {
                _syrop = value;
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                if (_price < 0)
                {
                    _price = 0;
                }
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                if (_weight < 0)
                {
                    _weight = 0;
                }
            }
        }

        public bool IsDiscount
        {
            get => _isDiscount;
            set
            {
                _isDiscount = value;
            }
        }

        public int Discount
        {
            get => _discount;
            set
            {
                _discount = value;
                if (_discount < 0 || _discount > 100)
                {
                    _discount = 0;
                }
            }
        }

        public Coffee(string name = "No name", string syrop = null, double price = 0, double weight = 0, bool isDiscount = false, int discount = 0)
        {
            _name = name;
            _syrop = syrop;
            _price = price;
            _weight = weight;
            _isDiscount = isDiscount;
            _discount = discount;
        }

        public override string ToString()
        {
            return $"\nНазвание кофе: {_name}\nНазвание сиропа: {_syrop}\nЦена: {_price} $\nВес: {_weight} г.\nНаличие скидки: {_isDiscount}\nСкидка: {_discount} %";
        }

        public string ShowClassName()
        {
            var name = this.GetType().Name;
            return name;
        }

        public double CountDiscount()
        {
            return (_price * (100 - _price) / 100);
        }

        public void FiveOClock()
        {
            Console.WriteLine("\nВремя пить кофе!");
        }
    }
}
