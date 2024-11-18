import { CommonModule } from "@angular/common";
import { Component, Input } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { RELATORIO_GERAL, TOAST } from "../../constantes";
import { EventoService } from "../../services/evento.service";
import { HttpService } from "../../services/http.service";
import { HttpParams } from '@angular/common/http';
import { AppAutocomplete } from "../autocomplete/autocomplete";
import { FormsModule } from "@angular/forms";
import { AppToast } from "../toast/toast";

@Component({
    selector: 'app-relatorio',
    standalone: true,
    imports: [CommonModule, AppAutocomplete, FormsModule, AppToast],
    templateUrl: './relatorios.html',
    styleUrl: './relatorios.css'
})
export class AppRelatorio {
    @Input() relatorios: Array<any> = [];
    filtroCurso: any;
    serie = '';
    turma = '';
    erro = '';
    exibe = false;

    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _cursoService: EventoService
    ) {}

    setSelecionado(event: any) {
        this.filtroCurso = event;
    }

    gerarRelatorio() {
        console.log(' ')
        let params = new HttpParams();
        if (this.filtroCurso?.id)
            params = params.set('curso', this.filtroCurso?.id);
        if (this.serie !== '')    
            params = params.set('serie', this.serie)
        if (this.turma !== '')
            params = params.set('turma', this.turma);

        this._httpService.get(RELATORIO_GERAL, params).subscribe({
            next: (dados) => {
            this.relatorios = dados.lista;
            },
            error: (e) => {
                this.erro = e.error.erro
                this._cursoService.eventEmitter.emit({nome: TOAST, valor: true});
            }
        });
    }

    limpa() {
        this.serie = '';
        this.turma = '';
        this.filtroCurso = {};
    }

    pdf() {
        document.title = `Relatorio geral alunos-nota`
        window.print();
        document.title = 'FrontEscola';
    }
}