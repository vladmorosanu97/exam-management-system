import { TestBed, async, inject } from '@angular/core/testing';

import { IsProfessorGuard } from './is-professor.guard';

describe('IsProfessorGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [IsProfessorGuard]
    });
  });

  it('should ...', inject([IsProfessorGuard], (guard: IsProfessorGuard) => {
    expect(guard).toBeTruthy();
  }));
});
