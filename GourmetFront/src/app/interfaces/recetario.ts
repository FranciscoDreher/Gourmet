import { Comida } from './comida';

export interface Recetario {
    recetarioId: number;
    titulo: string;
    comidas: Comida[];
}
