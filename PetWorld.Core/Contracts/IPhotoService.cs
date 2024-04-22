﻿using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace PetWorld.Core.Contracts
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);

        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
