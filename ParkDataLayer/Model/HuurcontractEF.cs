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
    public class HuurcontractEF
    {
        [Key]
        [Column(TypeName = "nvarchar(25)")]
        public string Id { get; set; }


        public Huurperiode Huurperiode { get; set; }

        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        [Required]
        public int VerhuurdeDagen { get; set; }

        public HuurderEF HuurderEF { get; set; }

        public HuisEF HuisEF { get; set; }

        public HuurcontractEF()
        {
        }

        public HuurcontractEF(string id, DateTime startDatum, DateTime eindDatum, int verhuurdeDagen)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            VerhuurdeDagen = verhuurdeDagen;
        }

        public HuurcontractEF(string id, DateTime startDatum, DateTime eindDatum, int verhuurdeDagen,HuurderEF huurderEF,HuisEF huisEF)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            VerhuurdeDagen = verhuurdeDagen;
            HuurderEF = huurderEF;
            HuisEF = huisEF;
        }

    }
}

