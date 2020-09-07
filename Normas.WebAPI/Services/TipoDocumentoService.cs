using Normas.WebAPI.Entities;
using Normas.WebAPI.Interfaces.Repositories;
using Normas.WebAPI.Interfaces.Services;
using System;
using System.Linq;

namespace Normas.WebAPI.Services
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly ITipoDocumentoRepository _tipoDocumentoRepository;
        public TipoDocumentoService(ITipoDocumentoRepository tipoDocumentoRepository)
        {
            _tipoDocumentoRepository = tipoDocumentoRepository;
        }

        public TipoDocumento BuscarTipoDocumentoPorDescricao(string descricaoDocumento)
        {
            try
            {
                return _tipoDocumentoRepository.GetAll().FirstOrDefault(w => w.Descricao.Contains(descricaoDocumento));
            }
            catch(Exception ex)
            {
                throw new Exception("Ocorreu um erro na busca de tipo de documento por descrição.", ex);
            }
        }
    }
}
