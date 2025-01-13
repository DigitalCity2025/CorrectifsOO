using GestionBanque1.Models;


namespace GestionBanque2.Models
{
    public class Banque
    {
        private List<Courant> courants = new ();
        public string Nom { get; set; }

        public Courant? this[string numero]
        {
            get 
            {
                Courant? c = courants.Find(c => c.Numero == numero);
                return c;
            }
        } 

        public void Ajouter(Courant courant)
        {
            // permet de vérifier si il existe déjà un compte dans la banque avec ce numero 
            if(courants.Any(c => c.Numero == courant.Numero))
            {
                // plus déclencher une erreur
                return;
            } 
            courants.Add(courant);
        }

        public void Supprimer(string numero)
        {
            // Chercher un compte dans la liste de comptes
            // qui repond à une condition
            Courant? c = courants.Find(c => c.Numero == numero);
            if(c == null)
            {
                // plus déclencher une erreur
                return;
            }
            courants.Remove(c);
        } 

        public double AvoirDesComptes(string nom, string prenom)
        {
            List<Courant> comptesDuTitulaire = courants.Where(c => c.Titulaire.Nom == nom && c.Titulaire.Prenom == prenom).ToList();

            Courant total = new();
            foreach (Courant c in comptesDuTitulaire)
            {
                total += c;
            }
            return total.Solde;
        }
    }
}
