using System.Dynamic;
using System.Net.NetworkInformation;
using System.Net.Security;
using System.Runtime.CompilerServices;

public class Traverse
{
    static String fileName = "cities.csv";
    static String [,] data = ReadFile.readFile(fileName);
    static List<String> cities = ReadFile.cities(data);
    static int [,] cityCost = ReadFile.CityData(data);

    public static String getCity(int index)
    {
        String city = "";
        if (index < cities.Count)
        {
            city = cities[index];
        }
        else{
            Console.WriteLine("Error!");
        }
        
        return city;
    }

    public static int getCityIndex (String citiName)
    {
        int index = -1;
        index = cities.IndexOf(citiName);
        return index;
    }


    public static List<List<int>> getRoutes (int start, int end, List<int> path)
    {
        path.Add(start);

        if (start == end)
        {
            return new List<List<int>> { new List<int>(path) };
        }

        List<List<int>> routes = new List<List<int>>();

        for (int i=0; i<cities.Count; i++)
        {
            if (cityCost[start,i] != 0 && !path.Contains(i))
            {
                List<List<int>> newRoutes = getRoutes(i, end, new List<int>(path));
                foreach (List<int> x in newRoutes)
                {   
                    routes.Add(x);
                }
                
            }
        }
        return routes;
    }


     public static void printList<T>(List<T> list)
    {
        foreach(var x in list)
        {
            Console.Write(x + " ");
        }
    }

    public static void printList2<T> (List<List<T>> lists)
    {
        foreach (List<T> list in lists)
        {
            foreach(var x in list)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine();
        }
    }

}