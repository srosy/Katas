namespace DesignPatterns
{
    public sealed class President
    {
        /* 
            When to use: Use when there can only ever be a single Instance of this class. There can only ever be one president of the USA, for example.
            To create a singleton, make the constructor private, disable cloning, disable extension and create a static variable to house the instance
         */

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Create two pointers to the President Singleton");
        //    var president1 = President.GetInstance();
        //    var president2 = President.GetInstance();
        //    Console.WriteLine($"President1 and President2 are equal: {president1 == president2}");
        //}

        private static President Instance = null;
        private President() { }

        public static President GetInstance()
        {
            if (Instance == null)
            {
                Instance = new President();
            }

            return Instance;
        }

        private void Clone()
        {
            // disable cloning
        }

        private void WakeUp()
        {
            // disable unserialize
        }

    }
}
