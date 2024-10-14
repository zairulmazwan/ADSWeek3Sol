using System.Globalization;
using System.Runtime.CompilerServices;

public class ReadFile
{
    public static String [,] readFile (String FileName)
    {
        String [,] res = null;
        StreamReader sr = null;

        if(File.Exists(FileName))
        {
            sr = new StreamReader(FileName);
            String line = null;
            int row=0, col=0;

            while(!sr.EndOfStream)
            {
                row++;
                line = sr.ReadLine();
                var val = line.Split(",");
                col = val.Length;
            }
            res = new String[row,col];

            sr = new StreamReader(FileName);
            int rowIndex = 0;

            while (!sr.EndOfStream)
            {
                var ln = sr.ReadLine();
                var val = ln.Split(",");
                for (int colIndex=0; colIndex<val.Length; colIndex++)
                {
                    res[rowIndex,colIndex] = val[colIndex];
                }
                rowIndex++;
            }
        }
        return res;
    }

    public static List<String> cities (String [,] data)
    {
        List<String> cities = new List<String>();

        for(int i=1; i<data.GetLength(1); i++)
        {
            cities.Add(data[0,i]);
        }
        return cities;
    }

    public static int [,] CityData (String [,] data)
    {
        int row = data.GetLength(0), col = data.GetLength(1);
        int [,] res = new int [row-1,col-1];

        for (int i=1; i<data.GetLength(0); i++)
        {
            for (int j=1; j<data.GetLength(1); j++)
            {
                res[i-1,j-1] = Int32.Parse(data[i,j]);
                // Console.Write(data[i,j]+"@");
            }
            // Console.WriteLine();
        }
        return res;
    }


    public static void printArray<T>(T [,] array)
    {
        for (int i = 0; i<array.GetLength(0); i++)
        {
            for (int j=0; j<array.GetLength(1); j++)
            {
                Console.Write(array[i,j]+" ");
            }
            Console.WriteLine();
        }
    }

    public static void printCities (List<String> cities)
    {
        foreach(var city in cities)
        {
            Console.Write(city+" ");
        }
    }
}