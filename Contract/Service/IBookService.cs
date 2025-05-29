using Batch27WebApi.DTO.RequestModel;
using Batch27WebApi.DTO.ResponseModel;

namespace Batch27WebApi.Contract.Service
{
    public interface IBookService
    {
        CreateBookResponseModel CreateBook(BookRequestModel bookRequestModel);
        BookResponse Delete(string bookCode);
        BookResponse GetBookById(BookRequestModel bookRequestModel);       
        UpdateBookResponseModel Update( string id, UpdateBookRequestModel updateBookRequestModel);
        IEnumerable<BookResponse> GetAll();
    }
}
