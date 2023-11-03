using Microsoft.AspNetCore.Mvc;
using TuProyecto.Models; 
using TuProyecto.Services; 

public class AuthorsController : Controller
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    public IActionResu2lt AuthorList(string authorName)
    {
        List<Author> authors;

        if (!string.IsNullOrWhiteSpace(authorName))
        {
            authors = _authorService.GetAuthorsByName(authorName); 
        }
        else
        {
            authors = _authorService.GetAllAuthors(); 
        }

        return View(authors);
    }
}
