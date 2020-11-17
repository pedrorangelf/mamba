
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { DataService } from './data.service';

@Injectable({
  providedIn: 'root'
})
export class CargoService extends DataService {

  private accessToken: string;
  context = 'cargo';

  obterCargos() {
    return this.get<any>('');
  }
}
