using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerDev2.ClassLayer
{
    public class FilmObject
    {
        public int FilmId { get;}
        public string Name {  get; }
        public string Description { get; }
        public double Rating { get; }
        public List<Actor> Actors { get; }
        public List<string> Genres { get; }

        public bool IsPlanned = false;
        public bool IsFavorite = false;
        public bool IsWatched = false;
        
        private void addActor(Actor actor)
        {
            Actors.Add(actor);
        }
    
        public FilmObject(int id, string name, double rating, string description, List<Actor> actors , List<string> genres,
            bool isFavorite = false, bool isPlaned = false, bool isWatched = false)
        {
            FilmId = id;
            Name = name;
            Rating = rating;
            Description = description;
            IsFavorite = isFavorite;
            IsPlanned = isPlaned;
            IsWatched = isWatched;
            foreach (var actor in actors)
            {
                Actors?.Add(actor);
            }
            foreach (var genre in genres)
            {
                Genres?.Add(genre);
            }
        }

    }
}
