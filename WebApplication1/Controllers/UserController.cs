﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.BD;
using WebApplication1.Models.TableViewsModel;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lista = null;

            using( CursoMVCEntities db = new CursoMVCEntities() )
            {
                lista = db.user
                    .Where(x => x.idState == 1)
                    .Select(x => new UserTableViewModel
                    {
                        Email = x.email,
                        Id = x.id,
                        Edad = x.edad
                    })
                    .OrderBy(x => x.Email)
                    .ToList();
            }

            return View(lista);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);                
            }

            using ( var db = new CursoMVCEntities() )
            {
                user oUser = new user();
                oUser.idState = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.user.Add(oUser);

                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }
    }
}