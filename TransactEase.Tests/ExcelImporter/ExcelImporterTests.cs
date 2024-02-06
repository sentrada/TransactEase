using Moq;
using TransactEase.ExcelImporter;
using TransactEase.ExcelImporter.DTOs;

namespace TransactEase.Tests.ExcelImporter;

public class ExcelImporterTests
{
    private readonly Mock<IExcelReader<BranchOfficeDto>> _mockReader;
    private readonly ExcelImporter<BranchOfficeDto> _excelImporter;

    public ExcelImporterTests()
    {
        _mockReader = new Mock<IExcelReader<BranchOfficeDto>>();
        _excelImporter = new ExcelImporter<BranchOfficeDto>(_mockReader.Object);
    }

    [Fact]
    public void ReadExcel_ReturnsCorrectData_WhenStreamIsValid()
    {
        var stream = new MemoryStream();
        var expectedData = new List<BranchOfficeDto> { new BranchOfficeDto() };
        _mockReader.Setup(x => x.GetExcelData(It.IsAny<Stream>(), It.IsAny<Dictionary<string, int>>()))
            .Returns(expectedData);

        var result = _excelImporter.ReadExcel(stream);

        Assert.Equal(expectedData, result);
    }

    [Fact]
    public void ReadExcel_ThrowsException_WhenStreamIsNull()
    {
        Stream stream = null;
        Assert.Throws<ArgumentNullException>(() => _excelImporter.ReadExcel(stream));
    }

    [Fact]
    public void ReadExcel_ReturnsEmptyList_WhenNoDataInExcel()
    {
        var stream = new MemoryStream();
        var expectedData = new List<BranchOfficeDto>();
        _mockReader.Setup(x => x.GetExcelData(It.IsAny<Stream>(), It.IsAny<Dictionary<string, int>>()))
            .Returns(expectedData);

        var result = _excelImporter.ReadExcel(stream);

        Assert.Equal(expectedData, result);
    }
}