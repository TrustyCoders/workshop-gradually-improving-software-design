using Bookstore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Domain.Specifications;

public static class BookSpecifications
{
    public static IQueryable<Book> GetBooks(this IQueryable<Book> books) =>
        books
            .Include(book => book.AuthorsCollection)
            .ThenInclude(bookAuthor => bookAuthor.Person);

    public static async Task<Book?> ById(this IQueryable<Book> books, Guid id) =>
        await books.FirstOrDefaultAsync(book => book.Id == id);

    public static IQueryable<Book> ByTitle(this IQueryable<Book> books, string title) =>
        books.Where(book => book.Title == title);
}