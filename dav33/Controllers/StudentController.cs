using dav33.Data;
using dav33.Models;
using dav33.Repositories;
using System;
using System.Linq;
using System.Web.Mvc;

namespace dav33.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _repository;

        public StudentController()
        {
            _repository = new StudentRepository(new ApplicationDbContext());
        }

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        // GET: Students via AJAX (for dynamic updates)
        [HttpGet]
        public ActionResult GetStudents(string search, string sort, string order, int page = 1, int pageSize = 10)
        {
            var query = _repository.GetAll(
                filter: s => string.IsNullOrEmpty(search) || s.FirstName.Contains(search) || s.LastName.Contains(search),
                orderBy: q =>
                {
                    if (sort == "FirstName")
                        return order == "desc" ? q.OrderByDescending(s => s.FirstName) : q.OrderBy(s => s.FirstName);
                    if (sort == "BirthDate")
                        return order == "desc" ? q.OrderByDescending(s => s.BirthDate) : q.OrderBy(s => s.BirthDate);
                    return q.OrderBy(s => s.Id);
                }
            );

            var totalItems = query.Count();
            var students = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return Json(new
            {
                TotalItems = totalItems,
                Students = students,
                CurrentPage = page,
                PageSize = pageSize
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
