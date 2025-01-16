using GestionBanque1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanque5.Interfaces
{
    interface IBanker : ICustomer
    {
        void AppliquerInterets();
        Personne Titulaire { get; }
        string Numero { get; }
    }
}
