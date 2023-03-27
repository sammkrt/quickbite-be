namespace QuickBiteBE.Services.Interfaces;

public interface IBlobService
{
    Task<IFormFile> UploadFile(IFormFile file);
    Task<List<string>> GetImageUrls();
    Task DeleteFile(string fileName);
    Task<string> UploadFileV2(IFormFile file);
}