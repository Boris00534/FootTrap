using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootTrap.Data.Models;
using Microsoft.AspNetCore.Http;

namespace FootTrap.Services.Contracts
{
    public interface IImageService
    {
        Task<string> UploadImageToUser(IFormFile image, string folderName, User user);
        Task<string> UploadImageToShoe(IFormFile image, string folderName, Shoe shoe);
    }
}
