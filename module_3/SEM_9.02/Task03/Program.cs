using System;
using System.Collections.Generic;

namespace A
{
    /// <summary>
    /// Пассажир
    /// </summary>
    public class Passenger
    {
        string name;
        string lastName;
        int age;
        public bool IsOld { private set; get; }
        public string Name
        {
            set
            { // only latin simbols and spaces
              // not longer 30 simbols 

                if (value.Length > 30)
                    throw new ArgumentException("Name shouldn't be longer than 30 simblos.");

                foreach (char symb in value)
                    if ((symb < 'a' || symb > 'b') && (symb < 'A' || symb > 'A') && (symb != ' '))
                        throw new ArgumentException("Name should contain only latin simbols and spaces.");

                name = value;
            }
            get
            {
                return name;
            }
        }
        public string LastName
        {
            set
            { // only latin simbols and spaces
              // not longer 40 simbols 

                if (value.Length > 40)
                    throw new ArgumentException("Last name shouldn't be longer than 30 simblos.");

                foreach (char symb in value)
                    if ((symb < 'a' || symb > 'b') && (symb < 'A' || symb > 'A') && (symb != ' '))
                        throw new ArgumentException("Last name should contain only latin simbols and spaces.");

                lastName = value;
            }
            get
            {
                return lastName;
            }
        }
        public int Age
        {
            set
            { // more then 0

                if (Age <= 0)
                    throw new ArgumentException("Age should be a positive number");

                age = value;

                if (age > 65)
                    IsOld = true;
            }
            get { return age; }
        }
        public override string ToString()
        {
            return $"Passenger {Name} {LastName} at the Age {Age}";
        }
    }
    /// <summary>
    /// Пассажир с детьми
    /// </summary>
    public class PassengerWithChildren : Passenger
    {
        int numberOfChildren;
        public bool IsNewBorn { private set; get; }
        public int NumberOfChildren
        {
            set
            { // strictly more then 0

                if (value <= 0)
                    throw new ArgumentException("Number of children chould be a positive number.");

                numberOfChildren = value;

                Random rand = new Random();
                IsNewBorn = (rand.NextDouble() >= 0.5);
            }
            get { return numberOfChildren; }
        }
    }
    /// <summary>
    /// Очередь на посадку состоит из двух подочередей: обычной и приоритетной
    /// Пассажиры приоритетной очереди обслуживаются вне очереди
    /// </summary>
    public class PassengerQueue
    {
        // if passenger is ordinary we use ordinaryQueue
        Queue<Passenger> ordinaryQueue = new Queue<Passenger>();
        // if passenger is old or with newborns we use priorityQueue
        Queue<Passenger> priorityQueue = new Queue<Passenger>();

        public void AddToQueue(Passenger newPassenger)
        {
            if (newPassenger.Age > 65 || newPassenger is PassengerWithChildren && ((PassengerWithChildren)newPassenger).IsNewBorn) priorityQueue.Enqueue(newPassenger);
            else ordinaryQueue.Enqueue(newPassenger);
        }
        public void StartServingQueue()
        {
            if (priorityQueue.Count <= 3)
            {
                // Обслуживаем приоритетную очередь.
                while (priorityQueue.Count > 0)
                {
                    Console.WriteLine(priorityQueue.Peek().ToString() + " served.");
                    priorityQueue.Dequeue();
                }

                // Обслуживаем обычную.
                while (ordinaryQueue.Count > 0)
                {
                    Console.WriteLine(ordinaryQueue.Peek().ToString() + " served.");
                    ordinaryQueue.Dequeue();
                }
            }
            else
            {
                while (priorityQueue.Count > 0 || ordinaryQueue.Count > 0)
                {
                    if (priorityQueue.Count > 0)
                    {
                        Console.WriteLine(priorityQueue.Peek().ToString() + " served.");
                        priorityQueue.Dequeue();
                    }

                    if (ordinaryQueue.Count > 0)
                    {
                        Console.WriteLine(ordinaryQueue.Peek().ToString() + " served.");
                        ordinaryQueue.Dequeue();
                    }
                }
            }
        }
    }

    class MainClass
    {
        public static void Main()
        {
            int n1 = int.Parse(Console.ReadLine()),
                n2 = int.Parse(Console.ReadLine());

            PassengerQueue q = new PassengerQueue();

            // Обычные пассажиры.
            for (int i = 0; i < n1; ++i)
            {
                try
                {
                    Random rand = new Random();

                    Passenger newPassenger = new Passenger();
                    newPassenger.Age = rand.Next(0, 100);

                    // Рандомное имя.
                    newPassenger.Name = "Chel";
                    newPassenger.LastName = "c";
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("There is a problem with passenger №" + i + ":\n" + e.Message);
                }
            }

            // С детьми.
            for (int i = 0; i < n2; ++i)
            {
                try
                {
                    Random rand = new Random();

                    PassengerWithChildren newPassenger = new PassengerWithChildren();
                    newPassenger.Age = rand.Next(0, 100);

                    // Рандомное имя.
                    newPassenger.Name = "Chel with children";
                    newPassenger.LastName = "c";
                    newPassenger.NumberOfChildren = rand.Next(0, 10);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("There is a problem with passenger №" + i + ":\n" + e.Message);
                }
            }

            q.StartServingQueue();
        }
    }
}
