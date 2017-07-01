using System.Web.Mvc;
using GOOS_Sample.Models;
using GOOS_Sample.Models.ViewModels;
using GOOS_Sample.Services;

namespace GOOS_Sample.Controllers
{
    public class BudgetController : Controller
    {
        private IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        // GET: Budget
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BudgetAddViewModel model)
        {
            _budgetService.Create(model);
            ViewBag.Message = "added successfully";
            return View(model);
        }
    }
}