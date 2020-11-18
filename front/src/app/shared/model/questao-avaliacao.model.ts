export interface QuestaoAvaliacaoModel {
  questaoId: string;
  descricao: string;
  resposta: RespostaAvaliacaoModel;
  avaliacao: AvaliacaoQuestaoModel;
}

export interface AvaliacaoQuestaoModel {
  avaliador: string;
  descricao: string;
  aprovado: boolean;
}

export interface RespostaAvaliacaoModel {
  respostaId: string;
  descricao: string;
}

export interface AvaliacaoModel {
  desafioId: string;
  inscricaoId: string;
  candidatoAprovado: boolean;
  parecerFinal: string;
  avaliacoes: AvalicaoAvaliacoesModel[];
}

export interface AvalicaoAvaliacoesModel {
  respostaId: string;
  correta: boolean;
  descricao: string;
}
