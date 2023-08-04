using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Models.NotMapped;
using Nik.Api.Services.Interfaces;
using Nik.Api.Utilities;
using Nik.Api.Utilities.FileHelpers;

namespace Nik.Api.Services.Implemention
{
    public class CompanyLogoRepository : ICompanyLogoRepository
    {
        private readonly NikDbContext _context;
        private readonly IFileHelper _fileHelper;
        public CompanyLogoRepository(NikDbContext nikDbContext, IFileHelper fileHelper)
        {
            _context = nikDbContext;
            _fileHelper = fileHelper;
        }
        public async Task deleteCompanyLogo(int id)
        {
            var companyLogo = await _context.CompanyLogos.FindAsync(id);
            if (companyLogo == null)
            {
                throw new ArgumentException();
            }

            _context.CompanyLogos.Remove(companyLogo);
            await _context.SaveChangesAsync();

        }

        public async Task<List<CompanyLogo>> getAllLogoCompany()
        {
            var result = _context.CompanyLogos.ToListAsync();
            return await result;
        }

        public async Task<CompanyLogo> getCompanyById(int id)
        {
            var result = _context.CompanyLogos.FindAsync(id);
            if (result == null)
            {
                throw new ArgumentException();
            }
            return await result;
        }

        public Task<CompanyLogo> postCompanyLogo(CompanyLogo companyLogo)
        {
            companyLogo.ImageUrl = _fileHelper.Upload(companyLogo.FormFile, FilePath.Root);
            CompanyLogo companyLogo1 = new CompanyLogo
            {
                ImageUrl = companyLogo.ImageUrl,
            };

            _context.CompanyLogos.Add(companyLogo1);
            _context.SaveChangesAsync();
            return Task.FromResult(companyLogo1);
        }

        public async Task putCompanyLogo(int id, CompanyLogo companyLogo)
        {
            var result = _context.CompanyLogos.Where(c => c.CompanyLogosId == id).Select(c => new CompanyLogo
            {
                ImageUrl = companyLogo.ImageUrl,
            });
            companyLogo.ImageUrl = _fileHelper.Upload(companyLogo.FormFile, FilePath.Root);
            _context.SaveChanges();

        }
    }
}
