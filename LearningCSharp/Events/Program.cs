using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public delegate void LearningTracker(int currentKnowledge);
    class Student
    {
        public event LearningTracker Changed;
        private int TotalKnowledge = 0;

        public virtual void OnChanged()
        {
            if (Changed != null)
            {
                Changed(TotalKnowledge);
            }
        }

        public void ReadBook(int bookKnowledge)
        {
            TotalKnowledge += bookKnowledge;
            OnChanged();
        }

        public void Forget(int knowledge)
        {
            TotalKnowledge -= knowledge;
            OnChanged();
        }

    }
    class Program
    {
        public static void PrintCurrentKnowledge(int knowledge)
        {
            Console.WriteLine("Method delegate {0}", knowledge);
        }
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Changed += new LearningTracker(PrintCurrentKnowledge);
            student.Changed += new LearningTracker(s => Console.WriteLine(" With lambda! {0}", s));

            student.ReadBook(100);
            student.Forget(50);

        }
    }
}
