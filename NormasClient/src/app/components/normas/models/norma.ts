import { OrgaoExpedidor } from '../../../shared/models/orgaoExpedidor';
import { TipoDocumento } from '../../../shared/models/tipoDocumento';

export class Norma {
    id: number;
    codigoNorma: string;
    descricao: string;
    tipoDocumento: TipoDocumento;
    orgaoExpedidor: OrgaoExpedidor;
    dataPublicacao: Date;
    resumo: string;
    observacao: string;
    externa: string;
    localArquivoNormas: string;
}
