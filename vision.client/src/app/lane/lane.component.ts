import { Component } from '@angular/core';
import { TaskBoardsService } from '../services/taskboards.service';
import { Lane } from '../interfaces/Lane';

@Component({
  selector: 'app-lane',
  templateUrl: './lane.component.html',
  styleUrl: './lane.component.css'
})
export class LaneComponent {
  Lanes: Lane[] = [];
  constructor(
    private taskBoardService: TaskBoardsService
  ) { }

  ngOnInit(): void {
    this.taskBoardService.getLanes().subscribe(
      (data: Lane[]) => {
        this.Lanes = data;
      },
      (error) => {
        console.error('Error getting Lanes', error);
      }
    );
  }
}
