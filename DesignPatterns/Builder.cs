namespace DesignPatterns
{
    /*
        When to use?
        When there could be several flavors of an object and to avoid the constructor telescoping.
        The key difference from the factory pattern is that; factory pattern is to be used when the creation
        is a one step process while builder pattern is to be used when the creation is a multi step process.
     */

    //static void Main(string[] args)
    //{
    //    Console.WriteLine("Building a Burger using a BurgerBuilder.");
    //    var burger = new BurgerBuilder().AddCheese().AddLettuce().AddOnion().AddPickle().AddTomato().Build();
    //    Console.WriteLine("MMMMM that's a tasty Burger.");
    //}

    public class BurgerBuilder
    {
        public bool Cheese { get; set; }
        public bool Lettuce { get; set; }
        public bool Onion { get; set; }
        public bool Tomato { get; set; }
        public bool Pickle { get; set; }
        public bool Buns { get; set; }
        public bool Patty { get; set; }

        public BurgerBuilder()
        {
            Buns = true;
            Patty = true;
        }

        public Burger Build()
        {
            return new Burger(this);
        }

        public BurgerBuilder AddCheese()
        {
            Cheese = true;
            return this;
        }

        public BurgerBuilder AddLettuce()
        {
            Lettuce = true;
            return this;
        }

        public BurgerBuilder AddTomato()
        {
            Tomato = true;
            return this;
        }

        public BurgerBuilder AddOnion()
        {
            Onion = true;
            return this;
        }

        public BurgerBuilder AddPickle()
        {
            Pickle = true;
            return this;
        }
    }

    public class Burger
    {
        protected bool Cheese { get; set; }
        protected bool Lettuce { get; set; }
        protected bool Onion { get; set; }
        protected bool Tomato { get; set; }
        protected bool Pickle { get; set; }

        public Burger(BurgerBuilder builder)
        {
            Cheese = builder.Cheese;
            Lettuce = builder.Lettuce;
            Onion = builder.Onion;
            Tomato = builder.Tomato;
            Pickle = builder.Pickle;
        }
    }
}
