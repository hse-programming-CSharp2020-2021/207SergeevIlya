using System;

class Person
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsMale { get; set; }
    public Person(string fullname, DateTime bitrhdate, bool ismale)
    {
        FullName = fullname;
        BirthDate = bitrhdate;
        IsMale = ismale;
    }
    public virtual void ShowInfo()
    {
        Console.WriteLine($"{FullName} {BirthDate} {IsMale}");
    }
}

class Student : Person
{
    public string Institute { get; set; }
    public string Speciality { get; set; }
    public Student(string fullname, DateTime bitrhdate, bool ismale, string inst, string spec)
        : base(fullname, bitrhdate, ismale)
    {
        Institute = inst;
        Speciality = spec;
    }

    public override void ShowInfo()
    {
        Console.WriteLine($"{FullName} {BirthDate} {IsMale} {Institute} {Speciality}");
    }
}

class Employee : Person
{
    public string CompanyName { get; set; }
    public string Post { get; set; }
    public string Schedule { get; set; }
    public decimal Salary { get; set; }

    public Employee(string fullname, DateTime bitrhdate, bool ismale, string company, string post, string schedule, decimal salary)
        : base(fullname, bitrhdate, ismale)
    {
        FullName = fullname;
        BirthDate = bitrhdate;
        IsMale = ismale;
        CompanyName = company;
        Post = post;
        Schedule = schedule;
        Salary = salary;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine("Компания: " + CompanyName);
        Console.WriteLine("Пост, занимаемый в компании: " + Post);
        Console.WriteLine("График работы: " + Schedule);
        Console.WriteLine("Зарплата: " + Salary + "кк./наносек.");
    }
}

class Program
{
    static void Main()
    {
        Person person = new Person("frfger", new DateTime(2020, 10, 10), true);
        person.ShowInfo();

        Student student = new Student("3tgfvs", new DateTime(2000, 12, 15), true, "fefer", "ferwg");
        student.ShowInfo();

        Employee worker = new Employee("Ботальщик-3000", new DateTime(1488, 2, 28), true, "Плохая", "Машина бота", "25/7", 300);
        worker.ShowInfo();

        Console.WriteLine("Информация обо всех людях");

        Person[] arr = new Person[3];
        arr[0] = person;
        arr[1] = student;
        arr[2] = worker;

        foreach (Person Human in arr)
        {
            Human.ShowInfo();
        }
    }

}