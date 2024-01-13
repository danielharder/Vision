import { Component, OnInit } from '@angular/core';
import { TaskBoardsService } from '../services/taskboards.service';
import { TaskBoard } from '../interfaces/TaskBoard';

@Component({
  selector: 'app-taskboards',
  templateUrl: './taskboards.component.html',
  styleUrl: './taskboards.component.css'
})
export class TaskboardsComponent implements OnInit {
  taskBoards: TaskBoard[] = [];
  constructor(private taskBoardService: TaskBoardsService) {  }
  ngOnInit(): void {
    this.taskBoardService.getTaskBoards().subscribe(
      (data: TaskBoard[]) => {
        this.taskBoards = data;
      },
      (error) => {
        console.error('Error getting taskboards', error);
      }
    );
  }  
}
