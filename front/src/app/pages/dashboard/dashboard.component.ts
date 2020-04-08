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

  constructor(private desafioService: DesafioService) { }

  ngOnInit() {

    this.listarDesafios();

    this.datasets = [
      [0, 20, 10, 30, 15, 40, 20, 60, 60],
      [0, 20, 5, 25, 10, 30, 15, 40, 40]
    ];
    this.data = this.datasets[0];


    const chartOrders = document.getElementById('chart-orders');

    parseOptions(Chart, chartOptions());


    const ordersChart = new Chart(chartOrders, {
      type: 'bar',
      options: chartExample2.options,
      data: chartExample2.data
    });

    const chartSales = document.getElementById('chart-sales');

    this.salesChart = new Chart(chartSales, {
      type: 'line',
      options: chartExample1.options,
      data: chartExample1.data
    });
  }


  listarDesafios() {
    this.desafioService.listarDesafios().subscribe(result => {
      console.log(result);
      this.desafios = result;
    });
  }



  public updateOptions() {
    this.salesChart.data.datasets[0].data = this.data;
    this.salesChart.update();
  }

  public excluir(id: number) {
    // LOADING
    this.desafioService.excluir(id).subscribe(() => {
      // FIM LOADING
      // MENSAGEM SUCESSO
      // TRATAR ERRO
      this.listarDesafios();
    });
  }

}
