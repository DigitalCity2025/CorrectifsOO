using GestionBanque4.Models;

namespace GestionBanque1.Models
{
    public class Courant : Compte
    {
        #region Attributs 

        private double _LigneDeCredit;

        #endregion

        #region Prop's

        public double LigneDeCredit
        {
            get { return _LigneDeCredit; }
            set
            {
                if (value < 0)
                {
                    return; // à remplacer plus tard par un exception
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
                return; // à remplacer plus tard par un exception
            }
            base.Retrait(montant);
        }

        protected override double CalculInterets()
        {
            return Solde < 0 ? 0.0975 * Solde : 0.03 * Solde;
        }

        #endregion

        #region Surcharges Opérateurs
        public static Courant operator+(Courant c1, Courant c2)
        {
            Courant c = new Courant();
            c.Depot(Math.Max(c1.Solde, 0) + Math.Max(c2.Solde, 0));
            return c;
        }
        #endregion

    }
}
