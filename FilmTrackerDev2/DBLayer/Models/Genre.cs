using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Для Key
using System.ComponentModel.DataAnnotations.Schema;
public class Genre
{
    [Key]
    [Column("genre_id")]
    public int GenreId { get; set; }

    [Column("name_")]
    public string Name_ { get; set; }
}
