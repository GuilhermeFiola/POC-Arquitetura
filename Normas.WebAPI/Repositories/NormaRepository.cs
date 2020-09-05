using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Normas.WebAPI.Repositories
{
    public class NormaRepository : INormaRepository
    {
        IEnumerable<Norma> _normas;

        public NormaRepository()
        {
            _normas = new List<Norma>();
        }

        public IEnumerable<Norma> GetAll()
        {
            return _normas;
        }

        public Norma GetById(int id)
        {
            return _normas.FirstOrDefault(w => w.Id == id);
        }

        public Norma Insert(Norma norma)
        {
            norma.Id = _normas.ToList().Max(m => m.Id);
            _normas.ToList().Add(norma);
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
            _normas.ToList().Remove(normaLista);
            return normaLista;
        }
    }
}
