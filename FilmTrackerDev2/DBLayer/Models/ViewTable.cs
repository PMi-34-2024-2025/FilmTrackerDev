using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Для Key
using System.ComponentModel.DataAnnotations.Schema;

public class ViewTable
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Key]
    [Column("film_id")]
    public int FilmId { get; set; }

    [Column("rating")]
    public int? Rating { get; set; }

    [Column("comment_")]
    public string Comment_ { get; set; }

    [Column("iswached")]
    public bool IsWatched { get; set; }

    [Column("isplanned")]
    public bool IsPlanned { get; set; }
}
