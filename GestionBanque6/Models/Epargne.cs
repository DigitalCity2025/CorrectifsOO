using GestionBanque1.Models;

namespace GestionBanque4.Models
{
    public class Epargne : Compte
    {
        public Epargne(string numero, Personne titulaire) : base(numero, titulaire)
        {
        }

        public Epargne(string numero, Personne titulaire, double solde) : base(numero, titulaire, solde)
        {
        }


        #region Prop's
        public DateTime? DateDernierRetrait { get; set; }
        #endregion

        #region Methodes
        public override void Retrait(double montant)
        {
            if (Solde - montant < 0)
            {
                return; // à remplacer plus tard par un exception
            }
            DateDernierRetrait = DateTime.Now;
            base.Retrait(montant);
        }

        protected override double CalculInterets()
        {
            return 0.045 * Solde;
        }


        #endregion
    }
}
