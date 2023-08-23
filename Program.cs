using System.ComponentModel;

namespace stringman;    
class Program
{
    static void Main(string[] args)
    {
        using (var reader = new StreamReader("flyvning1.csv"))
        {
            int counter = 0;
            while (!reader.EndOfStream)
            {
                //Console.WriteLine(reader.ReadLine())
                var line = reader.ReadLine();
                List<string> values = new List<string>();
                values = line.Split(';').ToList();
                int i = values.Count;
                if (counter == 0)
                {
                    values.Add("GPSKoord");
                    counter++;
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (j == 2 || j == 3)
                        {

                            string newJ = values[j].Replace(".", string.Empty);
                            if (j == 2)
                            {
                                newJ = newJ.Insert(1, ".");
                                values[j] = newJ;
                            }
                            if (j == 3)
                            {
                                newJ = newJ.Insert(2, ".");
                                values[j] = newJ;
                            }
                        }
                        Console.WriteLine(values[j]);
                    }
                    Console.WriteLine("Counter: " + counter);
                    values.Add(values[2] + "," + values[3]);
                    counter++;

                }
            }
        }
        Console.ReadLine();
    }
}
