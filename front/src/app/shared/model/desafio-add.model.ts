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
  resposta: string;
  questaoId: string;
}

export interface RespostaModel {
  questaoId: string;
  descricao: string;
}

export interface InscricaoModel {
  desafioId: string;
  nome: string;
  celular: string;
  email: string;
  dataNascimento: Date;
  linkLinkedin: string;
  linkGithub: string;
  profissao: string;
  endereco: EnderecoModel;
  respostas: RespostaModel[];
}

export interface EnderecoModel {
  logradouro: string;
  numero: string;
  complemento: string;
  bairro: string;
  cidade: string;
  estado: string;
  cep: string;
}
