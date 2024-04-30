/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ExercicioServiceService } from './exercicioService.service';

describe('Service: ExercicioService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ExercicioServiceService]
    });
  });

  it('should ...', inject([ExercicioServiceService], (service: ExercicioServiceService) => {
    expect(service).toBeTruthy();
  }));
});
