import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class RecetarioService {

  constructor(private http: HttpClient) { }

  getRecetarios() {
    return this.http.get('https://localhost:5001/api/Recetario');
  }

  getRecetarioById(id: number) {
    return this.http.get('https://localhost:5001/api/Recetario/' + id);
  }


  getComidasDeRecetario(id: number) {
    return this.http.get('https://localhost:5001/api/Recetario/' + id + '/Comidas');
  }
}
