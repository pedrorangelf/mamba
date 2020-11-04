export interface DesafioModel {
  id: string;
  cargoId: string;
  limiteInscricao: number;
  dataAbertura: Date;
  dataFechamento: Date;
  questoes: QuestaoModel[];
}

export interface QuestaoModel {
  idQuestao: number;
  descricao: string;
}
