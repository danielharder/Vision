import { Component, Input, OnInit } from '@angular/core';
import { TaskBoardsService } from '../services/taskboards.service';
import { Lane } from '../interfaces/Lane';
@Component({
  selector: 'app-lane',
  templateUrl: './lane.component.html',
  styleUrl: './lane.component.css'
})
export class LaneComponent {
  @Input() boardPK!: string;
  Lanes: Lane[] = [];
  constructor(
    private taskBoardService: TaskBoardsService
  ) { }


  ngOnInit(): void {
    if (this.boardPK) {
      this.taskBoardService.getLanesByBoardId(this.boardPK).subscribe(
        (data: Lane[]) => {
          this.Lanes = data;
          console.log("BoardPK in Taskboard Component: " + this.boardPK);
        },
        (error) => {
          console.error('Error getting Lanes', error);
        }
      );
    }
  }
  addLane(): void {
    if (this.boardPK == null) {
      console.error("Can't add lane, boardID is null or undefined.")
    }

    const newLaneData = {
      name: 'New Lane',
      boardID: this.boardPK
    };

    this.taskBoardService.addLane(newLaneData).subscribe(
      (newLane: Lane) => {
        this.Lanes.push(newLane);
      },
      (error) => {
        console.error('Error adding lane', error);
      }
    );
  }
  deleteLane(laneId: string): void {
    if (confirm('Are you sure you want to delete this lane?')) {
      this.taskBoardService.deleteLane(laneId).subscribe(
        () => {
          this.Lanes = this.Lanes.filter(lane => lane.pk !== laneId);
          console.log('Lane deleted successfully - LaneId:', laneId);
        },
        error => {
          console.error('Error occurred while deleting lane:', error);
        }
      );
    }
  }  
}
