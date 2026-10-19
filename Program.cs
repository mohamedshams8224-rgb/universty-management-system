using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace universty_management_system
{
    
    class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public Instructor(int instructorId, string name , string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }
        public string PrintDetails()
        {
            return $"instructor id : {InstructorId}\n" +
                $"name : {Name}\n" +
                $"specialization : {Specialization}";
        }

    }
    class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }
        public Instructor Instructor { get; set; }


        public Course(int courseId, string title, Instructor instructor)
        {
            CourseId = courseId;
            Title = title;
            Instructor = instructor; 
            
        }

        public string PrintDetails()
        {
            return $"course id : {CourseId} \n" +
                $"course title : {Title}\n" +
                $"instructor : {Instructor.Name}";
        }
    }
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        
        public Student(int studentId, string name, int age )
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            
        }
        
        public bool Enroll(Course course)
        {
            Courses.Add(course);
            return true;
        }

        public string PrintDetails()
        {
            return $"student id : {StudentId}\n" +
                $"student name : {Name}\n" +
                $"student age : {Age}";

        }
    }
    class StudentManager
    {
        List<Student> Students { get; set; } = new List<Student>();
        List<Course> Courses { get; set; } = new List<Course>();
        List<Instructor> Instructors { get; set; } = new List<Instructor>();
        public bool AddStudent(Student student) 
        {
           for(int i=0; i< Students.Count; i++)
            {
                if(student.StudentId == Students[i].StudentId)
                {
                    return false;
                }
            }
            Students.Add(student);
            return true;
        }
        public bool AddCourse(Course course) 
        {
           for(int i = 0; i < Courses.Count; i++)
            {
                if(course.CourseId == Courses[i].CourseId)
                {
                    return false;
                }
            }
            Courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor) 
        {
           for(int i=0; i < Instructors.Count; i++)
            {
                if(instructor.InstructorId == Instructors[i].InstructorId)
                {
                    return false;
                }
            }
            Instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId) 
        {
           for (int i = 0; i < Students.Count; i++ )
            {
                if (Students[i].StudentId == studentId)
                {
                    return Students[i];
                }
            }
            return null;
        }
        public Course FindCourse(int courseId)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].CourseId == courseId)
                {
                    return Courses[i];
                }
            }

            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].InstructorId == instructorId)
                {
                    return Instructors[i];
                }
            }

            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);

            if (student == null || course == null)
            {
                return false;
            }

            return student.Enroll(course);
        }
        public void ShowAllStudents()
        {
            for (int i = 0; i < Students.Count; i++)
            {
                Console.WriteLine(Students[i].PrintDetails());
            }
        }
        public void ShowAllCourse()
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                Console.WriteLine(Students[i].PrintDetails());
            }
        }
        public void ShowAllInstructor()
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                Console.WriteLine(Students[i].PrintDetails());
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student(1, "mohamed" , 22);
            Instructor instructor_1 = new Instructor(1 , "hany" , "math");
            Course c1 = new Course(1, "math" , instructor_1);


        }
    }

}
