namespace Fiorella.App.Extensions
{
    public static class FileUpload
    {
        public async static Task<string> SaveFileAsync(this IFormFile file, string root, string path)
        {
            string filename = Guid.NewGuid().ToString() + file.FileName;
            string url = Path.Combine(root, path, filename);
            using(FileStream fileStream = new FileStream(url, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            return filename;
        }
    }
}
