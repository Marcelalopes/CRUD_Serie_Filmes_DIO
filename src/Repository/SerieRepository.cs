using DIO_Series.src.Interfaces;

namespace DIO_Series.src.Models
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public void Add(Serie entity)
        {
            listSerie.Add(entity);
        }

        public void Delete(int id)
        {
            listSerie[id].DeleteSerie();
        }

        public Serie GetById(int id)
        {
            return listSerie[id];
        }

        public List<Serie> List()
        {
            return listSerie;
        }

        public int NextId()
        {
            return listSerie.Count;
        }

        public void Update(int id, Serie entity)
        {
            listSerie[id] = entity;
        }
    }
}