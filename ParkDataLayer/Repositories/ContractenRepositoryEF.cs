using Microsoft.EntityFrameworkCore;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Exceptions;
using ParkDataLayer.Mappers;
using ParkDataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        private ParkBeheerContext ptx;
        private string ConString;

        public ContractenRepositoryEF(string conString)
        {
            this.ptx = new ParkBeheerContext(conString);
        }
        private void SaveAndClear()
        {
            ptx.SaveChanges();
            ptx.ChangeTracker.Clear();
        }

        public void AnnuleerContract(Huurcontract contract)
        {
            try
            {
                //HuurderEF huurderEF = new HuurderEF();
                //HuisEF huisEF = new HuisEF();
                ptx.Huurcontract.Remove(new HuurcontractEF(contract.Id, contract.Huurperiode.StartDatum, contract.Huurperiode.EindDatum, contract.Huurperiode.Aantaldagen/*, huurderEF, huisEF*/));
                ptx.SaveChanges();
            }
            catch (Exception e)
            {
                throw new RepositoryException("Annuleercontract", e);
            }
        }

        public Huurcontract GeefContract(string id)
        {
            try
            {
                return MapContracten.MapToDomain(ptx.Huurcontract.Where(x => x.Id == id).Include(x => x.HuurderEF).Include(x => x.HuisEF).AsNoTracking().FirstOrDefault());
            }
            catch (Exception e)
            {
                throw new RepositoryException("GeefContract", e);
            }
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
           /* try
            {
                return ptx.Huurcontract.Any(h => h.Huurperiode.StartDatum >= dtBegin || h.Huurperiode.EindDatum != null && dtBegin >= h.Huurperiode.StartDatum && dtEinde <= h.Huurperiode.EindDatum).toList();
            }
            catch (Exception e)
            {
                throw new RepositoryException("HeefHuurContract", e);
            }*/
            throw new NotImplementedException();

        }


        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            try
            {
                return ptx.Huurcontract.Any(h => h.StartDatum == startDatum && h.HuurderEF.Id == huurderid && h.HuisEF.Id == huisid);
            }
            catch (Exception e)
            {
                throw new RepositoryException("HeefHuurContract", e);
            }
        }

        public bool HeeftContract(string id)
        {
            try
            {
                return ptx.Huurcontract.Any(h => h.Id == id);
            }
            catch (Exception e)
            {
                throw new RepositoryException("HeefHuurContract", e);
            }
        }

        public void UpdateContract(Huurcontract contract)
        {
            try
            {
                ptx.Huurcontract.Update(MapContracten.MapToDB(contract, ptx));
                SaveAndClear();
            }
            catch (Exception e)
            {
                throw new RepositoryException("UpdateHuis", e);
            }
        }

        public void VoegContractToe(Huurcontract contract)
        {
            try
            {
                HuurcontractEF h = MapContracten.MapToDB(contract, ptx);
                ptx.Huurcontract.Add(h);
                SaveAndClear();
                contract.ZetId(h.Id);
            }
            catch (Exception e)
            {
                throw new RepositoryException("VoegcontractToe", e);
            }

        }
    }
}
