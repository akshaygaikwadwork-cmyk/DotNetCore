namespace Excel_GenerateFile.Services
{
    public interface IExcelService
    {
        byte[] GenerateExcel<T>(List<T> data);
    }
}
