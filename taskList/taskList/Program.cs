using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskList
{
    internal class Program
    {
        class Task
        { 
            public string name = "";
            public string description = "";
            public string deadline = "";
            public string isComplete = "";

        
            public Task(string name, string description, string deadline, string isComplete)
            {
                this.name = name;
                this.description = description;
                this.deadline = deadline;
                this.isComplete = isComplete;
            }
        }



        static void Main(string[] args)
        {
           
            List<Task> paper = new List<Task>();


            while (true)
            {


                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(1) Create a task");
                Console.WriteLine("(2) Delete a task");
                Console.WriteLine("(3) Edit a task");
                Console.WriteLine("(4) List all Incomplete tasks");
                Console.WriteLine("(5) Last all tasks");
                Console.WriteLine("(6) Quit");

                Console.WriteLine("Choose a number: ");
                int answer = Convert.ToInt32(Console.ReadLine());

                string nameoftask = "";
                string descriptionoftask = "";
                string deadlineoftask = "";
                string completestatus = "";
                

                switch (answer)
                {
                    case 1:
                        Console.WriteLine("Creating a Task");

                        Console.WriteLine("Enter Name: ");
                        nameoftask = Console.ReadLine();

                        Console.WriteLine("Enter Description: ");
                        descriptionoftask = Console.ReadLine();

                        Console.WriteLine("Enter Deadline: ");
                        deadlineoftask = Console.ReadLine();

                        completestatus = "Incomplete";

                        paper.Add(new Task(nameoftask, descriptionoftask, deadlineoftask, completestatus));

                        break;
                    case 2:
                        if (!paper.Any())
                        {
                            Console.WriteLine("Sorry there are no tasks to delete?");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("What task would you like to delete?");
                            int index = 0;
                            foreach (var item in paper)
                            {
                                index = paper.FindIndex(i => i.name == item.name);
                                Console.WriteLine("(" + index + ") " + item.name); 
                            }
                        
                            int deletetask = Convert.ToInt32(Console.ReadLine());
                            paper.RemoveAt(deletetask);

                        }
                        break;
                    case 3:
                        if (!paper.Any())
                        {
                            Console.WriteLine("Sorry there are no tasks to edit?");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Which task would you like to edit?");
                            int index = 0;
                            int indexfound = 0;
                            foreach (var item in paper)
                            {
                                index = paper.FindIndex(i => i.name == item.name);
                                if (index != -1)
                                { 
                                    Console.WriteLine("(" + index + ") " + item.name);
                                    indexfound = index;
                                }
                            }

                            
                            Console.WriteLine("what would you like to change about the selected task");
                            Console.WriteLine("(1)Name");
                            Console.WriteLine("(2)Description");
                            Console.WriteLine("(3)Date");
                            Console.WriteLine("(4)Complete status");

                            int selecttask = Convert.ToInt32(Console.ReadLine());

                            switch (selecttask)
                            {
                                case 1:
                                    Console.WriteLine("Replace Name with: ");
                                    string newname = Console.ReadLine(); 
                                    paper[indexfound].name = newname;
                                    break;
                                case 2:
                                    Console.WriteLine("Replace Description with: ");
                                    string newdescription = Console.ReadLine();
                                    paper[indexfound].description = newdescription;
                                    break;
                                case 3:
                                    Console.WriteLine("Replace Deadline with: ");
                                    string newdeadline = Console.ReadLine();
                                    paper[indexfound].deadline = newdeadline;
                                    break;
                                case 4:
                                    Console.WriteLine("Completion Status");
                                    Console.WriteLine("(1)Completed");
                                    Console.WriteLine("(2)Incomplete");

                                    int status = Convert.ToInt32(Console.ReadLine());

                                    if (status == 1)
                                    {
                                        paper[indexfound].isComplete = "Comleted";
                                    }

                                    if (status == 2)
                                    {
                                       paper[indexfound].isComplete = "Incomplete";
                                    }
                                    
                                    break;
                            }
                                
                        }
                        break;
                    case 4:
                        if (!paper.Any())
                        {
                            Console.WriteLine("Sorry there are no incomplete tasks");
                            break;
                        }



                        Console.WriteLine("Here are a list of all incomplete tasks");

                        List<Task> incompletelist = paper.FindAll(tasks => tasks.isComplete == "Incomplete");
                        int incompleteindex = 0;
                        foreach (var item in incompletelist)
                        {
                            incompleteindex  = incompletelist.FindIndex(task => task.name == item.name);
                            Console.WriteLine("(" + incompleteindex   + ") " + item.name);
                        }
                        break;
                    case 5:
                        if (!paper.Any())
                        {
                            Console.WriteLine("Sorry there are no tasks");
                            break;
                        }
                        int place = 0;
                        int placefound = 0;
                        foreach (var item in paper)
                        {
                            place = paper.FindIndex(i => i.name == item.name);
                            if (place != -1)
                            {
                                Console.WriteLine("(" + place + ") " + item.name);
                                placefound = place;
                            }
                        }

                        break;
                    case 6:
                        System.Environment.Exit(1);
                        break;
                    

                }
            }
        }
    }
}
