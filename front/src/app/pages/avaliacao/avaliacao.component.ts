import { DesafioService } from '../../services/desafio.service';
import { DesafioModel, InscricaoModel, RespostaModel } from '../../shared/model/desafio-add.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { QuestaoModel } from 'src/app/shared/model/desafio-add.model';
import Swal from 'sweetalert2';
import { CargoService } from 'src/app/services/cargo.service';
import { EnderecoModel } from '../../shared/model/desafio-add.model';
import { InscricaoService } from 'src/app/services/inscricao.service';
import { AvaliacaoModel, QuestaoAvaliacaoModel } from 'src/app/shared/model/questao-avaliacao.model';
import { AvalicaoAvaliacoesModel } from './../../shared/model/questao-avaliacao.model';
import { AvaliacaoService } from 'src/app/services/avaliacao.service';

@Component({
  selector: 'app-avaliacao',
  templateUrl: './avaliacao.component.html',
  styleUrls: ['./avaliacao.component.scss']
})
export class AvaliacaoComponent implements OnInit {

  formGroup: FormGroup;
  idInscricao: string;
  desafio: any = {};
  inscricao: any = {};
  questoes: QuestaoAvaliacaoModel[] = [];
  avaliacoes: AvalicaoAvaliacoesModel[] = [];
  textoCorrecao = 'Correção Pendente';
  classDiv = '';
  icon = '';

  respostas: RespostaModel[] = [];

  constructor(private avaliacaoService: AvaliacaoService,
    private formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private router: Router,
    private desafioService: DesafioService,
    private inscricaoService: InscricaoService) {
    this.idInscricao = this._activatedRoute.snapshot.params.id ?? null;

    if (this._activatedRoute.snapshot.params.id) {

      this.inscricaoService.obterDetalhesInscricao(this.idInscricao).subscribe((result => {
        this.inscricao = result.data;
        this.questoes = result.data.questoes;
        if (this.inscricao.aprovado) {
          this.textoCorrecao = 'Aprovado!';
          this.classDiv = 'icon icon-shape bg-success text-white rounded-circle shadow';
          this.icon = 'fas fa-check';
        } else if (this.inscricao.aprovado === null) {
          this.textoCorrecao = 'Correção Pendente';
          this.classDiv = 'icon icon-shape bg-yellow text-white rounded-circle shadow';
          this.icon = 'fas fa-edit';
        } else {
          this.textoCorrecao = 'Reprovado';
          this.classDiv = 'icon icon-shape bg-danger text-white rounded-circle shadow';
          this.icon = 'fas fa-times';
        }
      }));
    }
  }

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      parecerFinal: ['', Validators.required]
    });

  }

  salvar() {
    this.questoes.forEach(f => {
      const avaliacao = {} as AvalicaoAvaliacoesModel;
      if (f.avaliacao.aprovado == null) {
        avaliacao.correta = false;
      } else {
        avaliacao.correta = f.avaliacao.aprovado;
      }
      avaliacao.descricao = f.avaliacao.descricao;
      avaliacao.respostaId = f.resposta.respostaId;
      this.avaliacoes.push(avaliacao);
    });

    const acertos = this.avaliacoes.filter(f => f.correta === true);
    const porcentagem = acertos.length * 100 / this.questoes.length;

    const model: AvaliacaoModel = {
      desafioId: this.inscricao.desafioId,
      inscricaoId: this.idInscricao,
      candidatoAprovado: porcentagem > 60 ? true : false,
      parecerFinal: this.formGroup.value.parecerFinal,
      avaliacoes: this.avaliacoes
    };

    this.avaliacaoService.salvar(model).subscribe(result =>  this.router.navigate(['vaga/' + this.inscricao.desafioId]));
  }

  voltar() {

    this.router.navigate(['vaga/' + this.inscricao.desafioId]);

  }

}
