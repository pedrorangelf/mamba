import { DesafioService } from '../../services/desafio.service';
import { DesafioModel, InscricaoModel, RespostaModel } from '../../shared/model/desafio-add.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { QuestaoModel } from 'src/app/shared/model/desafio-add.model';
import Swal from 'sweetalert2';
import { CargoService } from 'src/app/services/cargo.service';
import { EnderecoModel } from './../../shared/model/desafio-add.model';

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
    private desafioService: DesafioService) {
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
        logradouro: this.formGroup.value.profissao,
        numero: this.formGroup.value.profissao,
        complemento: this.formGroup.value.profissao,
        bairro: this.formGroup.value.profissao,
        cidade: this.formGroup.value.profissao,
        estado: this.formGroup.value.profissao,
        cep: this.formGroup.value.profissao
      } as EnderecoModel,
      respostas: this.respostas
    };

    // console.log(model);
    // if (this.idDesafio) {
    //   console.log('editar');
    //   this.desafioService.editar(model).subscribe(result => {
    //     Swal.fire({
    //       title: 'Vaga salva com sucesso!',
    //       // text: 'Deseja continuar cadastrando ?',
    //       showCancelButton: false,
    //       confirmButtonColor: '#29b6f6',
    //       cancelButtonColor: '#ef9a9a',
    //       confirmButtonText: 'Ok',
    //     }).then(
    //       s => {
    //         if (s.value) {
    //           this.router.navigate(['dashboard']);
    //         } else {
    //           this.router.navigate(['dashboard']);
    //         }
    //       }
    //     );
    //   });
    // } else {
    //   this.desafioService.salvar(model).subscribe(result => {
    //     Swal.fire({
    //       title: 'Desafio salvo com sucesso!',
    //       text: 'Deseja continuar cadastrando ?',
    //       showCancelButton: true,
    //       confirmButtonColor: '#29b6f6',
    //       cancelButtonColor: '#ef9a9a',
    //       confirmButtonText: 'Sim',
    //       cancelButtonText: 'Não'
    //     }).then(
    //       s => {
    //         if (s.value) {
    //           this.router.navigate(['desafio']);
    //         } else {
    //           this.router.navigate(['dashboard']);
    //         }
    //       }
    //     );
    //   });
    // }

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
