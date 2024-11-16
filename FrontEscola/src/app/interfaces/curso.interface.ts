import { Aluno } from "./aluno.interface";

export interface Curso{
    id: number;
    nome: string;
    alunos: Array<Aluno>;
}