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

    excluir(data: any) {
        return this.post<any>('horariosreagendar', data);
    }

    buscarDesafioPorId(id: number) {
        return this.get<any[]>('listarTV', id);
    }

    listarDesafios() {
        return this.get<any>('');
    }
}
