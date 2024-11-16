import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class HttpService {
    url = 'http://localhost:5224/Api/v1'

    constructor (private _http: HttpClient) {}

    public get(caminho: string): Observable<any> {
        return this._http.get<any>(`${this.url}/${caminho}`);
    }

    public post(caminho: string, obj: any): Observable<any> {
        return this._http.post<any>(`${this.url}/${caminho}`, obj);
    }
}