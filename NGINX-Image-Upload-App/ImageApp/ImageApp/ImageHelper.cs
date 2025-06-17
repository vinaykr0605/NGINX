using System.Drawing;

public static class ImageHelper
{
    public static byte[] ConvertImageToBytes(string imagePath)
    {
        using (var image = Image.FromFile(imagePath))
        using (var stream = new MemoryStream())
        {
            image.Save(stream, image.RawFormat);
            return stream.ToArray();
        }
    }
}
