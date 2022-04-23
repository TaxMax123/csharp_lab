namespace WebApplication1;

public enum Currency
{
    Eur,
    Hrk,
    Aud,
    Cad,
    Dkk,
    Huf,
    Jpy,
    Nok,
    Sek,
    Chf,
    Gbp,
    Usd,
    Bam,
    Pln
}

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
    public Osoba Platitelj { get; set; }
    public Osoba Primatelj { get; set; }
    public bool Hitno { get; set; }
    public Currency ValutaPlacanja { get; set; }
    public double Iznos { get; set; }
    public DateTime DatumIzvrsenja { get; set; }
    public string PrimateljOsoba { get; set; }
}