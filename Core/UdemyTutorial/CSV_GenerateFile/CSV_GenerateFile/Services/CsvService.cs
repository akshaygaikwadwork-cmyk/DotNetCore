using CsvHelper;
using System.Globalization;
using System.Text;

namespace CSV_GenerateFile.Services
{
    public class CsvService : ICsvService
    {
        public byte[] GenerateCsv<T>(IEnumerable<T> records)
        {
            using var memoryStream = new MemoryStream();
            using var writer = new StreamWriter(memoryStream, Encoding.UTF8);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            csv.WriteRecords(records);
            writer.Flush();

            return memoryStream.ToArray();
        }
    }
}
