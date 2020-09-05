using Normas.WebAPI.Entities;
using System.Collections.Generic;

namespace Normas.WebAPI.Interfaces.Repositories
{
    public interface IOrgaoExpedidorRepository
    {
        IEnumerable<OrgaoExpedidor> GetAll();

        OrgaoExpedidor GetById(int id);

        OrgaoExpedidor Insert(OrgaoExpedidor orgao);

        OrgaoExpedidor Update(OrgaoExpedidor orgao);

        OrgaoExpedidor Delete(int id);
    }
}
