namespace ConsoleApp1
{
    class Human
    {
        private int age;

        public int GetAge()
        {
            return age;
        }

        public Human(int age)
        {
            if (age <= 22)
            {
                throw new ArgumentException("You entered the wrong age");
            }

            this.age = age;
        }
    
    }
    
}
