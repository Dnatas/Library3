using System;

public class BookList
{
    public List<Book> Books { get; set; } = null!;
    public void ListAll()
    {
        foreach (Book item in Books)
        {
            Console.Write($"{item}:{Books.IndexOf(item)} ");
            Console.WriteLine(item.BookDetails());
        }

    }
    public BookList Filter(string Attribute, string? Value)
    {
        BookList Filtered = new BookList() { Books = new List<Book>() };
        switch (Attribute)
        {
            case "Title":
                foreach (Book item in Books)
                {
                    if (item.Title == Value)
                    {
                        Filtered.Books.Add(item);
                    }
                }
                return Filtered;

            case "Author":
                foreach (Book item in Books)
                {
                    if (item.Author == Value)
                    {
                        Filtered.Books.Add(item);
                    }
                }
                return Filtered;

            case "Isbn":
                foreach (Book item in Books)
                {
                    if (item.Isbn == Value)
                    {
                        Filtered.Books.Add(item);
                    }
                }
                return Filtered;

            case "Release":
                foreach (Book item in Books)
                {
                    if (item.Release == Value)
                    {
                        Filtered.Books.Add(item);
                    }
                }
                return Filtered;

            case "Publisher":
                foreach (Book item in Books)
                {
                    if (item.Publisher == Value)
                    {
                        Filtered.Books.Add(item);
                    }
                }
                return Filtered;

            case "Genre":
                foreach (Book item in Books)
                {
                    if (item.Genre == Value)
                    {
                        Filtered.Books.Add(item);
                    }
                }
                return Filtered;

            case "Status":
                foreach (Book item in Books)
                {
                    if (item.Status == Value)
                    {
                        Filtered.Books.Add(item);
                    }
                }
                return Filtered;

            default:
                return Filtered;
        }

    }
}
