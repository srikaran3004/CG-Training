using System;
using System.Collections.Generic;

interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}

class Film : IFilm
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int Year { get; set; }

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
}

interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();

    public void AddFilm(IFilm film)
    {
        _films.Add(film);
    }

    public void RemoveFilm(string title)
    {
        for (int i = 0; i < _films.Count; i++)
        {
            if (_films[i].Title == title)
            {
                _films.RemoveAt(i);
                break;
            }
        }
    }

    public List<IFilm> GetFilms()
    {
        return _films;
    }

    public List<IFilm> SearchFilms(string query)
    {
        List<IFilm> result = new List<IFilm>();

        foreach (var film in _films)
        {
            if (film.Title.Contains(query) || film.Director.Contains(query))
            {
                result.Add(film);
            }
        }

        return result;
    }

    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}

class Program
{
    static void Main()
    {
        IFilmLibrary library = new FilmLibrary();

        library.AddFilm(new Film("Kalki", "Prabhas Rana", 2024));
        library.AddFilm(new Film("Bahubali", "Prabhas Rana", 2016));

        Console.WriteLine(library.GetTotalFilmCount());

        var searchResult = library.SearchFilms("Prabhas");

        foreach (var film in searchResult)
        {
            Console.WriteLine(film.Title);
        }

        library.RemoveFilm("Kalki");

        Console.WriteLine(library.GetTotalFilmCount());
    }
}
