using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Interfaces.Services
{
    public interface IOrgaoExpedidorService
    {
        OrgaoExpedidor BuscarOrgaoExpedidorPorDescricao(string descricaoOrgao);
    }
}
