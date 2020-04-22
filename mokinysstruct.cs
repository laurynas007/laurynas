using System;
using System.Collections.Generic;
using System.IO;
public struct Mokinys
{
    public string vardas, pavarde;
    public int n;
    public List<int> nd;
    public int egz;
    public double vid;
    public int med;
    public double galutinisvid;
    public double galutinismed;
    public Random random;
    public string kategorija;
    public void Enterdataman(string v,string p, List<int> n, int e)
    {
        vardas = v;
        pavarde = p;
        nd = n;
        egz = e;
        nd.Sort();
        med = nd[nd.Count / 2];
        int sum = 0;
        for(int i=0;i<nd.Count;i++)
        {
            sum += nd[i];
        }
        vid = Convert.ToDouble(sum / nd.Count);
        galutinisvid=vid*0.3+egz*0.7;
        galutinismed = Convert.ToDouble(med * 0.3) + Convert.ToDouble(egz * 0.7);
        if (galutinisvid < 5) kategorija = "Vargsiukai";
        else if (galutinisvid >= 5) kategorija = "Galvociai";
        
    }
    public void Enterdata()
    {
        Console.WriteLine("Įveskite mokinio vardą: ");
        vardas = Console.ReadLine();
        Console.WriteLine("Įveskite mokinio pavardę: ");
        pavarde = Console.ReadLine();
        string m4;

        do
        {
            Console.WriteLine("Jei norite, kad pažymius sugeneruotų atsitiktinai, spauskite 1,\n jeigu norite pažymius įvesti patys, spauskite 2");
            m4 = Console.ReadLine();
            if ((m4 != "1") && (m4 != "2"))
            {
                Console.WriteLine("Įvedėte neteisingai, pakartokite.");
            }
        } while ((m4 != "1") && (m4 != "2"));
        string m2;
        int sum;
        do
        {
            Console.WriteLine("Ar iš anksto yra žinomas atliktų namų darbų skaičius?\n Jeigu taip, spauskite 1, jeigu ne, spauskite 2");
            m2 = Console.ReadLine();
            sum = 0;
            nd = new List<int>();
            random = new Random();
            if (m2 == "1")
            {


                int sv = 0;
                do
                {
                    Console.WriteLine("Iveskite kiek namų darbų atlikta: ");
                    string nt = Console.ReadLine();
                    int t;
                    if (int.TryParse(nt, out t) && (Convert.ToInt32(nt) == 0))
                    {
                        Console.WriteLine("Nulio negali buti");
                    }
                    else if (int.TryParse(nt, out t))
                    {
                        n = Convert.ToInt32(nt);
                        sv++;
                    }
                    else
                    {
                        Console.WriteLine("Neteisingai ivedete");
                    }
                } while (sv == 0);

                sum = 0;

                for (int i = 0; i < n; i++)
                {
                    if (m4 == "1")
                    {
                        nd.Add(random.Next(1, 10));
                    }
                    else if (m4 == "2")
                    {
                        sv = 0;
                        do
                        {
                            Console.WriteLine("Iveskite namu darbo pažimį");
                            string ats = Console.ReadLine();
                            int t;
                            if (int.TryParse(ats, out t))
                            {
                                nd.Add(Convert.ToInt32(ats));
                                sv++;
                            }
                            else
                            {
                                Console.WriteLine("Neteisingai ivedete");
                            }
                        } while (sv == 0);
                    }
                    sum += nd[i];
                }
                nd.Sort();
                med = nd[nd.Count / 2];

            }

            else if (m2 == "2")
            {
                string m3;
                sum = 0;
                int j = 0;
                do
                {
                    Console.WriteLine("Ar norite įvesti naują namų darbą? Jeigu taip, spauskite 1, jeigu ne, spauskite bet ka kitka");
                    m3 = Console.ReadLine();
                    if (m3 == "1")
                    {
                        if (m4 == "1")
                        {
                            nd.Add(random.Next(1, 10));
                        }
                        else if (m4 == "2")
                        {
                            int sv = 0;
                            do
                            {
                                Console.WriteLine("Iveskite namu darbo pažimį");
                                string ats = Console.ReadLine();
                                int t;
                                if (int.TryParse(ats, out t))
                                {
                                    nd.Add(Convert.ToInt32(ats));
                                    sv++;
                                }
                                else
                                {
                                    Console.WriteLine("Neteisingai ivedete");
                                }
                            } while (sv == 0);
                        }
                        sum += nd[j];
                    }
                } while (m3 == "1");
                n = nd.Count;
                nd.Sort();
                med = nd[nd.Count / 2];
            }
            else
            {
                Console.WriteLine("Neteisingai įvedėte.");
            }
        } while ((m2!="1")&&(m2!="2"));
        if (m4 == "1") { egz = random.Next(1, 10); }
        else if (m4 == "2")
        {
            Console.WriteLine("Iveskite egzamino pažymį: ");
            egz = Convert.ToInt32(Console.ReadLine());

            int sv = 0;
            do
            {
                Console.WriteLine("Iveskite egzaimino pažimį");
                string ats = Console.ReadLine();
                int t;
                if (int.TryParse(ats, out t))
                {
                    egz = Convert.ToInt32(ats);
                    sv++;
                }
                else
                {
                    Console.WriteLine("Neteisingai ivedete");
                }
            } while (sv == 0);

        }
        vid = Convert.ToDouble(sum / n);
        //printtarp();
        galutinisvid = vid * 0.3 + Convert.ToDouble(egz * 0.7);
        galutinismed = Convert.ToDouble(med * 0.3) + Convert.ToDouble(egz * 0.7);
        if (galutinisvid < 5) kategorija = "Vargsiukai";
        else if (galutinisvid >= 5) kategorija = "Galvociai";
    }
    public void Printvid()
    {
        Console.WriteLine("{0,20}{1,20}{2,20:0.00}", vardas, pavarde, galutinisvid);

    }
    public void Printtarp()
    {
        Console.Write("Namų darbai: ");
        nd.ForEach(item => Console.Write(item+";"));
        Console.WriteLine("Egzaminas="+egz+" vid(nd)="+vid+" med(nd)"+med);
    }
    public void Printoof()
    {
        Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", pavarde, vardas, galutinisvid, galutinismed);
    }
    public void Printmed()
    {

        Console.WriteLine("{0,20}{1,20}{2,20:0.00}", vardas, pavarde, galutinismed);
    }
    public void PrintFileb(StreamWriter f1, StreamWriter f2)
    {
        if (kategorija == "Vargsiukai")
            f1.WriteLine("{0,20}{1,20}{2,20:0.00}", vardas, pavarde, galutinisvid);
        else if (kategorija == "Galvociai")
            f2.WriteLine("{0,20}{1,20}{2,20:0.00}", vardas, pavarde, galutinisvid);
    }
    public void PrintFile(StreamWriter f)
    {
        f.WriteLine("{0,20}{1,20}{2,20:0.00}", vardas, pavarde, galutinisvid);
    }
}