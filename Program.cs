
using DIO_Series.src.Enum;
using DIO_Series.src.Models;
using DIO_Series.src.Repository;

class Program
{
    static SerieRepository repository = new SerieRepository();
    static FilmRepository repositoryFilm = new FilmRepository();
    static void Main(string[] args)
    {
        int x;
        do{ 
            Console.WriteLine();
            Console.WriteLine("DIO Series");
            Console.WriteLine("What do you wish to see?");
            Console.WriteLine("1 - Series");
            Console.WriteLine("2 - Films");
            Console.WriteLine("3 - Close");
            x = int.Parse(Console.ReadLine());
            string op = Menu(x);
            while(op.ToUpper() != "X"){
                switch (op)
                {
                    case "1":
                        if (x == 1)
                            ListSerie();
                        else if (x == 2)
                            ListFilm();
                        break;
                    case "2":
                        if (x == 1)
                            AddSerie();
                        else if (x == 2)
                            AddFilm();
                        break;
                    case "3":
                        if (x ==1)
                            UpdateSerie();
                        else if (x == 2)
                            UpdateFilm();
                        break;
                    case "4":
                        if(x == 1)
                            DeleteSerie();
                        else if(x == 2)
                            DeleteFilm();
                        break;
                    case "5":
                        if(x == 1)
                            ViewSerie();
                        else if (x == 2)
                            ViewFilm();
                        break;
                    case "C":
                        Console.Clear();
                        break;              
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                op = Menu(x);
            }
        } while(x != 3);
    }
    private static string Menu(int x)
    {

        if(x == 1){
            Console.WriteLine("Enter the desired option:");

            Console.WriteLine("1 - Series list");
            Console.WriteLine("2 - Enter new serie");
            Console.WriteLine("3 - Update serie");
            Console.WriteLine("4 - Delete serie");
            Console.WriteLine("5 - View serie");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Close menu");

            string op = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return op;
        }
        else if (x == 2){
            Console.WriteLine("Enter the desired option:");

            Console.WriteLine("1 - Films list");
            Console.WriteLine("2 - Enter new film");
            Console.WriteLine("3 - Update film");
            Console.WriteLine("4 - Delete film");
            Console.WriteLine("5 - View film");
            Console.WriteLine("C - Clear screen");
            Console.WriteLine("X - Close menu");

            string op = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return op;
        }
        else{
            return "Opção Inválida";
        }
    }
    private static void ListSerie(){
        Console.WriteLine("Series List");

        var list = repository.List();

        if (list.Count == 0)
        {
            Console.WriteLine("No series registred");
        }

        foreach (var serie in list)
        {
            var deleted = serie.returnDeleted();

            Console.WriteLine("#ID {0}: - {1} - {2}", serie.returnId(), serie.returnTitulo(), (deleted ? "*Deleted*":""));
        }
        Console.ReadKey();
    }
    private static void AddSerie(){
        Console.WriteLine("Insert new series");

        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genre),i));
        }
        Console.WriteLine("Enter the genre from the options above");
        int gender = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the series title");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the series start year");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the series description");
        string description = Console.ReadLine();

        Serie newSerie = new Serie(id: repository.NextId(),genre:(Genre)gender, title: title, year: year, description: description);
        repository.Add(newSerie);
    }
    private static void UpdateSerie(){
        Console.WriteLine("Entre the series id:");
        int idSerie = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genre),i));            
        }
        Console.WriteLine("Enter the genre from the options above");
        int gender = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the series title");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the series start year");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the series description");
        string description = Console.ReadLine();

        Serie upSerie = new Serie(id: repository.NextId(),genre:(Genre)gender, title: title, year: year, description: description);
        repository.Update(idSerie, upSerie);
    }
    public static void DeleteSerie()
    {
        Console.WriteLine("Enter the series id:");
        int idSerie = int.Parse(Console.ReadLine());

        repository.Delete(idSerie);
    }
    private static void ViewSerie()
    {
        Console.WriteLine("Enter the series id:");
        int idSerie = int.Parse(Console.ReadLine());

        var serie = repository.GetById(idSerie);

        Console.WriteLine(serie);
        Console.ReadKey();
    }

    private static void ListFilm(){
        Console.WriteLine("Films List");

        var list = repositoryFilm.List();

        if (list.Count == 0)
        {
            Console.WriteLine("No films registred");
        }

        foreach (var film in list)
        {
            var deleted = film.returnDeletedFilm();

            Console.WriteLine("#ID {0}: - {1} - {2}", film.returnIdFilm(), film.returnTitleFilm(), (deleted ? "*Deleted*":""));
        }
        Console.ReadKey();
    }
    private static void AddFilm(){
        Console.WriteLine("Insert new film");

        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genre),i));
        }
        Console.WriteLine("Enter the genre from the options above");
        int gender = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the film title");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the film start year");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the film description");
        string description = Console.ReadLine();

        Film newFilm = new Film(
            id: repositoryFilm.NextId(), 
            genre:(Genre)gender, 
            title: title, 
            year:year,
            description:description
        );
        repositoryFilm.Add(newFilm);
    }
    private static void UpdateFilm(){
        Console.WriteLine("Entre the film id:");
        int idFilm = int.Parse(Console.ReadLine());

        foreach (int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine("{0} - {1}",i,Enum.GetName(typeof(Genre),i));            
        }
        Console.WriteLine("Enter the genre from the options above");
        int gender = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the film title");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the film start year");
        int year = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the film description");
        string description = Console.ReadLine();

        Film upFilm = new Film(id: repositoryFilm.NextId(),
        genre:(Genre)gender, 
        title: title, 
        year: year, 
        description: description);
        repositoryFilm.Update(idFilm, upFilm);
    }
    public static void DeleteFilm()
    {
        Console.WriteLine("Enter the film id:");
        int ifFilm = int.Parse(Console.ReadLine());

        repositoryFilm.Delete(ifFilm);
    }
    private static void ViewFilm()
    {
        Console.WriteLine("Enter the film id:");
        int ifFilm = int.Parse(Console.ReadLine());

        var film = repositoryFilm.GetById(ifFilm);

        Console.WriteLine(film);
        Console.ReadKey();
    }
}