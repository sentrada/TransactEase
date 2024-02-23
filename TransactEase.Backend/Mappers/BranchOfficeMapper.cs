using AutoMapper;
using TransactEase.Core.Models;
using TransactEase.ExcelImporter.DTOs;

namespace TransactEase.Backend.Mappers;

public class BranchOfficeMapper : Profile
{
    public BranchOfficeMapper()
    {
        CreateMap<BranchOfficeDto, BranchOffice>();
    }
}