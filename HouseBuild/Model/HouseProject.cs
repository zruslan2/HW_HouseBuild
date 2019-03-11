using HouseBuild.Interface;
using HouseBuild.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HouseBuild.Model
{
    class HouseProject
    {
        public HouseProject()
        {
            createProject();
            team.createTeam();
            createTasks();
        }
        private Team team = new Team();
        public List<IPart> parts = new List<IPart>();
        public List<ITask> tasks = new List<ITask>();
        private Random rnd = new Random();
        public void startBuilding()
        {
            ITask newTask = nonCompleateTask();
            while (newTask != null)
            {
                IWorker worker = team.getWorker();
                if (worker.position == Position.manager)
                {
                    //получить инфу о строительстве
                }
                else
                {
                    tasks[newTask.id].startDate = DateTime.Now;
                    tasks[newTask.id].endDate =
                        tasks[newTask.id].startDate
                                         .AddDays(rnd.Next(2, 30));
                    tasks[newTask.id].status = Status.complete;
                    tasks[newTask.id].idWorker = worker.id;

                    double diffDay = (tasks[newTask.id].endDate - tasks[newTask.id].startDate).TotalDays;

                    Console.WriteLine("Работа - {0} над {1} началась {2}",
                        worker.fullName, tasks[newTask.id].part.name,
                        tasks[newTask.id].startDate);

                    for (int i = 0; i < diffDay; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine("");
                    Console.WriteLine("Работы завершены: {0}", tasks[newTask.id].endDate);
                    Console.WriteLine("");
                }
                newTask = nonCompleateTask();
            }
            Console.WriteLine("Строительство завершено!");
        }
        private ITask nonCompleateTask()
        {
            return tasks.FirstOrDefault(w => w.status == Status.create);
        }
        public void createProject()
        {
            IPart pBasment = new Basement()
            {
                name = "Basement",
                price = rnd.Next(),
                count = 1,
                order = 0
            };

            parts.Add(pBasment);

            IPart pDoor = new Door()
            {
                name = "Door",
                price = rnd.Next(),
                count = 1,
                order = 1

            };
            parts.Add(pDoor);

            IPart pRoof = new Roof()
            {
                name = "Roof",
                price = rnd.Next(),
                count = 1,
                order = 2

            };
            parts.Add(pRoof);

            IPart pWall = new Walls()
            {
                name = "Walls",
                price = rnd.Next(),
                count = 4,
                order = 2

            };
            parts.Add(pWall);

            IPart pWindow = new Window()
            {
                name = "Window",
                price = rnd.Next(),
                count = 2,
                order = 3
            };
            parts.Add(pWindow);
        }
        public void createTasks()
        {
            int k = 0;
            foreach (IPart part in parts.OrderBy(o => o.order))
            {
                for (int i = 0; i < part.count; i++)
                {
                    ITask task = new Task()
                    {
                        id = k++,
                        part = part
                    };
                    tasks.Add(task);
                }
            }
        }
    }
}
