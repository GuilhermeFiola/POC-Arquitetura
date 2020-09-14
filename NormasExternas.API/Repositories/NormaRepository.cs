using NormasExternas.WebAPI.Data;
using NormasExternas.WebAPI.Entities;
using NormasExternas.WebAPI.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace NormasExternas.WebAPI.Repositories
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
            return _context.Normas;
        }

        public Norma GetById(int id)
        {
            return _context.Normas.FirstOrDefault(w => w.Id == id);
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
