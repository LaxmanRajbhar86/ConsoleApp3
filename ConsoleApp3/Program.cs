using System.Collections;
namespace ConsoleApp3
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> validMovName= new List<string>{ "M1", "M2", "M3", "M4", "M5", "M6", "M7", "M8", "M9" };
            Console.WriteLine("Hello, World! Enter the movies like M1, M2....M9");
            string inputMovName = Console.ReadLine().Trim();
            if (validMovName.Contains(inputMovName))
            {
                var s = Solution.GetRelatedMovies(inputMovName);
                Console.WriteLine("Related movies of " + inputMovName);
                foreach (string d in s)
                {
                    Console.WriteLine(d);
                }
            }
            else
            {
                Console.WriteLine("Bye You entered Invalid Movie name");
            }                     
            Console.ReadLine();
        }
    }

    public class Solution
    {
        public static Dictionary<string, string[]> movieMap = new Dictionary<string, string[]>
        {
            { "M1", new[] { "V3","V4"} },
            { "M2", new[] { "V1","V2","V4"} },
            { "M3", new[] { "V2","V5"} },
            { "M4", new[] { "V3","V5"} },
            { "M5", new[] { "V6","V7"} },
            { "M6", new[] { "V8"} },
            { "M7", new[] { "V8"} },
            { "M8", new[] { "V8","V1"} },
            { "M9", new[] { "V1"} }
        };

        public static Dictionary<string, string[]> viewerMap = new Dictionary<string, string[]>
        {
            { "V3", new[] { "M1","M4"} },
            { "V4", new[] { "M1","M2"} },            
            { "V1", new[] { "M2","M8","M9"} },
            { "V2", new[] { "M2","M3"} },
            { "V5", new[] { "M3","M4"} },
            { "V6", new[] { "M5"} },
            { "V7", new[] { "M5"} },
            { "V8", new[] { "M6","M7","M8"} }            
        };

        public static HashSet<string> GetRelatedMovies(string movie)
        {
            List<string> mvlist = new List<string>();
            if (movieMap.ContainsKey(movie))
            {
                string[] viewer = movieMap[movie];
                foreach (string vw in viewer)
                {
                    var curMov = movieMap.Where(e => e.Value.Contains(vw)).Select(e => e.Key).ToList();
                    mvlist.AddRange(curMov);
                }
            }
            int countDuplicate = mvlist.Count(e => e == movie);
            for (int i = 0; i < countDuplicate; i++)
            {
                mvlist.Remove(movie);
            }            
            return new HashSet<string>(mvlist);
        }
    }
}
