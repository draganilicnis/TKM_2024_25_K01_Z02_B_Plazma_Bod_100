// https://arena.petlja.org/sr-Latn-RS/competition/2024-2025-kv1-testiranje#tab_137812

using System;

class TKM_2024_25_K01_Z02_B_Plazma_Bod_100
{
    static void Main()
    {
        string[] sNQ = Console.ReadLine().Split();
        long N = long.Parse(sNQ[0]);        // broj dana
        long Q = long.Parse(sNQ[1]);        // Broj pitanja

        long[] D = new long[N];             // Kog dana
        long[] P = new long[N];             // Koliko pakovanja je kupio i-tog dana

        for (int i = 0; i < N; i++)
        {
            string[] sDP = Console.ReadLine().Split();
            D[i] = long.Parse(sDP[0]);
            P[i] = long.Parse(sDP[1]);
        }

        // RESAVANJE ZADATKA
        long zalihe = 0;                    // Trenutna kolicina zaliha
        long pojela = 0;                    // Trenutna kolicina pojela
        int id = 0;                         // Trenutna pozicija za nizove D[id] i P[id]
        long dana_proslo = 1;               // Koliko dana je proslo izmedju dva id, odnosno D[id] - D[id-1]: Inicijalno mora 1, jer je prvi dan nabavke 1, a pocetni je nulti

        for (int q = 0; q < Q; q++)
        {
            long K = long.Parse(Console.ReadLine());

            while (id < N && D[id] <= K)
            {
                long dan_nabavke_trenutni = D[id];                              // Trenutni (id) dan nabavke
                long dana_proslo_razlika = dan_nabavke_trenutni - dana_proslo;  // Koliko dana je proslo izmedju dva id, odnosno D[id] - D[id-1], odnosno od poslednje nabavke
                long pojela_novo = Math.Min(zalihe, dana_proslo_razlika);       // Koliko moze da pojede nakon kupovine id dana do K-tog dana
                pojela = pojela + pojela_novo;                                  // Koliko je ukupno pojela od prethodne do trenutno poslednje nabavke id dana
                zalihe = zalihe - pojela_novo;                                  // Koliko je ostalo zaliha do id dana
                // Console.Write(id + ": " + D[id] + " " + dana_proslo + " " + dana_proslo_razlika + " " + pojela_novo + " " + pojela + " " + zalihe);
                dana_proslo = dan_nabavke_trenutni;                             // D[id-1] priprema za sledecu iteraciju
                zalihe = zalihe + P[id];                                        // Priprema za sledecu iteraciju
                // Console.WriteLine(" => " + zalihe);
                id++;
            }

            long pojela_poslednje = Math.Min(zalihe, K - dana_proslo + 1);  // Koliko je ukupno pojela do K-tog dana
            long rezultat = pojela + pojela_poslednje;
            // Console.WriteLine(zalihe + " " + (K - dana_proslo + 1) + " " + pojela + " " + pojela_poslednje + " => " + rezultat);
            Console.WriteLine(rezultat);
        }
    }
}
