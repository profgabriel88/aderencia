import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from "@angular/router";
import { Curso } from "../interfaces/curso.interface";
import { HttpService } from "../services/http.service";
import { EventoService } from "../services/evento.service";
import { EDITANDO } from "../constantes";

@Component({
    selector: 'app-curso-detalhes',
    standalone: true,
    imports: [RouterLink, RouterOutlet, CommonModule],
    templateUrl: './curso-detalhes.html',
    styleUrl: './curso-detalhes.css'
})
export class AppCursoDetalhes {
    @Input() curso: Curso = {id: 0, nome: '', alunos: []};
    
    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _eventoService: EventoService
    ) {}

    editarCurso() {
        this._eventoService.eventEmitter.emit({nome: EDITANDO, valor: true});
        this._router.navigate([this.curso.id], {relativeTo: this._route});
    }
}