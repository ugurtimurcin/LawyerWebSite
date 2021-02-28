using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawyerWebSite.Core.Utilities.Helpers.FileHelpers
{
    public static class ImageProcessHelper
    {
        public static void Delete(string path)
        {
            var file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
        }

        public static async Task UploadAsync(string name, string folderName, IFormFile file)
        {
            var fileName = name + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/img/{folderName}/" + fileName);
            using var stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream);
        }
    }
}
