using BulletJournal.Core.Services;
using BulletJournal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BulletJournal.API.Controllers
{
    [ApiController]
    [Route("Journal")]
    [Authorize]
    public class JournalController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(Journal journal)
        {
            await _journalService.SaveJournal(journal);
            return Ok(journal);
        }

        [HttpPut]
        public async Task<ActionResult> Put(Journal journal)
        {
            await _journalService.UpdateJournal(journal);
            return Ok(journal);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> Get(string id)
        {
            var journal = await _journalService.GetJournalById(id);
            if (journal == null)
                return NotFound();

            return Ok(journal);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _journalService.DeleteJournal(id);
            return Ok();
        }


        [HttpGet]
        [Route("/journals/{ownerId}/default")]
        public async Task<IActionResult> GetOwnerDefaultJournal(string ownerId)
        {
            var journal = await _journalService.GetOwnerDefaultJournal(ownerId);
            return Ok(journal);
        }
    }
}
