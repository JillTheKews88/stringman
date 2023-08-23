namespace stringman;    
class Program
{
    static void Main(string[] args)
    {
        using (var reader = new StreamReader("flyvning1.csv"))
        {
            while (!reader.EndOfStream)
            {
                //Console.WriteLine(reader.ReadLine());
                var line = reader.ReadLine();
                string[] values = line.Split(';');
                int i = values.Length;
                for (int j = 0; j < i; j++)
                {
                    if (j == 2 || j == 3)
                    {
                    
                        string newJ = values[j].Replace(".", string.Empty);
                        if (j == 2)
                        {
                            newJ = newJ.Insert(1, ".");
                        }
                        if (j == 3)
                        {
                            newJ = newJ.Insert(2, ".");
                        }
                        Console.WriteLine(newJ);
                    }
                    //Console.WriteLine(values[j]);
                }
            }
        }
        Console.ReadLine();
    }
}
