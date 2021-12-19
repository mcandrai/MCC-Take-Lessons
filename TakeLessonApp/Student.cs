using System;
using System.Collections.Generic;
using System.Threading;

namespace TakeLessonApp
{
    class Student
    {
      
        public string UserName { get; set; }
        public string Password { get; set; }

  
        public Student(string username, string password)
        {
            UserName = username;
            Password = password;
        }


        public bool Authentication(List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                Student student = students[i];
                if (student.UserName == UserName && BCrypt.Net.BCrypt.Verify(Password, student.Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
