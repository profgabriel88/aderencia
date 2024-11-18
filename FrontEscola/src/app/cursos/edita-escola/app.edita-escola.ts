import { Component, Input, OnInit, Output } from "@angular/core";
import { HttpService } from "../../services/http.service";
import { CommonModule } from "@angular/common";
import { Curso } from "../../interfaces/curso.interface";
import { ActivatedRoute, Params, Router } from "@angular/router";
import { EventoService } from "../../services/evento.service";
import { EDITANDO, TOAST } from "../../constantes";
import { AppAutocomplete } from "../../shared/autocomplete/autocomplete";
import * as jspdf from 'jspdf';
import html2canvas from 'html2canvas';
import { AppToast } from "../../shared/toast/toast";

@Component({
    selector: 'app-edita-escola',
    standalone: true,
    imports: [CommonModule, AppAutocomplete, AppToast],
    templateUrl: './app.edita-escola.html',
    styleUrl: './app.edita-escola.css'
})
export class AppEditaEscola implements OnInit {
    usuario: string = 'Gabriel';
    id: number = 0;
    curso: Curso = {id: 0, nome: '', alunos: []};
    alunoCurso: Array<any> = [];
    erro= '';

    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _eventoService: EventoService
    ) {}

    ngOnInit() {
        this._route.params.subscribe((params: Params) => {
            this.id = Number.parseInt(params['id']);
            this._httpService.get(`Cursos/${this.id}`).subscribe({
                next: (dados) => {
                    this.curso = dados.curso;
                    this._eventoService.eventEmitter.emit({nome: EDITANDO, valor: true});
                    console.log(this.curso);
                },
                error: (e) => {
                    this.erro = e.error.erro
                    this._eventoService.eventEmitter.emit({nome: TOAST, valor: true});
                }     
            });
        });
    }

    setOpcao(opacao: any) {
        this.curso.alunos.push(opacao);
        this.alunoCurso.push({
            nome: '',
            novo: true,
            alunosId: opacao.id,
            cursosId: this.curso.id,
            nota: 0
        });
    }

    salvar() {
        this._httpService
        .post(`Cursos/Matriculas/`, this.alunoCurso)
        .subscribe({
            next: (dados) => {
                this._router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
                    this._router.navigate(['../'], { relativeTo: this._route });
                });
            },
            error: (e) => {
                if (e.status == 500 && e.error.indexOf('UniqueConstraintException') > -1) {
                    this.erro = 'Aluno já cadastrado no curso';
                }
                else if (e.status == 400) {
                    this.erro = 'Todos os campos são obrigatórios';
                }
                else
                    this.erro = e.error.erro
                this._eventoService.eventEmitter.emit({nome: TOAST, valor: true});
            } 
        });
    }

    cancelar() {
        this._eventoService.eventEmitter.emit({nome: EDITANDO, valor: false});
        this._router.navigate(['../'], { relativeTo: this._route });
    }

    pdf() {
        document.title = `Relatorio geral alunos-nota ${this.curso.nome}`
        window.print();
        document.title = 'FrontEscola';
    }
}

