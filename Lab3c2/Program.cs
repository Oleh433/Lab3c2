namespace Lab3c2
{
    internal class Program
    {
        private const string path = "C:\\Users\\Lenovo T470p\\source\\repos\\Lab3c2\\prc2t2\\Images";
        private static List<string> no_file_List = new List<string>();
        private static List<string> bad_data_List = new List<string>();
        private static List<string> overflow_List = new List<string>();

        static void Main(string[] args)
        {
            List<string> filePaths = GetFileNames();

            HandleInput(filePaths);
            CreateUltimateFiles();
        }

        static List<string> GetFileNames()
        {
            List<string> filePaths = new List<string>();

            for (int i = 10; i < 30; i++)
            {
                filePaths.Add(path + $"\\{i}.txt");
            }

            return filePaths;
        }

        static void HandleInput(IEnumerable<string> fileNames)
        {
            foreach (var fileName in fileNames)
            {
                try
                {
                    List<object> values = GetValues(fileName);
                }
                catch (ArgumentNullException)
                {
                    bad_data_List.Add(fileName);
                }
                catch (ArgumentOutOfRangeException)
                {
                    bad_data_List.Add(fileName);
                }
                catch (FormatException)
                {
                    bad_data_List.Add(fileName);
                }
                catch (OverflowException)
                {
                    overflow_List.Add(fileName);
                }
                catch (FileNotFoundException)
                {
                    no_file_List.Add(fileName);
                }
            }
        }

        static List<object> GetValues(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                List<object> result = new List<object> { "g", "g" };

                int i = 0;
                while (!sr.EndOfStream)
                {
                    result[i] = int.Parse(sr.ReadLine()!);
                    i++;
                }

                Console.WriteLine((Convert.ToInt32(result[0]) + Convert.ToInt32(result[1])) / 2);

                return result;
            }
        }

        static void CreateUltimateFiles()
        {
            File.WriteAllLines("no_file.txt", no_file_List);
            File.WriteAllLines("bad_data.txt", bad_data_List);
            File.WriteAllLines("overflow.txt", overflow_List);
        }
    }
}