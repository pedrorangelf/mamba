import { DesafioService } from '../../services/desafio.service';
import { DesafioModel, InscricaoModel, RespostaModel } from '../../shared/model/desafio-add.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { QuestaoModel } from 'src/app/shared/model/desafio-add.model';
import Swal from 'sweetalert2';
import { CargoService } from 'src/app/services/cargo.service';
import { EnderecoModel } from './../../shared/model/desafio-add.model';
import { InscricaoService } from 'src/app/services/inscricao.service';

@Component({
  selector: 'app-resposta',
  templateUrl: './resposta.component.html',
  styleUrls: ['./resposta.component.scss']
})
export class RespostaComponent implements OnInit {

  formGroup: FormGroup;
  idDesafio: string;
  desafio: any = {};
  questoes: QuestaoModel[] = [];
  respostas: RespostaModel[] = [];

  constructor(private formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private router: Router,
    private desafioService: DesafioService,
    private inscricaoService: InscricaoService) {
    this.idDesafio = this._activatedRoute.snapshot.params.id ?? null;

    if (this._activatedRoute.snapshot.params.id) {

      this.desafioService.obterVagaInscricao(this.idDesafio).subscribe((result => {
        this.desafio = result.data;
        this.questoes = this.desafio.questoes;
      }));
    }
  }

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      nome: ['', Validators.required],
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
    this.questoes.forEach(f => {
      const resposta = {} as RespostaModel;
      resposta.questaoId = f.questaoId;
      resposta.descricao = f.resposta;
      this.respostas.push(resposta);
    });

    const model: InscricaoModel = {
      desafioId: this.idDesafio,
      nome: this.formGroup.value.nome,
      celular: this.formGroup.value.celular,
      email: this.formGroup.value.email,
      dataNascimento: this.formGroup.value.dataNascimento,
      linkLinkedin: this.formGroup.value.linkLinkedin,
      linkGithub: this.formGroup.value.linkGithub,
      profissao: this.formGroup.value.profissao,
      endereco: {
        logradouro: this.formGroup.value.endereco.logradouro,
        numero: this.formGroup.value.endereco.numero,
        complemento: this.formGroup.value.endereco.complemento,
        bairro: this.formGroup.value.endereco.bairro,
        cidade: this.formGroup.value.endereco.cidade,
        estado: this.formGroup.value.endereco.estado,
        cep: this.formGroup.value.endereco.cep
      } as EnderecoModel,
      respostas: this.respostas
    };

    this.inscricaoService.salvar(model).subscribe(result => {
      Swal.fire({
        title: 'Tudo Certo',
        text: 'Recebemos as suas respostas! Em breve entraremos em contato com você novamente!',
        showCancelButton: false,
        confirmButtonColor: '#29b6f6',
        cancelButtonColor: '#ef9a9a',
        confirmButtonText: 'OK',
      }).then(
        s => {
          if (s.value) {
            this.router.navigate(['login']);
          }
        }
      );
    });
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
