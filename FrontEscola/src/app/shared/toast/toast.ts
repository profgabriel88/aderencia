import { CommonModule } from "@angular/common";
import { Component, Input, OnInit } from "@angular/core";
import { EventoService } from "../../services/evento.service";
import { TOAST } from "../../constantes";

@Component({
    selector: 'app-toast',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './toast.html',
    styleUrl: './toast.css'
})
export class AppToast implements OnInit{
    @Input() texto = '';
    @Input() exibe = false;

    constructor (
        private _eventoService: EventoService
    ) {}

    ngOnInit(): void {
        this._eventoService.eventEmitter.subscribe(evento => {
            if (evento.nome == TOAST) {
                this.exibe = evento.valor;
                setTimeout(() => {
                    this.exibe = false;
                }, 4000)
            }
        });
    }
}