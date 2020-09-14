using NormasExternas.WebAPI.Entities;
using System.Collections.Generic;

namespace NormasExternas.WebAPI.Interfaces.Repositories
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
