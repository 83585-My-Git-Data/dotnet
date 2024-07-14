namespace Question5
{
    internal class Program
    {

        static Student[] students;

        static void Main(string[] args)
        {
            CreateArray();
            AcceptInfo();
            PrintInfo();
            ReverseArray();
            PrintInfo();
        }

        static void CreateArray()
        {
            Console.Write("Enter the number of students: ");
            int count = Convert.ToInt32(Console.ReadLine());
            students = new Student[count];
        }

        static void AcceptInfo()
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine($"Enter details for student {i + 1}:");
                students[i].AcceptDetails();
            }
        }

        static void PrintInfo()
        {
            Console.WriteLine("Student Details:");
            foreach (var student in students)
            {
                student.PrintDetails();
            }
        }

        static void ReverseArray()
        {
            Array.Reverse(students);
        }

    }
}
