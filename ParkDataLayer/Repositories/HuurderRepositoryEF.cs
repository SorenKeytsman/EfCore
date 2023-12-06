using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class HuurderRepositoryEF : IHuurderRepository
    {
        private ParkBeheerContext ptx;
        private string ConString;

        public HuurderRepositoryEF(string conString)
        {
            this.ptx = new ParkBeheerContext(conString);
        }
        private void SaveAndClear()
        {
            ptx.SaveChanges();
            ptx.ChangeTracker.Clear();
        }

        public Huurder GeefHuurder(int id)
        {
            try
            {
                return MapHuurder.MapToDomain(ptx.Huurder.Where(h => h.Id == id).AsNoTracking().FirstOrDefault());
            }
            catch (Exception e)
            {
                throw new RepositoryException("GeefHuurder", e);
            }
        }

        public List<Huurder> GeefHuurders(string naam)
        {
            try
            {
                return ptx.Huurder.Select(h => MapHuurder.MapToDomain(h)).ToList();
            }
            catch (Exception ex)
            {
                throw new RepositoryException("GeefHuurders", ex);
            }
        }

        public bool HeeftHuurder(string naam, Contactgegevens contact)
        {
            try
            {
                return ptx.Huurder.Any(h => h.Naam == naam && h.Contactgegevens == contact);
            }
            catch (Exception e)
            {
                throw new RepositoryException("HeeftHuurder", e);
            }
        }

        public bool HeeftHuurder(int id)
        {
            try
            {
                return ptx.Huurder.Any(h => h.Id == id);
            }
            catch (Exception e)
            {
                throw new RepositoryException("HeeftHuurder", e);
            }
        }

        public void UpdateHuurder(Huurder huurder)
        {
            try
            {
                ptx.Huurder.Update(MapHuurder.MapToDB(huurder));
                SaveAndClear();
            }
            catch (Exception e)
            {
                throw new RepositoryException("UpdateHuurder", e);
            }

        }

        public Huurder VoegHuurderToe(Huurder h)
        {
            try
            {
                ptx.Huurder.Add(MapHuurder.MapToDB(h));
                ptx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new RepositoryException("VoegHuurderToe", e);
            }
            return h;
        }
    }
}
