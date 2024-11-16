import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AppEscola } from './escola/app.escola';
import { AppEditaEscola } from './edita-escola/app.edita-escola';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AppEscola, AppEditaEscola],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FrontEscola';
}
