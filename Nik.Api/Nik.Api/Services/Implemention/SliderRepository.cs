using Microsoft.EntityFrameworkCore;
using Nik.Api.Models;
using Nik.Api.Models.NotMapped;
using Nik.Api.Services.Interfaces;
using Nik.Api.Utilities;
using Nik.Api.Utilities.FileHelpers;

namespace Nik.Api.Services.Implemention
{
    public class SliderRepository : ISlidersRepository
    {
        private readonly NikDbContext _context;
        private readonly IFileHelper _fileHelper;
        public SliderRepository(NikDbContext context, IFileHelper fileHelper)
        {
            _context = context;
            _fileHelper = fileHelper;
        }

        public async Task deleteSlider(int id)
        {
            var result = await _context.Sliders.FindAsync(id);
            if (result == null)
            {
                throw new Exception();
            }
            _context.Sliders.Remove(result);
            _context.SaveChanges();
        }

        public async Task<List<Slider>> getAllSlider()
        {
            var result = await _context.Sliders.ToListAsync();
            return result;
        }

        public async Task<Slider> getSliderById(int id)
        {
            var result = await _context.Sliders.FindAsync(id);
            return result;
        }

        public async Task<Slider> postSlider(Slider slider)
        {
            slider.ImageName = _fileHelper.Upload(slider.FormFile, FilePath.Root);
            Slider slider1 = new Slider()
            {
                SliderId = slider.SliderId,
                FirstTitle = slider.FirstTitle,
                FinalTitle = slider.FinalTitle,
                MiddleTitle = slider.MiddleTitle,
                ImageName = slider.ImageName
            };

            _context.Sliders.Add(slider1);
            _context.SaveChangesAsync();
            return slider1;
        }

        public async Task putSlider(int id, Slider slider)
        {
            slider.ImageName = _fileHelper.Upload(slider.FormFile, FilePath.Root);
            _context.Sliders.Where(c => c.SliderId == id).Select(c => new Slider
            {
                FinalTitle = c.FinalTitle,
                FirstTitle = c.FirstTitle,
                MiddleTitle = c.MiddleTitle,
                SliderId = slider.SliderId,
                ImageName = slider.ImageName
            });

            await _context.SaveChangesAsync();

        }
    }
}
