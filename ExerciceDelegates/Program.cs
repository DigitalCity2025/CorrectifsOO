using ExerciceDelegates;

Voiture voiture = new("2BPX894");
Carwash carwash = new();

carwash.etapes += v => Console.WriteLine("cette methode à été ajoutée en dehors de la classe Carwash");

// impossible car event
// carwash.etapes.Invoke(voiture);

// carwash.Traiter(voiture);