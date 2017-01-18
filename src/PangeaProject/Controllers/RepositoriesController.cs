using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PangeaProject.DAL;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PangeaProject.Controllers
{
    [Route("api/[controller]")]
    public class RepositoriesController : Controller
    {
        private IPangeaRepoDBEntities _Entites;

        public RepositoriesController(PangeaProject.DAL.IPangeaRepoDBEntities Entites)
        {
            _Entites = Entites;
            
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<RepoCopy> Get()
        {
            return _Entites.RepoCopies.ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public RepoCopy Get(string id)
        {
            return _Entites.RepoCopies.FirstOrDefault(r => r.ID == int.Parse(id));
        }
    }
}
