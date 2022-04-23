using System;

namespace Lab3_4;

public class Osoba
{
    public string Ime { get; set; } = null!;
    public string Prezime { get; set; } = null!;
    public string Adresa { get; set; } = null!;
    public string BrojRacunaIliIban { get; set; } = null!;
    public string PozivNaBroj { get; set; } = null!;
    public string Model { get; set; } = null!;
}

public class UniverzalniNalog
{
    public Osoba Platitelj { get; set; } = new Osoba();
    public Osoba Primatelj { get; set; } = new Osoba();
    public bool? Hitno { get; set; }
    public int ValutaPlacanja { get; set; }
    public double Iznos { get; set; }
    public string PrimateljOsoba { get; set; } = "Fizicka";
    public DateTime DatumIzvrsenja { get; set; }

}