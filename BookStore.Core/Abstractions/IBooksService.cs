using BookStore.CoreDomain.Models;

namespace BookStore.CoreDomain.Abstractions
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> Delete(Guid id);
        Task<List<Book>> GetAllBooks();
        Task<Guid> UpdateBook(Guid id, string title, string description, decimal price);
    }
}