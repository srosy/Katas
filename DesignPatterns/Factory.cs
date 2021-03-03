namespace DesignPatterns
{
    /*
        When to use?

        Useful when there is some generic processing in a class but the required sub-class is dynamically
        decided at runtime. Or putting it in other words, when the client doesn't know what exact sub-class it might need.
     */

    //static void Main(string[] args)
    //{
    //    Console.WriteLine("Contructing an Object using a Factory...");
    //    var _object = Factory.CreateObject(5, 5);
    //    Console.WriteLine("Object Contructed.");
    //}

    public class Factory
    {
        public static Object CreateObject(int width, int height)
        {
            return new Object(width, height);
        }
    }

    public class Object
    {
        protected int Width { get; set; }
        protected int Height { get; set; }

        public Object(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
