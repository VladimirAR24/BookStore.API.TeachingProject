﻿using BookStore.API.Contracts;
using BookStore.CoreDomain.Abstractions;
using BookStore.CoreDomain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBooksService _booksService;

    public BooksController(IBooksService booksService)
    {
        _booksService = booksService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<BooksResponse>>> GetBooks()
    {
        var books = await _booksService.GetAllBooks();

        var responce = books.Select(b => new BooksResponse(b.Id, b.Title, b.Description, b.Price));

        return Ok(responce);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateBooks([FromBody] BooksRequest request)
    {
        var (book, error) = Book.Create(
            Guid.NewGuid(),
            request.Title,
            request.Description,
            request.Price);

        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var bookId = await _booksService.CreateBook(book);

        return Ok(bookId);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<Guid>> UpdateBooks(Guid id, [FromBody] BooksRequest request)
    {
        var bookId = await _booksService.UpdateBook(id, request.Title, request.Description, request.Price);

        return Ok(bookId);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Guid>> DeleteBook(Guid id)
    {
        return Ok(await _booksService.Delete(id));
    }
}
