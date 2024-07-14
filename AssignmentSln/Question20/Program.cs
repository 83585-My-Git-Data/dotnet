namespace Question7
{
    internal class Program
    {

        class Date
        {
            private int day;
            private int month;
            private int year;

            public Date()
            {
                day = 1;
                month = 1;
                year = 2000;
            }

            public Date(int day, int month, int year)
            {
                this.day = day;
                this.month = month;
                this.year = year;
            }

            public int Day
            {
                get { return day; }
                set { day = value; }
            }

            public int Month
            {
                get { return month; }
                set { month = value; }
            }

            public int Year
            {
                get { return year; }
                set { year = value; }
            }

            public bool IsValid()
            {
                if (year < 1 || month < 1 || month > 12 || day < 1 || day > 31)
                {
                    return false;
                }

                if (month == 2)
                {
                    if (IsLeapYear() && day > 29)
                        return false;
                    else if (!IsLeapYear() && day > 28)
                        return false;
                }

                if ((month == 4 || month == 6 || month == 9 || month == 11) && day > 30)
                    return false;

                return true;
            }

            private bool IsLeapYear()
            {
                return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
            }

            public int CalculateAge()
            {
                DateTime today = DateTime.Today;
                int age = today.Year - year;

                // Check if birthday has occurred this year
                if (month > today.Month || (month == today.Month && day > today.Day))
                {
                    age--;
                }

                return age;
            }

            public void AcceptDate()
            {
                Console.Write("Enter Day: ");
                day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Month: ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Year: ");
                year = Convert.ToInt32(Console.ReadLine());
            }

            public override string ToString()
            {
                return $"{day}/{month}/{year}";
            }
        }

        class Person
        {
            private string name;
            private bool gender;
            private Date birth;
            private string address;

            // Default constructor
            public Person()
            {
                name = "";
                gender = true; // Assuming default gender is Male
                birth = new Date();
                address = "";
            }

            // Parameterized constructor
            public Person(string name, bool gender, Date birth, string address)
            {
                this.name = name;
                this.gender = gender;
                this.birth = birth;
                this.address = address;
            }

            // Properties
            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public bool Gender
            {
                get { return gender; }
                set { gender = value; }
            }

            public Date Birth
            {
                get { return birth; }
                set { birth = value; }
            }

            public string Address
            {
                get { return address; }
                set { address = value; }
            }

            public int Age
            {
                get { return birth.CalculateAge(); }
            }

            // Method to accept data from console
            public void Accept()
            {
                Console.Write("Enter Name: ");
                name = Console.ReadLine();

                Console.Write("Enter Gender (true for Male, false for Female): ");
                gender = Convert.ToBoolean(Console.ReadLine());

                Console.WriteLine("Enter Birth Date:");
                birth.AcceptDate();

                Console.Write("Enter Address: ");
                address = Console.ReadLine();
            }

            // Method to print data to console
            public void Print()
            {
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Gender: {(gender ? "Male" : "Female")}");
                Console.WriteLine($"Birth Date: {birth}");
                Console.WriteLine($"Address: {address}");
                Console.WriteLine($"Age: {Age}");
            }

            // ToString method to return data in string format
            public override string ToString()
            {
                return $"Name: {name}, Gender: {(gender ? "Male" : "Female")}, Birth Date: {birth}, Address: {address}, Age: {Age}";
            }
        }


        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person();

            Console.WriteLine("Enter details for person1:");
            person1.Accept();

            Console.WriteLine("\nEnter details for person2:");
            person2.Accept();

            Console.WriteLine("\nDetails of person1:");
            person1.Print();

            Console.WriteLine("\nDetails of person2:");
            person2.Print();

            Console.WriteLine("\nString representation of person1:");
            Console.WriteLine(person1.ToString());

            Console.WriteLine("\nString representation of person2:");
            Console.WriteLine(person2.ToString());
        }
    }
}
