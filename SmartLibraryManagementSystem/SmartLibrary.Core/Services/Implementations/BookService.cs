using SmartLibrary.Core.DTOs.Books;
using SmartLibrary.Core.Entities;
using SmartLibrary.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLibrary.Core.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepo.GetAllAsync();

            return books.Select(b => new BookDto
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                IsAvailable = b.IsAvailable
            }).ToList();
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return null;

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                IsAvailable = book.IsAvailable
            };
        }

        public async Task<BookDto> CreateBookAsync(CreateBookDto dto)
        {
            var book = new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                IsAvailable = true
            };

            await _bookRepo.AddAsync(book);

            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                IsAvailable = true
            };
        }

        public async Task<bool> UpdateBookAsync(int id, UpdateBookDto dto)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return false;

            book.Title = dto.Title;
            book.Author = dto.Author;

            await _bookRepo.UpdateAsync(book);
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _bookRepo.GetByIdAsync(id);
            if (book == null) return false;

            await _bookRepo.DeleteAsync(book.Id);
            return true;
        }
    }

}
