using System;
using System.Collections.Generic;

class Parent
{
    protected string Pole1;
    protected int Pole2;
    protected double Pole3;
    protected double Pole4;

    public Parent()
    {
        Pole1 = "";
        Pole2 = 0;
        Pole3 = 0.0;
        Pole4 = 0.0;
    }

    public Parent(string name, int hireYear, double salary)
    {
        Pole1 = name;
        Pole2 = hireYear;
        Pole3 = salary;
        Pole4 = 0.0;
    }

    public virtual void Print()
    {
        Console.WriteLine("Ім'я: " + Pole1);
        Console.WriteLine("Рік прийняття на роботу: " + Pole2);
        Console.WriteLine("Зарплата: " + Pole3);
        Console.WriteLine("Премія: " + Pole4);
    }

    public void Metod1(int currentYear)
    {
        int workExperience = currentYear - Pole2;

        if (workExperience < 5)
            Pole4 = 0.1 * Pole3;
        else if (workExperience >= 5 && workExperience <= 10)
            Pole4 = 0.15 * Pole3;
        else
            Pole4 = 0.2 * Pole3;
    }
}

class Child : Parent
{
    private int Pole5;

    public Child(string name, int hireYear, double salary, int category) : base(name, hireYear, salary)
    {
        Pole5 = category;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine("Статус сотрудника: Віп співробітник");
        Console.WriteLine("Категорія: " + Pole5);

        double additionalBonus = 0.0;

        switch (Pole5)
        {
            case 1:
                additionalBonus = 0.5 * Pole4;
                break;
            case 2:
                additionalBonus = 0.3 * Pole4;
                break;
            case 3:
                additionalBonus = 0.2 * Pole4;
                break;
        }

        Console.WriteLine("Віп премія: " + additionalBonus);
    }
}

class Program
{
    static void Main()
    {
        List<Parent> employees = new List<Parent>
        {
            new Parent("Іван", 2000, 5000),
            new Child("Петро", 2015, 6000, 2),
            new Parent("Марія", 2012, 5500),
            new Child("Ольга", 2018, 6200, 1),
            new Parent("Андрій", 2005, 5800)
        };

        Console.WriteLine("Список співробітників:");
        foreach (var employee in employees)
        {
            employee.Print();
            employee.Metod1(2023);
            Console.WriteLine();
        }
    }
}