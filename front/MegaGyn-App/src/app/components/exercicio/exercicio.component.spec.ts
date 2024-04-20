/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { ExercicioComponent } from './exercicio.component';

describe('ExercicioComponent', () => {
  let component: ExercicioComponent;
  let fixture: ComponentFixture<ExercicioComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ExercicioComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ExercicioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
