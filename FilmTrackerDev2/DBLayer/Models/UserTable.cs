using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; // Для Key
using System.ComponentModel.DataAnnotations.Schema;
public class UserTable
{
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    [Column("user_name")]
    public string UserName { get; set; }

    [Column("language_preference")]
    public string LanguagePreference { get; set; }

    [Column("password")]
    public string Password_ { get; set; }
}
