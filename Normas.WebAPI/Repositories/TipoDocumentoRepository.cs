using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Normas.WebAPI.Repositories
{
    public class TipoDocumentoRepository : ITipoDocumentoRepository
    {
        IEnumerable<TipoDocumento> _tipoDocumentos;

        public TipoDocumentoRepository()
        {
            _tipoDocumentos = new List<TipoDocumento>()
            {
                new TipoDocumento() { Id = 0, Descricao = "Indefinido"},
                new TipoDocumento() { Id = 1, Descricao = "Norma de Base"},
                new TipoDocumento() { Id = 2, Descricao = "Norma de Terminologia"},
                new TipoDocumento() { Id = 3, Descricao = "Norma de Ensaio"},
                new TipoDocumento() { Id = 4, Descricao = "Norma de Produto"},
                new TipoDocumento() { Id = 5, Descricao = "Norma de Processo"},
                new TipoDocumento() { Id = 6, Descricao = "Norma de Serviço"},
            };
        }

        public IEnumerable<TipoDocumento> GetAll()
        {
            return _tipoDocumentos;
        }

        public TipoDocumento GetById(int id)
        {
            return _tipoDocumentos.FirstOrDefault(w => w.Id == id);

        }
    }
}
