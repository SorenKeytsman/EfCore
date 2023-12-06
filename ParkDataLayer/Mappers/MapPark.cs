using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Mappers
{
    public class MapPark
    {
        public static Park MapToDomain(ParkEF db)
        {
            try
            {
               List<HuisEF> huis = new List<HuisEF>();
                return new Park(db.Id, db.Naam, db.Locatie);
            }
            catch (Exception ex)
            {
                throw new MapperException("Mappark - MapToDomain", ex);
            }
        }
        public static ParkEF MapToDB(Park p)
        {
            try
            {
                return new ParkEF(p.Id,p.Naam,p.Locatie);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapPark - MapToDomain", ex);
            }
        }

    }
}
  