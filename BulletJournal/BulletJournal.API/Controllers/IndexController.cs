using BulletJournal.Core.Services;
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
    [Route("Index")]
    public class IndexController : ControllerBase
    {
        private readonly IIndexService _indexService;

        public IndexController(IIndexService indexService)
        {
            _indexService = indexService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Models.Index index)
        {
            await _indexService.CreateIndex(index);
            return Ok(index);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Models.Index index)
        {
            await _indexService.UpdateIndex(index);
            return Ok(index);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var index = await _indexService.GetIndexById(id);
            if (index == null)
                return NotFound();

            return Ok(index);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _indexService.DeleteIndex(id);
            return Ok();
        }



        [Route("{indexId}/topics")]
        [HttpPost]
        public async Task<ActionResult> CreateTopics(string indexId, IEnumerable<Topic> topics)
        {

        }
    }
}
