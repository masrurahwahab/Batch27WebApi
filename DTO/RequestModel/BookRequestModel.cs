using System.ComponentModel.DataAnnotations;

namespace Batch27WebApi.DTO.RequestModel
{
    public class BookRequestModel
    {
        [Required, Length(5, 10)]
        public string Title { get; set; }

        [Required, Length(5, 10)]
        public string Author { get; set; }

       // public string BookCode { get; set; }
    }
}
