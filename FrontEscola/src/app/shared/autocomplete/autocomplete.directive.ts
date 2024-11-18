import { Directive } from "@angular/core";

@Directive({
    selector: 'input[autoCompleteSelection]',
    standalone: true,
    host: {
        '(keydown)': 'onKeyPressed($event)'
    }
})
export class AutoCompleteDirective {
    divAtual = 0;
    divAnterior = 0;
    // nodes!: HTMLCollection;
    // parentNode!: HTMLDivElement;

    onKeyPressed(event: KeyboardEvent) {
        const e: HTMLInputElement = event.target as HTMLInputElement;
        const filhos = e.parentElement!.children;
        let filhosNotNull = filhos as HTMLCollection;
        let parentNode = filhosNotNull!.item(2)! as HTMLDivElement;
        let nodes = filhosNotNull!.item(2)!.children;
        let tam = nodes.length;

        if (event != null && event.key === 'ArrowDown') {
            nodes.item(this.divAnterior % tam)?.classList.remove('resultado-hover');
            nodes.item(this.divAtual % tam)?.classList.add('resultado-hover');
            this.divAnterior = this.divAtual;
            this.divAtual++;
        }

        if (event != null && event.key === 'Enter') {
            let div = nodes.item(this.divAnterior % tam) as HTMLDivElement;
            div.click();
        }

        if (event != null && event.key == 'Escape') {
            e.value = '';
            parentNode.hidden = true;
        }
        else {
            parentNode.hidden = false;
        }
    }
}