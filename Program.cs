using System;

abstract class Worker
{
    protected string Name;
    protected static Worker head; // указатель на начало списка
    protected Worker next;
    protected static Worker tail;

    public Worker(string name)
    {
        Name = name;
        AddToList(this);
    }

    protected void AddToList(Worker node)
    {

        if (head == null)
        {
            head = this;
        }
        else
        {
            tail.next = node;
        }
        tail = node;
    }
    protected Worker GetNext() => next;
    public static void Print()
    {
        Worker current = head;
        while (current != null)
        {
            current.Show();
            current = current.next;
        }
    }

    public abstract void Show(); // виртуальный метод для отображения информации
}

class Staff : Worker
{
    public Staff(string name) : base(name) { }

    public override void Show()
    {
        Console.WriteLine($"Staff: {Name}");
    }
}

class Engineer : Worker
{
    public Engineer(string name) : base(name) { }

    public override void Show()
    {
        Console.WriteLine($"Engineer: {Name}");
    }
}

class Administration : Worker
{
    public Administration(string name) : base(name) { }

    public override void Show()
    {
        Console.WriteLine($"Administration: {Name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Worker w1 = new Staff("Alice");
        Worker w2 = new Engineer("Bob");
        Worker w3 = new Administration("Carl");

        // Просмотр списка
        Console.WriteLine("Список работников:");
        Worker.Print();

        Worker w4 = new Staff("David");

        // Просмотр списка снова
        Console.WriteLine("\nОбновленный список работников:");
        Worker.Print();
    }
}
