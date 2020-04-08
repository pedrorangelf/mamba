import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpParams } from '@angular/common/http';
import { DataService } from './data.service';


@Injectable({
    providedIn: 'root'
})
export class DesafioService extends DataService {

    context = 'desafio';

    salvar(data: any) {
        return this.post<any>('', data);
    }

    excluir(id: number) {
        return this.delete<any>('excluir', id);
    }

    buscarDesafioPorId(id: number) {
        return this.get<any[]>('listarTV', id);
    }

    listarDesafios() {
        return this.get<any>('');
    }
}
