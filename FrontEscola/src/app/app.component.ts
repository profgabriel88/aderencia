import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppEscola } from './escola/app.escola';
import { AppEditaEscola } from './cursos/edita-escola/app.edita-escola';
import { AppNav } from './shared/navbar/navbar';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AppEscola, AppEditaEscola, AppNav],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FrontEscola';
}
