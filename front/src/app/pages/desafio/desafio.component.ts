import { DesafioService } from '../../services/desafio.service';
import { DesafioModel } from '../../shared/model/desafio-add.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { QuestaoModel } from 'src/app/shared/model/desafio-add.model';
import Swal from 'sweetalert2';
import { CargoService } from 'src/app/services/cargo.service';

@Component({
  selector: 'app-desafio',
  templateUrl: './desafio.component.html',
  styleUrls: ['./desafio.component.scss']
})
export class DesafioComponent implements OnInit {

  formGroup: FormGroup;
  idDesafio: string;
  title = 'Cadastar Vaga';
  subtitle = 'Nova Vaga';
  desafio: any = {};
  questoes: QuestaoModel[] = [];
  cargos = [];

  constructor(private formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private router: Router,
    private cargoService: CargoService,
    private desafioService: DesafioService) {
    this.idDesafio = this._activatedRoute.snapshot.params.id ?? null;
    console.log(this._activatedRoute.snapshot.params.id);

    this.cargoService.listarCargos().subscribe((result) => {
      this.cargos = result.data;
    });

    if (this._activatedRoute.snapshot.params.id) {
      this.title = 'Editar Vaga';
      this.subtitle = 'Editar';
      this.desafioService.buscarDesafioPorId(this.idDesafio).subscribe((result) => {
        console.log(result);
        this.desafio = result.data;
        this.questoes = this.desafio.questoes;
        this.formGroup.controls['select'].setValue(this.desafio.cargoId, { onlySelf: true });
      });
    }
  }

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      select: new FormControl(null)
    });

  }

  salvar() {
    console.log(this.formGroup.value.select);
    const model: DesafioModel = {
      cargoId: this.formGroup.value.select ?? this.desafio.cargoId,
      limiteInscricao: 10,
      id: this.idDesafio,
      dataAbertura: new Date(),
      dataFechamento: new Date('2021-01-16'),
      questoes: this.questoes
    };

    console.log(model);
    if (this.idDesafio) {
      console.log('editar');
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
    }
    else {
      this.router.navigate(['dashboard']);
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
