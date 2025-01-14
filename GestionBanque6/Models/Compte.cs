using GestionBanque1.Models;
using GestionBanque5.Interfaces;

namespace GestionBanque4.Models
{
    public abstract class Compte : ICustomer, IBanker
    {
        #region Attributs 

        private string _Numero;
        private double _Solde;
        private Personne _Titulaire;

        #endregion

        #region Ctors

        public Compte(string numero, Personne titulaire)
        {
            Numero = numero;
            Titulaire = titulaire;
        }

        protected Compte(string numero, Personne titulaire, double solde)
        {
            Numero = numero;
            Titulaire = titulaire;
            Solde = solde;
        }

        #endregion

        #region Prop's

        public string Numero
        {
            get { return _Numero; }
            private set { _Numero = value; }
        }
        public Personne Titulaire
        {
            get { return _Titulaire; }
            private set { _Titulaire = value; }
        }

        public double Solde
        {
            get { return _Solde; }
            private set { _Solde = value; }
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
