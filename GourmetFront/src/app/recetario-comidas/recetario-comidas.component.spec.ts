import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecetarioComidasComponent } from './recetario-comidas.component';

describe('RecetarioComidasComponent', () => {
  let component: RecetarioComidasComponent;
  let fixture: ComponentFixture<RecetarioComidasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecetarioComidasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecetarioComidasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
