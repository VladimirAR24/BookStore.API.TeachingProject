﻿using BookStore.CoreDomain.Models;

namespace BookStore.CoreDomain.Abstractions;

public interface IBooksRepository
{
    Task<Guid> Create(Book book);
    Task<Guid> Delete(Guid id);
    Task<List<Book>> Get();
    Task<Guid> Update(Guid id, string title, string description, decimal price);
}