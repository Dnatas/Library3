using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using static System.Reflection.Metadata.BlobBuilder;

class Program
{
    static void Main(string[] args)
    {
        BookList AllBooks = new BookList()
        {
            Books = new List<Book>
            {
                new Book() { Title = "Epoche", Author = "Nerijus Cibulskas", Isbn = "9786094803345", Release = "2022", Publisher = "LRS leidykla", Genre = "poezija", Status = "Available" },
                new Book() { Title = "Pakėliau Balsą", Author = "Giedrius Mickūnas", Isbn = "9786094462672", Release = "2022", Publisher = "Homo liber", Genre = "poezija", Status = "Available" },
                new Book() { Title = "Laikas išeina pats", Author = "Stasys Jonauskas", Isbn = "9789986398073", Release = "2014", Publisher = "LRS leidykla", Genre = "poezija", Status = "Reserved", },
                new Book() { Title = "Įžymūs lietuviai", Author = "Rokas Subačius", Isbn = "9785417011269", Release = "2022", Publisher = "Mintis", Genre = "biografija", Status = "Available" },
                new Book() { Title = "Kiborgų žemė", Author = "Dovydas Pancerovas", Isbn = "9786090150894", Release = "2022", Publisher = "Alma littera", Genre = "karo istorija", Status = "Available" },
                new Book() { Title = "Vieno žmogaus bohema", Author = "Ugnė Barauskaitė", Isbn = "9786094661563", Release = "2016", Publisher = "Tyto alba", Genre = "grožinė literatūra", Status = "Borrowed" },
                new Book() { Title = "Basics of fluid mechanics", Author = "Tadas Ždankus", Isbn = "9786090217078", Release = "2020", Publisher = "Technologija", Genre = "fizika", Status = "Returning" }
            }
        };
        Console.WriteLine("\nWelcome to Console Library\n");
        Menu(AllBooks);
    }

    static void Menu(BookList AllBooks)
    {
        string menuAnswer;

        Console.WriteLine("\nYour number of Choice:\n");
        Console.WriteLine("0 to display list of all books");
        Console.WriteLine("1 to borrow book");
        Console.WriteLine("2 to book return");
        Console.WriteLine("3 to reserve a book");
        Console.WriteLine("4 to book search");
        Console.WriteLine("8 to Admin");
        Console.WriteLine("9 to exit\n");

        string choice = GetInput(new List<string>() { "0", "1", "2", "3", "4", "8", "9" });

        switch (choice)
        {
            case "0":
                Console.Clear();
                AllBooks.ListAll();
                BackOrExit(AllBooks);
                break;

            case "1":
                Console.Clear();
                StatusChange(AllBooks, "Available","Borrowed");
                break;

            case "2":
                Console.Clear();
                StatusChange(AllBooks, "Borrowed", "Returning");
                break;

            case "3":
                Console.Clear();
                StatusChange(AllBooks, "Available", "Reserved");
                break;

            case "4":
                Console.Clear();
                Console.WriteLine("Book search:");
                Console.WriteLine("To search by title press 0, by author 1, by ISBN 2");
                Console.WriteLine("by year of release 3, publisher 4, by genre 5");
                menuAnswer = GetInput(new List<string> { "0", "1", "2", "3", "4", "5" });

                switch (menuAnswer)
                {
                    case "0":
                        Console.Clear();
                        SearchBook(AllBooks, "Title");
                        break;
                    case "1":
                        Console.Clear();
                        SearchBook(AllBooks, "Author");
                        break;
                    case "2":
                        Console.Clear();
                        SearchBook(AllBooks, "Isbn");
                        break;
                    case "3":
                        Console.Clear();
                        SearchBook(AllBooks, "Release");
                        break;
                    case "4":
                        Console.Clear();
                        SearchBook(AllBooks, "Publisher");
                        break;
                    case "5":
                        Console.Clear();
                        SearchBook(AllBooks, "Genre");
                        break;

                }
                break;

            case "8":
                Console.Clear();
                Console.WriteLine("type Admin password");

                GetInput(new List<string> { "admin", "password" });

                Console.Clear();
                Console.WriteLine("successfully joined");
                Console.WriteLine("The books that people have returning, and needs to be confirmed available");
                StatusChange(AllBooks, "Returning", "Available");

                break;
            case "9":
                Environment.Exit(0);
                break;
        }
    }

    static string GetInput(List<string> Choices)
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (Choices.Contains(input!)) 
                {
                    return input!;
                }
                else
                {
                    Console.WriteLine("Please type valid value");
                }

            }
        }

    
    static void ListEmpty(BookList AllBooks,  List<Book> list)
    {
        if (list.Count == 0)
        {
            Console.WriteLine("\nThere no books to display");
            BackOrExit(AllBooks);
        }
    }

    static void SearchBook(BookList AllBooks, string Category)
    {
        Console.WriteLine($"\nType book {Category}:");
        string? answer = Console.ReadLine();
        ListEmpty(AllBooks, AllBooks.Filter(Category, answer).Books);
        AllBooks.Filter(Category, answer).ListAll();
        BackOrExit(AllBooks);
    }

    static void StatusChange(BookList AllBooks, string Value, string NewValue)
    {
        ListEmpty(AllBooks, AllBooks.Filter("Status", Value).Books);
        Console.WriteLine("\nBooks available:");
        AllBooks.Filter("Status", Value).ListAll();

        List<string>fuse = new List<string>();

        foreach (Book item in AllBooks.Filter("Status", Value).Books)
        {
            fuse.Add($"{AllBooks.Filter("Status", Value).Books.IndexOf(item)}");
        }

        Console.WriteLine("Choose book by book number");
        string menuAnswer = GetInput(fuse);
        Console.WriteLine("You choosed the book:");
        Console.WriteLine(AllBooks.Filter("Status", Value).Books[int.Parse(menuAnswer)].BookDetailBasic());
        AllBooks.Filter("Status", Value).Books[int.Parse(menuAnswer)].ChangeStatus(NewValue);
        BackOrExit(AllBooks);
    }
    static void BackOrExit(BookList AllBooks)
    {
        Console.WriteLine("\nWhat would you like to do next:");
        Console.WriteLine("0: back to menu\n9: go to exit");
        string Input = GetInput(new List<string>() { "0", "9" });

        switch (Input)
        {
            case "0":
                Console.Clear();
                Menu(AllBooks);
                break;
            case "9":
                Environment.Exit(0);
                break;
        }
    }
}

