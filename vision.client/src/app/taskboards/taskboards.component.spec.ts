import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskboardsComponent } from './taskboards.component';

describe('TaskboardsComponent', () => {
  let component: TaskboardsComponent;
  let fixture: ComponentFixture<TaskboardsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskboardsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TaskboardsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
