using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PetWorld.Core.Contracts;
using PetWorld.Helpers;
using PetWorld.Infrastructure.Data;


namespace PetWorld.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;
        private readonly PetWorldDbContext dbContext;
        public PhotoService(IOptions<CloudinarySettings> config, PetWorldDbContext dbContext)
        {
            var acc = new Account(
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret);

            _cloudinary = new Cloudinary(acc);
            this.dbContext = dbContext;
        }
        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {

            var uploadedResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(file.FileName, stream),
                    Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                };
                uploadedResult = await _cloudinary.UploadAsync(uploadParams);
            }
            return uploadedResult;
        }

        public async Task<DeletionResult> DeletePhotoAsync(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);
            var result = await _cloudinary.DestroyAsync(deleteParams);

            return result;
        }

        //public async Task<HotelPhoto> GetPhotoById(string id)
        //{

        //    return await dbContext.HotelPhoto.FirstOrDefaultAsync(p => p.Id.ToString() == id);


        //}
    }
}
