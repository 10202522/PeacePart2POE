using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeacePart2
{
    internal class Ingredient
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Measurement { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        public Ingredient(string name, int quantity, string measurement, int calories, string foodGroup)
        {
            Name = name;
            Quantity = quantity;
            Measurement = measurement;
            Calories = calories;
            FoodGroup = foodGroup;
        }

        public void ScaleQuantity(double scalingFactor)
        {
            Quantity = (int)Math.Round(Quantity * scalingFactor);
        }

        public void ResetQuantity()
        {
            Quantity = 0;


        }
    }
}
