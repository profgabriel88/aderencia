import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { EventoService } from "../../services/evento.service";
import { HttpService } from "../../services/http.service";
import { NOVO, TOAST } from "../../constantes";
import { FormsModule, NgForm, ReactiveFormsModule } from "@angular/forms";
import { AppToast } from "../../shared/toast/toast";

@Component({
    selector: 'app-novo-aluno',
    standalone: true,
    imports: [CommonModule, FormsModule, AppToast],
    templateUrl: './novo-aluno.html',
    styleUrl: './novo-aluno.css'
})
export class AppNovoAluno implements OnInit {
    alunos: Array<any> = [];
    editando = false;
    erro = '';
    
    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _eventoService: EventoService
    ) {}

    ngOnInit(): void {
        
    }

    onSalvar(form: NgForm) {
        console.log(form.value);
        this._httpService.post('Alunos', form.value).subscribe({
            next: (dados) => {
                this._router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
                    this._router.navigate(['../'], { relativeTo: this._route });
                });
            },
            error: (e) => {
                if (e.status == 500 && e.error.indexOf('UniqueConstraintException') > -1) {
                    this.erro = 'Aluno já cadastrado';
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
        this._eventoService.eventEmitter.emit({nome: NOVO, valor: false});
        this._router.navigate(['../'], {relativeTo: this._route});
    }
}