import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ComidaService {

  constructor(private http: HttpClient) { }

  getComidas() {
    return this.http.get('https://localhost:5001/api/Comida');
  }
}
