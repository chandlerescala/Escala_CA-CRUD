using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Escala_CA_CRUD.Repository;

namespace Escala_CA_CRUD.Controllers
{
    public class BaseController : Controller
    {
        public dbsys32Entities _db;
        public BaseRepository<user> _userRepo;
        public BaseController()
        {
            _db = new dbsys32Entities();
            _userRepo = new BaseRepository<user>();
        }
    }
}