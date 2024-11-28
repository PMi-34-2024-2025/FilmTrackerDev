using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerDev2.ClassLayer
{
    public class ActorObject
    {
        public string Name { get; }
        private int id;

        public int getId()
        { 
            return id;
        }

        public ActorObject(string name, int id)
        {
            Name = name;
            this.id = id;
        }
    }
}
