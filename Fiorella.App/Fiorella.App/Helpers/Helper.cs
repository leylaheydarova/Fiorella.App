namespace Fiorella.App.Helpers
{
    public static class Helper
    {
        public static bool IsImage(this IFormFile file)
        {
            return file.ContentType.Contains("image");
        }

        public static bool IsSizeOK(this IFormFile file, int mbs)
        {
            return file.Length / 1024 / 1024 <= mbs;
        }

        public static void RemoveImage(string root, string path, string image)
        {
            string url = Path.Combine(root, path, image);
            if (File.Exists(url))
            {
                File.Delete(url);
            }
        }
    }
}
