using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;


class Program
    {
    public Random random=new Random();
    public List<Mokinys> mokiniai = new List<Mokinys>();
    public List<Mokinys> vargsiukail = new List<Mokinys>();
    public List<Mokinys> galvociail = new List<Mokinys>();
    public LinkedList<Mokinys> mokiniaill = new LinkedList<Mokinys>();
    public LinkedList<Mokinys> vargsiukaill = new LinkedList<Mokinys>();
    public LinkedList<Mokinys> galvociaill = new LinkedList<Mokinys>();
    public Queue<Mokinys> mokiniaiq = new Queue<Mokinys>();
    public Queue<Mokinys> vargsiukaiq = new Queue<Mokinys>();
    public Queue<Mokinys> galvociaiq = new Queue<Mokinys>();
    string defdir = Directory.GetCurrentDirectory();
    public void refresh()
    {

        mokiniai = new List<Mokinys>();
        vargsiukail = new List<Mokinys>();
        galvociail = new List<Mokinys>();
        mokiniaill = new LinkedList<Mokinys>();
        vargsiukaill = new LinkedList<Mokinys>();
        galvociaill = new LinkedList<Mokinys>();
        mokiniaiq = new Queue<Mokinys>();
        vargsiukaiq = new Queue<Mokinys>();
        galvociaiq = new Queue<Mokinys>();
    }
    
    public void ReadF(string fn)
    {
        String[] lines = System.IO.File.ReadAllLines(fn);
        int l = 0;
        foreach (string line in lines)
        {
            
            if (l != 0)
            {

                List<string> ele = new List<string>(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                if (ele.Count > 4)
                {
                    string var = ele[0];
                    string pav = ele[1];
                    List<int> n = new List<int>();
                    for (int i = 2; i < ele.Count - 1; i++)
                    {
                        n.Add(Convert.ToInt32(ele[i]));
                    }
                    int eg = Convert.ToInt32(ele[ele.Count - 1]);
                    Mokinys mok = new Mokinys();
                    mok.Enterdataman(var, pav, n, eg);
                    mokiniai.Add(mok);
                    mokiniaill.AddLast(mok);
                    mokiniaiq.Enqueue(mok);
                }

                //Console.WriteLine("{0,0} {1,0} {2,0} {3, 0}",var, pav, string.Join("; ", n), eg);
            }
            l++;
        }
    }
    public void DoFour(string fn, int n)
    {
        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        //Console.WriteLine("įveskite kiek failų ruošiaties generuoti");
                          
            Console.WriteLine("generuojamas " + fn);
           
            string docPath = defdir;
            StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, fn));

            outputFile.WriteLine("Vardas Pavarde nd1 nd2 nd3 nd4 nd5 Egzaminas");
            for (int j = 1; j <= n; j++)
            {
                string vardas = "Vardas" + Convert.ToString(j);
                string pavarde = "Pavarde" + Convert.ToString(j);
                int nd1 = random.Next(1, 10);
                int nd2 = random.Next(1, 10);
                int nd3 = random.Next(1, 10);
                int nd4 = random.Next(1, 10);
                int nd5 = random.Next(1, 10);
                int egz = random.Next(1, 10);
                string stud = vardas + " " + pavarde + " " + Convert.ToString(nd1) + " " + Convert.ToString(nd2) + " " + Convert.ToString(nd3) + " " + Convert.ToString(nd4) + " " + Convert.ToString(nd5) + " " + Convert.ToString(egz);
                outputFile.WriteLine(stud);
                List<int> nd = new List<int>();
                nd.Add(nd1);
                nd.Add(nd2);
                nd.Add(nd3);
                nd.Add(nd4);
                nd.Add(nd5);
                Mokinys mok = new Mokinys();
                mok.Enterdataman(vardas, pavarde, nd, egz);
                mokiniai.Add(mok);
            }
            mokiniai.Sort((s1, s2) => s1.galutinisvid.CompareTo(s2.galutinisvid));

            outputFile.Close();

        
        Console.WriteLine("Sukategoruojama į failus");
        string kat2 = "galvociai.txt";
        string kat1 = "vargsiukai.txt";
        StreamWriter outkat2 = new StreamWriter(Path.Combine(defdir, kat2), true);
        StreamWriter outkat1 = new StreamWriter(Path.Combine(defdir, kat1), true);
        outkat2.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
        outkat1.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
        for (int k = 0; k < mokiniai.Count; k++)
        {
            mokiniai[k].PrintFileb(outkat1, outkat2);
        }
        outkat1.Close();
        outkat2.Close();
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
    }
    public void DoFive(string fn, string m)
    {
        string strat = m;
        if (!File.Exists(fn))
        {
            Console.WriteLine("Nerasti failai.");
        }
        else if ((strat == "1") && File.Exists(fn) )
        {
            Console.WriteLine("Naudojama 1 strategija su "+fn+" failu");
            ReadF(defdir + @"\"+fn);
            
            string docPat = defdir;
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Kategoruojama i 2 listus.");
            foreach (Mokinys mok in mokiniai)
            {
                if (mok.galutinisvid >= 5)
                {
                    galvociail.Add(mok);
                }
                else
                {
                    vargsiukail.Add(mok);
                }
            }
            Console.WriteLine("Spausdinami failai");
            string kat2 = "galvociai1.txt";
            string kat1 = "vargsiukai1.txt";


            StreamWriter outkat2 = new StreamWriter(Path.Combine(defdir, kat2), true);
            StreamWriter outkat1 = new StreamWriter(Path.Combine(defdir, kat1), true);
            outkat2.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat1.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            foreach (Mokinys galv in galvociail)
            {
                galv.PrintFile(outkat2);
            }
            foreach (Mokinys varg in vargsiukail)
            {
                varg.PrintFile(outkat1);
            }
            outkat1.Close();
            outkat2.Close();
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");


            var watch2 = new System.Diagnostics.Stopwatch();
            watch2.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Kategoruojama i 2 linkedlist.");
            foreach (Mokinys mok in mokiniaill)
            {
                if (mok.galutinisvid >= 5)
                {
                    galvociaill.AddLast(mok);
                }
                else
                {
                    vargsiukaill.AddLast(mok);
                }
            }
            Console.WriteLine("Spausdinami failai");
            string kat4 = "galvociaill1.txt";
            string kat3 = "vargsiukaill1.txt";

            StreamWriter outkat4 = new StreamWriter(Path.Combine(defdir, kat4), true);
            StreamWriter outkat3 = new StreamWriter(Path.Combine(defdir, kat3), true);
            outkat4.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat3.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");

            foreach (Mokinys galv in galvociaill)
            {
                galv.PrintFile(outkat4);
            }
            outkat4.Close();

            foreach (Mokinys varg in vargsiukaill)
            {
                varg.PrintFile(outkat3);
            }
            outkat3.Close();

            watch2.Stop();
            Console.WriteLine($"Execution Time: {watch2.ElapsedMilliseconds} ms");


            var watch3 = new System.Diagnostics.Stopwatch();
            watch3.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Kategoruojama i 2 Queue.");
            foreach (Mokinys mok in mokiniaiq)
            {
                if (mok.galutinisvid >= 5)
                {
                    galvociaiq.Enqueue(mok);
                }
                else
                {
                    vargsiukaiq.Enqueue(mok);
                }
            }
            Console.WriteLine("Spausdinami failai");
            string kat6 = "galvociaiq1.txt";
            string kat5 = "vargsiukaiq1.txt";

            StreamWriter outkat6 = new StreamWriter(Path.Combine(defdir, kat6), true);
            StreamWriter outkat5 = new StreamWriter(Path.Combine(defdir, kat5), true);
            outkat6.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat5.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            foreach (Mokinys galv in galvociaiq)
            {
                galv.PrintFile(outkat6);
            }
            outkat6.Close();

            foreach (Mokinys varg in vargsiukaiq)
            {
                varg.PrintFile(outkat5);
            }
            outkat5.Close();

            watch3.Stop();
            Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms");


        }
        else if ((strat == "2") && File.Exists(fn))
        {
            Console.WriteLine("2 strategija su "+fn+" failu");
            ReadF(defdir + @"\"+fn);
            Console.WriteLine(fn+" failas perskaitytas");
           
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Sukategoruojama į failus naudojant list.");


            Mokinys tarp = new Mokinys();


            foreach (Mokinys mok in mokiniai)
            {
                if (mok.galutinisvid < 5)
                {
                    vargsiukail.Add(mok);

                }

            }
            mokiniai.RemoveAll(mok => mok.galutinisvid < 5);
            galvociail = mokiniai;
            Console.WriteLine("Spausdinami failai");
            string kat2 = "galvociai2.txt";
            string kat1 = "vargsiukai2.txt";


            StreamWriter outkat2 = new StreamWriter(Path.Combine(defdir, kat2), true);
            StreamWriter outkat1 = new StreamWriter(Path.Combine(defdir, kat1), true);

            outkat2.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat1.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");

            foreach (Mokinys galv in galvociail)
            {
                galv.PrintFile(outkat2);
            }
            foreach (Mokinys varg in vargsiukail)
            {
                varg.PrintFile(outkat1);
            }
            outkat1.Close();
            outkat2.Close();
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");


            var watch2 = new System.Diagnostics.Stopwatch();
            watch2.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Kategoruojama i 2 linkedlist.");

            var node = mokiniaill.First;

            foreach (Mokinys mok in mokiniaill)
            {
                if (mok.galutinisvid < 5)
                {
                    vargsiukaill.AddLast(mok);

                }

            }

            while (node != null)
            {
                var nextNode = node.Next;

                if (node.Value.galutinisvid < 5)
                {
                    mokiniaill.Remove(node);
                }
                node = nextNode;
            }

            galvociaill = mokiniaill;
            Console.WriteLine("Spausdinami failai");
            string kat4 = "galvociaill2.txt";
            string kat3 = "vargsiukaill2.txt";

            StreamWriter outkat4 = new StreamWriter(Path.Combine(defdir, kat4), true);
            StreamWriter outkat3 = new StreamWriter(Path.Combine(defdir, kat3), true);
            outkat4.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat3.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");

            foreach (Mokinys galv in galvociaill)
            {
                galv.PrintFile(outkat4);
            }

            foreach (Mokinys varg in vargsiukaill)
            {
                varg.PrintFile(outkat3);
            }
            outkat4.Close();
            outkat3.Close();
            watch2.Stop();
            Console.WriteLine($"Execution Time: {watch2.ElapsedMilliseconds} ms");


            var watch3 = new System.Diagnostics.Stopwatch();
            watch3.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Kategoruojama i 2 Queue.");
            foreach (Mokinys mok in mokiniaiq)
            {
                if (mok.galutinisvid < 5)
                {
                    vargsiukaiq.Enqueue(mok);

                }

            }

            galvociaiq = new Queue<Mokinys>(mokiniaiq.Where(x => x.galutinisvid < 5));

            Console.WriteLine("Spausdinami failai");
            string kat6 = "galvociaiq2.txt";
            string kat5 = "vargsiukaiq2.txt";

            StreamWriter outkat6 = new StreamWriter(Path.Combine(defdir, kat6), true);
            StreamWriter outkat5 = new StreamWriter(Path.Combine(defdir, kat5), true);

            outkat6.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat5.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");

            foreach (Mokinys galv in galvociaiq)
            {
                galv.PrintFile(outkat6);
            }

            foreach (Mokinys varg in vargsiukaiq)
            {
                varg.PrintFile(outkat5);
            }
            outkat6.Close();
            outkat5.Close();
            watch3.Stop();
            Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms");


        }
        else if ((strat == "3") && File.Exists(fn))
        {
            Console.WriteLine("3 strategija su "+fn+" failu");
            ReadF(defdir + @"\"+fn);
            Console.WriteLine(fn+" failas perskaitytas");
                       var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Sukategoruojama į failus naudojant list.");
            string kat2 = "galvociai3.txt";
            string kat1 = "vargsiukai3.txt";


            StreamWriter outkat2 = new StreamWriter(Path.Combine(defdir, kat2), true);
            StreamWriter outkat1 = new StreamWriter(Path.Combine(defdir, kat1), true);
            outkat2.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat1.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");

            foreach (Mokinys mok in mokiniai)
            {
                mok.PrintFileb(outkat1, outkat2);
            }
            outkat1.Close();
            outkat2.Close();
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            var watch2 = new System.Diagnostics.Stopwatch();
            watch2.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Sukategoruojama į failus naudojant linkedlist.");

            string kat4 = "galvociaill3.txt";
            string kat3 = "vargsiukaill3.txt";

            StreamWriter outkat4 = new StreamWriter(Path.Combine(defdir, kat4), true);
            StreamWriter outkat3 = new StreamWriter(Path.Combine(defdir, kat3), true);

            outkat4.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat3.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");

            foreach (Mokinys mok in mokiniaill)
            {
                mok.PrintFileb(outkat3, outkat4);
            }
            outkat3.Close();
            outkat4.Close();
            watch2.Stop();
            Console.WriteLine($"Execution Time: {watch2.ElapsedMilliseconds} ms");

            var watch3 = new System.Diagnostics.Stopwatch();
            watch3.Start();
            Console.WriteLine("Timer starts.");
            Console.WriteLine("Sukategoruojama į failus naudojant queue.");

            string kat6 = "galvociaiq3.txt";
            string kat5 = "vargsiukaiq3.txt";
            StreamWriter outkat6 = new StreamWriter(Path.Combine(defdir, kat6), true);
            StreamWriter outkat5 = new StreamWriter(Path.Combine(defdir, kat5), true);
            outkat6.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
            outkat5.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");

            foreach (Mokinys mok in mokiniaiq)
            {
                mok.PrintFileb(outkat5, outkat6);
            }
            outkat5.Close();
            outkat6.Close();
            watch3.Stop();
            Console.WriteLine($"Execution Time: {watch3.ElapsedMilliseconds} ms");
        }
        else
        {
            Console.WriteLine("Ivedete netaisiklinga komanda.");
        }
    }
     public void Menu()
        {
        Console.WriteLine(defdir);
            string men;
            do
            {
                Console.WriteLine("Jeigu norite įvesti naują mokinį spauskite 1,\n Jeigu norite perskaityti mokinių sąrašą iš failo ir jį apdorojus atspausdinti, spaukite 2, \n jeigu norite matyti visų mokinių sąrašą - spauskite 3,\n jeigu norite sugeneruoti atsitiktinių įrašų failą ir jį apdoroti, spauskite 4, \n jeigu norite atlikti v0.5 tyrimo dalį, tai spauskite 5, \n jeigu norite, kad programa baigtų darbą, spauskite 0");
                men =Console.ReadLine();
                if (men == "1")
                {
                    Mokinys mok = new Mokinys();
                    mok.Enterdata();
                    mokiniai.Add(mok);
                }
                else if(men=="2")
            {
                
                ReadF(defdir+@"\studentai.txt");
                mokiniai.Sort((s1,s2)=>s1.pavarde.CompareTo(s2.pavarde));
                Console.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}", "Pavarde", "Vardas", "Galutinis(vid)", "Galutinis(Med.)");
                for(int i=0;i<mokiniai.Count;i++)
                {
                    mokiniai[i].Printoof();
                }
            }
                    else if (men == "3")
                {
                mokiniai.Sort((s1, s2) => s1.vardas.CompareTo(s2.vardas));
                string men4;
                    Console.WriteLine("Jeigu norite kad galutinis pažimys būtų spausdinamas pagal namų darbų vidurkį, spauskite 1,\n jeigu norite kad galutinis pažimys būtų spausdinamas pagal medianą, spauskite 0");
                    men4 = Console.ReadLine();
                    if (men4 == "1")
                    {
                        Console.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
                        for (int i = 0; i < mokiniai.Count; i++)
                        {
                            mokiniai[i].Printvid();
                        }

                    }
                    else if (men4 == "0")
                    {


                        Console.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(med)");
                        for (int i = 0; i < mokiniai.Count; i++)
                        {
                            mokiniai[i].Printmed();
                        }

                    }

                }
                else if (men=="4")
            {
                refresh();
                DoFour("1.txt", 1000);
                refresh();
                DoFour("2.txt", 10000);
                refresh();
                DoFour("3.txt", 100000);
                refresh();
                DoFour("4.txt", 1000000);
                refresh();
                DoFour("5.txt", 10000000);
                refresh();
                /*var watch = new System.Diagnostics.Stopwatch();
                watch.Start(); 
                //Console.WriteLine("įveskite kiek failų ruošiaties generuoti");
                int f = 5;
                int fi = 100;//Convert.ToInt32(Console.ReadLine());
                for(int i=1;i<=f;i++)
                {
                    string filename = Convert.ToString(i) + ".txt";
                    Console.WriteLine("generuojamas "+filename);
                    fi *= 10;
                    string docPath = defdir;
                    StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, filename));
                    
                        outputFile.WriteLine("Vardas Pavarde nd1 nd2 nd3 nd4 nd5 Egzaminas");
                        for(int j=1;j<=fi;j++)
                        {
                            string vardas = "Vardas" + Convert.ToString(j);
                            string pavarde = "Pavarde" + Convert.ToString(j);
                            int nd1= random.Next(1, 10);
                            int nd2 = random.Next(1, 10);
                            int nd3 = random.Next(1, 10);
                            int nd4 = random.Next(1, 10);
                            int nd5 = random.Next(1, 10);
                            int egz=random.Next(1, 10); 
                            string stud=vardas+" "+pavarde+" "+Convert.ToString(nd1) + " " + Convert.ToString(nd2) + " " + Convert.ToString(nd3) + " " + Convert.ToString(nd4)+" " + Convert.ToString(nd5) + " " + Convert.ToString(egz);
                        outputFile.WriteLine(stud);
                        List<int> nd = new List<int>();
                            nd.Add(nd1);
                            nd.Add(nd2);
                            nd.Add(nd3);
                            nd.Add(nd4);
                            nd.Add(nd5);
                            Mokinys mok = new Mokinys();
                            mok.Enterdataman(vardas,pavarde,nd,egz);
                            mokiniai.Add(mok);
                        }
                        mokiniai.Sort((s1, s2) => s1.galutinisvid.CompareTo(s2.galutinisvid));

                    outputFile.Close();
                    
                }
                Console.WriteLine("Sukategoruojama į failus");
                string kat2 = "galvociai.txt";
                string kat1 = "vargsiukai.txt";
                StreamWriter outkat2 = new StreamWriter(Path.Combine(defdir, kat2), true);
                StreamWriter outkat1 = new StreamWriter(Path.Combine(defdir, kat1), true);
                outkat2.WriteLine("{0,30}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
                outkat1.WriteLine("{0,20}{1,20}{2,20}", "Vardas", "Pavarde", "Galutinis(vid)");
                for (int k=0;k<mokiniai.Count;k++)
                {
                    mokiniai[k].PrintFileb(outkat1, outkat2);
                }
                outkat1.Close();
                outkat2.Close();
                watch.Stop();
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            */}
                else if (men=="5")
            {
                refresh();
                Console.WriteLine("Listo dydis"+mokiniai.Count);
                Console.WriteLine("Jeigu norite uzduoti padaryti 1 strategija, spauskite 1, \n jeiguo norite uzduoti padaryti 2 strategija,\n jeigu norite uzduoti padaryti savo metodu spauskite 3");
                DoFive("1.txt", "1");
                refresh();
                DoFive("2.txt", "1");
                refresh();
                DoFive("3.txt", "1");
                refresh();
                DoFive("4.txt", "1");
                refresh();
                DoFive("5.txt", "1");
                refresh();
                DoFive("1.txt", "2");
                refresh();
                DoFive("2.txt", "2");
                refresh();
                DoFive("3.txt", "2");
                refresh();
                DoFive("4.txt", "2");
                refresh();
                DoFive("5.txt", "2");
                refresh();
                DoFive("1.txt", "3");
                refresh();
                DoFive("2.txt", "3");
                refresh();
                DoFive("3.txt", "3");
                refresh();
                DoFive("4.txt", "3");
                refresh();
                DoFive("5.txt", "3");
                refresh();
            }
            } while (men != "0");
        
            Console.WriteLine("Programa darbą baigė");
        
    }
        static void Main(string[] args)
        {
           try
        {
            if (!File.Exists("studentai.txt"))
                throw new FileNotFoundException();
            else Console.WriteLine("File studentai.txt is found");
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File studentai.txt not found");
        }

            Program m = new Program();
            m.Menu();
            Console.ReadKey();
      
        }

    
    }


