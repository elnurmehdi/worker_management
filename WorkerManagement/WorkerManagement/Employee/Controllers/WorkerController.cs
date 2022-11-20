using Microsoft.AspNetCore.Mvc;

namespace WorkerManagement.Employee.Controllers
{
    public class WorkerController : Controller
    {
        public ActionResult List()
        {
            return View();
        }
    }
}
