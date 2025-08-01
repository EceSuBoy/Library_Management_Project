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

        private KutuphaneContext db = new KutuphaneContext();

        [HttpPost]
        public JsonResult SearchBook(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return Json(new { success = false, message = "Please enter a search term." });
            }

            query = query.ToLower();

            var matchingBooks = db.Kitaplar
                .Include("KitapTurleri")
                .Where(b =>
                    (!string.IsNullOrEmpty(b.KitapAdi) && b.KitapAdi.ToLower().Contains(query)) ||
                    (!string.IsNullOrEmpty(b.Yazari) && b.Yazari.ToLower().Contains(query)) ||
                    (b.KitapTurleri != null && !string.IsNullOrEmpty(b.KitapTurleri.KitapTuru) && b.KitapTurleri.KitapTuru.ToLower().Contains(query)) ||
                    (!string.IsNullOrEmpty(b.Aciklama) && b.Aciklama.ToLower().Contains(query)) // now checks descriptions
                )
                .Select(b => new
                {
                    b.Id,
                    b.KitapAdi,
                    b.Yazari,
                    Genre = b.KitapTurleri.KitapTuru
                })
                .ToList();

            if (matchingBooks.Count == 0)
            {
                return Json(new { success = false, message = "No matching book found." });
            }
            else if (matchingBooks.Count == 1)
            {
                return Json(new
                {
                    success = true,
                    redirectTo = Url.Action("Detail", "Books", new { id = matchingBooks.First().Id })
                });
            }
            else
            {
                return Json(new
                {
                    success = true,
                    multiple = true,
                    books = matchingBooks.Select(b => new
                    {
                        id = b.Id,
                        title = b.KitapAdi,
                        author = b.Yazari,
                        genre = b.Genre,
                        link = Url.Action("Detail", "Books", new { id = b.Id })
                    })
                });
            }
        }


    }
}
