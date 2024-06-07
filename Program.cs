using System.ComponentModel.Design;

class Task
{
    public string Description { get; set; }      // declared two properties for the Task Class
    public bool MarkTaskDone { get; set; }

    public Task(string TaskDescription)           // Using a constructor to initialize the two properties

    {
        Description = TaskDescription;
        MarkTaskDone = false;
    }

    /// <summary>
    /// In the Main program: AddTask, RemovetTask, MarkTaskAsCompleted and ViewTask are four different methods used on the To-Do-List
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)  // Main entry of the program

    {
        // Using a list to initaize the Task Class

        List<Task> tasks = new List<Task>();

        while (true)
        {
            Console.WriteLine("To-Do List Menu:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. Remove Task");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. View Tasks");
            Console.WriteLine("5. Exit Program");
            Console.WriteLine("");
            Console.Write("Enter Your Menu Number: ");

            string menu = Console.ReadLine();

            switch (menu)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    RemoveTask();
                    break;
                case "3":
                    MarkTaskAsDone();
                    break;
                case "4":
                    ViewTasks();
                    break;
                case "5":
                    Console.WriteLine("Exiting Program!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

        }


        void AddTask()
        {
            Console.Write("Enter the task description: ");
            string TaskDescription = Console.ReadLine();

            tasks.Add(new Task(TaskDescription));

            Console.WriteLine("");
            Console.WriteLine("Task was added successfully!");

            Console.WriteLine("*******************************************************************************************");


        }

        void RemoveTask()
        {
            ViewTasks();
            Console.Write("Enter the task number you want to remove: ");
            if (int.TryParse(Console.ReadLine(), out int TaskNumber) && TaskNumber > 0 && TaskNumber <= tasks.Count)
            {
                tasks.RemoveAt(TaskNumber - 1);

                Console.WriteLine("");
                Console.WriteLine("Task removed successfully!");
                Console.WriteLine("*******************************************************************************************");

            }
            else
            {
                Console.WriteLine("Invalid task number.");

            }
        }

        void MarkTaskAsDone()
        {
            ViewTasks();
            Console.WriteLine("");
            Console.Write("Enter the number of the task to mark as completed: ");
            if (int.TryParse(Console.ReadLine(), out int TaskNumber) && TaskNumber > 0 && TaskNumber <= tasks.Count)
            {
                tasks[TaskNumber - 1].MarkTaskDone = true;
                Console.WriteLine("Taskcompleted succefullly!");
                Console.WriteLine("*******************************************************************************************");

            }
            else
            {
                Console.WriteLine("Invalid task number.");


            }
        }

        void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("There is no Task on the list.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("The List of Tasks & their Status in the To-Do-List are:");
                Console.WriteLine("*******************************************************************************************");

                for (int i = 0; i < tasks.Count; i++)
                {
                    // Status tells us the status all tasks on To-do-List

                    string status = tasks[i].MarkTaskDone ? " =>  [Completed Task!]" : " =>  [Uncompleted Task]";
                   
                    Console.WriteLine($" {i + 1}. {tasks[i].Description}{status} ");

                    Console.WriteLine("");



                }


            }
        }



    }
}