using Application.Book.Dto;
using Application.Book.Ports;
using Application.Book.Requests;
using Application.Book.Responses;
using Domain.Book.Exceptions;
using Domain.Book.Ports;

namespace Application.Book
{
    public class BookManager : IBookManager
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookResponse> CreateAsync(CreateBookRequest request)
        {
            try
            {
                var book = BookDto.MapToEntity(request.Data ?? new());
                await book.Save(_bookRepository);
                request.Data.Id = book.Id;

                return new BookResponse
                {
                    Success = true,
                    Data = request.Data
                };
            }
            catch (InvalidNameException ex)
            {
                return new BookResponse
                {
                    Success = false,
                    Message = ex.Message,
                    ErrorCode = ErrorCode.BOOK_INVALID_NAME
                };
            }
            catch (InvalidBioException ex)
            {
                return new BookResponse
                {
                    Success = false,
                    Message = ex.Message,
                    ErrorCode = ErrorCode.BOOK_INVALID_BIO
                };
            }
            catch (InvalidAuthorException ex)
            {
                return new BookResponse
                {
                    Success = false,
                    Message = ex.Message,
                    ErrorCode = ErrorCode.BOOK_INVALID_AUTHOR
                };
            }
            catch (InvalidPublishingCompanyException ex)
            {
                return new BookResponse
                {
                    Success = false,
                    Message = ex.Message,
                    ErrorCode = ErrorCode.BOOK_INVALID_PUBLISING_COMPANY
                };
            }
            catch (InvalidPagesException ex)
            {
                return new BookResponse
                {
                    Success = false,
                    Message = ex.Message,
                    ErrorCode = ErrorCode.BOOK_INVALID_PAGE
                };
            }
            catch (InvalidEditionException ex)
            {
                return new BookResponse
                {
                    Success = false,
                    Message = ex.Message,
                    ErrorCode = ErrorCode.BOOK_INVALID_EDITION
                };
            }
            catch (Exception)
            {
                return new BookResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.BOOK_COLD_NOT_SAVE,
                    Message = "There was an error during using DB."
                };
            }
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            await _bookRepository.DeleteBookAsync(book);
        }

        public async Task<BookResponse> GetBookByIdAsync(int id)
        {
            var book = BookDto.MapToDto(await _bookRepository.GetBookByIdAsync(id));

            return new BookResponse
            {
                Data = book
            };
        }

        public async Task<BookResponse> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            var bookDto = new BookResponse();
            books.ForEach(x => bookDto.Books.Add(BookDto.MapToDto(x)));

            return new BookResponse
            {
                Books = bookDto.Books
            };
        }

        public BookResponse UpdateBook(UpdateBookRequest request)
        {
            var book = BookDto.MapToEntity(request.Data ?? new());
            _bookRepository.UpdateBook(book);

            return new BookResponse
            {
                Data = request.Data
            };
        }
    }
}

