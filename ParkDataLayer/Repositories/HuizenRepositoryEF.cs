using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {

        private ParkBeheerContext ptx;
        private string ConString;

        public HuizenRepositoryEF(string conString)
        {
            this.ptx = new ParkBeheerContext(conString);
        }
        private void SaveAndClear()
        {
            ptx.SaveChanges();
            ptx.ChangeTracker.Clear();
        }
        public Huis GeefHuis(int id)
        {
            try
            {
                return MapHuis.MapToDomain(ptx.Huis.Where(h => h.Id == id).AsNoTracking().FirstOrDefault());

            }
            catch (Exception e)
            {
                throw new RepositoryException("Geefhuis", e);
            }

        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            try
            {
                return ptx.Huis.Any(h => h.Straat == straat && h.Nummer == nummer && h.parkEF.Id == park.Id);
            }
            catch (Exception e)
            {
                throw new RepositoryException("HeeftHuis", e);
            }

        }

        public bool HeeftHuis(int id)
        {
            try
            {
                return ptx.Huis.Any(h => h.Id == id);
            }
            catch (Exception e)
            {
                throw new RepositoryException("HeeftHuis", e);
            }
        }


        public void UpdateHuis(Huis huis)
        {
            try
            {
                ptx.Huis.Update(MapHuis.MapToDB(huis, ptx));
                SaveAndClear();
            }
            catch (Exception e)
            {
                throw new RepositoryException("UpdateHuis", e);
            }

        }

        public Huis VoegHuisToe(Huis h)
        {
            try
            {
                HuisEF hu = MapHuis.MapToDB(h, ptx);
                ptx.Huis.Add(hu);
                SaveAndClear();
                return h;
            }
            catch (Exception e)
            {
                throw new RepositoryException("VoegHuisToe", e);
            }

        }
    }
}
