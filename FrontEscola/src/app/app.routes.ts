import { Routes } from '@angular/router';
import { AppEditaEscola } from './cursos/edita-escola/app.edita-escola';
import { AppEscola } from './escola/app.escola';
import { AppNovoCurso } from './cursos/novo-curso/novo-curso';
import { AppAlunoLista } from './alunos/alunos-lista/alunos-lista';
import { AppNovoAluno } from './alunos/novo-aluno/novo-aluno';
import { AppRelatorio } from './shared/relatorio/relatorios';

export const routes: Routes = [
    // { path: '', redirectTo: '/cursos', pathMatch: 'full' },
    { path: 'cursos', component: AppEscola, children: [
        { path: 'novo', component: AppNovoCurso },
        { path: ':id', component: AppEditaEscola }
    ]},
    { path: 'alunos', component: AppAlunoLista, children: [
        { path: 'novo', component: AppNovoAluno },
        // { path: ':id', component: AppEditaEscola }
    ]},
    { path: 'relatorios', component: AppRelatorio }
];
