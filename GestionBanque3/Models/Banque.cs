﻿using GestionBanque1.Models;


namespace GestionBanque2.Models
{
    public class Banque
    {
        private List<Courant> comptes = new ();
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

        public Courant? this[string numero]
        {
            get 
            {
                Courant? c = comptes.Find(c => c.Numero == numero);
                return c;
            }
        } 

        public void Ajouter(Courant courant)
        {
            // permet de vérifier si il existe déjà un compte dans la banque avec ce numero 
            if(comptes.Any(c => c.Numero == courant.Numero))
            {
                // plus déclencher une erreur
                return;
            } 
            comptes.Add(courant);
        }

        public void Supprimer(string numero)
        {
            // Chercher un compte dans la liste de comptes
            // qui repond à une condition
            Courant? c = comptes.Find(c => c.Numero == numero);
            if(c == null)
            {
                // plus déclencher une erreur
                return;
            }
            comptes.Remove(c);
        } 

        public double AvoirDesComptes(string nom, string prenom)
        {
            List<Courant> comptesDuTitulaire = comptes.Where(c => c.Titulaire.Nom == nom && c.Titulaire.Prenom == prenom).ToList();

            Courant total = new();
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

            List<string> data = comptes.Select(item => $"{item.Numero},{item.Solde},{item.LigneDeCredit},{item.Titulaire.Nom},{item.Titulaire.Prenom},{item.Titulaire.DateNaissance}").ToList();

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
                Courant c = new Courant()
                {
                    Numero = line[0],
                    LigneDeCredit = double.Parse(line[2]),
                    Titulaire = new Personne()
                    {
                        Nom = line[3],
                        Prenom = line[4],
                        DateNaissance = DateTime.Parse(line[5]),
                    }
                };
                c.Depot(double.Parse(line[1]));
                Ajouter(c);
            }
        }
    }
}
