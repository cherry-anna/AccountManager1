using System;
using System.Collections.Generic;
using System.Linq;
using AccountManager.Models;
namespace AccountManager
{
    class Program
    {
        private static List<Employee> Employees = new List<Employee>();
        private static List<Report> Reports = new List<Report>();
        private static List<Project> Projects = new List<Project>();
        
        static void Main(string[] args)
        {
            Employee employee;
            Project project;
            
            employee = new Employee() { Id = 1, Name = "Ivanov" } ;
            project = new Project() { Id = 1, Name = "Sun", Description = "Make the rays of the sun" };
            Employees.Add(employee);
            Projects.Add(project);
            Reports.Add(new Report(new DateTime(2021, 9, 27, 10, 0, 0), new DateTime(2021, 9, 27, 11, 0, 0), "made 1 ray of sun", employee, project) { Id = 0});
            Reports.Add(new Report(new DateTime(2021, 9, 27, 13, 0, 0), new DateTime(2021, 9, 27, 14, 0, 0), "made 1 ray of sun", employee, project) { Id = 2 });
            Reports.Add(new Report(new DateTime(2021, 9, 28, 10, 0, 0), new DateTime(2021, 9, 28, 11, 0, 0), "made 1 ray of sun", employee, project) { Id = 4 });

            employee = new Employee() { Id = 2, Name = "Petrov" };
            project = new Project() { Id = 2, Name = "Clouds", Description = "Make 50 clouds" };
            Employees.Add(employee);
            Projects.Add(project);
            Reports.Add(new Report(new DateTime(2021, 9, 27, 10, 0, 0), new DateTime(2021, 9, 27, 11, 0, 0), "made 1 cloud", employee, project) { Id = 1 });
            Reports.Add(new Report(new DateTime(2021, 9, 27, 14, 0, 0), new DateTime(2021, 9, 27, 17, 0, 0), "made 5 clouds", employee, project) { Id = 3 });
            Reports.Add(new Report(new DateTime(2021, 9, 28, 11, 0, 0), new DateTime(2021, 9, 28, 13, 0, 0), "made 3 clouds", employee, project) { Id = 5 });

            Console.WriteLine("Welcome to Account Manager system!");

            while (true) { ShowMainMenu(); }
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t\tMain menu");
            Console.WriteLine("\t1 New report");
            Console.WriteLine("\t2 Change exist report");
            Console.WriteLine("\t3 List reports");
            Console.WriteLine("\t4 New project");
            Console.WriteLine("\t5 List projects");
            Console.WriteLine("\t6 New employee");
            Console.WriteLine("\t7 List employees");
            Console.WriteLine("\t8 Statistics");
            Console.WriteLine("\t9 Quit");

            bool isValidOption;
            do
            {
                string str = Console.ReadLine();
                isValidOption = true;
                switch (str)
                {
                    case "1":
                        NewReport();
                        break;
                    case "2":
                        ChangeExistReport();
                        break;
                    case "3":
                        ShowReports();
                        break;
                    case "4":
                        NewProject();
                        break;
                    case "5":
                        ShowProjects();
                        break;
                    case "6":
                        NewEmployee();
                        break;
                    case "7":
                        ShowEmployees();
                        break;
                    case "8":
                        Statistics();
                        break;
                    case "9":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("This is not a valid option.");
                        isValidOption = false;
                        break;
                }
            } while (!isValidOption);
        }
       
        private static void NewReport()
        {
            Employee employee=null;
            Project project=null;
            DateTime startJobTime, endJobTime;
            string description;
            
            Console.WriteLine("Create new report");
            Console.WriteLine("Enter employee ID:");
            string IdEmployee = Console.ReadLine();
            if (int.TryParse(IdEmployee, out int result))
            {
                if (Employees.Exists(e => e.Id == result))
                {
                    employee = Employees.Find(e => e.Id == result);
                }
                else {
                    Console.WriteLine("There is no employee with this ID.");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    ShowMainMenu();
                }

            }
            else
            {
                Console.WriteLine("The entered value cannot be converted to a number.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }

            Console.WriteLine("Enter project ID:");
            string IdProject = Console.ReadLine();
            if (int.TryParse(IdProject, out int resultProject))
            {
                if (Projects.Exists(p => p.Id == resultProject))
                {
                    project = Projects.Find(p=>p.Id == resultProject);
                }
                else
                {
                    Console.WriteLine("There is no project with this ID.");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    ShowMainMenu();
                }

            }
            else {
                Console.WriteLine("The entered value cannot be converted to a number.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }

            Console.WriteLine("Enter start job time to format dd/mm/yyyy hh:mm :");
            
            if (!DateTime.TryParse(Console.ReadLine(), out startJobTime))
            {
                Console.WriteLine("You have entered an incorrect value.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }

            Console.WriteLine("Enter end job time to format dd/mm/yyyy hh:mm :");

            if (!DateTime.TryParse(Console.ReadLine(), out endJobTime))
            {
                Console.WriteLine("You have entered an incorrect value.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }
                        
            Console.WriteLine("Enter description:");
            description = Console.ReadLine();

            Report report = new Report(startJobTime,endJobTime, description, employee, project);
            
            if(Reports.Count==0)
            { 
                report.Id = 0; 
            }
            else
            {
                report.Id = Reports.Max(r => r.Id)+1;
            }
             
            
            Reports.Add(report);
            Console.WriteLine("Report added successfully.");
            Console.WriteLine("Press any key");
            Console.ReadKey();
            ShowMainMenu();

        }
        private static void ChangeExistReport()
        {
            Report report=null;
           
            Console.WriteLine("Change exist report");
            Console.WriteLine("Enter report ID:");
            string IdReport = Console.ReadLine();
            if (int.TryParse(IdReport, out int result))
            {
                if (Reports.Exists(r => r.Id == result))
                {
                    report = Reports.Find(r => r.Id == result);
                }
                else
                {
                    Console.WriteLine("There is no report with this ID.");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    ShowMainMenu();
                }

            }
            else
            {
                Console.WriteLine("The entered value cannot be converted to a number.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }

            Console.WriteLine("{0,-4} {1,-12} {2,-12} {3,-12} {4,-8} {5,-10} {6,-10}", "ID", "Employee", "StartJobTime", "EndJobTime", "Duration", "Project", "Description");
            Console.WriteLine("{0,-4} {1,-12} {2,-12:dd-MM-yyyy HH:mm} {3,-12:dd-MM-yyyy HH:mm} {4,-8} {5,-10} {6,-10}", report.Id, report.Employee.Name, report.StartJobTime, report.EndJobTime, report.Duration, report.Project.Name, report.Description);
            
            
            Console.WriteLine("\n");
            Console.WriteLine("\t Change menu");
            Console.WriteLine("\t1 Change employee");
            Console.WriteLine("\t2 Change start job time");
            Console.WriteLine("\t3 Change end job time");
            Console.WriteLine("\t4 Change project");
            Console.WriteLine("\t5 Change description");
            bool isValidOption;
            do
            {
                string str = Console.ReadLine();
                isValidOption = true;
                switch (str)
                {
                    case "1":
                        ChangeEmployeeForReport(report);
                        break;
                    case "2":
                        ChangeStartJobTime(report);
                        break;
                    case "3":
                        ChangeEndJobTime(report);
                        break;
                    case "4":
                        ChangeProject(report);
                        break;
                    case "5":
                        ChangeDescription(report);
                        break;
                    default:
                        Console.WriteLine("This is not a valid option.");
                        isValidOption = false;
                        break;
                }
            } while (!isValidOption);

           





            //Report report = new Report(startJobTime, endJobTime, description, employee, project);
            //if (Reports.Count == 0)
            //{
            //    report.Id = 0;
            //}
            //else
            //{
            //    report.Id = Reports.Max(r => r.Id) + 1;
            //}

                     
            Console.WriteLine("Change added successfully.");
            Console.WriteLine("Press any key");
            Console.ReadKey();
            ShowMainMenu();
        }
        private static void ChangeEmployeeForReport(Report report)
        {
            Employee employee = null;

            Console.WriteLine("Enter new employee ID:");
            string IdEmployee = Console.ReadLine();

            if (int.TryParse(IdEmployee, out int result))
            {
                if (Employees.Exists(e => e.Id == result))
                {
                    employee = Employees.Find(e => e.Id == result);
                }
                else
                {
                    Console.WriteLine("There is no employee with this ID.");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    ShowMainMenu();
                }

            }
            else
            {
                Console.WriteLine("The entered value cannot be converted to a number.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }

            report.Employee = employee;

        }
        private static void ChangeStartJobTime(Report report)
        {
            DateTime startJobTime;
            Console.WriteLine("Enter new start job time to format dd/mm/yyyy hh:mm :");
            if (!DateTime.TryParse(Console.ReadLine(), out startJobTime))
            {
                Console.WriteLine("You have entered an incorrect value.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }
            
            report.StartJobTime = startJobTime;
            
        } 
        private static void ChangeEndJobTime(Report report)
        {
            DateTime endJobTime;
            Console.WriteLine("Enter new end job time to format dd/mm/yyyy hh:mm :");

            if (!DateTime.TryParse(Console.ReadLine(), out endJobTime))
            {
                Console.WriteLine("You have entered an incorrect value.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }

            report.EndJobTime = endJobTime;
        }
        private static void ChangeProject(Report report)
        {
            Project project = null;
            Console.WriteLine("Enter new project ID:");
            string IdProject = Console.ReadLine();
            if (int.TryParse(IdProject, out int resultProject))
            {
                if (Projects.Exists(p => p.Id == resultProject))
                {
                    project = Projects.Find(p => p.Id == resultProject);
                }
                else
                {
                    Console.WriteLine("There is no project with this ID.");
                    Console.WriteLine("Press any key");
                    Console.ReadKey();
                    ShowMainMenu();
                }

            }
            else
            {
                Console.WriteLine("The entered value cannot be converted to a number.");
                Console.WriteLine("Press any key");
                Console.ReadKey();
                ShowMainMenu();
            }

            report.Project = project;
        }
        private static void ChangeDescription(Report report)
        {
            string description;
            Console.WriteLine("Enter new description:");
            description = Console.ReadLine();
            report.Description = description;
        }
        private static void ShowReports()
        {

            Console.WriteLine("List reports");
            Console.WriteLine("{0,-2} {1,-6} {2,-12} {3,-12} {4,-8} {5,-6} {6,-10}", "ID", "Employee", "StartJobTime", "EndJobTime", "Duration", "Project", "Description");
            foreach (Report report in Reports)
            {
                Console.WriteLine("{0,-2} {1,-6} {2,-12:dd-MM-yyyy HH:mm} {3,-12:dd-MM-yyyy HH:mm} {4,-8} {5,-6} {6,-10}", report.Id, report.Employee.Name, report.StartJobTime, report.EndJobTime, report.Duration, report.Project.Name, report.Description);
            }
            Console.ReadKey();
           
        }
        private static void NewProject()
        {
            Project project = new Project();
            Console.WriteLine("Create new project");
            Console.WriteLine("Enter name project:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description project:");
            string description = Console.ReadLine();

            project.Name = name;
            project.Description = description;

            if (Projects.Count == 0)
            {
                project.Id = 0;
            }
            else
            {
                project.Id = Projects.Max(p => p.Id) + 1;
            }
            Projects.Add(project);
            Console.WriteLine("Project added successfully.");
            Console.WriteLine("Press any key");
            Console.ReadKey();
            ShowMainMenu();
        }
        private static void ShowProjects()
        {
            Console.WriteLine("List projects");
            Console.WriteLine("{0,-4} {1,-12} {2,-12} ", "ID", "Project name", "Project description");
            foreach (Project project in Projects)
            {
                Console.WriteLine("{0,-4} {1,-12} {2,-12} ", project.Id, project.Name, project.Description);
            }
            Console.ReadKey();
        }
        private static void NewEmployee()
        {
            Employee employee = new Employee();
            Console.WriteLine("Create new employee");
            Console.WriteLine("Enter name employee:");
            string name = Console.ReadLine();
            employee.Name =name;

            if (Employees.Count == 0)
            {
                employee.Id = 0;
            }
            else
            {
                employee.Id = Employees.Max(e => e.Id) + 1;
            }
            Employees.Add(employee);
            Console.WriteLine("Employee added successfully.");
            Console.WriteLine("Press any key");
            Console.ReadKey();
            ShowMainMenu();
        }
        private static void ShowEmployees()
        {

            Console.WriteLine("List employees");
            Console.WriteLine("{0,-4} {1,-12} ", "ID", "Employee name");
            foreach (Employee employee in Employees)
            {
                Console.WriteLine("{0,-4} {1,-12} ", employee.Id, employee.Name);
            }
            Console.ReadKey();

        }
        private static void Statistics()
        {
            Console.WriteLine("\t\tMenu statistics");
            Console.WriteLine("\t1 DailyStatistics");
            //Console.WriteLine("\t2 ProjectStatistics");
            //Console.WriteLine("\t3 EmployeeStatistics");
            //Console.WriteLine("\t4 StatisticsForTheMonth");

            bool isValidOption;
            do
            {
                string str = Console.ReadLine();
                isValidOption = true;
                switch (str)
                {
                    case "1":
                        DailyStatistics();
                        break;
                    //case "2":
                    //    ProjectStatistics();
                    //    break;
                    //case "3":
                    //    EmployeeStatistics();
                    //    break;
                    //case "4":
                    //    StatisticsForTheMonth();
                    //    break;
                    
                    default:
                        Console.WriteLine("This is not a valid option.");
                        isValidOption = false;
                        break;
                }
             } while (!isValidOption) ;
                      
        }
        private static void DailyStatistics()
        {
            var result = 
            Reports.GroupBy(r => r.StartJobTime.Date).Select(g =>
            g.GroupBy(ig => ig.Employee).Select(e =>

              new
              {
                  day = g.Key,
                  empId = e.Key.Id,
                  empName = e.Key.Name,
                  duration = new TimeSpan(e.Sum(r => r.Duration.Ticks))
              })).SelectMany(G=>G.Select(e=>e));

            Console.WriteLine("Daily statistics");
            Console.WriteLine("{0,-12} {1,-12} {2,-14} {3,-12} ", "Day", "Employee ID", "Employee name", "Duration");
            foreach (var item in result)
            {
                Console.WriteLine("{0,-12:dd-MM-yyyy} {1,-12} {2,-14} {3,-12:hh\\:mm\\:ss} ", item.day, item.empId, item.empName, item.duration);
            }
            Console.ReadKey();
        }
    }
}
