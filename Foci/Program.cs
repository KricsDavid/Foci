using Foci;

public class Program()
{
    public static void Main(string[] args)
    {
        List<Meccs> meccsek = new List<Meccs>();

        try
        {
            string[] sorok = File.ReadAllLines("meccs.txt");
            int meccsekSzama = int.Parse(sorok[0]);

            for (int i = 1; i <= meccsekSzama; i++)
            {
                string[] adatok = sorok[i].Split(' ');
                Meccs meccs = new Meccs
                {
                    Fordulo = int.Parse(adatok[0]),
                    HazaiGol = int.Parse(adatok[1]),
                    VendegGol = int.Parse(adatok[2]),
                    HazaiFelidogol = int.Parse(adatok[3]),
                    VendegFelidogol = int.Parse(adatok[4]),
                    HazaiCsapat = adatok[5],
                    VendegCsapat = adatok[6]
                };
                meccsek.Add(meccs);
            }
        }
        catch (Exception)
        {

            meccsek.Add(new Meccs { Fordulo = 14, HazaiGol = 1, VendegGol = 2, HazaiFelidogol = 0, VendegFelidogol = 2, HazaiCsapat = "Agarak", VendegCsapat = "Ovatosak" });
            meccsek.Add(new Meccs { Fordulo = 5, HazaiGol = 4, VendegGol = 0, HazaiFelidogol = 1, VendegFelidogol = 0, HazaiCsapat = "Erosek", VendegCsapat = "Agarak" });
            meccsek.Add(new Meccs { Fordulo = 4, HazaiGol = 0, VendegGol = 2, HazaiFelidogol = 0, VendegFelidogol = 2, HazaiCsapat = "Ijedtek", VendegCsapat = "Hevesek" });
            meccsek.Add(new Meccs { Fordulo = 8, HazaiGol = 1, VendegGol = 1, HazaiFelidogol = 0, VendegFelidogol = 0, HazaiCsapat = "Ijedtek", VendegCsapat = "Nyulak" });
            meccsek.Add(new Meccs { Fordulo = 8, HazaiGol = 3, VendegGol = 2, HazaiFelidogol = 3, VendegFelidogol = 1, HazaiCsapat = "Lelkesek", VendegCsapat = "Bogarak" });
            meccsek.Add(new Meccs { Fordulo = 13, HazaiGol = 0, VendegGol = 1, HazaiFelidogol = 0, VendegFelidogol = 1, HazaiCsapat = "Fineszesek", VendegCsapat = "Csikosak" });
            meccsek.Add(new Meccs { Fordulo = 2, HazaiGol = 1, VendegGol = 0, HazaiFelidogol = 0, VendegFelidogol = 0, HazaiCsapat = "Pechesek", VendegCsapat = "Csikosak" });
            meccsek.Add(new Meccs { Fordulo = 1, HazaiGol = 4, VendegGol = 0, HazaiFelidogol = 2, VendegFelidogol = 0, HazaiCsapat = "Csikosak", VendegCsapat = "Kedvesek" });
            meccsek.Add(new Meccs { Fordulo = 9, HazaiGol = 2, VendegGol = 0, HazaiFelidogol = 0, VendegFelidogol = 0, HazaiCsapat = "Nyulak", VendegCsapat = "Lelkesek" });
            meccsek.Add(new Meccs { Fordulo = 6, HazaiGol = 0, VendegGol = 2, HazaiFelidogol = 0, VendegFelidogol = 0, HazaiCsapat = "Ovatosak", VendegCsapat = "Nyulak" });
        }


        // 2. feladat
        Console.Write("Kérlek, add meg a forduló számát: ");
        int fordulo = int.Parse(Console.ReadLine());
        Console.WriteLine($"2. feladat:");
        foreach (var meccs in meccsek.Where(m => m.Fordulo == fordulo))
        {
            Console.WriteLine($"{meccs.HazaiCsapat}-{meccs.VendegCsapat}: {meccs.HazaiGol}-{meccs.VendegGol} ({meccs.HazaiFelidogol}-{meccs.VendegFelidogol})");
        }

        // 3. feladat
        Console.WriteLine("3. feladat:");
        foreach (var meccs in meccsek.Where(m => m.HazaiFelidogol < m.VendegFelidogol && m.HazaiGol > m.VendegGol))
        {
            Console.WriteLine($"{meccs.Fordulo}. {meccs.HazaiCsapat}");
        }
        foreach (var meccs in meccsek.Where(m => m.HazaiFelidogol > m.VendegFelidogol && m.HazaiGol < m.VendegGol))
        {
            Console.WriteLine($"{meccs.Fordulo}. {meccs.VendegCsapat}");
        }

        //4.feladat
        Console.WriteLine("4. feladat:");
        Console.Write("Kérem adja meg a csapat nevét: ");
        string csapat = Console.ReadLine();
        if (string.IsNullOrEmpty(csapat))
        {
            csapat = "Lelkesek";
        }

        //5.feladat
        Console.WriteLine("5. feladat:");
        var csapatMeccsek = meccsek.Where(m => m.HazaiCsapat == csapat || m.VendegCsapat == csapat);
        int lottGol = csapatMeccsek.Sum(m => m.HazaiCsapat == csapat ? m.HazaiGol : m.VendegGol);
        int kapottGol = csapatMeccsek.Sum(m => m.HazaiCsapat == csapat ? m.VendegGol : m.HazaiGol);
        Console.WriteLine($"Lőtt: {lottGol} Kapott: {kapottGol}");

    }
}

Console.ReadKey();
