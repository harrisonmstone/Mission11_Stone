using Microsoft.AspNetCore.Mvc;
using Mission11_Stone.Models;
using Mission11_Stone.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Stone.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _repo;

        public HomeController(IBookstoreRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index(int pageNum, string? projectType)
        {
            int pageSize = 10;

            var blah = new BookListViewModel
            {
                Books = _repo.Books
                    .Where(x => x.Category == projectType || projectType == null)
                    .OrderBy(x => x.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = projectType == null ? _repo.Books.Count() : _repo.Books.Where(x => x.Category == projectType).Count()
                },

                CurrentProjectType = projectType

            };

            return View(blah);
        }

    }
}
