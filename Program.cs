using System;
using System.Collections.Generic;
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
                new Book() { Title = "Basic of fluid mechanics", Author = "Tadas Ždankus", Isbn = "9786090211078", Release = "2020", Publisher = "Technologija", Genre = "fizika", Status = "Return" }

            }
        };
        Console.WriteLine("\nWelcome to Console Library\n");
        Menu(AllBooks);
    }

    static void Menu(BookList AllBooks)
    {
        
        Console.WriteLine("\nYour number of Choice:\n");
        Console.WriteLine("0 for display list of all books");
        Console.WriteLine("1 for borrow book");
        Console.WriteLine("2 for book return");
        Console.WriteLine("3 for reserve a book");
        Console.WriteLine("4 for book search");
        Console.WriteLine("8 for Admin");
        Console.WriteLine("9 for exit\n");

        string chc = GetInput(new List<string>() { "0", "1", "2", "3", "4", "8", "9" });
        switch (chc)
        {
            case "0":
                AllBooks.ListAll();
                Menu(AllBooks);
                break;
            case "1":
                ListEmpty(AllBooks, AllBooks.Filter("Status", "Available").Books);
                Console.WriteLine("\nBooks available:");
                AllBooks.Filter("Status","Available").ListAll();
                Console.WriteLine("Choose book by book number");
                    while (true) {
                    int an1 = int.Parse(Console.ReadLine());
                    if (AllBooks.Filter("Status", "Available").Books.ElementAtOrDefault(an1) != null)
                    {
                        Console.WriteLine("Check local delivery for the book:");
                        Console.WriteLine(AllBooks.Filter("Status", "Available").Books[an1].BookDetailBasic());
                        AllBooks.Filter("Status", "Available").Books[an1].ChangeStatus("Borrowed");
                        Menu(AllBooks);
                     }
                    else 
                    {
                         Console.WriteLine("That book is not available, please retype");
                         continue;
                    }
                }
                
            case "2":
                ListEmpty(AllBooks, AllBooks.Filter("Status", "Borrowed").Books);
                Console.WriteLine("Which book do you want to return?");
                AllBooks.Filter("Status", "Borrowed").ListAll();
                Console.WriteLine("Choose book by book number");
                while (true)
                {
                    int an2 = int.Parse(Console.ReadLine());
                    if (AllBooks.Filter("Status", "Borrowed").Books.ElementAtOrDefault(an2) != null)
                    {
                        Console.WriteLine("Library Admin will available book on arriving:");
                        Console.WriteLine(AllBooks.Filter("Status", "Borrowed").Books[an2].BookDetailBasic());
                        AllBooks.Filter("Status", "Borrowed").Books[an2].ChangeStatus("Return");
                        Menu(AllBooks);
                    }
                    else
                    {
                        Console.WriteLine("That book is not returnable, please retype");
                        continue;
                    }
                }
            case "3":
                ListEmpty(AllBooks, AllBooks.Filter("Status", "Available").Books);
                Console.WriteLine("\nBooks available:");
                AllBooks.Filter("Status", "Available").ListAll();
                Console.WriteLine("Choose book by book number");
                while (true)
                {
                    int an1 = int.Parse(Console.ReadLine());
                    if (AllBooks.Filter("Status", "Available").Books.ElementAtOrDefault(an1) != null)
                    {
                        Console.WriteLine("This book get reserved for you:");
                        Console.WriteLine(AllBooks.Filter("Status", "Available").Books[an1].BookDetailBasic());
                        AllBooks.Filter("Status", "Available").Books[an1].ChangeStatus("Reserved");
                        Menu(AllBooks);
                    }
                    else
                    {
                        Console.WriteLine("That book is not available, please retype");
                        continue;
                    }
                }

            case "4":
                Console.WriteLine("Book search:");
                Console.WriteLine("Search by title press 0, by author 1, by ISBN 2");
                Console.WriteLine("by year of release 3, publisher 4, by genre 5");
                string an3 = GetInput(new List<string> { "0", "1", "2", "3", "4", "5" });
                switch (an3)
                {
                    case "0":
                        SearchBook(AllBooks, "Title");
                        break;
                    case "1":
                        SearchBook(AllBooks, "Author");
                        break;
                    case "2":
                        SearchBook(AllBooks,"Isbn");
                        break;
                    case "3":
                        SearchBook(AllBooks, "Release");
                        break;
                    case "4":
                        SearchBook(AllBooks, "Publisher");
                        break;
                    case "5":
                        SearchBook(AllBooks, "Genre");
                        break;

                }
                break;
            case "8":
                Console.WriteLine("Welcome back, Admin");
                Console.WriteLine("type Admin password");
                GetInput(new List<string> { "admin", "Admin"});
                Console.Clear();
                Console.WriteLine("successfully joined");

                ListEmpty(AllBooks, AllBooks.Filter("Status", "Return").Books);

                Console.WriteLine("\nReturning books arrived:");
                AllBooks.Filter("Status", "Return").ListAll();
                Console.WriteLine("Choose book by book number");
                while (true)
                {
                    int an8 = int.Parse(Console.ReadLine());
                    if (AllBooks.Filter("Status", "Return").Books.ElementAtOrDefault(an8) !=null)
                    {
                        Console.WriteLine("Check local delivery for the book:");
                        Console.WriteLine(AllBooks.Filter("Status", "Return").Books[an8].BookDetailBasic());
                        AllBooks.Filter("Status", "Return").Books[an8].ChangeStatus("Available");
                        Menu(AllBooks);
                    }
                    else
                    {
                        Console.WriteLine("That book is not in list, please retype");
                        continue;
                    }
                }
            case "9":
                Environment.Exit(0);
                break;
        }
        static string GetInput(List<string> Choices)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (Choices.Contains(input))
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("try to retype proper value");
                }

            }
        }

    }
    static void ListEmpty(BookList AllBooks,  List<Book> list)
    {
        if (list.Count == 0)
        {
        Console.WriteLine("\nThere no book lists to display");
        Menu(AllBooks);
        }
    }

    static void SearchBook(BookList AllBooks, string Category)
    {
        Console.WriteLine($"{Category} examples for testing: ");
        foreach (Book item in AllBooks.Books)
        {
            Console.Write($"{item.GetAttr(Category)} ");
        }
        Console.WriteLine($"\nType book {Category}:");
        string ans = Console.ReadLine();
        ListEmpty(AllBooks, AllBooks.Filter(Category, ans).Books);
        AllBooks.Filter(Category, ans).ListAll();
        Menu(AllBooks);
    }
}

