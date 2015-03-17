namespace RestaurantManager.Models
{
    using System;
    using System.Text;
    using RestaurantManager.Interfaces;

    public class MainCourse : Meal, IMainCourse
    {
        private MainCourseType type;

        public MainCourse(string name, decimal price, int calories, int quantity, int timeToPrepare, bool isVegan, string type)
            : base(name, price, calories, quantity, timeToPrepare, isVegan)
        {
            switch (type)
            {
                case "Soup": this.Type = MainCourseType.Soup;
                    break;
                case "Entree": this.Type = MainCourseType.Entree;
                    break;
                case "Pasta": this.Type = MainCourseType.Pasta;
                    break;
                case "Side": this.Type = MainCourseType.Side;
                    break;
                case "Meat": this.Type = MainCourseType.Meat;
                    break;
                case "Other": this.Type = MainCourseType.Other;
                    break;
                default: this.Type = MainCourseType.Other;
                    break;
            }
        }

        public MainCourseType Type
        {
            get
            {
                return this.type;
            }

            private set
            {
                this.type = value;
            }
        }

        public override string ToString()
        {
            var printMainCourse = new StringBuilder(base.ToString());

            printMainCourse.AppendFormat("\r\nType: {0}", this.Type);

            return printMainCourse.ToString();
        }
    }
}