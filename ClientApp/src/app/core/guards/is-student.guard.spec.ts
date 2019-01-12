import { TestBed, async, inject } from '@angular/core/testing';

import { IsStudentGuard } from './is-student.guard';

describe('IsStudentGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [IsStudentGuard]
    });
  });

  it('should ...', inject([IsStudentGuard], (guard: IsStudentGuard) => {
    expect(guard).toBeTruthy();
  }));
});
