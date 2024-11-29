using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerDev2.ClassLayer
{
    public class FilmObject
    {
        public int FilmId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string comment {  get; set; }
        public List<ActorObject> Actors { get; set; }
        public List<string> Genres { get; set; }
        public int year;

        public bool IsPlanned = false;
        public bool IsFavorite = false;
        public bool IsWatched = false;
        
        private void addActor(ActorObject actor)
        {
            Actors.Add(actor);
        }
    
        public FilmObject(int id, string name, double rating,string comment, string description, List<ActorObject> actors , List<string> genres,
            int year,bool isFavorite = false, bool isPlaned = false, bool isWatched = false)
        {
            FilmId = id;
            Name = name;
            Rating = rating;
            Description = description;
            this.comment = comment;
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

        public FilmObject() { }

    }
}
