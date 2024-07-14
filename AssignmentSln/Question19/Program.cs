namespace Question6
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

            public void AcceptDate()
            {
                Console.Write("Enter Day: ");
                day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Month: ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Year: ");
                year = Convert.ToInt32(Console.ReadLine());
            }

            public void PrintDate()
            {
                Console.WriteLine($"{day}/{month}/{year}");
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

            public override string ToString()
            {
                return $"{day}/{month}/{year}";
            }

            public static int DifferenceInYears(Date d1, Date d2)
            {
                return Math.Abs(d1.year - d2.year);
            }

            public static int operator -(Date d1, Date d2)
            {
                return DifferenceInYears(d1, d2);
            }
        }


        static void Main(string[] args)
        {
            Date date1 = new Date(10, 7, 2024);
            Date date2 = new Date();

            Console.WriteLine("Enter details for date2:");
            date2.AcceptDate();

            Console.WriteLine("\nDate1:");
            date1.PrintDate();
            Console.WriteLine($"Valid: {date1.IsValid()}");

            Console.WriteLine("\nDate2:");
            date2.PrintDate();
            Console.WriteLine($"Valid: {date2.IsValid()}");

            Console.WriteLine($"\nDifference in years between date1 and date2: {date1 - date2}");
        }
    }
}
