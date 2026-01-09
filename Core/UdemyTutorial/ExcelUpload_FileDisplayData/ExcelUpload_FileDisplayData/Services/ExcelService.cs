using ExcelUpload_FileDisplayData.Models;
using OfficeOpenXml;

namespace ExcelUpload_FileDisplayData.Services
{
    public class ExcelService : IExcelService
    {
        private readonly long MaxFileSize = 2 * 1024 * 1024; // 2MB

        //Excel_FileUploadExample  - Upload this file to test
        public async Task<(List<UserData> Users, string ErrorMessage)> ReadExcelAsync(IFormFile file)
        {
            var userList = new List<UserData>();

            //  Validate File
            if (file == null || file.Length == 0)
                return (userList, "Please select a valid Excel file.");

            if (!file.FileName.EndsWith(".xlsx"))
                return (userList, "Invalid file type. Only .xlsx files are allowed.");

            if (file.Length > MaxFileSize)
                return (userList, "File size exceeds 2MB limit.");

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using var package = new ExcelPackage(stream);
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                if (worksheet == null)
                    return (userList, "Excel file is empty or corrupted.");

                //  Validate Column Headers
                if (worksheet.Cells[1, 1].Text != "Id" ||
                    worksheet.Cells[1, 2].Text != "Name" ||
                    worksheet.Cells[1, 3].Text != "Email")
                {
                    return (userList, "Invalid column headers. Expected: Id, Name, Email.");
                }

                int rowCount = worksheet.Dimension.Rows;
                for (int row = 2; row <= rowCount; row++) // Skip Header Row
                {
                    int id;
                    bool isIdValid = int.TryParse(worksheet.Cells[row, 1].Value?.ToString(), out id);

                    var name = worksheet.Cells[row, 2].Value?.ToString();
                    var email = worksheet.Cells[row, 3].Value?.ToString();

                    //  Validate Each Row
                    if (!isIdValid || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
                    {
                        return (userList, $"Invalid data at row {row}. Ensure all columns are filled correctly.");
                    }

                    userList.Add(new UserData
                    {
                        Id = id,
                        Name = name,
                        Email = email
                    });
                }
            }
            return (userList, string.Empty);
        }
    }
}
