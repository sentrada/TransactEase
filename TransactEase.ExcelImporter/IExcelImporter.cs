namespace TransactEase.ExcelImporter;

/// <summary>
/// Interface for Excel Importer.
/// </summary>
/// <typeparam name="T">The type of object to be imported from Excel.</typeparam>
public interface IExcelImporter<T> where T : new()
{
    /// <summary>
    /// Reads data from an Excel file and returns a list of objects of type T.
    /// </summary>
    /// <param name="stream">The stream of the Excel file.</param>
    /// <returns>A list of objects of type T.</returns>
    List<T> ReadExcel(Stream stream);
}