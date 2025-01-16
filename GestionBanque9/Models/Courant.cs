using GestionBanque4.Models;
using GestionBanque7.Exceptions;

namespace GestionBanque1.Models
{
    public class Courant : Compte
    {
        #region Attributs 

        private double _LigneDeCredit;

        #endregion

        #region Ctors
        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit) : base(numero, titulaire, solde)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public Courant(string numero, Personne titulaire, double ligneDeCredit) : base(numero, titulaire)
        {
            LigneDeCredit = ligneDeCredit;
        }

        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }

        #endregion

        #region Prop's

        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException();
                }

                _LigneDeCredit = value;
            }

        }

        #endregion

        
        #region Méthodes
        // Retrait
        public override void Retrait(double montant)
        {
            if ( Solde - montant < -_LigneDeCredit)
            {
                throw new SoldeInsuffisantException(Solde + LigneDeCredit, montant);
            }
            base.Retrait(montant);
            if(Solde < 0)
            {
                RaisePassageEnNegatif();
            }
        }

        protected override double CalculInterets()
        {
            return Solde < 0 ? 0.0975 * Solde : 0.03 * Solde;
        }

        #endregion

        #region Surcharges Opérateurs
        public static Courant operator+(Courant c1, Courant c2)
        {
            double solde = Math.Max(c1.Solde, 0) + Math.Max(c2.Solde, 0);
            Courant c = new Courant("", null, solde, 0);
            return c;
        }
        #endregion

    }
}
