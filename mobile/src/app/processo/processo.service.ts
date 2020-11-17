import { Injectable } from '@angular/core';
import { DataService } from '../services/data.service';

@Injectable({
    providedIn: 'root'
})
export class ProcessoService extends DataService {

    context = 'desafio';

    listarDesafio(id: any) {
        return this.get<any>(id);
    }
}
