using Library_Automation.Entities.DAL;
using Library_Automation.Entities.Model;
using Library_Automation.Entities.Model.Contacts;
using System.Linq;
using System.Web.Mvc;

namespace Library_Automation_Project.Controllers
{
    [AllowAnonymous]
    public class BooksController : Controller
    {
       
        KutuphaneContext context = new KutuphaneContext();
        KitaplarDAL kitaplarDAL = new KitaplarDAL();

        // GET: Books
        public ActionResult Index()
        {
            var model = kitaplarDAL.GetAll(context, x => !x.SilindiMi, "KitapTurleri");
            return View(model);
        }

        // GET: Books/Detail/5
        public ActionResult Detail(int? id)
        {
            if (id == null)
                return HttpNotFound();

            var model = kitaplarDAL.GetByFilter(context, x => x.Id == id, "KitapTurleri");
            if (model == null)
                return HttpNotFound();

            return View(model);
        }
    }
}
