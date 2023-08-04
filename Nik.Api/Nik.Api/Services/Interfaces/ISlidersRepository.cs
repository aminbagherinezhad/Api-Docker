using Nik.Api.Models;

namespace Nik.Api.Services.Interfaces
{
    public interface ISlidersRepository
    {
        Task<List<Slider>> getAllSlider();
        Task<Slider> getSliderById(int id);
        Task<Slider> postSlider(Slider slider);
        Task putSlider(int id, Slider slider);
        Task deleteSlider(int id);
    }
}
