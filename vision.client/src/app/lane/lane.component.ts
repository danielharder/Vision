import { Component, Input, OnInit } from '@angular/core';
import { TaskBoardsService } from '../services/taskboards.service';
import { Lane } from '../interfaces/Lane';
import { ActivatedRoute } from '@angular/router';

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
    //const boardID = this.taskBoard?.pk ?? null;
    if (this.boardPK == null) {
      console.error("Can't add lane, boardID is null or undefined.")
    }

    const newLaneData = {
      name: 'New Lane',
      boardID: this.boardPK
    };

    this.taskBoardService.addLane(newLaneData).subscribe(
      (newLane: Lane) => {
        this.taskBoardService.addLane(newLaneData);
        this.Lanes.push(newLane);
      },
      (error) => {
        console.error('Error adding lane', error);
      }
    );
  }
}
