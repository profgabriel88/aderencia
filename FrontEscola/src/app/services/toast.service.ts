import { HttpClient } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class ToastService {
    eventEmitter = new EventEmitter<{nome: string, valor: any}>();
}