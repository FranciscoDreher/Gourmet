import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RecetarioComponent } from './recetario/recetario.component';
import { RecetarioComidasComponent } from './recetario-comidas/recetario-comidas.component';
import { ComidaComponent } from './comida/comida.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'recetarios' },
  { path: 'recetarios', component: RecetarioComponent },
  { path: 'recetarios/:id/comidas', component: RecetarioComidasComponent },
  { path: 'comidas', component: ComidaComponent },
  { path: '**', redirectTo: 'recetarios' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
