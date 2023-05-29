using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeacePart2
{
    internal class recipe
    {

        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
        }

        public void AddIngredient(string name, int quantity, string measurement, int calories, string foodGroup)
        {
            Ingredients.Add(new Ingredient(name, quantity, measurement, calories, foodGroup));
        }

        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in Ingredients)
            {
                totalCalories += ingredient.Calories;
            }
            return totalCalories;
        }

        public void ScaleRecipe(double scalingFactor)
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ScaleQuantity(scalingFactor);
            }
        }

        public void ResetRecipeData()
        {
            foreach (Ingredient ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }
    }
}
