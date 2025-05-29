using Batch27WebApi.Contract.Repository;
using Batch27WebApi.Contract.Service;
using Batch27WebApi.DTO.RequestModel;
using Batch27WebApi.DTO.ResponseModel;
using Batch27WebApi.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Xml.Linq;

namespace Batch27WebApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository) => _bookRepository = bookRepository;

        public CreateBookResponseModel CreateBook(BookRequestModel bookRequestModel)
        {
            var response = new CreateBookResponseModel();
          
            try
            {

                var bookExists = _bookRepository.IsExist(b => b.Title == bookRequestModel.Title);

                if (bookExists)
                {

                    response.Message = "Book already exist";
                }
            }
            catch
            {
                return new CreateBookResponseModel
                {
                    Message = response.Message,
                };
            }

            try
            {
                var newBook = new BookMenu
                {
                    Title = bookRequestModel.Title,
                    Author = bookRequestModel.Author,
                    //  BookCode = bookRequestModel.BookCode
                };
                var create = _bookRepository.CreateBook(newBook);
                return new CreateBookResponseModel
                {
                    Title = create.Title,
                    Author = create.Author,
                    BookCode = create.BookCode
                };
            }
              
            catch
            {

                response.Message = $"Error occured while creating a new book - code {bookRequestModel.Title}";
                response.Status = false;
            }

            return response;
        }
       
        public BookResponse Delete(string bookCode)
        {
            var response = new BookResponse();
            BookMenu book = null;
            try
            {
                book  = _bookRepository.GetBookById(bookCode);               
            }
            catch
            {
                return new BookResponse
                {
                    Message = "An error occured",
                    Status = false
                };
            }
            if (book is null)
                return new BookResponse
                {
                    Message = $"Book not found. code - {bookCode}"
                };
            try
            {              

                _bookRepository.Delete(book);
                Console.WriteLine("Deleted successfully");

                return new BookResponse
                {
                    Title = book.Title,
                    Author = book.Author,
                    BookCode = book.BookCode,
                    Message ="Successfully deleted.",
                    Status = true
                };
            }
            catch
            {
                response.Message = $"An error occured while deleting the book - code {bookCode}";
                response.Status = false;
            }
            return response;          
        }


        public IEnumerable<BookResponse> GetAll()
        {
            var books = _bookRepository.GetAll();

            if (!books.Any())
            {
                Console.WriteLine("No books found.");
                return new List<BookResponse>();
            }

            var result = books.Select(b => new BookResponse
            {
                Title = b.Title,
                Author = b.Author,
                BookCode = b.BookCode
            });

            return result;
        }


        public BookResponse GetBookById(BookRequestModel bookRequestModel)
        {
            throw new NotImplementedException();
        }

        public UpdateBookResponseModel Update(string id, UpdateBookRequestModel updateBookRequestModel)
        {
            var existingBook = _bookRepository.GetBookById(id);

            if (existingBook == null)
            {
                Console.WriteLine("Book not found");
                return null;
            }

            
            existingBook.Title = updateBookRequestModel.Title;
            existingBook.Author = updateBookRequestModel.Author;

           
            _bookRepository.Update(existingBook);

            
            return new UpdateBookResponseModel
            {
                Title = existingBook.Title,
                Author = existingBook.Author,
                BookCode = existingBook.BookCode
            };
        }

    }
}
