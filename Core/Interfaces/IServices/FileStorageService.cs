using System.Text.Encodings.Web;
using Microsoft.Extensions.Options;
using stack_overflow.Core.Entities;
using stack_overflow.Infrastructure.Configuration;

namespace stack_overflow.Core.Interfaces.IServices;

public class FileStorageService : IFileStorageService
{
    private readonly FileUploadSettings _settings;
    public FileStorageService(IOptions<FileUploadSettings> options)
    {
        _settings = options.Value;
    }
    
    public async Task<PostFile> SaveFileAsync(IFormFile file, int postId)
    {
        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
        if(!_settings.AllowedExtensions.Contains(ext))
            throw new InvalidOperationException("File type not allowed");
        
        if(file.Length > _settings.MaxFileSizeMB * 1024 * 1024)
            throw new InvalidOperationException("File too large");

        var safeFileName = $"{Guid.NewGuid()}{ext}";
        var uploadPath = Path.Combine(_settings.UploadPath, safeFileName);

        if (!Directory.Exists(_settings.UploadPath))
            Directory.CreateDirectory(_settings.UploadPath);

        await using var stream = new FileStream(uploadPath, FileMode.CreateNew);
        await file.CopyToAsync(stream);

        return new PostFile
        {
            FileName = safeFileName,
            OriginalFileName = HtmlEncoder.Default.Encode(file.FileName),
            FilePath = uploadPath,
            ContentType = file.ContentType,
            PostId = postId
        };
    }
}