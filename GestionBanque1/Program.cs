using GestionBanque1.Models;

Personne personne1 = new Personne()
{
    Non = "Doe",
    Prenom = "John",
    DateNaissance = new DateTime(2000, 1, 1)
};

Courant courant1 = new Courant()
{
    Numero = "0001",
    Titulaire = personne1,
    LigneDeCredit = 50
};

courant1.Depot(2000);

courant1.Retrait(500);

Console.WriteLine($"Le solde de {courant1.Titulaire.Non} est de : {courant1.Solde} EUR.");