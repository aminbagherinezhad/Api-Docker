using System.ComponentModel.DataAnnotations.Schema;

namespace Nik.Api.Models.NotMapped
{
    public class blog
    {
        [NotMapped]
        public IFormFile FormFile { get; set; }
    }
}
