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
    public class MapHuis
    {
        private ParkBeheerContext  ptx;

        public static Huis MapToDomain(HuisEF db)
        {
            try
            {
                Park park = MapPark.MapToDomain(db.parkEF);
                //Dictionary<HuurderEF, List<HuurcontractEF>> Huurcontracten = MapContracten();
                return new Huis(db.Id,db.Straat,db.Nummer,db.Actief,park);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapToDomain", ex);
            }
        }
        public static HuisEF MapToDB(Huis h,ParkBeheerContext ptx)
        {
            try
            {
                ParkEF park = ptx.Park.Find(h.Park.Id);
                if (park == null) park = MapPark.MapToDB(h.Park);
               // Dictionary<HuurderEF, List<HuurcontractEF>> Huurcontracten = ptx.Huurcontract.Find(h.Huurcontracten());

                return new HuisEF(h.Id, h.Straat, h.Nr, h.Actief,park/*,huurcontracten*/);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuis - MapToDomain", ex);
            }
        }
    }

}
