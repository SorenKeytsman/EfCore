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
    public class HuisEF
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Column(TypeName = "nvarchar(250)")]
        public string Straat { get; set; }

        [Required]
        public int Nummer { get; set; }
        

        public ParkEF parkEF { get; set; }

        public Dictionary<HuurderEF, List<HuurcontractEF>> Huurcontracten = new Dictionary<HuurderEF, List<HuurcontractEF>>();

        //  public Dictionary<HuurderEF, List<HuurcontractEF>> huurContracten { get; set; }

        // public Huis(int id, string straat, int nr, bool actief, Park park, Dictionary<Huurder, List<Huurcontract>> huurcontracten)

        [Required]
        [Column(TypeName = "bit")]
        public bool Actief { get; set; }

        public HuisEF()
        {
        }

        public HuisEF(int id, string straat, int nummer, bool actief,ParkEF park/*, Dictionary<HuurderEF, List<HuurcontractEF>> huurcontracten*/)
        {
            Id = id;
            Straat = straat;
            Nummer = nummer;
            Actief = actief;
            parkEF = park;
            //Huurcontracten = huurcontracten;

        }
    }
}
