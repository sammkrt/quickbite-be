namespace QuickBiteBE.Services;

public interface IBlobService
{
    
        Task<IFormFile> UploadFile(IFormFile file);
        Task<List<string>> GetImageUrls();
        Task DeleteFile(string fileName);
    
}