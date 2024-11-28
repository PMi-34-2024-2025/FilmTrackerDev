﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Для Key
using System.ComponentModel.DataAnnotations.Schema;

public class GenreFilm
{
    [Key]
    [Column("genre_id")]
    public int GenreId { get; set; }

    [Column("film_id")]
    public int FilmId { get; set; }
}