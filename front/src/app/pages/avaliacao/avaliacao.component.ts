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
  questoes: any[] = [];
  respostas: RespostaModel[] = [];

  constructor(private formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private router: Router,
    private desafioService: DesafioService,
    private inscricaoService: InscricaoService) {
    this.idInscricao = this._activatedRoute.snapshot.params.id ?? null;

    if (this._activatedRoute.snapshot.params.id) {

      this.inscricaoService.obterDetalhesInscricao(this.idInscricao).subscribe((result => {
        console.log('obterDetalhesInscricao', result);
        this.inscricao = result.data;
        this.questoes = result.data.questoes;
      }));
    }
  }

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      parecerFinal: [{value: '', disabled: this.inscricao.parecerFinal != null ? true : false }, Validators.required],
      celular: ['', Validators.required],
      email: ['', Validators.required],
      dataNascimento: ['', Validators.required],
      linkLinkedin: [''],
      linkGithub: [''],
      profissao: [''],
      endereco: this.formBuilder.group({
        logradouro: ['', Validators.required],
        numero: ['', Validators.required],
        complemento: ['', Validators.required],
        bairro: ['', Validators.required],
        cidade: ['', Validators.required],
        estado: ['', Validators.required],
        cep: ['', Validators.required]
      })
    });

  }

  salvar() {
    console.log(this.formGroup.value.select);

    console.log(this.questoes);

    this.questoes.forEach(f => {
      const resposta = {} as RespostaModel;
      resposta.questaoId = f.questaoId;
      resposta.descricao = f.resposta;
      this.respostas.push(resposta);
    });

    console.log(this.respostas);

    // const model: InscricaoModel = {
    //   desafioId: this.idDesafio,
    //   nome: this.formGroup.value.nome,
    //   celular: this.formGroup.value.celular,
    //   email: this.formGroup.value.email,
    //   dataNascimento: this.formGroup.value.dataNascimento,
    //   linkLinkedin: this.formGroup.value.linkLinkedin,
    //   linkGithub: this.formGroup.value.linkGithub,
    //   profissao: this.formGroup.value.profissao,
    //   endereco: {
    //     logradouro: this.formGroup.value.endereco.logradouro,
    //     numero: this.formGroup.value.endereco.numero,
    //     complemento: this.formGroup.value.endereco.complemento,
    //     bairro: this.formGroup.value.endereco.bairro,
    //     cidade: this.formGroup.value.endereco.cidade,
    //     estado: this.formGroup.value.endereco.estado,
    //     cep: this.formGroup.value.endereco.cep
    //   } as EnderecoModel,
    //   respostas: this.respostas
    // };

    // console.log(JSON.stringify(model));

    // this.inscricaoService.salvar(model).subscribe(result => console.log(result));
  }

  cancelar() {
    if (this.formGroup.dirty) {
      Swal.fire({
        title: 'Deseja abandonar?',
        text: 'Se você sair, todos os dados alterados serão perdidos.',
        showCancelButton: true,
        confirmButtonColor: '#29b6f6',
        cancelButtonColor: '#ef9a9a',
        confirmButtonText: 'Sim',
        cancelButtonText: 'Não'
      }).then(
        s => {
          if (s.value) {
            this.router.navigate(['dashboard']);
          }
        }
      );
    } else {
      this.router.navigate(['dashboard']);
    }
  }

}
