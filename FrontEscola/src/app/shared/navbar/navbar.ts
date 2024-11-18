import { CommonModule } from "@angular/common";
import { Component } from "@angular/core";
import { RouterLink } from "@angular/router";

@Component({
    selector: 'app-nav',
    standalone: true,
    imports: [CommonModule, RouterLink],
    templateUrl: './navbar.html',
    styleUrl: './navbar.css'
})
export class AppNav {

}