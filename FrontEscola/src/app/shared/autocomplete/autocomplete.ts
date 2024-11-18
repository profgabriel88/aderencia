import { CommonModule } from "@angular/common";
import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { EventoService } from "../../services/evento.service";
import { HttpService } from "../../services/http.service";
import { FormsModule } from "@angular/forms";
import { AutoCompleteDirective } from "./autocomplete.directive";

@Component({
    selector: 'app-autocomplete',
    standalone: true,
    imports: [CommonModule, FormsModule, AutoCompleteDirective],
    templateUrl: './autocomplete.html',
    styleUrl: './autocomplete.css'
})
export class AppAutocomplete {
    @Input() url = '';
    @Input() nomeExibicao = '';
    @Input() nomeEntidade = '';
    @Input() apagaBusca = true;
    @Output() selecionado = new EventEmitter<any>();

    autoComplete: Array<any> = [];
    filtrados: Array<any> = [];
    showSearches = false;
    busca = '';

    constructor (
        private _httpService: HttpService,
        private _router: Router,
        private _route: ActivatedRoute,
        private _eventoService: EventoService
    ) {}

    ngOnInit() {
        this._httpService.get(this.url).subscribe(dados => {
            if (dados.erro !== '')
                console.log(dados.erro);

            this.autoComplete = dados.lista;
            console.log(this.autoComplete);
        });
    }

    setOpcao(opcao: any) {
        this.selecionado.emit(opcao);
        this.showSearches = false;
        this.busca = this.apagaBusca ? '' : opcao[this.nomeExibicao];
    }

    mostraOpcoes() {
        if (this.busca === '' || this.busca === '') {
            this.showSearches = false;
            return;
        }
        this.showSearches = true;
        this.filtrados = this.autoComplete.filter(x => x.nome.toLocaleLowerCase().indexOf(this.busca.toLocaleLowerCase()) !== -1 );
    }
}