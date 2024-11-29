using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Для Key
using System.ComponentModel.DataAnnotations.Schema;
public class ActorFilm
{
    //[Key]
    [Column("actor_id")]
    public int ActorId { get; set; }

    //[Key]
    [Column("film_id")]
    public int FilmId { get; set; }
}
