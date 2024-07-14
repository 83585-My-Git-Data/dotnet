namespace Question8
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

        // Define a Person class for basic personal information
        class Person
        {
            protected string name;
            protected bool gender;
            protected Date birth;
            protected string address;

            public Person()
            {
                name = "";
                gender = true; // Assuming default gender is Male
                birth = new Date();
                address = "";
            }

            public Person(string name, bool gender, Date birth, string address)
            {
                this.name = name;
                this.gender = gender;
                this.birth = birth;
                this.address = address;
            }

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

            public virtual void Accept()
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

            public virtual void Print()
            {
                Console.WriteLine($"Name: {name}");
                Console.WriteLine($"Gender: {(gender ? "Male" : "Female")}");
                Console.WriteLine($"Birth Date: {birth}");
                Console.WriteLine($"Address: {address}");
            }

            public override string ToString()
            {
                return $"Name: {name}, Gender: {(gender ? "Male" : "Female")}, Birth Date: {birth}, Address: {address}";
            }
        }

        // Define an enum for DepartmentType
        enum DepartmentType
        {
            HR,
            IT,
            Finance,
            Operations,
            Marketing
        }

        // Define the Employee class inheriting from Person
        class Employee : Person
        {
            private int id;
            private double salary;
            private string designation;
            private DepartmentType dept;

            private static int count = 1; // Static count for auto-generating id

            public Employee() : base()
            {
                id = count++;
                salary = 0.0;
                designation = "";
                dept = DepartmentType.IT; // Default department
            }

            public Employee(string name, bool gender, Date birth, string address, double salary, string designation, DepartmentType dept)
                : base(name, gender, birth, address)
            {
                id = count++;
                this.salary = salary;
                this.designation = designation;
                this.dept = dept;
            }

            public int Id
            {
                get { return id; }
            }

            public double Salary
            {
                get { return salary; }
                set { salary = value; }
            }

            public string Designation
            {
                get { return designation; }
                set { designation = value; }
            }

            public DepartmentType Dept
            {
                get { return dept; }
                set { dept = value; }
            }

            public override void Accept()
            {
                base.Accept();

                Console.Write("Enter Salary: ");
                salary = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Designation: ");
                designation = Console.ReadLine();

                Console.Write("Enter Department (0: HR, 1: IT, 2: Finance, 3: Operations, 4: Marketing): ");
                dept = (DepartmentType)Enum.Parse(typeof(DepartmentType), Console.ReadLine());
            }

            public override void Print()
            {
                base.Print();
                Console.WriteLine($"ID: {id}");
                Console.WriteLine($"Salary: {salary}");
                Console.WriteLine($"Designation: {designation}");
                Console.WriteLine($"Department: {dept}");
            }

            public override string ToString()
            {
                return base.ToString() + $", ID: {id}, Salary: {salary}, Designation: {designation}, Department: {dept}";
            }
        }


        static void Main(string[] args)
        {
            Employee emp1 = new Employee();
            Employee emp2 = new Employee();

            Console.WriteLine("Enter details for Employee 1:");
            emp1.Accept();

            Console.WriteLine("\nEnter details for Employee 2:");
            emp2.Accept();

            Console.WriteLine("\nDetails of Employee 1:");
            emp1.Print();

            Console.WriteLine("\nDetails of Employee 2:");
            emp2.Print();

            Console.WriteLine("\nString representation of Employee 1:");
            Console.WriteLine(emp1.ToString());

            Console.WriteLine("\nString representation of Employee 2:");
            Console.WriteLine(emp2.ToString());
        }
    }
}
