using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Для Key
using System.ComponentModel.DataAnnotations.Schema;

public class Actor
{
    [Key]
    [Column("actor_id")]
    public int ActorId { get; set; }

    [Column("name_")]
    public string Name_ { get; set; }
}

