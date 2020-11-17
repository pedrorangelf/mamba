import { Injectable } from '@angular/core';
import { DataService } from '../services/data.service';

@Injectable({
    providedIn: 'root'
})
export class DesafioService extends DataService {

    context = 'desafio';

    listarDesafiosAbertos() {
        return this.get<any>('desafios-abertos');
    }

    listarDesafiosFechados() {
        return this.get<any>('desafios-fechados');
    }
}
