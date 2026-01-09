using ExcelUpload_FileDisplayData.Models;

namespace ExcelUpload_FileDisplayData.Services
{
    public interface IExcelService
    {
        Task<(List<UserData> Users, string ErrorMessage)> ReadExcelAsync(IFormFile file);
    }
}
