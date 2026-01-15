using System.ComponentModel.Design;

namespace lesson
{
    public class Program
    {
        /// <summary>
        /// The main entrypoint of your application.
        /// </summary>
        /// <param name="args">The arguments passed to the program</param>
        public static void Main(string[] args)
        {
            //benchmarking: processo sistematico e continuo di confronto tra le performance, i processi o i prodotti
            //              di un'organizzazione con quelli di altre aziende considerate leader nel settore o in aree
            //              specifiche. L'obiettivo principale è identificare le best practices (pratiche eccellenti)
            //              per migliorare le proprie prestazioni in termini di qualità, tempo, costo e efficienza

            //definire:
            // - l'algoritmo (o algoritmi) di cui fare il benchmark, in questo caso algoritmi di ricerca
            // - i test cases (casi numerosi ma univoci, uguali per tutti), su cui far girare gli algoritmi. I test cases spesso hanno un nome: 'ordinato', 'ordinato al contrario', 'casuale' etc..
            // - calcolare i tempi (media, varianza)

            int choice = Menu();

            switch (choice)
            {
                case 1:
                    BenchmarkSearch();
                    break;
                case 2:
                    BenchmarkSort();
                    break;
                default:
                    Console.WriteLine("Scelta non valida");
                    break;
            }



        }
private static void BenchmarkSort()
        {
            throw new NotImplementedException();
        }

        private static void BenchmarkSearch()
        {
            Console.WriteLine("Benchmark degli algoritmi di ricerca...");

            // abbiamo:
            // - ricerca sequenziale
            // - ricerca sequenziale ottimizzata
            // - ricerca binaria
            //
            // abbiamo (casi):
            // - vettori di dimensioni diverse
            // - vettori ordinati e non 
            // - vettori ordinati al contrario
            // - vettori parzialmente ordinati
            //
            // abbiamo (unità di misura target) = ms

            int[][] cases = GenerateBenchmarkCases(1000);
            int[][] sequentialSearchTimes = BenchmarkSequentialSearch(cases);
            int[][] optimizedSequentialSearchTimes = BenchmarkOptimizedSequentialSearch(cases);
            int[][] binarySearchTimes = BenchmarkBinarySearch(cases);
            PrintTimes("Ricerca sequenziale", sequentialSearchTimes);

        }
        
        /// <summary>
        /// stampa i tempi di un benchmark
        /// </summary>
        /// <param name="name">nome visualizzato del benchmark</param>
        /// <param name="times">i tempi da stapare</param>
        /// <exception cref="NotImplementedException"></exception>
        private static void PrintTimes(string name, int[] times)
        {
            Console.WriteLine($"name");

            //media
            double average = times[0];
            for (int i = 0; i < times.Length; i++) 
            {
                average += times[i];
            }
            average /= times.Length;

            // scarto quadratico medio
            double discartAvg = 0;
            for (int i = 0; i < times.Length; i++)
            {
                double discart = times[i] - average;
                discartAvg += discart * discart;
            }
            discartAvg


            Console.WriteLine($"Media (ms): {average}, Scarto quadrato medio (ms): {discart}")
        }

        private static int[][] BenchmarkBinarySearch(int[][] cases)
        {
            throw new NotImplementedException();
        }

        private static int[][] BenchmarkOptimizedSequentialSearch(int[][] cases)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// effettua un benchmark della ricerca sequenziale
        /// </summary>
        /// <param name="cases">i bench cases da usare</param>
        /// <returns>i tempi dei benchmark</returns>
        private static int[][] BenchmarkSequentialSearch(int[][] cases)
        {
            int[] times = new int[cases.Length];

            for (int i = 0; i < cases.Length; i++)
            {
                times[i] = BenchmarkSequentialSearchCase(cases[i]);
            }


        }

        /// <summary>
        /// restituisce il tempo di benchmark per un singolo caso di ricerca sequenziale
        /// </summary>
        /// <param name="benchCase">il bench case</param>
        /// <returns>il tempo del benchmark</returns>
        private static int BenchmarkSequentialSearchCase(int[] benchCase)
        {
            DateTime start = DateTime.Now;

            // cerchiamo sempre l'elemento a metà, per comodità, ma si può cambiare
            int index = SequentialSearch(benchCase, benchCase[benchCase.Length / 2]);
            if (index != benchCase.Length / 2)
            {
                Console.WriteLine("ERRORE IMPORTANTE");
            }

            DateTime end = DateTime.Now;

            return (int)((start - end).TotalMilliseconds);
        }

        private static int SequentialSearch(int[] benchCase, int v)
        {
            for (int i = 0; i < benchCase.Length; i++)
            {
                if (benchCase[i] == v)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// genera i vettori da usare in tutti i benchmark:
        /// - vettori di dimensioni diverse
        /// - vettori ordinati e non 
        /// - vettori ordinati al contrario
        /// - vettori parzialmente ordinati
        /// </summary>
        /// <returns>I vettori genera</returns>
        private static int[][] GenerateBenchmarkCases(int n)
        {
            int[][] cases = new int[100][];

            for (int i = 0; i < n; i++)
            {
                cases[i] = GenerateBenchmarkCase(i * 10 + 1);
            }

            return cases;
        }

        private static int[] GenerateBenchmarkCase(int n)
        {
            Random rnd = new Random();
            int[] benchCase = new int[n];

            for(int i = 0; i < n; i++)
            {
                benchCase[i] = rnd.Next();
            }

            return benchCase;
        }

        private static int Menu()
        {
            int choice;

            do
            {
                Console.WriteLine("1 --> Benchmark ricercato");
                Console.WriteLine("2 --> Benchmark ordinato");

                choice = Convert.ToInt32(Console.ReadLine());


            } while (choice != 1 || choice != 2);

            return choice;
        }
    }
}
