using System.ComponentModel;

namespace stringman;    
class Program
{
    static void Main(string[] args)
    {
        File.Delete("newCSV.csv");
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
                        //Console.WriteLine(values[j]);
                    }
                    values.Add(values[2] + "," + values[3]);
                    counter++;
                    //Console.WriteLine(values[2] + "," + values[3]);
                    //Console.WriteLine("Counter: " + counter);
                }
                string newLine = "";
                for(int m = 0; m < values.Count; m++)
                {
                    newLine += values[m] + ";" ;
                }
                Console.WriteLine(newLine + "\n");
                using(StreamWriter writer = File.AppendText("newCSV.csv"))
                {
                    writer.WriteLine(newLine);
                }
            } 
        }
        Console.ReadLine();
    }
}
