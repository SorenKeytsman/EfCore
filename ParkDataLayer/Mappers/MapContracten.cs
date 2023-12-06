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
   public class MapContracten
    {
        //public Huurcontract(string id, Huurperiode huurperiode, Huurder huurder, Huis huis)
        public static Huurcontract MapToDomain(HuurcontractEF db)
        {
            try
            {

                //Park park = MapPark.MapToDomain(db.parkEF);
                Huurder huurder = MapHuurder.MapToDomain(db.HuurderEF);
                Huis huis = MapHuis.MapToDomain(db.HuisEF);

                return new Huurcontract(db.Id,db.Huurperiode,huurder,huis);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurcontract - MapToDomain", ex);
            }
        }
        public static HuurcontractEF MapToDB(Huurcontract hc, ParkBeheerContext ptx)
        {
            try
            {
                HuurderEF hu = ptx.Huurder.Find(hc.Huurder.Id);
                HuisEF h = ptx.Huis.Find(hc.Huis.Id);
                if (hu == null) hu = MapHuurder.MapToDB(hc.Huurder);
                if (h == null) h = MapHuis.MapToDB(hc.Huis,ptx);
                return new HuurcontractEF(hc.Id, hc.Huurperiode.StartDatum, hc.Huurperiode.EindDatum, hc.Huurperiode.Aantaldagen,hu,h);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurContract - MapToDB", ex);
            }

        }
    }
}
