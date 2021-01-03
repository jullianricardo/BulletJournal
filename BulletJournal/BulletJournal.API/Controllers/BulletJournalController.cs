using BulletJournal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.API.Controllers
{
    [ApiController]
    [Route("Journal")]
    public class BulletJournalController : ControllerBase
    {
        
        public ActionResult Post(Journal journal)
        {


            var uri = new Uri("");
            return Created(uri, journal);
        }



    }
}
