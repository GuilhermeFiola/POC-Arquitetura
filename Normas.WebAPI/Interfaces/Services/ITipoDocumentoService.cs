using Normas.WebAPI.Entities;

namespace Normas.WebAPI.Interfaces.Services
{
    public interface ITipoDocumentoService
    {
        TipoDocumento BuscarTipoDocumentoPorDescricao(string descricaoDocumento);
    }
}
