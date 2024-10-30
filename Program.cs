using System;
using System.Collections.Generic;

// ЗАВДАННЯ 1.2

// Інтерфейс для завдань
interface ITask
{
    void Start();
    void Complete();
    string GetTaskInfo();
}

// Клас для робочих завдань
class WorkTask : ITask
{
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    private bool isCompleted;

    public WorkTask(string title, DateTime dueDate)
    {
        Title = title;
        DueDate = dueDate;
        isCompleted = false;
    }

    public void Start()
    {
        Console.WriteLine($"Work Task '{Title}' started.");
    }

    public void Complete()
    {
        isCompleted = true;
        Console.WriteLine($"Work Task '{Title}' completed.");
    }

    public string GetTaskInfo()
    {
        return $"Work Task: {Title}, Due Date: {DueDate}, Completed: {isCompleted}";
    }
}

// Клас для особистих завдань
class PersonalTask : ITask
{
    public string Description { get; set; }
    private bool isCompleted;

    public PersonalTask(string description)
    {
        Description = description;
        isCompleted = false;
    }

    public void Start()
    {
        Console.WriteLine($"Personal Task '{Description}' started.");
    }

    public void Complete()
    {
        isCompleted = true;
        Console.WriteLine($"Personal Task '{Description}' completed.");
    }

    public string GetTaskInfo()
    {
        return $"Personal Task: {Description}, Completed: {isCompleted}";
    }
}

// Клас для навчальних завдань
class StudyTask : ITask
{
    public string Course { get; set; }
    private bool isCompleted;

    public StudyTask(string course)
    {
        Course = course;
        isCompleted = false;
    }

    public void Start()
    {
        Console.WriteLine($"Study Task for '{Course}' started.");
    }

    public void Complete()
    {
        isCompleted = true;
        Console.WriteLine($"Study Task for '{Course}' completed.");
    }

    public string GetTaskInfo()
    {
        return $"Study Task: {Course}, Completed: {isCompleted}";
    }
}

class Program
{
    static void Main()
    {
        List<ITask> tasks = new List<ITask>
        {
            new WorkTask("Finish report", DateTime.Now.AddDays(3)),
            new PersonalTask("Call mom"),
            new StudyTask("Math homework")
        };

        foreach (var task in tasks)
        {
            task.Start();
            task.Complete();
            Console.WriteLine(task.GetTaskInfo());
            Console.WriteLine();
        }
    }
}


// ЗАВДАННЯ 2.1

// Інтерфейс для виведення інформації
interface IPrintable
{
    void Print();
}

// Інтерфейс для взаємодії з бібліотекою
interface IBorrowable
{
    void BorrowItem();
    void ReturnItem();
    bool IsAvailable();
}

// Клас книги
class Book : IPrintable, IBorrowable
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    private bool isBorrowed;

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
        isBorrowed = false;
    }

    public void Print()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Year: {Year}, Available: {(!isBorrowed ? "Yes" : "No")}");
    }

    public void BorrowItem()
    {
        if (!isBorrowed)
        {
            isBorrowed = true;
            Console.WriteLine($"Book '{Title}' has been borrowed.");
        }
        else
        {
            Console.WriteLine($"Book '{Title}' is already borrowed.");
        }
    }

    public void ReturnItem()
    {
        if (isBorrowed)
        {
            isBorrowed = false;
            Console.WriteLine($"Book '{Title}' has been returned.");
        }
        else
        {
            Console.WriteLine($"Book '{Title}' is not currently borrowed.");
        }
    }

    public bool IsAvailable()
    {
        return !isBorrowed;
    }
}

class Program
{
    static void Main()
    {
        Book book1 = new Book("The Catcher in the Rye", "J.D. Salinger", 1951);
        Book book2 = new Book("To Kill a Mockingbird", "Harper Lee", 1960);

        // Тестування інтерфейсу IPrintable
        Console.WriteLine("Book 1 Information:");
        book1.Print();
        Console.WriteLine("\nBook 2 Information:");
        book2.Print();

        // Тестування інтерфейсу IBorrowable
        Console.WriteLine("\nBorrowing Book 1:");
        book1.BorrowItem();

        Console.WriteLine("\nAttempting to Borrow Book 1 Again:");
        book1.BorrowItem();

        Console.WriteLine("\nReturning Book 1:");
        book1.ReturnItem();

        Console.WriteLine("\nAvailability of Book 1: " + (book1.IsAvailable() ? "Yes" : "No"));
    }
}


// ЗАВДВННЯ 3

using System;

// Інтерфейс для продуктів
interface IProduct
{
    void DisplayInfo();
}

// Інтерфейс для покупок
interface IShoppable
{
    void AddToCart();
}

// Базовий клас для електронних пристроїв
class ElectronicDevice : IProduct
{
    public string DeviceName { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }

    public ElectronicDevice(string deviceName, string manufacturer, double price)
    {
        DeviceName = deviceName;
        Manufacturer = manufacturer;
        Price = price;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Device: {DeviceName}, Manufacturer: {Manufacturer}, Price: ${Price}");
    }
}

// Клас для смартфонів
class Smartphone : ElectronicDevice, IShoppable
{
    public string OperatingSystem { get; set; }

    public Smartphone(string deviceName, string manufacturer, double price, string operatingSystem)
        : base(deviceName, manufacturer, price)
    {
        OperatingSystem = operatingSystem;
    }

    public void AddToCart()
    {
        Console.WriteLine($"Smartphone '{DeviceName}' added to the cart.");
    }
}

// Клас для ноутбуків
class Laptop : ElectronicDevice, IShoppable
{
    public string Processor { get; set; }

    public Laptop(string deviceName, string manufacturer, double price, string processor)
        : base(deviceName, manufacturer, price)
    {
        Processor = processor;
    }

    public void AddToCart()
    {
        Console.WriteLine($"Laptop '{DeviceName}' added to the cart.");
    }
}

class Program
{
    static void Main()
    {
        Smartphone smartphone = new Smartphone("iPhone 13", "Apple", 999.99, "iOS");
        Laptop laptop = new Laptop("Dell XPS 13", "Dell", 1299.99, "Intel Core i7");

        // Тестування інтерфейсу IProduct
        Console.WriteLine("Smartphone Information:");
        smartphone.DisplayInfo();
        Console.WriteLine("\nLaptop Information:");
        laptop.DisplayInfo();

        // Тестування інтерфейсу IShoppable
        Console.WriteLine("\nAdding to Cart:");
        smartphone.AddToCart();
        laptop.AddToCart();
    }
}