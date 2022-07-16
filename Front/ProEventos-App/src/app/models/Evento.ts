import { Lote } from './Lote';
import { Palestrante } from './Palestrante';
import { RedesSociais } from './RedesSociais';

export interface Evento {
  id: number;
  local: string;
  dataEvento?: Date;
  tema: string;
  qtdPessoas: number;
  imagemURL: string;
  telefone: number;
  email: string;
  lotes: Lote[];
  redesSociais: RedesSociais[];
  palestrantesEventos: Palestrante[];
}
