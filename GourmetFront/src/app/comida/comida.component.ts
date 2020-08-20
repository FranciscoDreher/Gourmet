import { Component, OnInit } from '@angular/core';
import { ComidaService } from '../comida.service';
import { Comida } from '../interfaces/comida';

@Component({
  selector: 'app-comida',
  templateUrl: './comida.component.html',
  styleUrls: ['./comida.component.css']
})
export class ComidaComponent implements OnInit {

  comidas: Comida[] = [];

  constructor(private service: ComidaService) { }

  ngOnInit(): void {
    this.service.getComidas()
        .subscribe((data: Comida[]) => {
          this.comidas = data;
        }, (error) => {
          console.error(error);
        });
  }

}
