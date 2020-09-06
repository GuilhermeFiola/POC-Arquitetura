using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Linq;

namespace Normas.WebAPI.Services
{
    public class OrgaoExpedidorService : IOrgaoExpedidorService
    {
        private readonly IOrgaoExpedidorRepository _orgaoExpedidorRepository;
        public OrgaoExpedidorService(IOrgaoExpedidorRepository orgaoExpedidorRepository)
        {
            _orgaoExpedidorRepository = orgaoExpedidorRepository;
        }

        public int BuscarOrgaoExpedidorPorDescricao(string descricaoOrgao)
        {
            try
            {
                return _orgaoExpedidorRepository.GetAll().FirstOrDefault(w => w.Descricao.Contains(descricaoOrgao)).Id;
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro na busca do órgão expedidor por descrição.", ex);
            }
        }
    }
}
