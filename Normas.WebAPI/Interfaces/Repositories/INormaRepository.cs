using Normas.WebAPI.Entities;
using System.Collections.Generic;

namespace Normas.WebAPI.Interfaces.Repositories
{
    public interface INormaRepository
    {
        IEnumerable<Norma> GetAll();

        Norma GetById(int id);

        Norma Insert(Norma norma);

        Norma Update(Norma norma);

        Norma Delete(int id);
    }
}
