using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Normas.WebAPI.Repositories
{
    public class OrgaoExpedidorRepository : IOrgaoExpedidorRepository
    {
        IEnumerable<OrgaoExpedidor> _orgaos;

        public OrgaoExpedidorRepository()
        {
            _orgaos = new List<OrgaoExpedidor>()
            {
                new OrgaoExpedidor() { Id = 0, Descricao = "Indefinido"},
                new OrgaoExpedidor() { Id = 1, Descricao = "ABNT"},
                new OrgaoExpedidor() { Id = 2, Descricao = "ISO"},
            };
        }

        public IEnumerable<OrgaoExpedidor> GetAll()
        {
            return _orgaos;
        }

        public OrgaoExpedidor GetById(int id)
        {
            return _orgaos.FirstOrDefault(w => w.Id == id);
        }

        public OrgaoExpedidor Insert(OrgaoExpedidor orgao)
        {
            orgao.Id = _orgaos.ToList().Max(m => m.Id);
            _orgaos.ToList().Add(orgao);
            return orgao;
        }

        public OrgaoExpedidor Update(OrgaoExpedidor orgao)
        {
            var orgaoLista = GetById(orgao.Id);
            if (orgaoLista == null) return null;

            var orgaoExcluido = Delete(orgao.Id);
            if (orgaoExcluido == null) return null;

            return Insert(orgao);
        }

        public OrgaoExpedidor Delete(int id)
        {
            var orgaoLista = GetById(id);
            if (orgaoLista == null) return null;
            _orgaos.ToList().Remove(orgaoLista);
            return orgaoLista;
        }
    }
}
