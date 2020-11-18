import { DesafioService } from './../../services/desafio.service';
import { Component, OnInit } from '@angular/core';
import Chart from 'chart.js';

// core components
import {
  chartOptions,
  parseOptions,
  chartExample1,
  chartExample2
} from '../../variables/charts';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {

  public datasets: any;
  public data: any;
  public salesChart;
  public clicked = true;
  public clicked1 = false;
  public desafios = [];

  constructor(private desafioService: DesafioService, private router: Router) {
  }

  ngOnInit() {

    this.listarDesafios();

    this.datasets = [
      [0, 20, 10, 30, 15, 40, 20, 60, 60],
      [0, 20, 5, 25, 10, 30, 15, 40, 40]
    ];
    this.data = this.datasets[0];

    const chartOrders = document.getElementById('chart-orders');

    parseOptions(Chart, chartOptions());

    if (chartOrders) {
      const ordersChart = new Chart(chartOrders, {
        type: 'bar',
        options: chartExample2.options,
        data: chartExample2.data
      });
    }

    const chartSales = document.getElementById('chart-sales');

    if (chartSales) {
      this.salesChart = new Chart(chartSales, {
        type: 'line',
        options: chartExample1.options,
        data: chartExample1.data
      });
    }
  }


  listarDesafios() {
    this.desafioService.listarDesafios().subscribe(result => {
      this.desafios = result.data;
    });
  }



  public updateOptions() {
    this.salesChart.data.datasets[0].data = this.data;
    this.salesChart.update();
  }

  public excluir(id: string) {
    this.desafioService.excluir(id).subscribe(() => {
      this.listarDesafios();
    });
  }

  editar(id: any): void {
    this.router.navigate(['desafio/' + id]);

    // this.dialogFormCreateOrEditService
    //   .open({ title: `${acao} Funcionário`, model: row }, FuncionarioEditComponent)
    //   .pipe(take(1))
    //   .subscribe((res: boolean) => { if (res) { this.listarFuncionarios(); } });
  }

  visualizarDetalhes(id: any) {
    this.router.navigate(['vaga/' + id]);
  }

}
