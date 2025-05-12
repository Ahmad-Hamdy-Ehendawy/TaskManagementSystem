using System;
using System.Collections.Generic;

class Task
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Deadline { get; set; }
    public string Priority { get; set; }
    public bool Status { get; set; }

    public void DisplayTaskInfo()
    {
        Console.WriteLine($"Task's name: {this.Name}");
        Console.WriteLine($"Task's description: {this.Description}");
        Console.WriteLine($"Task's deadline: {this.Deadline}");
        Console.WriteLine($"Task's priority: {this.Priority}");
        Console.WriteLine($"Task's status: {this.Status}");
    }

    public Task(string name, string description, string deadline, string priority, bool status)
    {
        Name = name;
        Description = description;
        Deadline = deadline;
        Priority = priority;
        Status = status;
    }
}

class TaskOp
{
    List<Task> ListOfTasks = new List<Task>();

    public void Create()
    {
        Console.WriteLine("Task name: ");
        string taskName = Console.ReadLine();

        Console.WriteLine("Task description: ");
        string taskDescription = Console.ReadLine();

        Console.WriteLine("Deadline: ");
        string deadline = Console.ReadLine();

        Console.WriteLine("Priority: ");
        string priority = Console.ReadLine();

        Console.WriteLine("Status (true/false): ");
        bool status = false;
        string statusInput = Console.ReadLine();

        if (!bool.TryParse(statusInput, out status))
        {
            Console.WriteLine("Invalid status, defaulting to False.");
        }

        Task newTask = new Task(taskName, taskDescription, deadline, priority, status);
        ListOfTasks.Add(newTask);
        Console.WriteLine("Task added");
    }

    public Task SearchTask()
    {
        Console.WriteLine("Enter the name of the task you wish to find: ");
        string taskName = Console.ReadLine();
        foreach (var task in ListOfTasks)
        {
            if (task.Name.Equals(taskName, StringComparison.OrdinalIgnoreCase))
            {
                return task;
            }
        }
        Console.WriteLine("Task not found.");
        return null;
    }

    public void Delete()
    {
        Task task = SearchTask();
        if (task != null)
        {
            ListOfTasks.Remove(task);
            Console.WriteLine("Task deleted");
        }
        else
        {
            Console.WriteLine("Task couldn't be found");
        }
    }

    public void Update()
    {
        Task task = SearchTask();
        if (task != null)
        {
            Console.WriteLine("What would you like to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. Deadline");
            Console.WriteLine("4. Priority");
            Console.WriteLine("5. Status");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter new name");
                    task.Name = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Enter new description");
                    task.Description = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Enter new deadline");
                    task.Deadline = Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Enter new priority");
                    task.Priority = Console.ReadLine();
                    break;
                case "5":
                    Console.WriteLine("Enter status (true/false)");
                    if (bool.TryParse(Console.ReadLine(), out bool status))
                    {
                        task.Status = status;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, status unchanged.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }

    public void MarkAsCompleted()
    {
        Task task = SearchTask();
        if (task != null)
        {
            task.Status = true;
            Console.WriteLine("Task marked as completed");
        }
    }

    public void DisplayAllTasks()
    {
        if (ListOfTasks.Count == 0)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        foreach (var task in ListOfTasks)
        {
            task.DisplayTaskInfo();
            Console.WriteLine("--------");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TaskOp taskOp = new TaskOp();
        bool run = true;

        while (run)
        {
            Console.WriteLine("\n===== TASK MANAGEMENT MENU =====");
            Console.WriteLine("1. Create New Task");
            Console.WriteLine("2. Display All Tasks");
            Console.WriteLine("3. Update a Task");
            Console.WriteLine("4. Delete a Task");
            Console.WriteLine("5. Mark Task as Completed");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    taskOp.Create();
                    break;
                case "2":
                    taskOp.DisplayAllTasks();
                    break;
                case "3":
                    taskOp.Update();
                    break;
                case "4":
                    taskOp.Delete();
                    break;
                case "5":
                    taskOp.MarkAsCompleted();
                    break;
                case "6":
                    Console.WriteLine("Closing app");
                    run = false;
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        }
    }
}
