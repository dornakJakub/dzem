// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Frozen;

/*
public class CardData
{
    public string cardName;
    public float dropChance = 1f;
    public Food food;
    public int points;
    public int ingCount;
    public bool unlocked = false;
    public bool isIng;
    public int milestone;
}

*/


enum Food_name
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
    FLOUR,
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
    BEEF,
    PORK,
    CHICKEN,
    CHICKEN_SKEWER,

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
    CHICKEN_SKEWER_DISH,
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
    BAKED_ALASKA,
    TIRAMISU
}


class Food
{
    public Food_name name;
    public int is_ingredient = 0;
    public int is_full = 0;
    public int is_full_plus = 0;
    public int is_side = 0;
    public int is_dessert = 0;
    public int taste = 0;
    public int points = 0;
    public List<Food_name> ingredients = new List<Food_name>();
    public int ing_count = 0;
    public int unlocked = 0;



}

class Program
{


   
    public static List<Food_name> get_ingredients(Food_name food)
    {

        switch (food)
        {
            case Food_name.SPAGHETTI_MARINARA:
                return new List<Food_name> { Food_name.TOMATO, Food_name.PASTA }; //2
            case Food_name.LASAGNE:
                return new List<Food_name> { Food_name.TOMATO, Food_name.PASTA, Food_name.BEEF, Food_name.CHEESE }; //4
            case Food_name.CARBONARA:
                return new List<Food_name> { Food_name.PASTA, Food_name.EGG, Food_name.CHEESE, Food_name.BACON }; //4
            case Food_name.CHICKEN_SOUP:
                return new List<Food_name> { Food_name.WATER, Food_name.CHICKEN, Food_name.ONION, Food_name.CARROT }; //5
            case Food_name.GARLIC_SOUP:
                return new List<Food_name> { Food_name.WATER, Food_name.CHICKEN, Food_name.ONION, Food_name.CARROT, Food_name.GARLIC }; //4
            case Food_name.MINESTRONE:
                return new List<Food_name> { Food_name.WATER, Food_name.TOMATO, Food_name.ONION, Food_name.CARROT }; //4
            case Food_name.FRENCH_ONION_SOUP:
                return new List<Food_name> { Food_name.WATER, Food_name.ONION, Food_name.BEEF, Food_name.CHEESE }; //4
            case Food_name.BORSCHT:
                return new List<Food_name> { Food_name.WATER, Food_name.BEEF, Food_name.PORK, Food_name.BEETROOT, Food_name.CABBAGE, Food_name.CARROT }; //6
            case Food_name.HALUSKY_BRYNDZA:
                return new List<Food_name> { Food_name.POTATO, Food_name.FLOUR, Food_name.BRYNDZA, Food_name.BACON }; //4
            case Food_name.HALUSKY_CABBAGE:
                return new List<Food_name> { Food_name.POTATO, Food_name.FLOUR, Food_name.CABBAGE }; //3
            case Food_name.DUMPLINGS:
                return new List<Food_name> { Food_name.FLOUR, Food_name.WATER, Food_name.PORK, Food_name.SOY_SAUCE, Food_name.CABBAGE }; //5
            case Food_name.GRATIN:
                return new List<Food_name> { Food_name.POTATO, Food_name.HEAVY_CREAM, Food_name.CHEESE }; //3
            case Food_name.RISOTTO_PORK:
                return new List<Food_name> { Food_name.RICE, Food_name.CARROT, Food_name.PORK }; //3
            case Food_name.RISOTTO_BEEF:
                return new List<Food_name> { Food_name.RICE, Food_name.BROCCOLI, Food_name.BEEF }; //3
            case Food_name.RISOTTO_CHICKEN:
                return new List<Food_name> { Food_name.RICE, Food_name.TOMATO, Food_name.CHICKEN }; //3
            case Food_name.STEAK:
                return new List<Food_name> { Food_name.BEEF }; //1
            case Food_name.SCHNITZEL_CHICKEN:
                return new List<Food_name> { Food_name.CHICKEN, Food_name.FLOUR, Food_name.EGG, Food_name.BREADCRUMBS }; //4
            case Food_name.CHICKEN_SKEWER_DISH:
                return new List<Food_name> { Food_name.CHICKEN, Food_name.ONION, Food_name.TOMATO };
            case Food_name.SCHNITZEL_PORK:
                return new List<Food_name> { Food_name.PORK, Food_name.FLOUR, Food_name.EGG, Food_name.BREADCRUMBS }; //4
            case Food_name.FRIED_CHEESE:
                return new List<Food_name> { Food_name.CHEESE, Food_name.FLOUR, Food_name.EGG, Food_name.BREADCRUMBS }; //4
            case Food_name.ROASTED_CHICKEN:
                return new List<Food_name> { Food_name.CHICKEN }; //1
            case Food_name.OMELETTE:
                return new List<Food_name> { Food_name.EGG, Food_name.TOMATO, Food_name.CHEESE, Food_name.BROCCOLI }; //4
            case Food_name.BEEF_WELLINGTON:
                return new List<Food_name> { Food_name.BEEF, Food_name.MUSHROOMS, Food_name.FLOUR, Food_name.BUTTER }; //4
            case Food_name.BOEUF_BOURGUIGNON:
                return new List<Food_name> { Food_name.BEEF, Food_name.MUSHROOMS, Food_name.CARROT, Food_name.RED_WINE }; //4
            case Food_name.GARLIC_BREAD:
                return new List<Food_name> { Food_name.FLOUR, Food_name.WATER, Food_name.GARLIC, Food_name.BUTTER }; //4
            case Food_name.SALAD:
                return new List<Food_name> { Food_name.LETTUCE, Food_name.TOMATO, Food_name.CUCUMBER }; //3
            case Food_name.CHERRY_PIE:
                return new List<Food_name> { Food_name.FLOUR, Food_name.BUTTER, Food_name.SUGAR, Food_name.CHERRY }; //4
            case Food_name.APPLE_PIE:
                return new List<Food_name> { Food_name.FLOUR, Food_name.BUTTER, Food_name.SUGAR, Food_name.APPLE }; //4
            case Food_name.SCHWARZWALDEN:
                return new List<Food_name> { Food_name.FLOUR, Food_name.EGG, Food_name.SUGAR, Food_name.CHANTILLY, Food_name.CHOCOLATE, Food_name.CHERRY }; //6
            case Food_name.MAKOVNIK:
                return new List<Food_name> { Food_name.FLOUR, Food_name.MILK, Food_name.POPPY, Food_name.SUGAR }; //4
            case Food_name.CARROT_CAKE:
                return new List<Food_name> { Food_name.FLOUR, Food_name.EGG, Food_name.SUGAR, Food_name.CARROT }; //4
            case Food_name.CHEESECAKE:
                return new List<Food_name> { Food_name.BISCUIT_DUST, Food_name.EGG, Food_name.HEAVY_CREAM, Food_name.CHEESE, Food_name.SUGAR }; //5
            case Food_name.SMORES:
                return new List<Food_name> { Food_name.BISCUIT, Food_name.CHOCOLATE, Food_name.MARSHMALLOW }; //3
            case Food_name.BAKED_ALASKA:
                return new List<Food_name> { Food_name.ICE_CREAM, Food_name.WHIPPED_WHITES }; //2
            case Food_name.TIRAMISU:
                return new List<Food_name> { Food_name.COFFEE_CUP, Food_name.HEAVY_CREAM, Food_name.SUGAR, Food_name.BISCUIT, Food_name.EGG }; //4
            default:
                return new List<Food_name> { };
        }

    }

    public static int set_ingredient_points(Food_name ingredient)
    {
        switch (ingredient)
        {
            case Food_name.FLOUR:
                return 1;
            case Food_name.EGG:
            case Food_name.SUGAR:
            case Food_name.TOMATO:
            case Food_name.BEEF:
            case Food_name.CARROT:
            case Food_name.CHEESE:
            case Food_name.WATER:
            case Food_name.CHICKEN:
                return 2;
            case Food_name.ONION:
            case Food_name.BUTTER:
            case Food_name.PORK:
            case Food_name.PASTA:
                return 3;
            case Food_name.GRAPE:
            case Food_name.COFFEE_BEAN:
            case Food_name.HEAVY_CREAM:
            case Food_name.BREADCRUMBS:
            case Food_name.CABBAGE:
            case Food_name.RICE:
            case Food_name.POTATO:
                return 4;
            case Food_name.CHERRY:
            case Food_name.CHOCOLATE:
            case Food_name.BISCUIT:
            case Food_name.BACON:
            case Food_name.BROCCOLI:
            case Food_name.MUSHROOMS:
            case Food_name.GARLIC:
                return 7;
            case Food_name.MILK:
            case Food_name.APPLE:
            case Food_name.POPPY:
            case Food_name.MARSHMALLOW:
            case Food_name.LETTUCE:
            case Food_name.CUCUMBER:
            case Food_name.BRYNDZA:
            case Food_name.BEETROOT:
            case Food_name.SOY_SAUCE:
                return 13;
            case Food_name.RED_WINE:
            case Food_name.WHIPPED_WHITES:
            case Food_name.CHANTILLY:
            case Food_name.BISCUIT_DUST:
            case Food_name.COFFEE_CUP:
            case Food_name.CHICKEN_SKEWER:
            case Food_name.FRIES:
            case Food_name.MASHED_POTATOES:
            case Food_name.ICE_CREAM:
            case Food_name.COTTON_CANDY:
                return 30;
            default:
                return 0;
        }

    }

    public static int set_food_points(Food food)
    {
        int points = 0;
        foreach (Food_name ingredient in food.ingredients)
        {
            points += set_ingredient_points(ingredient);
        }

        points += 6 * food.ingredients.Count;
        return points;
    }


    int plate_points(List<CardData> plate_content, Dictionary<Food_name, Food>[] recipes)
    {
        int max_ingredients = plate_content.food.ing_count;

        for (int recipe_group = max_ingredients - 1; recipe_group > -1; recipe_group--)
        {
            foreach (Food recipe in recipes[recipe_group])
            {
                //Determines if recipe was found on plate
                if (recipe.ingredients.All(item => plate_content.Contains(item)))
                {
                    //substitutes ingredients on plate by dish_name
                    foreach (var item in listA)
                    {
                        plate_content.Remove(item);
                    }
                    plate_content.Add(recipe);
                    break;
                }

            }
            break;
        }

        //Plate food evaluated
        int points = 0;
        int ing;
        int full;
        int full_plus;
        int side;
        int dessert;
        int main_taste = 0;

        //Types of content on plate
        foreach (Food food in plate_content)
        {

            if (food.is_full)
            {
                full++;
                points += food.points;
            }
            else if (food.is_full_plus)
            {
                full_plus++;
                points += food.points;
            }
            else if (food.is_dessert)
            {
                dessert++;
                points += food.points;
            }
            else if (food.is_side)
            {
                side++;
                points += food.points;
            }
            else
            {
                ing++;
            }
        }

        //main taste
        foreach (Food food in plate_content)
        {
            if (main_taste == 0)
            {
                if (food.is_full)
                {
                    main_taste = food.taste;
                    break;
                }
                else if (food.is_full_plus && !full)
                {
                    main_taste = food.taste;
                    break;
                }
                else if (food.is_dessert && !full && !full_plus)
                {
                    main_taste = food.taste;
                    break;
                }
                else if (food.is_side && !full & !full_plus && !dessert)
                {
                    main_taste = food.taste;
                    break;
                }
                else if (!full && !full_plus && !dessert && !side)
                {
                    main_taste = food.taste;
                    break;
                }
            }
        }

        //Subtract incorrect ingredients
        if (full_plus && !side)
        {
            points *= 0.75;
        } else if (full && side)
        {
            points *= 0.9;
        }

        //Sub points for incorrect taste pairings
        foreach (Food food in plate_content)
        {
            if (food.is_ingredient && (food.taste == main_taste))
            {
                if (food.points >= 13)
                {
                    points -= food.points / 2;
                }
                points -= food.points;
            }
            else if (food.is_ingredient && (food.taste != main_taste))
            {
                if (food.points >= 13)
                {
                    points -= food.points;
                }
                points -= food.points * 2;
            }

        }

        return points;
    }




    static void Main()
    {
        Dictionary<Food_name, Food>[] all_food = new Dictionary<Food_name, Food>[6];

        for (int i = 0; i < all_food.Length; i++)
        {
            all_food[i] = new Dictionary<Food_name, Food>();
        }


        foreach (Food_name food in Enum.GetValues(typeof(Food_name)))
        {
            Food current_food = new Food();
            current_food.name = food;

            //BASIC INGREDIENTS
            if (food < Food_name.PASTA)
            {

                current_food.ingredients.Add(food);
                current_food.is_ingredient = 1;


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


                current_food.points = set_ingredient_points(food);


            }
            //BASIC INGREDIENTS THAT ARE SIDES
            else if (food < Food_name.ICE_CREAM)
            {
                current_food.ingredients.Add(food);
                current_food.is_side = 1;
                current_food.taste = -1;
                current_food.points = set_ingredient_points(food);

            }
            //BASIC INGREDIENTS THAT ARE DESSERTS
            else if (food >= Food_name.ICE_CREAM && food < Food_name.SPAGHETTI_MARINARA)
            {
                current_food.ingredients.Add(food);
                current_food.is_dessert = 1;
                current_food.taste = 1;
                current_food.points = set_ingredient_points(food);
            }
            else
            {
                current_food.ingredients.AddRange(get_ingredients(food));

                //FULL
                if (food >= Food_name.SPAGHETTI_MARINARA && food < Food_name.STEAK)
                {
                    current_food.is_full = 1;
                    current_food.taste = -1;

                }
                //FULL_PLUS
                else if (food >= Food_name.STEAK && food < Food_name.GARLIC_BREAD)
                {
                    current_food.is_full_plus = 1;
                    current_food.taste = -1;
                }
                //NOT BASIC SIDES
                else if (food >= Food_name.GARLIC_BREAD && food < Food_name.CHERRY_PIE)
                {
                    current_food.is_side = 1;
                    current_food.taste = -1;
                }
                //DESSERTS
                else
                {
                    current_food.is_dessert = 1;
                    current_food.taste = 1;

                }

                current_food.points = set_food_points(current_food);

            }

            //add food to dictionary
            current_food.ing_count = current_food.ingredients.Count;

            all_food[current_food.ing_count - 1].Add(current_food.name, current_food);



        }

       

    }

}



/*
CIVET
PENGUIN
ELEPHANT
SPIDER


*/
