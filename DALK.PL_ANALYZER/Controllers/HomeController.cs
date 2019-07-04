using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DALK.PL_ANALYZER.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public PartialViewResult _LeftSideBar()
        {
            return PartialView();
        }

        public PartialViewResult _DetachedLeftSideBar()
        {
            return PartialView();
        }

        public PartialViewResult _Footer()
        {
            return PartialView();
        }

        public PartialViewResult _HorizontalNav()
        {
            return PartialView();
        }

        public PartialViewResult _LeftSideBarLight()
        {
            return PartialView();
        }

        public PartialViewResult _RightSideBar()
        {
            return PartialView();
        }

        public PartialViewResult _TopBarDark()
        {
            return PartialView();
        }

        public PartialViewResult _TopBar()
        {
            return PartialView();
        }

        public ViewResult Test()
        {
            Person t = new Person() { Name = "test1!", Phone = "test2..." };
            return View(t);
        }

        /*
         * 
         *     
      function send() {
        var person = {
            name:"Pawel",
            address:"add",
            phone:"333-333-444"
        };

        $('#target').html('sending..');

        $.ajax({
            url: '/Home/Test',
            type: 'post',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                window.alert('ok');
            },
            data: JSON.stringify(person)
        });
    }
         * 
         * 
         */

        [HttpPost]
        public ViewResult Test(Person person)
        {
            return View(person);
        }
    }
}