using System;

namespace lab_1_3
{
    interface IBreakfastDrink : IElement
    {
        string Name { get; set; }

        string Syrop { get; set; }

        double Price { get; set; }
       
        double Weight { get; set; }

        bool IsDiscount { get; set; }

        int Discount { get; set; }

        double CountDiscount();

        void FiveOClock();
    }
}
