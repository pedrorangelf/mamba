import { DesafioService } from './../../services/desafio.service';
import { DesafioModel } from './../../shared/model/desafio-add.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { QuestaoModel } from 'src/app/shared/model/desafio-add.model';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-desafio',
  templateUrl: './desafio.component.html',
  styleUrls: ['./desafio.component.scss']
})
export class DesafioComponent implements OnInit {

  formGroup: FormGroup;
  idDesafio: number;
  title = 'Cadastar Vaga';
  subtitle = 'Nova Vaga';
  desafio: any = {};
  questoes: QuestaoModel[] = [];

  constructor(private formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private router: Router,
    private desafioService: DesafioService) {
    this.idDesafio = this._activatedRoute.snapshot.params.id ?? 0;
    console.log(this._activatedRoute.snapshot.params.id);

    if (this._activatedRoute.snapshot.params.id > 0) {
      this.title = 'Editar Vaga';
      this.desafioService.buscarDesafioPorId(this.idDesafio).subscribe((result) => {
        this.desafio = result;
        this.subtitle = this.desafio.titulo;
        this.questoes = this.desafio.questoes;
      });
    }
  }

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      titulo: [this.desafio.titulo],
      descricao: [this.desafio.descricao]
    });

  }

  salvar() {
    const model: DesafioModel = {
      descricao: this.formGroup.value.descricao ?? this.desafio.descricao,
      titulo: this.formGroup.value.titulo ?? this.desafio.titulo,
      idDesafio: this.idDesafio,
      questoes: this.questoes
    };
    if (this.idDesafio > 0) {
      this.desafioService.editar(model).subscribe(result => {
        Swal.fire({
          title: 'Vaga salva com sucesso!',
          // text: 'Deseja continuar cadastrando ?',
          showCancelButton: false,
          confirmButtonColor: '#29b6f6',
          cancelButtonColor: '#ef9a9a',
          confirmButtonText: 'Ok',
        }).then(
          s => {
            if (s.value) {
              this.router.navigate(['dashboard']);
            } else {
              this.router.navigate(['dashboard']);
            }
          }
        );
      });
    } else {
      this.desafioService.salvar(model).subscribe(result => {
        Swal.fire({
          title: 'Desafio salvo com sucesso!',
          text: 'Deseja continuar cadastrando ?',
          showCancelButton: true,
          confirmButtonColor: '#29b6f6',
          cancelButtonColor: '#ef9a9a',
          confirmButtonText: 'Sim',
          cancelButtonText: 'Não'
        }).then(
          s => {
            if (s.value) {
              this.router.navigate(['desafio']);
            } else {
              this.router.navigate(['dashboard']);
            }
          }
        );
      });
    }

  }

  cancelar() {
    if (this.formGroup.dirty) {
      Swal.fire({
        title: 'Deseja abandonar?',
        text: 'Se você sair os dados alterados não serão salvos.',
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
    }
  }

  addQuestao() {
    this.questoes.push({
      descricao: '',
      idQuestao: 0
    });
  }


  removeQuestao(i: number) {
    this.questoes.splice(i, 1);
  }

}
