namespace TransactEase.ExcelImporter
{
    /// <summary>
    /// Class for Excel Importer.
    /// </summary>
    /// <typeparam name="T">The type of object to be imported from Excel.</typeparam>
    public class ExcelImporter<T>(IExcelReader<T> excelReader) : IExcelImporter<T>
        where T : new()
    {
        /// <summary>
        /// Reads data from an Excel file and returns a list of objects of type T.
        /// </summary>
        /// <param name="stream">The stream of the Excel file.</param>
        /// <returns>A list of objects of type T.</returns>
        public List<T> ReadExcel(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException(nameof(stream), "The stream cannot be null.");

            var propertyNamesWithColumnIndexes = excelReader.GetPropertyNamesWithColumnIndexes(stream);
            var result = excelReader.GetExcelData(stream, propertyNamesWithColumnIndexes);
            return result;
        }
    }
}