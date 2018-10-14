using System;
using System.Collections.Generic;
using System.Text;

namespace NorthShore.Restaurant.Restaurant.Dto
{
    public class EditFoodDto
    {
        public long Id { get; set; }
        public int Calorie { get; set; }
        public string Name { get; set; }
        public bool IsGlutenFree { get; set; }
        public bool IsDairyFree { get; set; }
        public bool IsNutFree { get; set; }
        public decimal Price{get;set;}

    }
}
