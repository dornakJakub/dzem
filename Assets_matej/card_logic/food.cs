
using System;
using UnityEngine.UI;
using System.Collections.Generic;

namespace card_logic
{
public enum Food_name
{
    //NEUTRAL INGREDIENTS
    RED_WINE,
    BUTTER,
    MILK,
    EGG,
    HEAVY_CREAM,

    //SWEET INGREDIENTS
    CHERRY,
    WHIPPED_WHITES,
    SUGAR,
    CHOCOLATE,
    APPLE,
    POPPY,
    CHANTILLY,
    MARSHMALLOW,
    BISCUIT,
    BISCUIT_DUST,
    GRAPE,
    COFFEE_BEAN,
    COFFEE_CUP,

    //SAVORY INGREDIENTS
    TOMATO,
    FLOUR,
    BEEF,
    PORK,
    CHICKEN,
    CARROT,
    LETTUCE,
    CUCUMBER,
    CHEESE,
    BACON,
    BRYNDZA,
    BEETROOT,
    BROCCOLI,
    MUSHROOMS,
    WATER,
    SOY_SAUCE,
    BREADCRUMBS,
    CABBAGE,
    ONION,
    GARLIC,


    //BASIC SIDES
    PASTA,
    RICE,
    FRIES,
    MASHED_POTATOES,
    POTATO,

    //BASIC DESSERTS
    ICE_CREAM,
    COTTON_CANDY,

    //DISHES
    SPAGHETTI_MARINARA,
    LASAGNE,
    CARBONARA,
    CHICKEN_SOUP,
    GARLIC_SOUP,
    MINESTRONE,
    FRENCH_ONION_SOUP,
    BORSCHT,
    HALUSKY_BRYNDZA,
    HALUSKY_CABBAGE,
    DUMPLINGS,
    GRATIN,
    RISOTTO_PORK,
    RISOTTO_BEEF,
    RISOTTO_CHICKEN,
    STEAK,
    SCHNITZEL_CHICKEN,
    SCHNITZEL_PORK,
    FRIED_CHEESE,
    ROASTED_CHICKEN,
    OMELETTE,
    BEEF_WELLINGTON,
    BOEUF_BOURGUIGNON,
    GARLIC_BREAD,
    SALAD,
    CHERRY_PIE,
    APPLE_PIE,
    SCHWARZWALDEN,
    MAKOVNIK,
    CARROT_CAKE,
    CHEESECAKE,
    SMORES,
    ALASKA,
    TIRAMISU
}



    [System.Serializable]
    public class Food
    {
        public Food_name name;
        public int is_full;
        public int is_full_plus;
        public int is_side;
        public int is_dessert;
        public int taste;
        public List<Food_name> ingredients = new List<Food_name>();

    }

class Program
{

    public static List<Food_name> get_ingredients(Food_name food)
    {

        switch (food)
        {
            case Food_name.SPAGHETTI_MARINARA:
                return new List<Food_name> { Food_name.TOMATO, Food_name.PASTA };
            case Food_name.LASAGNE:
                return new List<Food_name> { Food_name.TOMATO, Food_name.PASTA, Food_name.BEEF, Food_name.CHEESE };
            case Food_name.CARBONARA:
                return new List<Food_name> { Food_name.PASTA, Food_name.EGG, Food_name.CHEESE, Food_name.BACON };
            case Food_name.CHICKEN_SOUP:
                return new List<Food_name> { Food_name.WATER, Food_name.CHICKEN, Food_name.ONION, Food_name.CARROT, Food_name.GARLIC };
            case Food_name.GARLIC_SOUP:
                return new List<Food_name> { Food_name.WATER, Food_name.CHICKEN, Food_name.ONION, Food_name.CARROT };
            case Food_name.MINESTRONE:
                return new List<Food_name> { Food_name.WATER, Food_name.TOMATO, Food_name.ONION, Food_name.CARROT };
            case Food_name.FRENCH_ONION_SOUP:
                return new List<Food_name> { Food_name.WATER, Food_name.ONION, Food_name.BEEF, Food_name.CHEESE };
            case Food_name.BORSCHT:
                return new List<Food_name> { Food_name.WATER, Food_name.BEEF, Food_name.PORK, Food_name.BEETROOT, Food_name.CABBAGE, Food_name.CARROT };
            case Food_name.HALUSKY_BRYNDZA:
                return new List<Food_name> { Food_name.POTATO, Food_name.FLOUR, Food_name.BRYNDZA, Food_name.BACON };
            case Food_name.HALUSKY_CABBAGE:
                return new List<Food_name> { Food_name.POTATO, Food_name.FLOUR, Food_name.CABBAGE };
            case Food_name.DUMPLINGS:
                return new List<Food_name> { Food_name.FLOUR, Food_name.WATER, Food_name.PORK, Food_name.SOY_SAUCE };
            case Food_name.GRATIN:
                return new List<Food_name> { Food_name.POTATO, Food_name.HEAVY_CREAM, Food_name.CHEESE };
            case Food_name.RISOTTO_PORK:
                return new List<Food_name> { Food_name.RICE, Food_name.CARROT, Food_name.PORK };
            case Food_name.RISOTTO_BEEF:
                return new List<Food_name> { Food_name.RICE, Food_name.BROCCOLI, Food_name.BEEF };
            case Food_name.RISOTTO_CHICKEN:
                return new List<Food_name> { Food_name.RICE, Food_name.TOMATO, Food_name.CHICKEN };
            case Food_name.STEAK:
                return new List<Food_name> { Food_name.BEEF };
            case Food_name.SCHNITZEL_CHICKEN:
                return new List<Food_name> { Food_name.CHICKEN, Food_name.FLOUR, Food_name.EGG, Food_name.BREADCRUMBS };
            case Food_name.SCHNITZEL_PORK:
                return new List<Food_name> { Food_name.PORK, Food_name.FLOUR, Food_name.EGG, Food_name.BREADCRUMBS };
            case Food_name.FRIED_CHEESE:
                return new List<Food_name> { Food_name.CHEESE, Food_name.FLOUR, Food_name.EGG, Food_name.BREADCRUMBS };
            case Food_name.ROASTED_CHICKEN:
                return new List<Food_name> { Food_name.CHICKEN };
            case Food_name.OMELETTE:
                return new List<Food_name> { Food_name.EGG, Food_name.TOMATO, Food_name.CHEESE, Food_name.BROCCOLI };
            case Food_name.BEEF_WELLINGTON:
                return new List<Food_name> { Food_name.BEEF, Food_name.MUSHROOMS, Food_name.FLOUR, Food_name.BUTTER };
            case Food_name.BOEUF_BOURGUIGNON:
                return new List<Food_name> { Food_name.BEEF, Food_name.MUSHROOMS, Food_name.CARROT, Food_name.RED_WINE };
            case Food_name.GARLIC_BREAD:
                return new List<Food_name> { Food_name.FLOUR, Food_name.WATER, Food_name.GARLIC, Food_name.BUTTER };
            case Food_name.SALAD:
                return new List<Food_name> { Food_name.LETTUCE, Food_name.TOMATO, Food_name.CUCUMBER };
            case Food_name.CHERRY_PIE:
                return new List<Food_name> { Food_name.FLOUR, Food_name.BUTTER, Food_name.SUGAR, Food_name.CHERRY };
            case Food_name.APPLE_PIE:
                return new List<Food_name> { Food_name.FLOUR, Food_name.BUTTER, Food_name.SUGAR, Food_name.APPLE };
            case Food_name.SCHWARZWALDEN:
                return new List<Food_name> { Food_name.FLOUR, Food_name.EGG, Food_name.SUGAR, Food_name.CHANTILLY, Food_name.CHOCOLATE, Food_name.CHERRY };
            case Food_name.MAKOVNIK:
                return new List<Food_name> { Food_name.FLOUR, Food_name.MILK, Food_name.POPPY };
            case Food_name.CARROT_CAKE:
                return new List<Food_name> { Food_name.FLOUR, Food_name.EGG, Food_name.SUGAR, Food_name.CARROT };
            case Food_name.CHEESECAKE:
                return new List<Food_name> { Food_name.BISCUIT_DUST, Food_name.EGG, Food_name.HEAVY_CREAM, Food_name.CHEESE, Food_name.SUGAR };
            case Food_name.SMORES:
                return new List<Food_name> { Food_name.BISCUIT, Food_name.CHOCOLATE, Food_name.MARSHMALLOW };
            case Food_name.ALASKA:
                return new List<Food_name> { Food_name.ICE_CREAM, Food_name.WHIPPED_WHITES };
            case Food_name.TIRAMISU:
                return new List<Food_name> { Food_name.COFFEE_CUP, Food_name.HEAVY_CREAM, Food_name.SUGAR, Food_name.BISCUIT };
            default:
                return new List<Food_name> { };
        }

    }


 
    static void Main()
    {
        Dictionary<Food_name, Food> all_food = new Dictionary<Food_name, Food>();
        foreach (Food_name food in Enum.GetValues(typeof(Food_name)))
        {
            Food current_food = new Food();
            current_food.name = food;

            //BASIC INGREDIENTS
            if (food < Food_name.PASTA)
            {

                current_food.ingredients.Add(food);
                current_food.is_full = 0;
                current_food.is_full_plus = 0;
                current_food.is_side = 0;
                current_food.is_dessert = 0;

                if (food < Food_name.CHERRY)
                {
                    current_food.taste = 0;
                }
                else if (food < Food_name.TOMATO)
                {
                    current_food.taste = 1;
                }
                else
                {
                    current_food.taste = -1;
                }





            }
            //BASIC INGREDIENTS THAT ARE SIDES
            else if (food < Food_name.ICE_CREAM)
            {
                current_food.ingredients.Add(food);
                current_food.is_full = 0;
                current_food.is_full_plus = 0;
                current_food.is_side = 1;
                current_food.is_dessert = 0;
                current_food.taste = -1;

            }
            else if (food >= Food_name.ICE_CREAM && food < Food_name.SPAGHETTI_MARINARA)
            {
                current_food.ingredients.Add(food);
                current_food.is_full = 0;
                current_food.is_full_plus = 0;
                current_food.is_side = 0;
                current_food.is_dessert = 1;
                current_food.taste = 1;
            }
            else
            {
                current_food.ingredients.AddRange(get_ingredients(food));

                //FULL
                if (food >= Food_name.SPAGHETTI_MARINARA && food < Food_name.STEAK)
                {
                    current_food.is_full = 1;
                    current_food.is_full_plus = 0;
                    current_food.is_side = 0;
                    current_food.is_dessert = 0;
                    current_food.taste = -1;

                }
                //FULL_PLUS
                else if (food >= Food_name.STEAK && food < Food_name.GARLIC_BREAD)
                {
                    current_food.is_full = 0;
                    current_food.is_full_plus = 1;
                    current_food.is_side = 0;
                    current_food.is_dessert = 0;
                    current_food.taste = -1;
                }
                //NOT BASIC SIDES
                else if (food >= Food_name.GARLIC_BREAD && food < Food_name.CHERRY_PIE)
                {
                    current_food.is_full = 0;
                    current_food.is_full_plus = 0;
                    current_food.is_side = 1;
                    current_food.is_dessert = 0;
                    current_food.taste = -1;
                }
                //DESSERTS
                else
                {
                    current_food.is_full = 0;
                    current_food.is_full_plus = 0;
                    current_food.is_side = 0;
                    current_food.is_dessert = 1;
                    current_food.taste = 1;

                }

            }

            //add food to dictionary
            all_food[food] = current_food;

        }

        Console.WriteLine($"FOOD NAME: {all_food[Food_name.TIRAMISU].name}, INGREDIENTS: {string.Join(", ", all_food[Food_name.TIRAMISU].ingredients)}");
            

        
        
    }

}

}

/*
CIVET
PENGUIN
ELEPHANT
SPIDER


*/
