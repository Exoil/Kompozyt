using System;
using System.Collections.Generic;

namespace Kompozyt
{

    interface InterWorker
    {
        void DisplayFullinformationAboutWorker();
    }
    class Worker : InterWorker
    {
        private int id;
        private string name, surname, degree;

        public Worker(int id, string name, string surname, string degree)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.degree = degree;
        }

        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Surname: {surname}, Degree {degree}";
        }
        public void DisplayFullinformationAboutWorker()
        {
            Console.WriteLine(ToString());
        }
    }

    class Manager : InterWorker
    {
        private int id;
        private string name, surname, degree;

        private List<InterWorker> workersUnderManager;

        public Manager(int id, string name, string surname, string degree)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.degree = degree;

            workersUnderManager = new List<InterWorker>();


        }

        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Surname: {surname}, Degree {degree}";
        }

        public void AddWorker(Worker worker)
        {
            workersUnderManager.Add(worker);
        }

        public void RemoveWorker(Worker worker)
        {
            workersUnderManager.Remove(worker);
        }

        public void DisplayFullinformationAboutWorker()
        {
            Console.WriteLine(ToString()+$"{Environment.NewLine}Workers under this manager");

            foreach(var worker in workersUnderManager)
            {
                worker.DisplayFullinformationAboutWorker();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Manager proManager = new Manager(1, "Magda", "Przygodzka", "Mlodszy mMnager");          
            proManager.AddWorker(new Worker(2, "Kamil", "Kossakowski", "Pracownik HR"));
            proManager.AddWorker(new Worker(3, "Jakub", "Tederko", "Programista"));
            proManager.AddWorker(new Worker(4, "Pani", "Halina", "Konserwator Powierzchni Plaskich"));

            proManager.DisplayFullinformationAboutWorker();

            Console.ReadLine();
        }
    }
}
