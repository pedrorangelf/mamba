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
  title = 'Cadastar Desafio';
  desafio: any = {};

  constructor(private formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private router: Router,
    private desafioService: DesafioService) {
    this.idDesafio = this._activatedRoute.snapshot.params.id ?? 0;

    if (this._activatedRoute.snapshot.params.id > 0) { this.title = 'Editar Desafio'; }
  }

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      titulo: [this.desafio.titulo],
      descricao: [this.desafio.descricao],
      questao: ['']
    });
  }

  salvar() {
    const questoes: QuestaoModel[] = [];
    const questao: QuestaoModel = {
      idQuestao: 0,
      descricao: this.formGroup.value.questao
    };

    questoes.push(questao);

    const model: DesafioModel = {
      descricao: this.formGroup.value.descricao,
      titulo: this.formGroup.value.titulo,
      idDesafio: this.idDesafio,
      questoes: questoes
    };

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

          } else {
            this.router.navigate(['dashboard']);
          }
        }
      );
    });

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

}
