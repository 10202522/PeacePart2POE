using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeacePart2
{
    internal class Program
    {
        static List<recipe> recipe = new List<recipe>();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Gray;

            bool applcv = true;
            while (applcv)
            {
                Console.WriteLine("***************=WELCOME=**************");
                Console.WriteLine("choose an action that you would like to perform!");
                Console.WriteLine("1. Add Recipe you would like to enter");
                Console.WriteLine("2. Display Recipe of your choice");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Recipe Data");
                Console.WriteLine("5. Clear Data");
                Console.WriteLine("6. Exit");

                int Menu = Convert.ToInt32(Console.ReadLine());

                switch (Menu)
                {
                    case 1:
                        AddRecipe();
                        break;
                    case 2:
                        DisplayRecipes();
                        break;
                    case 3:
                        ScaleRecipe();
                        break;
                    case 4:
                        ResetRecipeData();
                        break;
                    case 5:
                        ClearData();
                        break;
                    case 6:
                        applcv= false;
                        Console.WriteLine("toodles user!");
                        return;
                    default:
                        Console.WriteLine("your choice is invalid. Please choose a valid selection.");
                        break;
                }
            }
        }

        static void AddRecipe()
        {
            Console.WriteLine("Enter the name of recipe:");
            string RecName = Console.ReadLine();

            recipe NRecipe = new recipe(RecName);

            Console.WriteLine("How many ingredients does the recipe need to achieve the end product?");
            int IngreCount = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < IngreCount; i++)
            {
                Console.WriteLine($"Enter the details for ingredient {i + 1}:");
                Console.WriteLine("product Name:");
                string ingreName = Console.ReadLine();
                Console.WriteLine("Quantity:");
                int ingreQuantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Measurement:");
                string ingreMeasurement = Console.ReadLine();
                Console.WriteLine("Calories:");
                int ingreCalories = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Food Group:");
                string ingreFoodGroup = Console.ReadLine();

                NRecipe.AddIngredient(ingreName, ingreQuantity, ingreMeasurement, ingreCalories, ingreFoodGroup);
            }

            recipe.Add(NRecipe);
            Console.WriteLine("Recipe has been added successfully!");
        }

        static void DisplayRecipes()
        {
            if (recipe.Count == 0)
            {
                Console.WriteLine("No recipes has been found!");
                return;
            }

            Console.WriteLine("Select the recipe to be displayed (enter the number of recipe):");

            for (int i = 0; i < recipe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe[i].Name}");
            }

            int recIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if (recIndex >= 0 && recIndex < recipe.Count)
            {
                recipe selectRecipe = recipe[recIndex];
                Console.WriteLine("Recipe Details:");
                Console.WriteLine($"Name: {selectRecipe.Name}");

                Console.WriteLine("Ingredients:");
                foreach (Ingredient ingre in selectRecipe.Ingredients)
                {
                    Console.WriteLine($"{ingre.Name} - {ingre.Quantity} {ingre.Measurement}");
                }

                int totalCalories = selectRecipe.CalculateTotalCalories();
                Console.WriteLine($"Total Calories: {totalCalories}");

                if (totalCalories > 300)
                {
                    Console.WriteLine("Warning: The recipe exceeds 300 calories.please, reduce the caleries because the results will be catastrophic!");
                }
            }
            else
            {
                Console.WriteLine("the recipe selection is not valid.");
            }
        }

        static void ScaleRecipe()
        {
            if (recipe.Count == 0)
            {
                Console.WriteLine("No recipes has been found.");
                return;
            }

            Console.WriteLine("Select the recipe to scale (enter the number of recipe):");

            for (int i = 0; i < recipe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe[i].Name}");
            }


            int recipeIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipe.Count)
            {
                recipe selectRecipe = recipe[recipeIndex];

                Console.WriteLine("Enter the scaling factor:");
                double scalingFactor = Convert.ToDouble(Console.ReadLine());

                selectRecipe.ScaleRecipe(scalingFactor);

                Console.WriteLine("Recipe scaling successfully!");
            }
            else
            {
                Console.WriteLine("the recipe selection is not valid.");
            }
        }

        static void ResetRecipeData()
        {
            if (recipe.Count == 0)
            {
                Console.WriteLine("No recipes found.");
                return;
            }

            Console.WriteLine("Select the recipe to reset (enter the number of recipe):");

            for (int i = 0; i < recipe.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe[i].Name}");
            }

            int recipeIndex = Convert.ToInt32(Console.ReadLine()) - 1;

            if (recipeIndex >= 0 && recipeIndex < recipe.Count)
            {
                recipe selectedRecipe = recipe[recipeIndex];

                selectedRecipe.ResetRecipeData();

                Console.WriteLine("Recipe data reset successfully!");
            }
            else
            {
                Console.WriteLine("Invalid recipe choice.");
            }
        }

        static void ClearData()
        {
            recipe.Clear();
            Console.WriteLine("Data has cleared successfully!");
        }
    }

    

  
    
}
