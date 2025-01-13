using GestionBanque2.Models;
using GestionBanque1.Models;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

Banque banque = new()
{
    Nom = "Banque de Digital City"
};

ConsoleKey key = default;

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Ajouter un compte");
    Console.WriteLine("2. Afficher un compte");
    Console.WriteLine("3. Afficher les avoirs");
    key = Console.ReadKey(true).Key;
    switch (key)
    {
        case ConsoleKey.NumPad1:
            AjouterCompte();
            break;
        case ConsoleKey.NumPad2:
            AfficherCompte();
            break;
        case ConsoleKey.NumPad3:
            AfficherLesAvoirs();
            break;
    }
}

void AfficherLesAvoirs()
{
    string nom = Question("nom ?");
    string prenom = Question("prenom ?");
    Console.WriteLine($"Avoirs du compte de {nom} {prenom}: {banque.AvoirDesComptes(nom, prenom)} €");
    Console.ReadKey(true);
}

void AfficherCompte()
{
    string numero = Question("Entrer le numéro");
    Courant? c = banque[numero];
    if (c == null)
    {
        Console.WriteLine("Aucun compte existant avec ce numero");
        return;
    }

    AfficherInfo(c);

    Console.WriteLine("1. Ajouter de l'argent");
    Console.WriteLine("2. Retirer de l'argent");

    key = Console.ReadKey(true).Key;
    switch (key)
    {
        case ConsoleKey.NumPad1:
            AjouterArgent(c);
            break;
        case ConsoleKey.NumPad2:
            RetirerArgent(c);
            break;
    }
}

void AfficherInfo(Courant c)
{
    Console.WriteLine("------------------------");
    Console.WriteLine($"Numero {c.Numero}");
    Console.WriteLine($"Solde {c.Solde}€");
    Console.WriteLine($"Ligne de crédit {c.LigneDeCredit}€");
    Console.WriteLine($"Nom {c.Titulaire.Nom}");
    Console.WriteLine($"Prenom {c.Titulaire.Prenom}");
    Console.WriteLine($"Date de naissance {c.Titulaire.DateNaissance:dd/MM/yyyy}");
    Console.WriteLine("------------------------");
}

void AjouterArgent(Courant c)
{
    double montant = double.Parse(Question("Quel montant ?"));
    c.Depot(montant);
}

void RetirerArgent(Courant c)
{
    double montant = double.Parse(Question("Quel montant ?"));
    c.Retrait(montant);
}

void AjouterCompte()
{
    Personne p = new()
    {
        Nom = Question("Entrer un nom"),
        Prenom = Question("Entrer un prenom"),
        DateNaissance = DateTime.Parse(Question("Entrer une date de naissance")),
    };

    Courant c = new()
    {
        Numero = Question("Entrer le numero"),
        Titulaire = p,
        LigneDeCredit = double.Parse(Question("Entrer la ligne de crédit"))
    };
    banque.Ajouter(c);
}

string Question(string message)
{
    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write(message + ": ");
    Console.ResetColor();
    return Console.ReadLine() ?? string.Empty;
}