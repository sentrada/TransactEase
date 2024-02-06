namespace TransactEase.ExcelImporter.Attributes;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class ExcelColumnAttribute : Attribute
{
    public string? ColumnName { get; }
    public int ColumnIndex { get; }

    public ExcelColumnAttribute(string? columnName)
    {
        ColumnName = columnName;
        ColumnIndex = -1;
    }

    public ExcelColumnAttribute(int columnIndex)
    {
        ColumnIndex = columnIndex;
        ColumnName = null;
    }
}