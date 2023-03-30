namespace QuickBiteBE.Services.Interfaces;

public interface IBlobService
{
    Task<List<string>> GetImageUrls();
    Task DeleteFile(string fileName);
    Task<string> UploadFile(IFormFile file);
}