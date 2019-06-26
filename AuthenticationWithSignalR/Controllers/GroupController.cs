using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationWithSignalR.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index(string room = "main")
        {
            ViewBag.chatRoom = room;
            return View();
        }
    }
}