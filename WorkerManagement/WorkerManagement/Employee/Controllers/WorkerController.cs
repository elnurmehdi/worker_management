using Microsoft.AspNetCore.Mvc;
using WorkerManagement.Database.DataBaseAccess;
using WorkerManagement.Employee.Models;
using WorkerManagement.Employee.ViewModels;

namespace WorkerManagement.Employee.Controllers
{
    [Route("Employee")]
    public class WorkerController : Controller
    {
        #region Read
        [HttpGet("List", Name = "employee-list")]
        public ActionResult List()
        {
            using DataContext dataContext = new DataContext();


            var model = dataContext.Workers
                .Select(e => new ListViewModel(e.EmployeeCode, e.FirstName, e.LastName, e.FatherName, e.IsDeleted))
                .ToList();

            return View("~/Employee/Views/List.cshtml", model);
        }
        #endregion

        #region Add

        [HttpGet("Add", Name = "employee-add")]
        public ActionResult Add()
        {
            return View("~/Employee/Views/Add.cshtml");
        }

        [HttpPost("Add", Name = "employee-add")]
        public ActionResult Add(AddViewModel addModel)
        {

            if (!ModelState.IsValid)
            {
                return View("~/Employee/Views/Add.cshtml");
            }
            using DataContext dataContext = new DataContext();
            dataContext.Workers.Add(new Worker
            {


                EmployeeCode = TableAutoIncrementEmployeeCode.RandomEmployeeCode,

                FirstName = addModel.FirstName,
                LastName = addModel.LastName,
                FatherName = addModel.FatherName,
                Email = addModel.Email,
                FIN = addModel.FIN,
                IsDeleted = default



            });
            dataContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        #endregion

        #region Delete

        [HttpGet("Delete/{employeecode}", Name = "employee-delete")]
        public ActionResult Delete(string employeeCode)
        {
            using DataContext dataContext = new DataContext();

            var employee = dataContext.Workers.FirstOrDefault(e => e.EmployeeCode == employeeCode);

            if (employee == null)
            {
                return NotFound();
            }

            employee.IsDeleted = true;

            dataContext.SaveChanges();

            return RedirectToAction(nameof(List));

        }

        #endregion

        #region Update
        [HttpGet("Update/{employeecode}", Name = "employee-update-employeeCode")]
        public ActionResult Update(string employeecode)
        {
            using DataContext dataContext = new DataContext();

            var employee = dataContext.Workers.FirstOrDefault(e => e.EmployeeCode == employeecode);

            if (employee == null && employee.IsDeleted == true)
            {
                return NotFound();
            }

            var exEmp = new UpdateViewModel(employee.FirstName, employee.LastName, employee.FatherName, employee.Email, employee.FIN, employee.EmployeeCode);
            return View("~/Employee/Views/Update.cshtml", exEmp);
        }
        [HttpPost("Update", Name = "employee-update")]
        public ActionResult Update(UpdateViewModel updatedModel)
        {
            using DataContext dataContext = new DataContext();

            var employee = dataContext.Workers.FirstOrDefault(e => e.EmployeeCode == updatedModel.EmployeeCode);

            if (employee == null && employee.IsDeleted == true)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View("~/Employee/Views/Update.cshtml", updatedModel);
            }
            employee.FirstName = updatedModel.FirstName;
            employee.LastName = updatedModel.LastName;
            employee.FatherName = updatedModel.FatherName;
            employee.Email = updatedModel.Email;
            employee.FIN = updatedModel.FIN;
            dataContext.SaveChanges();



            return RedirectToAction(nameof(List));
        }


        #endregion
    }
}
