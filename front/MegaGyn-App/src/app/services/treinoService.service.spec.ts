/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TreinoServiceService } from './treinoService.service';

describe('Service: TreinoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TreinoServiceService]
    });
  });

  it('should ...', inject([TreinoServiceService], (service: TreinoServiceService) => {
    expect(service).toBeTruthy();
  }));
});
