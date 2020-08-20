import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RecetarioComponent } from './recetario/recetario.component';
import { RecetarioComidasComponent } from './recetario-comidas/recetario-comidas.component';
import { ComidaComponent } from './comida/comida.component';

@NgModule({
  declarations: [
    AppComponent,
    RecetarioComponent,
    RecetarioComidasComponent,
    ComidaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
