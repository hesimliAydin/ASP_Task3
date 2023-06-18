using ASP_Task3.Entities;
using ASP_Task3.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ASP_Task3.Controllers
{
    public class StudentController : Controller
    {
        public readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task<IActionResult> Index(string key = "")
        {
            return View(await _studentService.GetAllByKey(key));
        }


        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Student model)
        {
            if (ModelState.IsValid)
            {
                await _studentService.Add(model);
                return RedirectToAction("index");
            }
            else
            {
                return View(model);
            }
        }


        
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var item = await _studentService.GetByIdAsync(id);

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student model)
        {
            if (ModelState.IsValid)
            {
                foreach (var element in await _studentService.GetAllByKey())
                {
                    if (element.Id == model.Id)
                    {
                        element.FirstName = model.FirstName;
                        element.LastName = model.LastName;
                        element.Email = model.Email;
                        element.Birthdate = model.Birthdate;
                        break;
                    }
                }
                _studentService.Update(model);
                return RedirectToAction("index");
            }
            else
            {
                return View(model);
            }
        }


        public async Task<ActionResult> Delete(int id)
        {
            var item = await _studentService.GetByIdAsync(id);
            _studentService.Delete(item);
            return View(item);
        }

        
        public async Task<ActionResult> DeleteItem(int id)
        {
            var item = await _studentService.GetByIdAsync(id);
            _studentService.Delete(item);
            return RedirectToAction("index");
        }


        
        public async Task<ActionResult> Details(int id)
        {
            var data = await _studentService.GetByIdAsync(id);
            return View(data);
        }
    }
}
