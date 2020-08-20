import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RecetarioService } from '../recetario.service';
import { Recetario } from '../interfaces/recetario';
import { Comida } from '../interfaces/comida';

@Component({
  selector: 'app-recetario-comidas',
  templateUrl: './recetario-comidas.component.html',
  styleUrls: ['./recetario-comidas.component.css']
})
export class RecetarioComidasComponent implements OnInit {

  recetario: Recetario = { recetarioId: 0, titulo: '', comidas: [] };
  comidas: Comida[] = [];

  constructor(private route: ActivatedRoute,
              private service: RecetarioService) { }

  ngOnInit(): void {
    this.route.params.subscribe(params => {

      this.service.getComidasDeRecetario(params.id)
          .subscribe((data: Comida[]) => {
            this.comidas = data;
          }, (error) => {
            console.error(error);
          });

      this.service.getRecetarioById(params.id)
          .subscribe((data: Recetario) => {
            this.recetario = data;
          }, (error) => {
            console.error(error);
          });
    });
  }

}
