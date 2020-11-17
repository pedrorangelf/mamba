import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProcessoService } from './processo.service';

@Component({
  selector: 'app-processo',
  templateUrl: './processo.page.html',
  styleUrls: ['./processo.page.scss'],
})
export class ProcessoPage implements OnInit {

  detalhe: any = {};

  constructor(private route: ActivatedRoute,
              public router: Router,
              private activatedRoute: ActivatedRoute,
              private processoService: ProcessoService) {


    // console.log(this.route.snapshot);

    if (this.route.snapshot.data['desafio']) {
      this.detalhe = this.route.snapshot.data['desafio'];
    }

    // this.route.queryParams.subscribe(params => {
    //   this.detalhe = JSON.parse(this.route.snapshot.params.queryParams);
    //   console.log(this.detalhe);
    //   console.log(params.desafio);
    //   if (params && params.desafio) {
    //     this.detalhe = JSON.parse(params.desafio);
    //   }
    // });

  }

  ngOnInit() {
  }

  voltar() {
    this.router.navigate(['/tabs']);
  }

  obterDesafio(id: any) {
    this.processoService.listarDesafio(id).subscribe(result => {
      console.log(result);
      this.detalhe = result.data;
    });
  }

}
