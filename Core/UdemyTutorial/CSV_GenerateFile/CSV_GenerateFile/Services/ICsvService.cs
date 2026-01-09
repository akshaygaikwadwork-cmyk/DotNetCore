namespace CSV_GenerateFile.Services
{
    public interface ICsvService
    {
        byte[] GenerateCsv<T>(IEnumerable<T> records);
    }
}
