using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti 
che una banca concede ai propri clienti.

La banca è caratterizzata da 
- un nome 
- un insieme di clienti (una lista) 
- un insieme di prestiti concessi ai clienti (una lista)


I clienti sono caratterizzati da 
- nome, 
- cognome, 
- codice fiscale 
- stipendio

I prestiti sono caratterizzati da 
- intestatario del prestito (il cliente), 
- un ammontare, una rata, 
- una data inizio, 
- una data fine. 



Per la banca deve essere possibile:
- aggiungere, modificare, eliminare e ricercare un cliente. 
- aggiungere un prestito. 
- effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale 
- sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.

Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo 
con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere. 

*/


namespace csharp_esercizio_banca
{
    public class Banca
    {
        private string sNomeBanca { get; set; }
        private List<Cliente> lsClienti { get; set; }
        private List<Prestito> lsPrestiti { get; set; }

        public Banca(string sNome)
        {
            sNomeBanca = sNome;
            lsClienti = new List<Cliente>();
            lsPrestiti = new List<Prestito>();
        }

        public bool AddCliente(string sNome, string sCognome, string sCodiceFiscale, double dStipendio)
        {
            Cliente mioCliente = new Cliente { sNome = sNome, sCognome = sCognome, sCodiceFiscale = sCodiceFiscale, dStipendio = dStipendio };
            lsClienti.Add(mioCliente);
            return true;

        }
        public bool UpdateCliente(string sCodiceFiscale, double dStipendio)
        {
            Cliente mioCliente = lsClienti.Find(x => x.sCodiceFiscale == sCodiceFiscale);
            if (mioCliente != null)
            {
                mioCliente.dStipendio = dStipendio;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddPrestito(Cliente sIntestatario, double dAmmontarePrestito, double dRataPrestito, DateTime dDataInizio, DateTime dDataFine)
        {
            Prestito mioPrestito = new Prestito { 
                sIntestatario = sIntestatario,
                dAmmontarePrestito = dAmmontarePrestito,
                dRataPrestito = dRataPrestito,
                dDataInizio = dDataInizio,
                dDataFine = dDataFine
            };
            lsPrestiti.Add(mioPrestito);
            return true;
        }
    }
    public class Cliente
    {
        public string sNome { get; set; }
        public string sCognome { get; set; }
        public string sCodiceFiscale { get; set; }
        public double dStipendio  { get; set; }

        public override string ToString()
        {
            return base.Format("Nome: {0}\nCognome: {1}\nCodiceFiscale: {2}\nStipendio: {3}",
                this.sNome,
                this.sCognome,
                this.sCodiceFiscale,
                this.dStipendio);
        }
    }
    public class Prestito
    {
        public Cliente sIntestatario { get; set;}
        public double dAmmontarePrestito { get; set; }
        public double dRataPrestito { get; set; }
        public DateTime dDataInizio { get; set; }
        public DateTime dDataFine { get; set; }

        public int GiorniAllaScadenza()
        {
            TimeSpan tsAppo = dDataFine - DateTime.Now;
            return (int)tsAppo.TotalDays;
        }
    }

    
}
