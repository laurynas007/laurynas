using System;
using System.Collections.Generic;

namespace _0_1
{
    public class Mokinys
    {
        private string vardas, pavarde;
        private int n;
        private List<int> nd = new List<int>();
        private int[] ndm;
        private int egz;
        private double vid;
        private int med;
        private double galutinisvid;
        private double galutinismed;
private  Random random = new Random();
        public void enterdata()
        {
            Console.WriteLine("Įveskite mokinio vardą: ");
            vardas = Console.ReadLine();
            Console.WriteLine("Įveskite mokinio pavardę: ");
            pavarde = Console.ReadLine();
            int m4;
            do
            {
                Console.WriteLine("Jei norite, kad pažymius sugeneruotų atsitiktinai, spauskite 1,\n jeigu norite pažymius įvesti patys, spauskite 2");
                m4 = Convert.ToInt32(Console.ReadLine());
                if ((m4 != 1) && (m4 != 2))
                {
                    Console.WriteLine("Įvedėte neteisingai, pakartokite.");
                }
            } while ((m4 != 1) && (m4 != 2));
            Console.WriteLine("Ar iš anksto yra žinomas atliktų namų darbų skaičius?\n Jeigu taip, spauskite 1, jeigu ne, spauskite 2");
            int m2 = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
                      
            if (m2 == 1)
            {
                Console.WriteLine("Iveskite kiek namų darbų atlikta: ");
                n = Convert.ToInt32(Console.ReadLine());
                ndm = new int[n];
                sum = 0;

              for (int i = 0; i < n; i++)
                {
                    if (m4 == 1) {
                        ndm[i] = random.Next(1, 10);
                            }
                    else if (m4 == 2)
                    {
                        Console.WriteLine("Iveskite  namu darbo pažimį");
                        ndm[i] = Convert.ToInt32(Console.ReadLine());
                    }
                    sum = sum + ndm[i];
                }
                Array.Sort(ndm);
                med = ndm[n / 2];

            }

            else if (m2 == 2)
            {
                int m3;
                sum = 0;
                int j = 0;
                do
                {
                    Console.WriteLine("Ar norite įvesti naują namų darbą? Jeigu taip, spauskite 1");
                    m3 = Convert.ToInt32(Console.ReadLine());
                    if (m3 == 1)
                    {
                        if (m4 == 1) { nd.Add(random.Next(1, 10));
                        }
                        else if (m4 == 2) {
                            Console.WriteLine("Iveskite namu darbo pažimį");
                            nd.Add(Convert.ToInt32(Console.ReadLine())); 
                                }
                        sum += nd[j];
                    }
                } while (m3 == 1);
                n = nd.Count;
                nd.Sort();
                med = nd[nd.Count / 2];
            }
            else
            {
                Console.WriteLine("Neteisingai įvedėte.");
            }
            if (m4 == 1) {egz = random.Next(1, 10); }
            else if (m4 == 2) {
                Console.WriteLine("Iveskite egzamino pažymį: ");
                egz = Convert.ToInt32(Console.ReadLine());
            }
            vid = Convert.ToDouble(sum / n);
            galutinisvid = vid * 0.3 + Convert.ToDouble(egz * 0.7);
            galutinismed = Convert.ToDouble(med * 0.3) + Convert.ToDouble(egz * 0.7);
        }
        public void printvid()
        {
            Console.WriteLine("{0,20}{1,20}{2,20:0.00}", vardas, pavarde, galutinisvid);
            
        }
    
    public void printmed()
    {

         Console.WriteLine("{0,20}{1,20}{2,20:0.00}", vardas, pavarde, galutinismed); 
    }
}
    
    class Program
    {
        public void menu()
        {
            List<Mokinys> mokiniai = new List<Mokinys>();
            int men;
            do
            {
                Console.WriteLine("Jeigu norite įvesti naują mokinį spauskite 1,\n jeigu norite matyti visų mokinių sąrašą - spauskite 2,\n jeigu norite, kad programa baigtų darbą, spauskite 0");
                men = Convert.ToInt32(Console.ReadLine());
                if (men == 1)
                {
                    Mokinys mok = new Mokinys();
                    mok.enterdata();
                    mokiniai.Add(mok);
                }
                else if (men == 2)
                {
                    int men4;
                    Console.WriteLine("Jeigu norite kad galutinis pažimys būtų spausdinamas pagal namų darbų vidurkį, spauskite 1,\n jeigu norite kad galutinis pažimys būtų spausdinamas pagal medianą, spauskite 0");
                    men4 = Convert.ToInt32(Console.ReadLine());
                    if (men4 == 1)
                    {
                        Console.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
                        for (int i = 0; i < mokiniai.Count; i++)
                        {
                            mokiniai[i].printvid();
                        }

                    }
                    else if (men4 == 0)
                    {


                        Console.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(med)");
                        for (int i = 0; i < mokiniai.Count; i++)
                        {
                            mokiniai[i].printmed();
                        }

                    }

                }
            } while (men != 0);
            Console.WriteLine("Programa darbą baigė");

        }
        static void Main(string[] args)
        {
            

            Program m = new Program();
            m.menu();
            Console.ReadKey();
        }
    }
}
