using cat.itb.NF3EA4_VillodresAdrian.cruds;

class Program
{

    static void Main(string[] args)
    {
        {
            CountryCRUD country = new CountryCRUD();
            ProductCRUD product = new ProductCRUD();
            RestaurantCRUD restaurant = new RestaurantCRUD();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("EXERCICI 1: Importació de coleccions");
                Console.WriteLine("     1. Importar Coleccions");
                Console.WriteLine("");
                Console.WriteLine("EXERCICI 2: Agregacions");
                Console.WriteLine("     2: Crea un mètode que mostri de la col·lecció «countries» el número de països on es parla Anglès.");
                Console.WriteLine("     3: Crea un mètode que mostri de la col·lecció «countries» la regió on hi ha més països.");
                Console.WriteLine("     4: Crea un mètode que mostri de la col·lecció «countries» quants països conté cada subregió «subregion».");
                Console.WriteLine("     5: Crea un mètode que mostri de la col·lecció «countries» el país on es parlen més idiomes. Ordena els països per\r\nnúmero d’idiomes que es parla de més a menys i mostra només el primer.");
                Console.WriteLine("     6: Crea un mètode que mostri de la col·lecció «restaurants» el número de vegades que apareix cada puntuació \"score\"\r\nentre tots els restaurants. Mostra només la puntuació, el \"score\" i el número de vegades que apareix la puntuació.");
                Console.WriteLine("     7: Crea un mètode que mostri de la col·lecció «restaurants» els codis postals de cada barri \"borough\".");
                Console.WriteLine("     8: Crea un mètode que mostri de la col·lecció «restaurants» el número de restaurants per tipus de cuina i ordena'ls de\r\nforma descendent de la cuina amb menys restaurants a la cuina amb més restaurants.");
                Console.WriteLine("     9: Crea un mètode que mostri de la col·lecció «restaurants» el número de valoracions \"grades\" de cada restaurant.\r\nMostra només el nom del restaurant i el número de valoracions.");
                Console.WriteLine("     10: Crea un mètode que mostri de la col·lecció «restaurants» els noms de tipus de cuina per cada barri \"borough\".");
                Console.WriteLine("     11: Crea un mètode que mostri de la col·lecció «restaurants» la valoració \"score\" més alta per cada restaurant. Mostra\r\nel nom del restaurant i el \"score\" més alt obtingut.");
                Console.WriteLine("     12: Crea un mètode que mostri de la col·lecció «products» el número de \"categories\" que té cada producte.");
                Console.WriteLine("     13: Crea un mètode que mostri de la col·lecció «products» totes les categories de tots els productes sense que es\r\nrepeteixi el nom de la categoria.");
                Console.WriteLine("");
                Console.WriteLine("0. Exit");
                Console.Write("Option: ");


                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("");

                        Console.WriteLine("Coleccions importades correctament");
                        Console.WriteLine("");
                        break;
                    case "2":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "3":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "4":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "5":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "6":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "7":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "8":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "9":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "10":
                        Console.WriteLine("");

                        Console.WriteLine("");
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("");
                        Console.WriteLine("Opció no válida, intenta de nou.");
                        Console.WriteLine("");
                        break;
                }
            }

        }
    }
