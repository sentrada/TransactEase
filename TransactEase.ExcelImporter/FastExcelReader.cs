using System.Reflection;
using FastExcel;
using ExcelColumnAttribute = TransactEase.ExcelImporter.Attributes.ExcelColumnAttribute;

namespace TransactEase.ExcelImporter;

/// <summary>
/// Class for Fast Excel Reader.
/// </summary>
/// <typeparam name="T">The type of object to be read from Excel.</typeparam>
public sealed class FastExcelReader<T> : IExcelReader<T> where T : new()
{
    /// <summary>
    /// Gets the property names with their corresponding column indexes from an Excel file.
    /// </summary>
    /// <param name="excelStream">The stream of the Excel file.</param>
    /// <returns>A dictionary with property names as keys and column indexes as values.</returns>
    public Dictionary<string, int> GetPropertyNamesWithColumnIndexes(Stream excelStream)
    {
        using var excel = new FastExcel.FastExcel(excelStream);
        var worksheet = GetWorksheet(excel);
        var properties = typeof(T).GetProperties();
        var result = new Dictionary<string, int>();
        foreach (var property in properties)
        {
            var customAttribute =
                property.GetCustomAttribute(typeof(ExcelColumnAttribute), true) as ExcelColumnAttribute;

            if (customAttribute is null)
                continue;

            var columnIndex = customAttribute.ColumnIndex;

            if (columnIndex == -1)
            {
                var columnName = customAttribute.ColumnName;
                if (columnName is null)
                    continue;

                columnIndex = GetColumnIndexByName(worksheet, columnName);
            }

            result.Add(property.Name, columnIndex);
        }

        return result;
    }


    /// <summary>
    /// Gets the Excel data and returns a list of objects of type T.
    /// </summary>
    /// <param name="excelStream">The stream of the Excel file.</param>
    /// <param name="propertyNamesWithColumnIndexes">A dictionary with property names as keys and column indexes as values.</param>
    /// <returns>A list of objects of type T.</returns>
    public List<T> GetExcelData(Stream excelStream, Dictionary<string, int> propertyNamesWithColumnIndexes)
    {
        using var excel = new FastExcel.FastExcel(excelStream);
        var worksheet = GetWorksheet(excel);
        var result = new List<T>();
        var rows = worksheet?.Rows;

        if (!rows.Any())
            return result;

        foreach (var row in rows)
        {
            if (row.RowNumber == 1)
            {
                continue;
            }

            var item = new T();
            var cells = row.Cells.ToList();
            foreach (var (propertyName, columnIndex) in propertyNamesWithColumnIndexes)
            {
                var cell = cells.ElementAtOrDefault(columnIndex);
                var cellValue = cell?.Value;
                var conversionType = typeof(T).GetProperty(propertyName)?.PropertyType;
                if (conversionType != null)
                    typeof(T).GetProperty(propertyName)?.SetValue(item,
                        Convert.ChangeType(cellValue, conversionType));
            }

            result.Add(item);
        }

        return result;
    }

    /// <summary>
    /// Gets the worksheet from the Excel file.
    /// </summary>
    /// <param name="excelStream">The stream of the Excel file.</param>
    /// <returns>The worksheet from the Excel file.</returns>
    private static Worksheet GetWorksheet(FastExcel.FastExcel excel)
    {
        var ws = excel.Worksheets.First();
        ws.Read();
        return ws;
    }

    /// <summary>
    /// Gets the column index by the column name from the worksheet.
    /// </summary>
    /// <param name="worksheet">The worksheet from the Excel file.</param>
    /// <param name="columnName">The name of the column.</param>
    /// <returns>The column index.</returns>
    private static int GetColumnIndexByName(Worksheet worksheet, string columnName)
    {
        var headerRow = worksheet.Rows.First();
        var columnIndex = -1;

        var cells = headerRow.Cells.ToList();
        for (var i = 0; i < cells.Count; i++)
        {
            var cell = cells.ElementAt(i);
            var cellValue = cell.Value;

            if (!columnName.Equals(cellValue)) continue;
            columnIndex = i;
            break;
        }

        return columnIndex;
    }
}