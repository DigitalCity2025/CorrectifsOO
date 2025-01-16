namespace GestionBanque7.Exceptions
{
    public class SoldeInsuffisantException : Exception
    {
        public SoldeInsuffisantException(double soldeDisponible, double montant)
            : base($"Le solde est insuffisant. Solde disponible: {soldeDisponible} ")
        {
            SoldeDisponible = soldeDisponible;
            Montant = montant;
        }

        public double SoldeDisponible { get; set; }
        public double Montant { get; set; }
    }
}
