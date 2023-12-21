using System.Drawing;


namespace Lab3_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePaths = GetFilePaths("C:\\Users\\Lenovo T470p\\source\\repos\\Lab3c2\\prc2t2\\Images");

            foreach (var file in filePaths)
            {
                CreateMirrored(file);
            }
        }

        static IEnumerable<string> GetFilePaths(string directoryPath)
        {
            return Directory.GetFiles(directoryPath);
        }

        static void CreateMirrored(string filePath)
        {
            try
            {
                if (!filePath.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                    && !filePath.EndsWith(".gif", StringComparison.OrdinalIgnoreCase)
                    && !filePath.EndsWith(".png", StringComparison.OrdinalIgnoreCase)
                    && !filePath.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase))
                {
                    throw new WrongTypeException();
                }

                Bitmap originalBitmap = new Bitmap(filePath);

                originalBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

                string mirroredFilePath = @$"{filePath}-mirrored.gif";
                originalBitmap.Save(mirroredFilePath);

                originalBitmap.Dispose();
            }
            catch (Exception)
            {
                throw new UnableToOpenFileException();
            }
        }
    }
}