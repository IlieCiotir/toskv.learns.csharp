using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Delegates
{
    public struct Student
    {
        public List<int> Grades;
        public string Name;

        public Student(string name)
        {
            this.Name = name;
            Grades = new List<int>();
        }
    }

    public delegate void TeacherDelegate(Student student);
    public delegate void ReportDelegate(List<Student> student);
    public class School
    {
        List<Student> students = new List<Student>();

        public void EnlistStudent(string name)
        {
            students.Add(new Student(name));
        }

        public void HandleStudents(TeacherDelegate teacher)
        {
            foreach (Student s in students)
            {
                teacher(s);
            }
        }

        public void EndYear(ReportDelegate report)
        {
            report(students);
        }

    }

    class Report
    {
        public string EndOfYearReport;
        private struct FinalGrade
        {
            public Student Student;
            public int Grade;

            public FinalGrade(Student student, int grade)
            {
                Student = student;
                Grade = grade;
            }
        }

        public void AddClassReport(List<Student> students)
        {
            EndOfYearReport += "Class:\n";
            List<FinalGrade> orderedStudents = students.Select(s => new FinalGrade(s, s.Grades.Sum())).Where(s => s.Grade > 5000).OrderByDescending(s => s.Grade).ToList();
            foreach (FinalGrade g in orderedStudents)
            {
                EndOfYearReport += String.Format("Name: {0} | Grade: {1}\n", g.Student.Name, g.Grade);
            }
        }

    }

    class Program
    {
        static void Grade(Student student)
        {
            Console.WriteLine("Grading {0}", student.Name);
            student.Grades.Add(new Random(System.DateTime.Now.Millisecond).Next() % 100);
        }

        static void Teach(Student student)
        {
            Console.WriteLine("Teaching {0}", student.Name);
        }


        static void Main(string[] args)
        {
            School school = new School();

            school.EnlistStudent("Ion");
            school.EnlistStudent("Maria");
            school.EnlistStudent("Gicu");

            // nice feature, pitty it only allows the same type of delegate to be combined, type inference would've been awesome here
            TeacherDelegate teaching = new TeacherDelegate(Teach);
            TeacherDelegate grading = new TeacherDelegate(Grade);
            TeacherDelegate teachAndGrade = teaching + grading;

            for (int i = 0; i < 100; i++)
            {
                school.HandleStudents(teachAndGrade);
            }

            Report report = new Report();

            school.EndYear(new ReportDelegate(report.AddClassReport));

            Console.WriteLine(report.EndOfYearReport);
        }
    }
}
