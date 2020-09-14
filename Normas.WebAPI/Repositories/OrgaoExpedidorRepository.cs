using Normas.WebAPI.Data;
using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Normas.WebAPI.Repositories
{
    public class OrgaoExpedidorRepository : IOrgaoExpedidorRepository
    {

        private readonly ApiContext _context;

        public OrgaoExpedidorRepository(ApiContext context)
        {
            _context = context;
        }

        public IEnumerable<OrgaoExpedidor> GetAll()
        {
            return _context.OrgaosExpedidores;
        }

        public OrgaoExpedidor GetById(int id)
        {
            return _context.OrgaosExpedidores.FirstOrDefault(w => w.Id == id);
        }
    }
}
