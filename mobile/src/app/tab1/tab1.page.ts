import { Component } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { RotaService } from '../services/rota.service';
import { DesafioService } from './desafio.service';

@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page {

  desafiosAbertos: any[] = [];
  desafiosFechados: any[] = [];
  nomeUsuario: string;

  constructor(public desafioService: DesafioService, public router: Router, private dataService: RotaService) {
    this.listarDesafiosAbertos();
    this.listarDesafiosFechados();
    const user = JSON.parse(localStorage.getItem('currentUser'));
    this.nomeUsuario = user.nome;
  }

  listarDesafiosAbertos(){
    this.desafioService.listarDesafiosAbertos().subscribe(result => {
      console.log(result);
      this.desafiosAbertos = result.data;
    });
  }

  listarDesafiosFechados(){
    this.desafioService.listarDesafiosFechados().subscribe(result => {
      console.log(result);
      this.desafiosFechados = result.data;
    });
  }

goToDetalhes(item: any){
  console.log(item);
  const navigationExtras: NavigationExtras = {
    queryParams: {
      desafio: JSON.stringify(item)
    }
  };

  this.dataService.setData(item.id, item);
  this.router.navigateByUrl('processo/' + item.id);
  // this.router.navigate(['processo/', navigationExtras]);
}

}
