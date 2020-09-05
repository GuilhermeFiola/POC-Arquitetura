using Normas.WebAPI.Entities;
using System.Collections.Generic;

namespace Normas.WebAPI.Interfaces.Repositories
{
    public interface ITipoDocumentoRepository
    {
        IEnumerable<TipoDocumento> GetAll();

        TipoDocumento GetById(int id);
    }
}