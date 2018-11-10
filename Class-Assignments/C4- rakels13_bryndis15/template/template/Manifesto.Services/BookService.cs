using System;
using System.Collections.Generic;
using Manifesto.Models.DTOs;
using Manifesto.Models.InputModels;
using Manifesto.Repositories;

namespace Manifesto.Services
{
    public class BookService
    {
        private readonly BookRepository _context = new BookRepository();
        public IEnumerable<BookDTO> GetAllBooks(string category)
        {
            return _context.GetAllBooks(string category);
        }

        public BookDTO GetBookById(int id)
        {
           var book = _context.GetBookById(id);
            if(book == null) {throw new Exception($"Book with id {id} was not found")}
            return book;
        }

        public int CreateBook(BookInputModel book)
        {
            return _context.CreateBook(book);
        }

        public void UpdateBookById(BookInputModel book, int id)
        {
            var entity = _context.GetBookById(id);
            if(entity == null) {throw new Exception($"Book with id {id} was not found")}
            _context.UpdateBookById(book, id);
        }

        public void DeleteBookById(int id)
        {
            var entity = _context.GetBookById(id);
            if (entity == null) { throw new Exception($"Book with id {id} was not found")}
            _context.DeleteBookById(entity);
        }
    }
}