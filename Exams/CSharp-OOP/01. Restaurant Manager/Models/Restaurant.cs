namespace RestaurantManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using RestaurantManager.Interfaces;

    public class Restaurant : IRestaurant
    {
        private string name;
        private string location;
        private readonly IList<IRecipe> recipes;

        private const string DrinksTitle = "~~~~~ DRINKS ~~~~~";
        private const string SaladsTitle = "~~~~~ SALADS ~~~~~";
        private const string MainCoursesTitle = "~~~~~ MAIN COURSES ~~~~~";
        private const string DessertsTitle = "~~~~~ DESSERTS ~~~~~";

        public Restaurant(string name, string location)
        {
            this.Name = name;
            this.Location = location;
            this.recipes = new List<IRecipe>();
        }

        #region Properties

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Restaurant name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Restaurant location cannot be null or empty!");
                }

                this.location = value;
            }
        }

        public IList<IRecipe> Recipes
        {
            get
            {
                return this.recipes;
            }

            private set { }
        }
        #endregion

        public void AddRecipe(IRecipe recipe)
        {
            this.recipes.Add(recipe);
        }

        public void RemoveRecipe(IRecipe recipe)
        {
            this.recipes.Remove(recipe);
        }

        public string PrintMenu()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            var restaurant = new StringBuilder();

            restaurant.AppendFormat("***** {0} - {1} *****", this.Name, this.Location);

            if (this.recipes.Count > 0)
            {
                var drinks = this.recipes.Where(type => type.GetType().Name == "Drink").OrderBy(x => x.Name).ToList();
                var salads = this.recipes.Where(type => type.GetType().Name == "Salad").OrderBy(x => x.Name).ToList();
                var mainCourses = this.recipes.Where(type => type.GetType().Name == "MainCourse").OrderBy(x => x.Name).ToList();
                var desserts = this.recipes.Where(type => type.GetType().Name == "Dessert").OrderBy(x => x.Name).ToList();

                if (drinks.Count > 0)
                {
                    restaurant.Append(Environment.NewLine + DrinksTitle + Environment.NewLine + string.Join(Environment.NewLine, drinks));
                }
                if (salads.Count > 0)
                {
                    restaurant.Append(Environment.NewLine + SaladsTitle + Environment.NewLine + string.Join(Environment.NewLine, salads));
                }
                if (mainCourses.Count > 0)
                {
                    restaurant.Append(Environment.NewLine + MainCoursesTitle + Environment.NewLine + string.Join(Environment.NewLine, mainCourses));
                }
                if (desserts.Count > 0)
                {
                    restaurant.Append(Environment.NewLine + DessertsTitle + Environment.NewLine + string.Join(Environment.NewLine, desserts));
                }
            }
            else
            {
                restaurant.Append("\r\nNo recipes... yet");
            }

            return restaurant.ToString();
        }
    }
}