using Nik.Api.Models;

namespace Nik.Api.Services.Interfaces
{
    public interface ICompanyLogoRepository
    {
        Task<List<CompanyLogo>> getAllLogoCompany();
        Task<CompanyLogo> getCompanyById(int id);
        Task putCompanyLogo(int id, CompanyLogo companyLogo);
        Task<CompanyLogo> postCompanyLogo(CompanyLogo companyLogo);
        Task deleteCompanyLogo(int id);
    }
}
