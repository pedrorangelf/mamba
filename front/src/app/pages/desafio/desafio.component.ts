import { DesafioService } from '../../services/desafio.service';
import { DesafioModel } from '../../shared/model/desafio-add.model';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { QuestaoModel } from 'src/app/shared/model/desafio-add.model';
import Swal from 'sweetalert2';
import { CargoService } from 'src/app/services/cargo.service';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-desafio',
  templateUrl: './desafio.component.html',
  styleUrls: ['./desafio.component.scss']
})
export class DesafioComponent implements OnInit {

  formGroup: FormGroup;
  idDesafio: string;
  title = 'Cadastrar Desafio';
  subtitle = 'Novo Desafio';
  desafio: any = {};
  questoes: QuestaoModel[] = [];
  cargos = [];

  constructor(private formBuilder: FormBuilder,
    private _activatedRoute: ActivatedRoute,
    private router: Router,
    private cargoService: CargoService,
    private desafioService: DesafioService,
    private datePipe: DatePipe) {
    this.idDesafio = this._activatedRoute.snapshot.params.id ?? null;

    this.cargoService.listarCargos().subscribe((result) => {
      this.cargos = result.data;
    });

    if (this._activatedRoute.snapshot.params.id) {
      this.title = 'Editar Desafio';
      this.subtitle = 'Editar';
      this.desafioService.buscarDesafioPorId(this.idDesafio).subscribe((result) => {
        this.desafio = result.data;
        this.questoes = this.desafio.questoes;
        this.formGroup.controls['select'].setValue(this.desafio.cargoId, { onlySelf: true });

        this.formGroup.controls['dataAbertura'].setValue(this.formataData(this.desafio.dataAbertura), { onlySelf: true });
        this.formGroup.controls['dataFechamento'].setValue(this.formataData(this.desafio.dataFechamento), { onlySelf: true });
        this.formGroup.controls['limiteInscricao'].setValue(this.desafio.limiteInscricao, { onlySelf: true });
      });
    }
  }

  ngOnInit(): void {

    this.formGroup = this.formBuilder.group({
      select: new FormControl(null),
      dataAbertura: ['', [Validators.required]],
      dataFechamento: ['', [Validators.required]],
      limiteInscricao: ['', [Validators.required]]
    }, { validator: this.dateLessThan('dataAbertura', 'dataFechamento') });

  }

  dateLessThan(from: string, to: string) {
    return (group: FormGroup): { [key: string]: any } => {
      const f = group.controls[from];
      const t = group.controls[to];
      if (f.value > t.value) {
        return {
          dates: 'Data Abertura não pode ser maior que Data Fechamento'
        };
      }
      return {};
    };
  }

  salvar() {
    const model: DesafioModel = {
      cargoId: this.formGroup.value.select ?? this.desafio.cargoId,
      limiteInscricao: this.formGroup.value.limiteInscricao,
      id: this.idDesafio,
      dataAbertura: this.formGroup.value.dataAbertura,
      dataFechamento: this.formGroup.value.dataFechamento,
      questoes: this.questoes
    };

    if (this.idDesafio) {
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
    } else {
      this.router.navigate(['dashboard']);
    }
  }

  addQuestao() {
    this.questoes.push({
      descricao: '',
      idQuestao: 0,
      questaoId: '',
      resposta: ''
    });
  }

  removeQuestao(i: number) {
    this.questoes.splice(i, 1);
  }

  formataData(data: string): string {
    return this.datePipe.transform(new Date(data), 'yyyy-MM-dd');
  }

}
