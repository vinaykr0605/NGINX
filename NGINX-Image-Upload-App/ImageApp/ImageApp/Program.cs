class Program
{
    static void Main()
    {
        string sourceDirectory = @"NGINX-Image-Upload-App\imageSource";
        string destinationDirectory = @"NGINX-Image-Upload-App\imageDestination";



        string[] imageExtensions = { ".jpg", ".jpeg", ".png" };

        foreach (string file in Directory.EnumerateFiles(sourceDirectory))
        {
            if (imageExtensions.Contains(Path.GetExtension(file).ToLower()))
            {
                string destinationFileName = Path.Combine(destinationDirectory, Path.GetFileName(file));

                if (!File.Exists(destinationFileName))
                {
                    byte[] imageBytes = ImageHelper.ConvertImageToBytes(file);
                    File.WriteAllBytes(destinationFileName, imageBytes);
                    Console.WriteLine($"Image '{file}' converted and saved to '{destinationFileName}' " +
                        $"with a size of {new FileInfo(destinationFileName).Length} bytes.");
                }
                else
                {
                    Console.WriteLine($"Image '{file}' already exists in the destination folder.");
                }
            }
        }

        Console.WriteLine("Image conversion and storage completed.");
    }
}

