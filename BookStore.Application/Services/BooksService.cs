﻿using BookStore.CoreDomain.Abstractions;
using BookStore.CoreDomain.Models;

namespace BookStore.Application.Services;

public class BooksService : IBooksService
{
    private readonly IBooksRepository _booksRepository;

    public BooksService(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<List<Book>> GetAllBooks()
    {
        return await _booksRepository.Get();
    }

    public async Task<Guid> CreateBook(Book book)
    {
        return await _booksRepository.Create(book);
    }

    public async Task<Guid> UpdateBook(Guid id, string title, string description, decimal price)
    {
        return await _booksRepository.Update(id, title, description, price);
    }

    public async Task<Guid> Delete(Guid id)
    {
        return await _booksRepository.Delete(id);
    }
}
