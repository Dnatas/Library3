using System;

public class Book
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public string Release { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public void ChangeStatus(string st)
	{
        Status = st;
	}
    public string BookDetailShort()
    {
        return string.Format(" {0}; {1}; {2}; {3}", Title, Author, Genre, Status);
    }
    public string BookDetailBasic()
    {
        return String.Format(" {0}; {1}; {2}", Title, Author, Genre);
    }
    public string BookDetails()
    {
        return String.Format("{0}; {1}; {2}; {3}; {4}; {5}", Title, Author, Isbn, Publisher, Release, Genre);
    }
}
