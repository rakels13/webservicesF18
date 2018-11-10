using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Manifesto.Models.DTOs;
using Manifesto.Models.InputModels;

namespace Manifesto.Repositories
{
    public class BookRepository
    {
        private readonly BookDbContext _context = new BookDbContext();
        public IEnumerable<BookDTO> GetAllBooks(string category)
        {
            return Mapper.Map<IEnumerable<BookDTO>>(_context.Books.Where(b => b.Category == category));
        }

        public BookDTO GetBookById(int id)
        {
            return Mapper.Map<IEnumerable<BookDTO>>(_context.Books.FirstOrDefault(b => b.Id == id));
        }

        public int CreateBook(BookInputModel book)
        {
            var entity = Mapper.Map<Book>(book);
            _context.Books.Add(entity);
        }

        public void UpdateBookById(BookInputModel book, int id)
        {
            var updateBook = _context.Books.FirstOrDefault(b => b.Id == id);

            if (updateBook == null) {return; /*Throw exception*/}

            updateBook.Author = book.Author;
            updateBook.Category = book.Category;
            updateBook.Description = book.Description;
            updateBook.ImageUrl = book.ImageUrl;
            updateBook.Isbn = book.Isbn;
            updateBook.Name = book.Name;
            updateBook.ModifiedOn = DateTime.Now;
        }

        public void DeleteBookById(BookDTO book)
        {
            _context.Books.Remove(BookDTO book);
        }
    }
}