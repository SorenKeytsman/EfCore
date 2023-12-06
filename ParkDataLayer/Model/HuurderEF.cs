using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class HuurderEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Naam { get; set; }



        public Contactgegevens Contactgegevens { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Telefoon { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Adres { get; set; }

        public HuurderEF()
        {
        }

        public HuurderEF(int id, string naam, string telefoon, string email, string adres)
        {
            Id = id;
            Naam = naam;
            Telefoon = telefoon;
            Email = email;
            Adres = adres;
        }
    }
}
