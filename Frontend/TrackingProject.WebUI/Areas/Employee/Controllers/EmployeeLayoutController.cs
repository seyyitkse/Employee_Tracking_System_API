using Microsoft.AspNetCore.Mvc;

namespace TrackingProject.WebUI.Areas.Employee.Controllers
{
    [Area("Admin")]
    public class EmployeeLayoutController : Controller
    {      
            public IActionResult EmployeeLayout()
            {
                return View();
            }
            public PartialViewResult PartialHead()
            {
                return PartialView();
            }
            public PartialViewResult PartialSidebar()
            {
                return PartialView();
            }
            public PartialViewResult PartialHeader()
            {
                return PartialView();
            }
            public PartialViewResult PartialScript()
            {
                return PartialView();
            }
    }
}
