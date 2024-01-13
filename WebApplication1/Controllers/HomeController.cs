using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _hostingEnvironment;
        //private readonly ILogger _logger2;

        public HomeController(ILogger<HomeController> logger, IEmployeeRepository employeeRepository, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
        }

      
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Details(int id)
        {

            Employee employee = _employeeRepository.GetEmployee(id);
            if(employee == null)
            {
                Response.StatusCode = 404;

                return View("EmployeeNotFound", id);
            }

            HomeDetailsViewModel hDVM = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };

            return View(hDVM);

        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        { 
            if (ModelState.IsValid)
            {
                string? uniqueFileName = null;

                if(model.Photos != null && model.Photos.Count > 0) {
                    foreach (IFormFile photo in model.Photos)
                    {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName

                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();

        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee emp = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel eEVM = new EmployeeEditViewModel
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Department = emp.Department,
                

            };

            return View(eEVM);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = _employeeRepository.GetEmployee(model.Id);
                emp.Name = model.Name;
                emp.Email = model.Email;
                emp.Department = model.Department;

                
                _employeeRepository.Update(emp);
                return RedirectToAction("Index");
            }
            return View(model);

        }


        public ViewResult List()
        {
            var model = _employeeRepository.GetAllEmployees();

            return View(model);
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
