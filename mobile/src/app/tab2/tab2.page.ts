import { Component } from '@angular/core';
import { CargoService } from '../services/cargo.service';

@Component({
  selector: 'app-tab2',
  templateUrl: 'tab2.page.html',
  styleUrls: ['tab2.page.scss']
})
export class Tab2Page {

  cargos: any[] = [];
  cargos2: any[] = [];
  myInput = '';

  constructor(private cargoService: CargoService) {
    this.cargoService.obterCargos().subscribe(result => {
      this.cargos = result.data;
      this.cargos2 = result.data;
    });
  }

  // teste() {
  //   if (this.myInput === '') {
  //     this.cargos = this.cargos2;
  //   }
  //   else {
  //     this.cargos = this.cargos.filter(item => { item.nome.toLowerCase().indexOf(this.myInput.toLowerCase()) > -1; });
  //   }
  // }

}
