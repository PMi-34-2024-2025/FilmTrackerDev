using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Для Key
using System.ComponentModel.DataAnnotations.Schema; // Для Column

public class Film
{
    [Key]
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("name_")]
    public string Name_ { get; set; }

    [Column("year_")]
    public int Year_ { get; set; }

    [Column("description")]
    public string Description { get; set; }
}
