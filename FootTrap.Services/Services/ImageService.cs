using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FootTrap.Data;
using FootTrap.Data.Models;
using FootTrap.Services.Contracts;
using Microsoft.AspNetCore.Http;

namespace FootTrap.Services.Services
{
    public class ImageService : IImageService
    {
        private readonly Cloudinary cloudinary;
        private readonly FootTrapDbContext context;

        public ImageService(Cloudinary cloudinary, FootTrapDbContext context)
        {
            this.cloudinary = cloudinary;
            this.context = context;
        }
        public async Task<string> UploadImageToUser(IFormFile imageFile, string folderName, User user)
        {
            using var stream = imageFile.OpenReadStream();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(user.Id, stream),
                Folder = folderName
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            if (uploadResult.Error != null)
            {
                throw new InvalidOperationException(uploadResult.Error.Message);
            }

            user.ProfilePictureUrl = uploadResult.Url.ToString();

            return user.ProfilePictureUrl;
        }
    }
}
