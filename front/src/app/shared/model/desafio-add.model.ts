export interface DesafioModel {
  idDesafio: number;
  titulo: string;
  descricao: string;
  questoes: QuestaoModel[];
}

export interface QuestaoModel {
  idQuestao: number;
  descricao: string;
}
