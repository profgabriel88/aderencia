import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute, RouterOutlet } from "@angular/router";
import { EventoService } from "../../services/evento.service";
import { HttpService } from "../../services/http.service";
import { EDITANDO, NOVO, TOAST } from "../../constantes";
import { Aluno } from "../../interfaces/aluno.interface";
import { AppAutocomplete } from "../../shared/autocomplete/autocomplete";

@Component({
    selector: 'app-alunos-lista',
    standalone: true,
    imports: [CommonModule, RouterOutlet, AppAutocomplete],
    templateUrl: './alunos-lista.html',
    styleUrl: './alunos-lista.css'
})
export class AppAlunoLista implements OnInit {
    alunos: Array<any> = [];
    cursos: Array<any> = [];
    cursosNovos: Array<any> = [];
    alunoSelecionado = new Aluno();
    semMatriculas = false;
    matriculaNova = false;
    editando = false;
    novo = false;
    erro = '';
    
    constructor(
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _eventoService: EventoService
    ) { }

    ngOnInit(): void {
        this._httpService.get('Alunos').subscribe({
            next: (dados) => {
                this.alunos = dados.lista;
            },
            error: (e) => console.log(e.error.erro)
        });

        this._eventoService.eventEmitter.subscribe(evento => {
            if (evento.nome === EDITANDO)
                this.editando = evento.valor;
            if (evento.nome === NOVO)
                this.novo = evento.valor;
        });
    }

    onNovo() {
        this.novo = true;
        this._router.navigate(['novo'], { relativeTo: this._route });
    }

    inserirNota(id: number) {
        this.alunoSelecionado = this.alunos.find(a => a.id == id);
        this._httpService.get(`Alunos/Cursos/${id}`).subscribe({
            next: (dados) => {
                if (dados.lista.length == 0) {
                    this.semMatriculas = true;
                    this.matriculaNova = true;
                    this.cursos = [];
                }
                else {
                    this.semMatriculas = false;
                    this.matriculaNova = false;
                    this.cursos = dados.lista;
                }
            },
            error: (e) => {
                this.erro = e.error.erro
                this._eventoService.eventEmitter.emit({nome: TOAST, valor: true});
            }
        });
    }

    incluiNota(nota: string, curso: number) {
        let i = this.cursos.findIndex(c => c.cursosId == curso);
        this.cursos[i].nota = Number.parseFloat(nota);
        console.log(this.cursos[i]);
    }

    salvarNotas() {
        this._httpService
        .post(`Alunos/Notas/${this.alunoSelecionado.id}`, this.cursos)
        .subscribe(dados => {
            this.alunoSelecionado = new Aluno();
            this.cursos = [];
        });
    }

    setOpcao(opacao: any) {
        this.cursos.push({
            alunosId: this.alunoSelecionado.id,
            cursosId: opacao.id,
            nome: opacao.nome,
            nota: 0.0,
            novo: true
        });
        this.semMatriculas = false;
    }
}