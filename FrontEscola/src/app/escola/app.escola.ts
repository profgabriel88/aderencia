import { Component, Input, OnInit, signal } from "@angular/core";
import { HttpService } from "../services/http.service";
import { CommonModule } from "@angular/common";
import { Curso } from "../interfaces/curso.interface";
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from "@angular/router";
import { AppCursoDetalhes } from "../curso-detalhes/curso-detalhes";
import { EventoService } from "../services/evento.service";
import { EDITANDO, NOVO } from "../constantes";

@Component({
    selector: 'app-escola',
    standalone: true,
    imports: [RouterLink, RouterOutlet, CommonModule, AppCursoDetalhes],
    templateUrl: './app.escola.html',
    styleUrl: './app.escola.css'
})
export class AppEscola implements OnInit {
    usuario: string = 'Gabriel';
    curso: Curso = {id: 0, nome: '', alunos: []};
    cursos: Array<Curso> = [];
    nome: string = '';
    editando = false;
    novo = false;

    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _cursoService: EventoService
    ) {}

    ngOnInit() {
        this._httpService.get('Cursos').subscribe(dados => {
            if (dados.erro !== "")
                console.log(dados.erro);
            this.cursos = dados.lista;
            console.log(this.cursos);;
        });
        this._cursoService.eventEmitter.subscribe(evento => {
            if (evento.nome === EDITANDO)
                this.editando = evento.valor;
            if (evento.nome === NOVO)
                this.novo = evento.valor;
        });
    }

    onEdita(event: boolean) {
        this.editando = event;
    }

    onNovo() {
        this.novo = true;
        this._router.navigate(['novo'], {relativeTo: this._route});
    }

    cancelar() {
        this.editando = false;
    }
}