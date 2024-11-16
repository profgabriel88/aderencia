import { Component, Input, OnInit, Output } from "@angular/core";
import { HttpService } from "../services/http.service";
import { CommonModule } from "@angular/common";
import { Curso } from "../interfaces/curso.interface";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { EventoService } from "../services/evento.service";
import { EDITANDO } from "../constantes";

@Component({
    selector: 'app-edita-escola',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './app.edita-escola.html',
    styleUrl: './app.edita-escola.css'
})
export class AppEditaEscola implements OnInit {
    usuario: string = 'Gabriel';
    id: number = 0;
    curso: Curso = {id: 0, nome: '', alunos: []};
    

    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _eventoService: EventoService
    ) {}

    ngOnInit() {
        this._route.params.subscribe((params: Params) => {
            this.id = Number.parseInt(params['id']);
            this._httpService.get(`Cursos/${this.id}`).subscribe(dados => {
                if (dados.erro !== "")
                    console.log(dados.erro);
                this.curso = dados.curso;
                this._eventoService.eventEmitter.emit({nome: EDITANDO, valor: true});
                console.log(this.curso);
            })
        })
    }

    cancelar() {
        this._eventoService.eventEmitter.emit({nome: EDITANDO, valor: false});
        this._router.navigate(['../'], { relativeTo: this._route });
    }
}

