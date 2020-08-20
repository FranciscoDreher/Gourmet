import { Component, OnInit } from '@angular/core';
import { RecetarioService } from '../recetario.service';
import { Router } from '@angular/router';
import { Recetario } from '../interfaces/recetario';

@Component({
  selector: 'app-recetario',
  templateUrl: './recetario.component.html',
  styleUrls: ['./recetario.component.css']
})
export class RecetarioComponent implements OnInit {

  recetarios: Recetario[] = [];

  constructor(private service: RecetarioService,
              private router: Router) { }

  ngOnInit(): void {
    this.service.getRecetarios()
        .subscribe((data: Recetario[]) => {
          this.recetarios = data;
        }, (error) => {
          console.error(error);
        });
  }
}
