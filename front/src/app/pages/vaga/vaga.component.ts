
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CandidatoService } from 'src/app/services/candidato.service';
import { DesafioService } from './../../services/desafio.service';

@Component({
  selector: 'app-vaga',
  templateUrl: './vaga.component.html',
  styleUrls: ['./vaga.component.scss']
})
export class VagaComponent implements OnInit {


  candidatos: any[] = [];
  idVaga: string;
  vaga: any = {};

  constructor(private candidatoService: CandidatoService,
    private desafioService: DesafioService,
    private _activatedRoute: ActivatedRoute,
    private router: Router) {
    this.idVaga = this._activatedRoute.snapshot.params.id;
  }

  ngOnInit(): void {
    this.obterCandidatosPorVaga(this.idVaga);

  }

  obterCandidatosPorVaga(id: any) {
    this.candidatoService.obterCandidatosPorVaga(id)
      .subscribe(result => {
        this.obterDetalhesVaga(id);
        this.candidatos = result.data;
      });
  }

  getWidth(acertos: any, total: any) {
    const porcentagem = acertos * 100 / total;

    return porcentagem.toString() + '%';
  }

  getClass(acertos: any, total: any) {
    const porcentagem = acertos * 100 / total;

    if (porcentagem > 60) {
      return 'progress-bar bg-success';
    }

    if (porcentagem < 20) {
      return 'progress-bar bg-danger';
    }

    return 'progress-bar bg-yellow';
  }

  obterDetalhesVaga(id: string) {
    this.desafioService.obterDetalhes(id).subscribe(result => { this.vaga = result.data; console.log(result.data); });
  }

  fecharDesafio() {
    this.desafioService.fecharDesafio(this.idVaga).subscribe(result => this.obterCandidatosPorVaga(this.idVaga));
  }

}
