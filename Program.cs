using System.ComponentModel;

namespace stringman;    
class Program
{
    static void Main(string[] args)
    {
        File.Delete("newCSV.csv"); //every time you run the code it deletes a pre-existing file if it exists, to make sure it doesnt write the same text twice, makes sure every document is new
        using (var reader = new StreamReader("flyvning1.csv")) // inserts the file into visual studio so the program can read the cvs file's data
        {
            int counter = 0;
            while (!reader.EndOfStream) // while there still is data to read
            {
                //Console.WriteLine(reader.ReadLine())
                var line = reader.ReadLine(); // Read the current line from the text reader and store it in the 'line' variable.
                List<string> values = new List<string>();  // Create a new List<string> called 'values' to store the elements of the current line.
                values = line.Split(';').ToList(); // Split the 'line' string into a list of values using semicolon ';' as the delimiter, and store them in the 'values' list.
                int i = values.Count;  // Get the number of elements in the 'values' list and store it in the 'i' variable.
                if (counter == 0)
                {
                    values.Add("GPSKoord");
                    counter++; // increment counter variable by 1 
                }
                else
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (j == 2 || j == 3) //Check if the current value of 'j' is equal to 2 or 3.
                        {

                            string newJ = values[j].Replace(".", string.Empty); // Extract the value at index j from the 'values' array and remove any periods (".") from it.
                            if (j == 2) // If 'j' is equal to 2, insert a period after the first character of 'newJ'.
                            {
                                newJ = newJ.Insert(1, ".");
                                values[j] = newJ; 
                            }
                            if (j == 3)  // If 'j' is equal to 3, insert a period after the second character of 'newJ'.
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
                } // After the loop, 'newLine' will contain all the elements from the 'values' collection
                Console.WriteLine(newLine + "\n"); //Prints the newLine value, newLine value being the corrected drone data 
                using(StreamWriter writer = File.AppendText("newCSV.csv"))
                {
                    writer.WriteLine(newLine);
                }
            } 
        }
        Console.ReadLine();
    }
}
