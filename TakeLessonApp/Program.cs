using System;
using System.Collections.Generic;
using System.Threading;

namespace TakeLessonApp
{
    class Program
    {
        public static List<string> subjects = new List<string>();
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("candra.irawan1", "$2b$10$8tzD9anTWecp9EtPdg2uMu3Q9GU7GvokUIT1JFw2ToW/bJ1NRGEWy"));
            students.Add(new Student("maikel.irawan2", "$2b$10$8tzD9anTWecp9EtPdg2uMu3Q9GU7GvokUIT1JFw2ToW/bJ1NRGEWy"));
            students.Add(new Student("hanny.irawan3", "$2b$10$8tzD9anTWecp9EtPdg2uMu3Q9GU7GvokUIT1JFw2ToW/bJ1NRGEWy"));

            GuestView(students);
        }

        private static void GuestView(List<Student> students)
        {
            string username, password;

            Console.Clear();
            Console.WriteLine("\t------------------------------\t");
            Console.WriteLine("\t                              \t");
            Console.WriteLine("\t     Login School Weekend     \t");
            Console.WriteLine("\t                              \t");
            Console.WriteLine("\t------------------------------\t");
            Console.WriteLine("\t                              \t");
            Console.Write("\tUsername : ");
            username = Console.ReadLine();
            Console.WriteLine("\t                              \t");
            Console.Write("\tPassword : ");
            password = Console.ReadLine();
            Console.WriteLine("\t                              \t");
            Console.WriteLine("\t------------------------------\t");
            Console.WriteLine("\t                              \t");

            Student student = new Student(username, password);

            LoadingView();

            if (student.Authentication(students))
            {
                DashboardView(username, students);
            }
            else
            {
                MessageNotification(true, "User not found", students);
            }

        }

        static void DashboardView(string username, List<Student> students)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\t------------------------------\t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine($"\t     {username}     \t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t------------------------------\t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t1. Add Subject\t");
                Console.WriteLine("\t2. View Friend\t");
                Console.WriteLine("\t3. View Profile\t");
                Console.WriteLine("\t4. Logout\t");
                Console.WriteLine("");
                Console.Write("\tEnter the number (1-4) : ");
                int menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        SubjectView(username,students);
                        break;
                    case 2:
                        FriendView(username, students);
                        break;
                    case 3:
                        ProfileView(username, students);
                        break;
                    case 4:
                        GuestView(students);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
                MessageNotification(false, "Please enter number", students);
                DashboardView(username, students);
            }
        }

        static void SubjectView(string username, List<Student> students)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\t------------------------------\t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t         Choose Subject       \t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t------------------------------\t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t1. Mathematics\t");
                Console.WriteLine("\t2. Phiysics\t");
                Console.WriteLine("\t3. Biology\t");
                Console.WriteLine("\t4. Exit\t");
                Console.WriteLine("");
                Console.Write("\tEnter the number (1-4) : ");
                int chooseSubject = Convert.ToInt32(Console.ReadLine());
                switch (chooseSubject)
                {
                    case 1:
                        SaveSubject("Mathematics",username,students);
                        break;
                    case 2:
                        SaveSubject("Phiysics", username, students);
                        break;
                    case 3:
                        SaveSubject("Biology", username, students);
                        break;
                    case 4:
                        DashboardView(username,students);
                        break;
                    default:
                        SubjectView(username,students);
                        break;
                }
            }
            catch (Exception)
            {
                MessageNotification(false, "Please enter number",students);
                SubjectView(username, students);
            }
        }


        static void FriendView(string username, List<Student> students)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\t------------------------------\t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t         List Friend       \t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t------------------------------\t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine("\t" + (i + 1) + "." + " " + students[i].UserName + "\t");
                }
                Console.WriteLine("");
                Console.Write("\tEnter number 4 to exit : ");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 4:
                        DashboardView(username, students);
                        break;
                    default:
                        FriendView(username, students);
                        break;
                }
            }
            catch (Exception)
            {
                MessageNotification(false, "Please enter number",students);
                FriendView(username, students);
            }
        }


        static void ProfileView(string username, List<Student> students)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\t------------------------------\t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t         My Profile       \t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t------------------------------\t");
                Console.WriteLine("\t                              \t");
                Console.WriteLine("\t" + "Username : " + username + "\t");
                Console.Write("\tSubject  : ");
                for (int i = 0; i < subjects.Count; i++)
                {
                    if (subjects.Count - 1 == i)
                    {
                        Console.Write(subjects[i] + "");
                    }
                    else
                    {
                        Console.Write(subjects[i] + ", ");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.Write("\tEnter number 4 to exit  : ");
                int choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 4:
                        DashboardView(username,students);
                        break;
                    default:
                        ProfileView(username,students);
                        break;
                }
            }
            catch (Exception)
            {
                MessageNotification(false, "Please enter number", students);
                ProfileView(username, students);
            }
        }


        static void SaveSubject(string subject,string username, List<Student> students)
        {
            if (CheckSubject(subject))
            {
                MessageNotification(false, "Data already exists", students);
                SubjectView(username,students);
            }
            else
            {
                subjects.Add(subject);
                MessageNotification(false, "Successfully saved",students);
                SubjectView(username, students);
            }
        }

        static bool CheckSubject(string subject)
        {
            foreach (var item in subjects)
            {
                if (item == subject)
                {
                    return true;
                }
            }
            return false;
        }



        private static void LoadingView()
        {

            int load = 20;
            Console.Write("\tLoading.");
            for (int i = 0; i < load; i++)
            {
                Console.Write(".");
                Thread.Sleep(400);
            }
        }

        private static void MessageNotification(bool isAuthentication, string message, List<Student> students)
        {
            Console.Clear();
            Console.WriteLine("\t------------------------------\t");
            Console.WriteLine("\t                              \t");
            Console.WriteLine($"\t     {message}     \t");
            Console.WriteLine("\t                              \t");
            Console.WriteLine("\t------------------------------\t");
            Thread.Sleep(1500);
            if (isAuthentication)
            {
                GuestView(students);
            }

        }


    }
}
