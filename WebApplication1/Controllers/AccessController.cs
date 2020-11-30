using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.BD;

namespace WebApplication1.Controllers
{
    public class AccessController : Controller
    {
        // GET: Acccess
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string user, string password)
        {
            try
            {
                using (CursoMVCEntities db = new CursoMVCEntities() )
                {
                    var list = db.user
                            .Where(x => x.email == user && x.password == password && x.idState == 1)
                            .FirstOrDefault();

                    if (list != null)
                    {
                        Session["User"] = list;
                        return Content("1");
                    }   else
                    {
                        return Content("Usuario invalido :(");
                    }
                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :( " + ex.Message);
            }
        }
    }
}