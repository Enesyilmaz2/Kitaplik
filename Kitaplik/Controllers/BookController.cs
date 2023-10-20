using Kitaplik.Models;
using Kitaplik.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kitaplik.Controllers;

public class BookController : Controller
{

    // Dependency Injection
    private readonly RepositoryBaglantisi _repository;

    public BookController(RepositoryBaglantisi repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    // Attribute
    [HttpPost]
    public  IActionResult Create(Book book)
    {
        _repository.Add(book);
        _repository.SaveChanges();
        return RedirectToAction("Index", "Home");
    }

    //[HttpGet]
    //public IActionResult Linq()
    //{
    //    string[] isimler = { "ras", "dslkj", "afkda", "çömdf", "lkmsdçöns", "roakqmnm" };
    //    List<string> linqQuery = isimler.Where(x=>x.Contains("r")).ToList();

        
    //    return View();
    //}

    public IActionResult GetList()
    {
        List<Book> books= _repository.Books.ToList();
        return View(books);
    }
}
