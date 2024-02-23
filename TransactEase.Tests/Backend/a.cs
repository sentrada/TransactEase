using System.Text;
using Moq;
using TransactEase.Backend.Services;
using TransactEase.Infrastructure.Interfaces.Communications;

namespace TransactEase.Tests.Backend;

public class FileDownloadServiceTests
{
    [Fact]
    public async Task DownloadFileAsync_ReturnsStream_WhenFileIsSuccessfullyDownloaded()
    {
        // Arrange
        var httpClientAdapterMock = new Mock<IHttpClientAdapter>();
        var fileBytes = Encoding.UTF8.GetBytes("file content");
        httpClientAdapterMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync(fileBytes);

        var fileDownloadService = new FileDownloadService(httpClientAdapterMock.Object);

        // Act
        var result = await fileDownloadService.DownloadFileAsync("http://example.com/file");

        // Assert
        var resultContent = new StreamReader(result).ReadToEnd();
        Assert.Equal("file content", resultContent);
    }

    [Fact]
    public async Task DownloadFileAsync_ReturnsEmptyStream_WhenFileCannotBeDownloaded()
    {
        // Arrange
        var httpClientAdapterMock = new Mock<IHttpClientAdapter>();
        httpClientAdapterMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync((byte[])null);

        var fileDownloadService = new FileDownloadService(httpClientAdapterMock.Object);

        // Act
        var result = await fileDownloadService.DownloadFileAsync("http://example.com/file");

        // Assert
        Assert.Equal(0, result.Length);
    }
}