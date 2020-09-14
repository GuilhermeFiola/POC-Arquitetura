using Normas.WebAPI.Data;
using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Normas.WebAPI.Repositories
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        private readonly ApiContext _context;

        public TipoDocumentoRepository(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<TipoDocumento> GetAll()
        {
            return _context.TiposDocumento;
        }

        public TipoDocumento GetById(int id)
        {
            return _context.TiposDocumento.FirstOrDefault(w => w.Id == id);

        }
    }
}
