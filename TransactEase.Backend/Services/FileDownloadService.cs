using AutoMapper;
using Quartz;
using TransactEase.Core.Models;
using TransactEase.ExcelImporter;
using TransactEase.ExcelImporter.DTOs;
using TransactEase.Infrastructure.Interfaces.Communications;
using TransactEase.Infrastructure.Persistence;

namespace TransactEase.Backend.Services;

public interface IFileDownloadService
{
    Task<Stream> DownloadFileAsync(string url);
}

public class FileDownloadService : IFileDownloadService
{
    private readonly IHttpClientAdapter _httpClientAdapter;

    public FileDownloadService(IHttpClientAdapter httpClientAdapter)
    {
        _httpClientAdapter = httpClientAdapter;
    }

    public async Task<Stream> DownloadFileAsync(string url)
    {
        byte[]? fileBytes = await _httpClientAdapter.GetAsync(url);
        return fileBytes == null ? new MemoryStream() : new MemoryStream(fileBytes);
    }
}

public class ExcelDownloadJob : IJob
{
    private readonly IFileDownloadService _fileDownloadService;
    private readonly IExcelImporter<BranchOfficeDto> _excelProcessingService;
    private readonly IDataComparisonService _dataComparisonService;
    private readonly IMapper _mapper;

    public ExcelDownloadJob(IFileDownloadService fileDownloadService,
        IExcelImporter<BranchOfficeDto> excelProcessingService, IDataComparisonService dataComparisonService,
        IMapper mapper)
    {
        _fileDownloadService = fileDownloadService;
        _excelProcessingService = excelProcessingService;
        _dataComparisonService = dataComparisonService;
        _mapper = mapper;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        string url = "https://www.mnb.hu/letoltes/sht.xlsx";
        string savePath = "path_to_save_file";
        var fileStream = await _fileDownloadService.DownloadFileAsync(url);

        var data = _excelProcessingService.ReadExcel(fileStream);
        await _dataComparisonService.CompareAndSaveDataAsync(_mapper.Map<List<BranchOffice>>(data));
    }
}

public interface IDataComparisonService
{
    Task CompareAndSaveDataAsync(List<BranchOffice> newData);
}

public class DataComparisonService : IDataComparisonService
{
    private readonly TransactEaseDbContext _dbContext;

    public DataComparisonService(TransactEaseDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CompareAndSaveDataAsync(List<BranchOffice> newData)
    {
        // Implement data comparison and saving logic here
    }
}