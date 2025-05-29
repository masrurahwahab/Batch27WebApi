using Batch27WebApi.DTO.ResponseModel;
using Batch27WebApi.Models.Entities;

namespace Batch27WebApi.Contract.Repository
{
    public interface IBookRepository
    {
        BookResponse CreateBook(BookMenu book);
        bool IsExist(Func<BookMenu, bool> expression);
        void Delete(BookMenu book);
        BookMenu GetBookById(string book);
        BookMenu Get(string title);
        BookMenu Get(Func<BookMenu, bool> expression);
        BookMenu Update(BookMenu foodMenu);
        IEnumerable<BookMenu> GetAll();
    }
}
