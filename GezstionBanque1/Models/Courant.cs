using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace GezstionBanque1.Models
{
    public class Courant
    {
        #region Attributs 

        private string _Numero;
        private double _Solde;
        private double _LigneDeCredit;
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

        public Personne Titulaire
        {
            get { return _Titulaire; }
            set { _Titulaire = value; }
        }

        #endregion

        #region Méthodes
        // Retrait
        public void Retrait(double montant)
        {
            if (montant <= 0)
            {
                return; // à remplacer plus tard par un exception
            }

            if ( Solde - montant < -_LigneDeCredit)
            {
                return; // à remplacer plus tard par un exception
            }

            _Solde -= montant;
        }
            
        // Depôt
        public void Depot(double montant)
        {
            if (montant <= 0)
            {
                return; // à remplacer plus tard par un exception
            }

            _Solde += montant;
        }

        #endregion

    }
}
