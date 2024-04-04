using Microsoft.AspNetCore.Mvc;
using Mission11_Stone.Models;

namespace Mission11_Stone.Components
{
    public class ProjectTypesViewComponent : ViewComponent
    {
        private IBookstoreRepository _bookRepo;
        public ProjectTypesViewComponent(IBookstoreRepository temp) {
            _bookRepo = temp;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedProjectType = RouteData?.Values["projectType"];

            var projectTypes = _bookRepo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(projectTypes);
        }
    }
}
