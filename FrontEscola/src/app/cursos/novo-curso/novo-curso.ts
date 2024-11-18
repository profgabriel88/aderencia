import { CommonModule } from "@angular/common";
import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute, Router, RouterLink, RouterOutlet } from "@angular/router";
import { Curso } from "../../interfaces/curso.interface";
import { HttpService } from "../../services/http.service";
import { NOVO, TOAST } from "../../constantes";
import { EventoService } from "../../services/evento.service";
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from "@angular/forms";
import { distinctUntilChanged } from "rxjs";
import { Aluno } from "../../interfaces/aluno.interface";
import { AppAutocomplete } from "../../shared/autocomplete/autocomplete";
import { AppToast } from "../../shared/toast/toast";

@Component({
    selector: 'app-novo-curso',
    standalone: true,
    imports: [RouterLink, RouterOutlet, CommonModule, FormsModule, ReactiveFormsModule, AppAutocomplete, AppToast],
    templateUrl: './novo-curso.html',
    styleUrl: './novo-curso.css'
})
export class AppNovoCurso implements OnInit {
    form = new FormGroup({
        nome: new FormControl(''),
        alunos: new FormControl([{}])
    });

    alunos: Array<any> = [];
    autoComplete: Array<Aluno> = [];
    filtrados: Array<Aluno> = [];
    showSearches = false;
    erro = '';

    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _eventoService: EventoService
    ) {}

    ngOnInit() {

    }

    onSalvar() {
        this.form.value.alunos = this.alunos.slice();
        this._httpService.post('Cursos', this.form.value).subscribe({
            next: (dados) => {
                this._router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
                    this._router.navigate(['../'], { relativeTo: this._route });
                });
            },
            error: (e) => {
                if (e.status == 500 && e.error.indexOf('UniqueConstraintException') > -1) {
                    this.erro = 'Curso já cadastrado';
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

    setOpcao(opacao: any) {
        console.log(opacao);
        this.alunos.push(opacao);
        this.showSearches = false;
    }

    cancelar() {
        this._eventoService.eventEmitter.emit({nome: NOVO, valor: false});
        
        this._router.navigate(['../'], { relativeTo: this._route });
    }

    remove(i: number) {
        this.alunos.splice(i, 1);
    }

}