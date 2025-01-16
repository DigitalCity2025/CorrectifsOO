namespace ExerciceDelegates
{
    delegate void Etape(Voiture v); 
    class Carwash
    {
        public event Etape etapes;

        public Carwash()
        {
            //etapes += Preparer;
            //etapes += Laver;
            //etapes += Secher;
            //etapes += Finaliser;
            etapes += v => Console.WriteLine("Je prépare la voiture " + v.Plaque);
            etapes += v => Console.WriteLine("Je lave la voiture " + v.Plaque);
            etapes += v => Console.WriteLine("Je séche la voiture " + v.Plaque);
            etapes += v => Console.WriteLine("Je finalise la voiture " + v.Plaque);
        }

        //private void Preparer(Voiture v)
        //{
        //    Console.WriteLine("Je prépare la voiture " + v.Plaque);
        //}

        //private void Laver(Voiture v)
        //{
        //    Console.WriteLine("Je lave la voiture " + v.Plaque);
        //}

        //private void Secher(Voiture v)
        //{
        //    Console.WriteLine("Je sèche la voiture " + v.Plaque);
        //}

        //private void Finaliser(Voiture v)
        //{
        //    Console.WriteLine("Je finalise la voiture " + v.Plaque);
        //}

        public void Traiter(Voiture v)
        {
            etapes.Invoke(v);
        }
    }
}
