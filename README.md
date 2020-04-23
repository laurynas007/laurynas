# laurynas
V0.1


zip failas 0_1 tai yra suzipuotas visual studio projektinis failas, o Program.cs tai pats C# kodinis failas jeigu su projektinio folderiu iškiltų bėdų kas nors nepasileis.
---------------------------------
Programą atlikau menu būdu. Viena menu funkcija yra skirta naujos mokinio klasės sukūrimui ir jos duomenų užpildymui, 
o kita menu funkcija tai ir yra mokinio klasių duomenų atspausdinimai.

Duomenų įvedimai prasideda nuo vardo, pavardės, o pažymiai gali būti vedami 2 būdais, random arba klaviatūra.
Namų darbų rezultatai gali būti vedami, kai iš anksto žinomas namų darbų kiekis (tiem rezultatam registrueti naudojamas paprastas masyvas),
o kitas tai kai nežinai iš anksto namų darbų kiekio, todėl vartotojo klausiama kas kart ar norite įvesti naujo namų darbo pažymį (tiem rezultatam naudojamas listas).
egzaminas irgi yra vedamas 2 būdais - random ar klaviatūra (duomenų įvedimo būdas yra klausiamas tik kartą)
Vedant duomenis yra apskaičiuojamas vidurkis, mediana iš kūrių sukuriamas 2 tipų galutinis balas.

Visi šie duomenys yra saugomi klasėje ir kiekviena klasė turi dviejus spausdinimo metodus, 
vienas, kai norimas galutinis balas būtų skaičiuojamas pagal namų darbų vidurkį, o kitas, pagal medianą.

Spausdinimo meniu duoda užklausą, kuri klausia ar vartotojas nori atspausdinti visus mokinius ir jų galutinius balus pagal vidurkį, arba pagal medianą.
V0.2&V0.3

Pakeičiau mokinio klasę į mokinio struktūrą. sukūriau naują meniu funkciją, kuri leidžia vartotojui nuskaityti duomenis iš failo ir iš karto juos atspausdinti, rūšiavau pagal pavardes nes tai pirmasis spausdinamas stulpelis. Try catch metodą naudoju prieš meniu kuris paskelbia ar failas rastas ar ne, o pats txt failas randasi bin>Debug>netcoreapp2.1
v0.4
ciklu pagalba generuojami failai..
tuo paciu metu kai pildomi failai, taip pat ir yra pildomas mokiniu listas
sukuriamas naujas mokinys structuros atributas kategorija, kuri yra uzpildoma automatiskai pagal gaultini bala.
2 failai pavadinti pagal tas kategorijas ir i jas yra spausdinami irasai.
galutinai failai susikuria kai uzdarai programa.
v0.5
sukuriau failo nuskaitymo funkcija, i kuria kreipiuosi failo pavadinimu, paciuss 5 failus as susigeneravau anksciau 4 uzd pagalba.
Tuos failus reikia patalpinti i bin>Debug>netcoreapp2.1
gaila, bet duomenu failu neiseis i githuba ikelti nes jie kartu virsija 25mb riba.

as skaitant failus ir uzpildant struktura jau is anksto nustatau kategorija, o atliekant tam tikra testa, pakeiciu duomenu strukturos tipa, tarp list, linklist ir queue.
Tyrimų rezultatai:
l - list
ll - linkedlist
q - queue
laikas matuojamas milisekundemis (ms)
| Uzduotis\failas  | 1.txt  | 2.txt | 3.txt | 4.txt | 5.txt |
| -------------    | ------ | ------| ------|-------|-------|
| v0.4             | 17     | 35    | 324   | 3364  | 36275 |
| v0.5 1 strat l   | 3      | 16    | 122   | 924   | 19949 | 
| v0.5 1 strat ll  | 4      | 10    | 109   | 1041  | 11262 |
| v0.5 1 strat q   | 3      | 14    | 92    | 827   | 21768 |
| v0.5 2 strat l   | 137    | 11    | 116   | 885   | 9217  |
| v0.5 2 strat ll  | 16     | 14    | 96    | 1153  | 10892 |
| v0.5 2 strat q   | 148    | 11    | 97    | 903   | 22781 |
| v0.5 3 strat l   | 11     | 9     | 93    | 802   | 9841  |
| v0.5 3 strat ll  | 13     | 9     | 76    | 856   | 10645 |
| v0.5 3 strat q   | 4      | 11    | 76    | 825   | 12592 |
v1.0

Patobulinau v0.5 versija, taip pat sukuriau meniu kurios pagalba iskvieciu norima strategija.
Kiekviena strategija automatiskai atlieka apskaiciavimus su list, linkedlist ir queue.
1.strategija tai rusiavimas i 2 konteinerius.

2 strategija tai perkeli vienos kategorijos duomenis (vargsiukai) i atskira konteineri, o is pirminio jie istrinami, kas lieka, tas perkeliama i galvociu konteineri.

3 strategija tai manoji. Mano student structura turi kategorijos atributa, kuris yra uzpildomas ivedant duomenis. To atributo pagalba as galiu nuspresti i kuri konteineri as noriu spausdinti duomenis, tokiu budu, man nereikia kurti papildomu konteineriu ir i juos dar ka nors rusiuoti. 


Siulau atliekant v0.5 uzduoti paleisti programa isnaujo, nes kitaip pastebejau labai ilgai failus nuskaitoma.

be to, pataisiau galimus bugus kitose versijose.

----
Naudojimosi instrukcija.

Mano programa yra padaryta meniu pagalba.

1 meniu funkcija leidžia rankiniu budu sukurti student strukturos elementa ir ji uzpildyt ir sukurta studenta ikelti i sarasa.
Kuriant studenta yra prasoma ivesti varda ir pavarde.
Del pažymiu išvedama apklausa, ar noriu įvesti pažymius pats ar noriu, kad man juos sugeneruotu kompiuteris.
Toliau bet kokiu atveju klausiama ar is anksto žinomas namų darbų skaicius, jeigu taip, tai prasoma ivesti skaiciu (jeigu 0, prasoma pakartoti), jeigu ne, tai kas karta klausiama ar norima ivesti nauja namu darbu pažymį.
Jeigu buvo pasirinktas atsitiktiniu pažymiu rėžimas, tai pačius pažymius sugeneruoja kompiuteris, jeigu ne, reikia ivesti patiems.

2 meniu funkcija nuskaito studentai.txt faila, ir is karto atspausdina apdorota studentai sarasa, tam reikia pačiam sukurti studentai.txt failą ir jį patalpinti reikiamoje direktorijoje (direktoriją matome paleidus programą).

3 meniu funkcija tiesiog leidžia atspausdinti i konsole studentu sarasa.

4 meniu funkcija sugeneruoja 5 studentu failus su skirtingais irasu kiekiais: 1000,10000,100000,1000000,10000000 ir juos atspausdina i vargsiukai.txt ir galvociai.txt. Ši meniu funkcija turi kodo laiko matuokli.

5 meniu funkcija naudoja jau sugeneruotus 5 failus 4 meniu funkcijos pagalba, kurios dėka yra išbandomas 3 strategiju greitis.
Norint atlikti 5 meniu funkciją yra siūloma paleisti programą iš naujo.

Paleidžiant programą yra matoma failų direktorija.
