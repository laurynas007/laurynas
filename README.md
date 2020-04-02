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
4 menu sakos greitis 50.23s
