﻿using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model
{
    public class ParkEF
    {
        [Key]

        [Column(TypeName = "nvarchar(20)")]
        public string Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public string Naam { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string Locatie { get; set; }

        public List<HuisEF> Huis = new List<HuisEF>() { };

        public ParkEF()
        {
        }

        public ParkEF(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }
    }
}