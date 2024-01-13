import { TestBed } from '@angular/core/testing';

import { TaskboardsService } from './taskboards.service';

describe('TaskboardsService', () => {
  let service: TaskboardsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TaskboardsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
