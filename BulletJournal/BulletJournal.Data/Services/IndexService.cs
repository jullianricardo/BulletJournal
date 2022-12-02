using BulletJournal.Core.Common;
using BulletJournal.Core.Domain;
using BulletJournal.Core.Repositories;
using BulletJournal.Core.Services;
using BulletJournal.Data.Model;
using BulletJournal.Data.Repositories;
using BulletJournal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletJournal.Data.Services
{
    public class IndexService : IIndexService
    {
        private readonly IIndexRepository _indexRepository;

        public IndexService(IIndexRepository indexRepository)
        {
            _indexRepository = indexRepository;
        }

        public async Task<Models.Index> GetIndexById(string id)
        {
            return await _indexRepository.GetIndexById(id);
        }

        public async Task<Models.Index> GetIndexByJournalId(string journalId)
        {
            return await _indexRepository.GetIndexByJournalId(journalId);
        }

        public async Task CreateIndex(Models.Index index)
        {
            await _indexRepository.CreateIndex(index);
        }

        public async Task UpdateIndex(Models.Index index)
        {
            await _indexRepository.UpdateIndex(index);
        }

        public async Task DeleteIndex(string indexId)
        {
            await _indexRepository.DeleteIndex(indexId);
        }
    }
}
