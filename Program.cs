using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

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
                new Book() { Title = "Įžymūs lietuviai", Author = "Rokas Subačius", Isbn = "9785417011269", Release = "2022", Publisher = "Mintis", Genre = "biografija", Status = "Borrowed" },
                new Book() { Title = "Kiborgų žemė", Author = "Dovydas Pancerovas", Isbn = "9786090150894", Release = "2022", Publisher = "Alma littera", Genre = "karo istorija", Status = "Borrowed" },
                new Book() { Title = "Vieno žmogaus bohema", Author = "Ugnė Barauskaitė", Isbn = "9786094661563", Release = "2016", Publisher = "Tyto alba", Genre = "grožinė literatūra", Status = "Borrowed" },
                new Book() { Title = "Basic of fluid mechanics", Author = "Tadas Ždankus", Isbn = "9786090211078", Release = "2020", Publisher = "Technologija", Genre = "fizika", Status = "Available" }

            }
        };

        Menu(AllBooks);
    }

    static void Menu(BookList AllBooks)
    {
        Console.WriteLine("\nWelcome to Console Library\n");
        Console.WriteLine("Your number of Choice:");
        Console.WriteLine("0 for display list of all books");
        Console.WriteLine("1 for borrow book");
        Console.WriteLine("2 for book return");
        Console.WriteLine("3 for book search");
        Console.WriteLine("9 for exit\n");

        string chc = GetInput(new List<string>() { "0", "1", "2", "3", "9" });
        switch (chc)
        {
            case "0":
                AllBooks.ListAll();
                Menu(AllBooks);
                break;
            case "1":
                Console.WriteLine("\nBooks available:");
                AllBooks.Filter("Status","Available").ListAll();
                Console.WriteLine("Choose book by book number");
                while (true) {
                    int an1 = int.Parse(Console.ReadLine());
                    if (AllBooks.Filter("Status", "Available").Books.ElementAtOrDefault(an1) != null)
                    {
                         AllBooks.Filter("Status", "Available").Books[an1].ChangeStatus("Borrowed");
                         Console.WriteLine("Check local delivery for the book:");
                         Console.WriteLine(AllBooks.Books[an1].BookDetailShort());
                         Menu(AllBooks);
                     }
                    else 
                    {
                         Console.WriteLine("That book is not available, please retype");
                         continue;
                    }
                }
            case "2":
                Console.WriteLine("Which book do you want to return?");
                int an2 = int.Parse(GetInput(new List<string> { "0", "1", "2", "3" }));
                //bookshelf[an2].ChangeStatus("Returning");
                Console.WriteLine("Thank you for returning the book:");
                Menu(AllBooks);
                //Console.WriteLine(AllBooks.Books[2].BookDetailSingle(an2));
                break;
            case "3":
                Console.WriteLine("Book search service");
                Console.WriteLine("Search by title press 0, by author 1, by ISBN 2, by release year 3");
                Console.WriteLine("by publisher 4, by genre 5, by status 6");
                string an3 = GetInput(new List<string> { "0", "1", "2", "3", "4", "5", "6" });
                switch (an3)
                {
                    case "0":
                        foreach (Book item in AllBooks.Books)
                        {
                            Console.Write(" " + item.Isbn + " ");
                        }
                        break;
                    case "1":
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;

                }
                break;
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
                    Console.WriteLine("try to retype proper number");
                }

            }
        }

    }
}

/*Attribute ž Talker ({"Titl;e","" <"",""})
    valute ž readline;

BookList.fileer (attribeu, value)*/