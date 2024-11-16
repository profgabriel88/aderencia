import { CommonModule } from "@angular/common";
import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from "@angular/router";
import { Curso } from "../interfaces/curso.interface";
import { HttpService } from "../services/http.service";
import { NOVO } from "../constantes";
import { EventoService } from "../services/evento.service";
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { distinctUntilChanged } from "rxjs";
import { Aluno } from "../interfaces/aluno.interface";

@Component({
    selector: 'app-novo-curso',
    standalone: true,
    imports: [RouterLink, RouterOutlet, CommonModule, FormsModule, ReactiveFormsModule],
    templateUrl: './novo-curso.html',
    styleUrl: './novo-curso.css'
})
export class AppNovoCurso implements OnInit {
    form = new FormGroup({
        nome: new FormControl(''),
        alunos: new FormControl([])
    });

    alunos: Array<Aluno> = [];

    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _eventoService: EventoService
    ) {}

    ngOnInit() {
        // this._eventoService.eventEmitter.emit({nome: NOVO, valor: true});
        
    }

    onAddAlunoVazio() {
        let aluno = {id: 0, nome: '', sobrenome: '', serie: '', turma: '', nota: 0};
        this.alunos.push(aluno);
    }

    onSalvar() {

    }

    cancelar() {
        this._eventoService.eventEmitter.emit({nome: NOVO, valor: false});
        this._router.navigate(['../'], { relativeTo: this._route });
    }

}