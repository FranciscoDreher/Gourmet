import { Ingrediente } from './ingrediente';

export interface Comida {
    comidaId: number;
    nombre: string;
    ingredientes: Ingrediente[];
}
