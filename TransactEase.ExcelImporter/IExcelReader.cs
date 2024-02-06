namespace TransactEase.ExcelImporter;

/// <summary>
/// Interface for Excel Reader.
/// </summary>
/// <typeparam name="T">The type of object to be read from Excel.</typeparam>
public interface IExcelReader<T> where T : new()
{
    /// <summary>
    /// Gets the property names with their corresponding column indexes from an Excel file.
    /// </summary>
    /// <param name="excelStream">The stream of the Excel file.</param>
    /// <returns>A dictionary with property names as keys and column indexes as values.</returns>
    Dictionary<string, int> GetPropertyNamesWithColumnIndexes(Stream excelStream);

    /// <summary>
    /// Gets the Excel data and returns a list of objects of type T.
    /// </summary>
    /// <param name="excelStream">The stream of the Excel file.</param>
    /// <param name="propertyNamesWithColumnIndexes">A dictionary with property names as keys and column indexes as values.</param>
    /// <returns>A list of objects of type T.</returns>
    List<T> GetExcelData(Stream excelStream, Dictionary<string, int> propertyNamesWithColumnIndexes);
}