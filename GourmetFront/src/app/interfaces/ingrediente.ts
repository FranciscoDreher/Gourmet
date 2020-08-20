import { Alimento } from './alimento';

export interface Ingrediente {
    ingredienteId: number;
    cantidad: number;
    unidadDeMedida: number;
    alimento: Alimento;
}
