import { HttpClient } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class EventoService {
    eventEmitter = new EventEmitter<{nome: string, valor: any}>();
}