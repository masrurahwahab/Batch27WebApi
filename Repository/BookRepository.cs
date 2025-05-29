using Batch27WebApi.Contract.Repository;
using Batch27WebApi.Data;
using Batch27WebApi.DTO.ResponseModel;
using Batch27WebApi.Models.Entities;

namespace Batch27WebApi.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public BookResponse CreateBook(BookMenu book)
        {
           var bk = _appDbContext.Books.Add(book);
            _appDbContext.SaveChanges();
            return new BookResponse
            {
               Title = bk.Entity.Title,
               Author = bk.Entity.Author,
               BookCode = bk.Entity.BookCode
            };
        }

        public void Delete(BookMenu book)
        {
             _appDbContext.Books.Remove(book);
            _appDbContext.SaveChanges();
        }

        public BookMenu Get(string title)
        {
            var blu = _appDbContext.Books.FirstOrDefault(r => r.Title == title);
            return blu;
        }

        public BookMenu Get(Func<BookMenu, bool> expression)
        {
            return _appDbContext.Books.FirstOrDefault(expression);
        }

        public IEnumerable<BookMenu> GetAll()
        {
            return _appDbContext.Books.ToList();
        }

        public BookMenu GetBookById(string book)
        {
            BookMenu? blu = _appDbContext.Books.FirstOrDefault(b => b.BookCode == book);
            return blu;
        }

        public bool IsExist(Func<BookMenu, bool> expression)
        {
            return _appDbContext.Books.Any(expression);
        }

        public BookMenu Update(BookMenu foodMenu)
        {
             _appDbContext.Books.Update(foodMenu);
            _appDbContext.SaveChanges();
            return foodMenu;
        }
    }
}
