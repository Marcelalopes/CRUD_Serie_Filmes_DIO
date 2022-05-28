using DIO_Series.src.Interfaces;
using DIO_Series.src.Models;

namespace DIO_Series.src.Repository
{
    public class FilmRepository : IRepository<Film>
    {
        private List<Film> listFilm = new List<Film>();
        public void Add(Film entity)
        {
            listFilm.Add(entity);
        }

        public void Delete(int id)
        {
            listFilm[id].DeleteFilm();
        }

        public Film GetById(int id)
        {
            return listFilm[id];
        }

        public List<Film> List()
        {
            return listFilm;
        }

        public int NextId()
        {
            return listFilm.Count;
        }

        public void Update(int id, Film entity)
        {
            listFilm[id] = entity;
        }
    }
}