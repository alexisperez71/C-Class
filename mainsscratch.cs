namespace ConsoleApp1
{
    public class test
    {
        public static void main(string[] args)
        {
            // Human someHuman;
            bool flag = false;
            while (flag is false)
            {
                try
                {
                    Console.WriteLine("Enter Age");
                    int someAge = int.Parse(Console.ReadLine());
                    Human someHuman = new Human(someAge);
                    Console.WriteLine(someHuman.GetAge());
                    flag = true;
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine("Wrong Age! Enter the correct age!");
                    


                }
            }



        }  
    }

}

