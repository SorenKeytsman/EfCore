using ParkBusinessLayer.Model;
using ParkDataLayer;
using ParkDataLayer.Repositories;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string constring = @"Data Source=DESKTOP-NDTRPE9\SQLEXPRESS;Initial Catalog=ParkbeheerEF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            ParkBeheerContext parkBeheerContext = new ParkBeheerContext(constring);

            HuizenRepositoryEF huizenRepository = new HuizenRepositoryEF(constring);
            HuurderRepositoryEF huurderrepo = new HuurderRepositoryEF(constring);
            ContractenRepositoryEF contractenRepositoryEF = new ContractenRepositoryEF(constring);

            // parkBeheerContext.Database.EnsureDeleted();
            // parkBeheerContext.Database.EnsureCreated();
            Park p = new Park("2", "Achterbuurt", "Velzeke");
            Huis h = new Huis("Veldstraat ", 12, true, p);
            Huis h2 = new Huis(1, "Provinciebaan 119", 12, true, p);
            Contactgegevens c = new Contactgegevens("Sören.Keytsman@gmail.com", "0496828108", "Provinciebaan 119");
            Huurder hu = new Huurder(1, "Bjarne Keytsman", c);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            Huurperiode hp = new Huurperiode(yesterday,15);
            Huurcontract hc = new Huurcontract("3", hp, hu, h2);

           





            /*deleteMethides*/
            //contractenRepositoryEF.AnnuleerContract(hc);


            /*updateMethodes*/
            //huizenRepository.UpdateHuis(h2);
            //contractenRepositoryEF.UpdateContract(hc);
            //huurderrepo.UpdateHuurder(hu);
            

            /*VoegToeMethodes*/
            // huizenRepository.VoegHuisToe(h); 
            //contractenRepositoryEF.VoegContractToe(hc);
            //huurderrepo.VoegHuurderToe(hu);          

        }
    }
}
