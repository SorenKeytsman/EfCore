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
    public class MapHuurder
    {
        public static Huurder MapToDomain(HuurderEF db)
        {
            try
            {
                return new Huurder(db.Id, db.Naam, db.Contactgegevens);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapToDomain", ex);
            }
        }
        public static HuurderEF MapToDB(Huurder h)
        {
            try
            {
                return new HuurderEF(h.Id, h.Naam, h.Contactgegevens.Tel, h.Contactgegevens.Email, h.Contactgegevens.Adres);
            }
            catch (Exception ex)
            {
                throw new MapperException("MapHuurder - MapToDomain", ex);
            }
        }

    }
}

