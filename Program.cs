using System;

namespace csharp_esercizio_banca
    internal class Program
    {
        static void Main(string[] args)
        {
            Banca MiaBanca = new Banca("Banco di Roma");
            Cliente MioCliente = new Cliente { sCodiceFiscale = "sssssss", dStipendio = 1000, sCognome = "Rossi", sNome = "Giacomo" };
        }
    }
}
