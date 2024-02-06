using TransactEase.ExcelImporter;
using TransactEase.ExcelImporter.DTOs;

namespace TransactEase.Tests.ExcelImporter;

public class FastExcelReaderTests
{
    private const string EXCEL_FILE_PATH = "./ExcelImporter/Documents/sht_test.xlsx";
    private readonly FastExcelReader<BranchOfficeDto> _fastExcelReader;

    public FastExcelReaderTests()
    {
        _fastExcelReader = new FastExcelReader<BranchOfficeDto>();
    }

    [Fact]
    public void GetPropertyNamesWithColumnIndexes_ReturnsCorrectData_WhenStreamIsValid()
    {
        using var fileStream = new FileStream(EXCEL_FILE_PATH, FileMode.Open, FileAccess.ReadWrite);
        var result = _fastExcelReader.GetPropertyNamesWithColumnIndexes(fileStream);

        Assert.NotNull(result);
    }

    [Fact]
    public void GetPropertyNamesWithColumnIndexes_ThrowsException_WhenStreamIsNull()
    {
        Stream stream = null;

        Assert.Throws<ArgumentNullException>(() => _fastExcelReader.GetPropertyNamesWithColumnIndexes(stream));
    }

    [Fact]
    public void GetExcelData_ReturnsCorrectData_WhenStreamIsValid()
    {
        var fileStream = new FileStream(EXCEL_FILE_PATH, FileMode.Open, FileAccess.ReadWrite);
        var propertyNamesWithColumnIndexes = new Dictionary<string, int>
        {
            { "BranchCode", 0 },
            { "BicCode", 1 },
            { "Name", 2 },
            { "Address", 3 },
            { "CanSendViber", 4 },
            { "CanReceiveViber", 5 }
        };
        var result = _fastExcelReader.GetExcelData(fileStream, propertyNamesWithColumnIndexes);
        Assert.NotNull(result);
        fileStream.Dispose();
    }

    [Fact]
    public void GetExcelData_ThrowsException_WhenStreamIsNull()
    {
        Stream stream = null;
        var propertyNamesWithColumnIndexes = new Dictionary<string, int>();

        Assert.Throws<ArgumentNullException>(
            () => _fastExcelReader.GetExcelData(stream, propertyNamesWithColumnIndexes));
    }

    [Fact]
    public void GetExcelData_ReturnsEmptyList_WhenWorksheetHasNoRows()
    {
        var fileStream = new FileStream("./ExcelImporter/Documents/sht_test_without_row.xlsx", FileMode.Open,
            FileAccess.ReadWrite);
        var propertyNamesWithColumnIndexes = new Dictionary<string, int>();

        var excelReader = new FastExcelReader<BranchOfficeDto>();

        // Act
        var result = excelReader.GetExcelData(fileStream, propertyNamesWithColumnIndexes);

        Assert.NotNull(result);
        Assert.Empty(result);
    }
}