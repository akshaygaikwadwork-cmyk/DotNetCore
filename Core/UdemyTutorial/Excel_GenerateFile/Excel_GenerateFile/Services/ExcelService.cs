using OfficeOpenXml;

namespace Excel_GenerateFile.Services
{
    public class ExcelService : IExcelService
    {
        public byte[] GenerateExcel<T>(List<T> data)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");

            // Add Headers
            var properties = typeof(T).GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = properties[i].Name;
                worksheet.Cells[1, i + 1].Style.Font.Bold = true; // Bold headers
            }

            // Add Data
            for (int row = 0; row < data.Count; row++)
            {
                for (int col = 0; col < properties.Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = properties[col].GetValue(data[row]);
                }
            }

            worksheet.Cells.AutoFitColumns(); // Auto-fit columns for better readability

            return package.GetAsByteArray();
        }
    }
}
