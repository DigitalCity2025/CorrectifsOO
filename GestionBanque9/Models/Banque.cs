using GestionBanque1.Models;
using GestionBanque4.Models;


namespace GestionBanque2.Models
{
    public class Banque
    {
        private List<Compte> comptes = new ();
        public string Nom { get; set; }

        private string SavePath
        {
            get
            {
                return Path.Combine(
                    DirectoryPath,
                    Nom + ".csv"
                );
            }
        }


        private string DirectoryPath
        {
            get
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "Gestion Banque");
            }
        }

        public Compte? this[string numero]
        {
            get 
            {
                Compte? c = comptes.Find(c => c.Numero == numero);
                return c;
            }
        } 

        public void Ajouter(Compte courant)
        {
            // permet de vérifier si il existe déjà un compte dans la banque avec ce numero 
            if(comptes.Any(c => c.Numero == courant.Numero))
            {
                throw new InvalidOperationException("Le numero existe déjà");
            } 
            comptes.Add(courant);
            courant.PassageEnNegatifEvent += AfficherNegatif;
        }

        public void Supprimer(string numero)
        {
            // Chercher un compte dans la liste de comptes
            // qui repond à une condition
            Compte? c = comptes.Find(c => c.Numero == numero);
            if(c == null)
            {
                // plus déclencher une erreur
                return;
            }
            comptes.Remove(c);
            c.PassageEnNegatifEvent -= AfficherNegatif;
        } 

        public double AvoirDesComptes(string nom, string prenom)
        {
            List<Compte> comptesDuTitulaire = comptes.Where(c => c.Titulaire.Nom == nom && c.Titulaire.Prenom == prenom && c is Courant).ToList();

            Courant total = new("", null);
            foreach (Courant c in comptesDuTitulaire)
            {
                total += c;
            }
            return total.Solde;
        }

        public void Sauver()
        {
            //List<string> data = new();

            //foreach (Courant item in comptes)
            //{
            //    data.Add($"{item.Numero},{item.Solde},{item.LigneDeCredit},{item.Titulaire.Nom},{item.Titulaire.Prenom}{item.Titulaire.DateNaissance}");
            //}

            if(!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            List<string> data = comptes.Select(item => $"{item.GetType().Name},{item.Numero},{item.Solde},{(item is Courant ? ((Courant)item).LigneDeCredit : ((Epargne)item).DateDernierRetrait)},{item.Titulaire.Nom},{item.Titulaire.Prenom},{item.Titulaire.DateNaissance}").ToList();

            File.WriteAllLines(SavePath, data);
        }


        public void Charger()
        {
            if(!File.Exists(SavePath))
            {
                return;
            }
            string[] data = File.ReadAllLines(SavePath);
            foreach(string item in data)
            {
                string[] line = item.Split(",");
                Compte c;
                Personne t = new Personne()
                {
                    Nom = line[4],
                    Prenom = line[5],
                    DateNaissance = DateTime.Parse(line[6]),
                };
                if (line[0] == "Courant")
                {
                    c = new Courant(line[1], t, double.Parse(line[3]), double.Parse(line[2]));
                }
                else
                {
                    c = new Epargne(line[1], t, double.Parse(line[2]))
                    {
                        DateDernierRetrait = line[3] == "" ? null : DateTime.Parse(line[3]),
                    };
                }
                Ajouter(c);
            }
        }

        private void AfficherNegatif(Compte c)
        {
            Console.WriteLine($"Le compte {c.Numero} est passé en négatif");
            Console.ReadKey();
        }
    }
}
