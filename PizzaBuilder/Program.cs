using System;
using System.Collections.Generic;

namespace PizzaBuilder
{
    public interface IPizzaBuilder
    {
        void BuildDough();
        void BuildSauce();
        void BuildTopping();
        public void Reset();

    }
    public class ConcreteWhitePizzaBuilder : IPizzaBuilder
    {
        private WhitePizza _white = new WhitePizza();

        public ConcreteWhitePizzaBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._white = new WhitePizza();
        }
        public void BuildDough()
        {
            this._white.Add("White dough pizza");
        }
        public void BuildSauce()
        {
            this._white.Add("White Sauce pizza");
        }
        public void BuildTopping()
        {
            this._white.Add(" white Cheese topping pizza");
        }
        public WhitePizza GetPizza()
        {
            WhitePizza result = this._white;
            this.Reset();
            return result;
        }
    }

    public class WhitePizza
    {
        private List<object> _pizaaparts = new List<object>();
        public void Add(string part)
        {
            this._pizaaparts.Add(part);
        }
        public string ListpizzaParts()
        {
            string str = string.Empty;
            for (int i = 0; i < this._pizaaparts.Count; i++)
            {
                str += this._pizaaparts[i] + ", ";
            }
            str = str.Remove(str.Length - 2);
            return "Pizza parts: " + str + "\n";
        }
    }

    public class ConcreteWheatPizzaBuilder : IPizzaBuilder
    {
        private WheatPizza _wheat = new WheatPizza();

        public ConcreteWheatPizzaBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._wheat = new WheatPizza();
        }
        public void BuildDough()
        {
            this._wheat.Add("Wheat dough pizza");
        }
        public void BuildSauce()
        {
            this._wheat.Add("whteat Tomato Sauce pizza");
        }
        public void BuildTopping()
        {
            this._wheat.Add("wheat ranch toping pizaa");
        }
        public WheatPizza GetPizza()
        {
            WheatPizza result = this._wheat;
            this.Reset();
            return result;
        }
    }

    public class WheatPizza
    {
        private List<object> _pizzaparts = new List<object>();
        public void Add(string part)
        {
            this._pizzaparts.Add(part);
        }
        public string ListpizzaParts()
        {
            string str = string.Empty;
            for (int i = 0; i < this._pizzaparts.Count; i++)
            {
                str += this._pizzaparts[i] + ", ";
            }
            str = str.Remove(str.Length - 2);
            return "Pizza parts: " + str + "\n";
        }
    }
    public class Director
    {
        private IPizzaBuilder _pizzaBuilder;
        public IPizzaBuilder PizzaBuilder
        {
            set => _pizzaBuilder = value;
        }
        public void BuildPizzaWithTopping()
        {
            this._pizzaBuilder.BuildDough();
            this._pizzaBuilder.BuildTopping();
        }
        public void BuildFullPizza()
        {
            this._pizzaBuilder.BuildDough();
            this._pizzaBuilder.BuildSauce();
            this._pizzaBuilder.BuildTopping();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var director = new Director();
            var whitePizzaBuilder = new ConcreteWhitePizzaBuilder();
            var wheatPizzaBuilder = new ConcreteWheatPizzaBuilder();
            director.PizzaBuilder = whitePizzaBuilder;

            //White Pizza
            Console.WriteLine("Standard white Pizza:");
            director.BuildPizzaWithTopping();
            Console.WriteLine(whitePizzaBuilder.GetPizza().ListpizzaParts());

            Console.WriteLine("Full white Pizza:");
            director.BuildFullPizza();
            Console.WriteLine(whitePizzaBuilder.GetPizza().ListpizzaParts());

            //wheat Pizza
            director.PizzaBuilder = wheatPizzaBuilder;
            Console.WriteLine("Standard wheat Pizza:");
            director.BuildPizzaWithTopping();
            Console.WriteLine(wheatPizzaBuilder.GetPizza().ListpizzaParts());

            Console.WriteLine("Full wheat Pizza:");
            director.BuildFullPizza();
            Console.WriteLine(wheatPizzaBuilder.GetPizza().ListpizzaParts());

            //Custom white Pizza
            Console.WriteLine("Custom white Pizza:");
            whitePizzaBuilder.BuildDough();
            whitePizzaBuilder.BuildTopping();
            Console.Write(whitePizzaBuilder.GetPizza().ListpizzaParts() + "\n");

            //Custom wheat Pizza
            Console.WriteLine("Custom wheat Pizza:");
            wheatPizzaBuilder.BuildDough();
            wheatPizzaBuilder.BuildTopping();
            Console.Write(wheatPizzaBuilder.GetPizza().ListpizzaParts());
        }
    }
}