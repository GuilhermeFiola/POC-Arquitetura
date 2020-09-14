using Microsoft.EntityFrameworkCore;
using Normas.WebAPI.Data;
using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Normas.WebAPI.Repositories
{
    public class NormaRepository : INormaRepository
    {
        private readonly ApiContext _context;

        public NormaRepository(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<Norma> GetAll()
        {
            return _context
                    .Normas
                    .Include(o => o.OrgaoExpedidor)
                    .Include(t => t.TipoDocumento);
        }

        public Norma GetById(int id)
        {
            return _context
                    .Normas
                    .Include(o => o.OrgaoExpedidor)
                    .Include(t => t.TipoDocumento)
                    .FirstOrDefault(w => w.Id == id);
        }

        public Norma Insert(Norma norma)
        {
            _context.Normas.Add(norma);
            _context.SaveChanges();

            return norma;
        }

        public Norma Update(Norma norma)
        {
            var normaLista = GetById(norma.Id);
            if (normaLista == null) return null;

            var normaExcluida = Delete(norma.Id);
            if (normaExcluida == null) return null;

            return Insert(norma);
        }

        public Norma Delete(int id)
        {
            var normaLista = GetById(id);
            if (normaLista == null) return null;
            _context.Normas.Remove(normaLista);
            _context.SaveChanges();

            return normaLista;
        }
    }
}
