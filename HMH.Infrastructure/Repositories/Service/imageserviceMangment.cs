using HMH.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Repositories.Service
{
    public class ImageserviceMangment : IimageserviceMangment
    {
        private readonly IFileProvider fileProvider;
        public ImageserviceMangment(IFileProvider fileProvider)
        {
            this.fileProvider = fileProvider;
        }

        public async Task<string> AddImageAsync(IFormFile file, string src)
        {
            string SaveImageSrc="";
            var ImageDiertory = Path.Combine("wwwroot", "Images", src);
            if (Directory.Exists(ImageDiertory) is not true)
            {
                Directory.CreateDirectory(ImageDiertory);
            }

            if(file.Length>0)
            {
                var ImageName=file.FileName;
                var Imagesrc = $"/Images/{src}/{ImageName}";
                var root=Path.Combine(ImageDiertory, ImageName);
                using (FileStream strem = new FileStream(root,FileMode.Create))
                {
                    await file.CopyToAsync(strem);
                }
                SaveImageSrc = Imagesrc;
            }
            return SaveImageSrc;
            




        }

       

        public void DeleteImageAsync(string src)
        {
           var info=fileProvider.GetFileInfo(src);
            var root = info.PhysicalPath;
            File.Delete(root); 
        }
    }
}
