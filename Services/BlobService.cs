using Azure.Storage.Blobs;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Services;

public class BlobService : IBlobService
{
    private readonly BlobServiceClient _blobServiceClient;

    public BlobService(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        _blobServiceClient = new BlobServiceClient(connectionString);
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        var containerName = "quickbitecontainer";
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var blobClient = containerClient.GetBlobClient(fileName);

        await using var stream = file.OpenReadStream();
        await blobClient.UploadAsync(stream, overwrite: true);
        // ==> 

        return blobClient.Uri.ToString();
    }
    
    public async Task<List<string>> GetImageUrls()
    {
        var containerName = "quickbitecontainer";
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        var blobs = containerClient.GetBlobsAsync();

        var imageUrls = new List<string>();
        await foreach (var blobItem in blobs)
        {
            var blobClient = containerClient.GetBlobClient(blobItem.Name);
            var blobUri = blobClient.Uri.ToString();
            imageUrls.Add(blobUri);
        }

        return imageUrls;
    }

    public async Task DeleteFile(string fileName)
    {
        var containerName = "quickbitecontainer";
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        var blobClient = containerClient.GetBlobClient(fileName);

        await blobClient.DeleteIfExistsAsync();
    }
}