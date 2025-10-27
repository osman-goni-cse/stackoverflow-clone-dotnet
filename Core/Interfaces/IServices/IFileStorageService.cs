using stack_overflow.Core.Entities;

namespace stack_overflow.Core.Interfaces.IServices;

public interface IFileStorageService
{
    Task<PostFile> SaveFileAsync(IFormFile file, int postId);
}