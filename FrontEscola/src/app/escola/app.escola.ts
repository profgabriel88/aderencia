import { Component, Input, OnInit, signal } from "@angular/core";
import { HttpService } from "../services/http.service";
import { CommonModule } from "@angular/common";
import { Curso } from "../interfaces/curso.interface";
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from "@angular/router";
import { EventoService } from "../services/evento.service";
import { EDITANDO, NOVO, RELATORIO_GERAL, TOAST } from "../constantes";
import { AppCursoDetalhes } from "../cursos/curso-detalhes/curso-detalhes";
import { AppRelatorio } from "../shared/relatorio/relatorios";
import { AppAutocomplete } from "../shared/autocomplete/autocomplete";
import { AppToast } from "../shared/toast/toast";

@Component({
    selector: 'app-escola',
    standalone: true,
    imports: [RouterLink, RouterOutlet, CommonModule, AppCursoDetalhes, AppRelatorio, AppAutocomplete, AppToast],
    templateUrl: './app.escola.html',
    styleUrl: './app.escola.css'
})
export class AppEscola implements OnInit {
    usuario: string = 'Gabriel';
    curso: Curso = {id: 0, nome: '', alunos: []};
    cursos: Array<Curso> = [];
    relatorios: Array<any> = [];
    nome: string = '';
    editando = false;
    novo = false;
    erro = '';

    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _cursoService: EventoService
    ) {}

    ngOnInit() {
        this._httpService.get('Cursos').subscribe({
            next: (dados) => {
                this.cursos = dados.lista;
            },
            error: (e) => {
                this.erro = e.error.erro
                this._cursoService.eventEmitter.emit({nome: TOAST, valor: true});
            }
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

    cancela() {
        this.relatorios = [];
    }
}