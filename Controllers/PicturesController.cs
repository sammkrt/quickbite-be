using Microsoft.AspNetCore.Mvc;
using QuickBiteBE.Services;
using QuickBiteBE.Services.Interfaces;

namespace QuickBiteBE.Controllers;

[ApiController]
[Route("[controller]")]
public class PicturesController : ControllerBase
{
    private IBlobService _blobService;

    public PicturesController(IBlobService blobService)
    {
        _blobService = blobService;
    }
    [HttpPost]
    [Route("upload")]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        var uploadedFile = await _blobService.UploadFile(file);

        if (uploadedFile != null)
        {
            return Ok();
        }
        return BadRequest();
    }
    [HttpGet]
    [Route("getimages")]
    public async Task<IActionResult> GetImages()
    {
        var imageUrls = await _blobService.GetImageUrls();

        if (imageUrls != null)
        {
            return Ok(imageUrls);
        }

        return BadRequest();
    }
    
    [HttpDelete("delete/{fileName}")]
    public async Task<IActionResult> DeleteBlob(string fileName)
    {
        try
        {
            await _blobService.DeleteFile(fileName);
            return Ok($"Blob {fileName} deleted successfully");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, $"Error deleting blob: {ex.Message}");
        }
    }
    
    
}