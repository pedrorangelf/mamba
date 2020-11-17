import { Injectable, Injector } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { retry } from 'rxjs/operators';
import { environment } from './../../environments/environment';

@Injectable()
export abstract class DataService {

    readonly config = environment.apiUrl;
    abstract context: string;
    currentUser = JSON.parse(localStorage.getItem('currentUser'));

    protected httpOptions = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
            Authorization: `Bearer ${this.currentUser.accessToken}`
        })
    };

    constructor(protected http: HttpClient) {
    }

    protected get<T>(url?: string, resourceId?: number | string): Observable<T> {
        const apiUrl = this.config + '/' + this.context + (url ? '/' + url : '') + (resourceId ? '/' + resourceId : '');
        return this.http.get<T>(apiUrl, this.httpOptions);
    }

    protected getWithParams<T>(url?: string, params?: HttpParams | { [param: string]: string | string[] }): Observable<T> {
        return this.http.get<T>(this.config + '/' + this.context + '/' + (url ? url : ''), { params });
    }

    protected post<T>(url: string, data: any): Observable<T> {
        return this.http.post<T>(this.config + '/' + this.context + '/' + (url ? url : ''), data, this.httpOptions);
    }

    protected delete<T>(url?: string, resourceId?: number | string): Observable<T> {
        return this.http.delete<T>(this.config + '/' + this.context + '/' + (url ? url : '') + '/' + resourceId, this.httpOptions);
    }
}
