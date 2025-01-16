using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque5.Interfaces
{
    interface ICustomer
    {
        double Solde { get; }
        void Retrait(double solde);
        void Depot(double solde);
    }
}
