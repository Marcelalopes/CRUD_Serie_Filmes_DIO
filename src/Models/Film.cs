using DIO_Series.src.Enum;

namespace DIO_Series.src.Models
{
    public class Film: EntityBase
    {
        public Film(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.isDeleted = false;

        }
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool isDeleted {get;set;}

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genre: "+this.Genre+Environment.NewLine;
            retorno += "Title: "+this.Title+Environment.NewLine;
            retorno += "Description: "+this.Description+Environment.NewLine;
            retorno += "Start Year: "+this.Year+Environment.NewLine;
            retorno += "Deleted: "+this.isDeleted;
            return retorno;

        }
        public string returnTitleFilm()
        {
            return this.Title;
        }
        public int returnIdFilm()
        {
            return this.Id;
        }
        public bool returnDeletedFilm(){
            return this.isDeleted;
        }
        public void DeleteFilm(){
            this.isDeleted = true;
        }
    }
}