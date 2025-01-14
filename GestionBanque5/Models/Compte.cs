using GestionBanque1.Models;

namespace GestionBanque4.Models
{
    public abstract class Compte
    {
        #region Attributs 

        private string _Numero;
        private double _Solde;
        private Personne _Titulaire;

        #endregion

        #region Prop's

        public string Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

        public double Solde
        {
            get { return _Solde; }
            private set { _Solde = value; }
        }

        public Personne Titulaire
        {
            get { return _Titulaire; }
            set { _Titulaire = value; }
        }

        #endregion

        #region Methodes
        // Retrait
        public virtual void Retrait(double montant)
        {
            if (montant <= 0)
            {
                return; // à remplacer plus tard par un exception
            }
            Solde -= montant;
        }

        // Depôt
        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                return; // à remplacer plus tard par un exception
            }
            Solde += montant;
        }

        public void AppliquerInterets()
        {
            Solde += CalculInterets();
        }

        protected abstract double CalculInterets();
        #endregion
    }
}
