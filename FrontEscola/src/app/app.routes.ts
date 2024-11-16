import { Routes } from '@angular/router';
import { AppEditaEscola } from './edita-escola/app.edita-escola';
import { AppEscola } from './escola/app.escola';
import { AppNovoCurso } from './novo-curso/novo-curso';

export const routes: Routes = [
    { path: '', redirectTo: '/cursos', pathMatch: 'full' },
    { path: 'cursos', component: AppEscola, children: [
        { path: 'novo', component: AppNovoCurso },
        { path: ':id', component: AppEditaEscola }
    ]}
];
