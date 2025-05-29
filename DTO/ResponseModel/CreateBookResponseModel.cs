namespace Batch27WebApi.DTO.ResponseModel
{
    public class CreateBookResponseModel : BaseResponsemodel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookCode { get; set; }

    }

        public class BaseResponsemodel
        {
           public bool Status { get; set; }
           public string Message { get; set; }

        }

}
