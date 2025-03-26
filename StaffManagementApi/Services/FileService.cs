using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace StaffManagementApi.Services
{
    public class FileService : IFileService
    {
        private readonly string _photoDirectory;
        private readonly string _excelDirectory;

        public FileService(IConfiguration configuration)
        {
            _photoDirectory = configuration["FilePaths:PhotoUploads"] ?? "Uploads/Photos";
            _excelDirectory = configuration["FilePaths:ExcelUploads"] ?? "Uploads/ExcelFiles";
        }

        public async Task<string> UploadPhotoAsync(IFormFile file, string staffId)
        {
            if (file == null || file.Length == 0) return null!;

            var fileName = $"{staffId}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(_photoDirectory, fileName);

            Directory.CreateDirectory(_photoDirectory);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<string> UploadExcelAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return null!;

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(_excelDirectory, fileName);

            Directory.CreateDirectory(_excelDirectory);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }

        public async Task<Stream> DownloadFileAsync(string fileName)
        {
            var filePath = Path.Combine(_photoDirectory, fileName);
            if (!File.Exists(filePath)) filePath = Path.Combine(_excelDirectory, fileName);
            if (!File.Exists(filePath)) return null!;

            return await Task.FromResult(File.OpenRead(filePath));
        }
    }
}
