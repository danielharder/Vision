import { Component, OnInit } from '@angular/core';
import { TaskBoardsService } from '../services/taskboards.service';
import { TaskBoard } from '../interfaces/TaskBoard';
import { Router } from '@angular/router';

@Component({
  selector: 'app-taskboards',
  templateUrl: './taskboards.component.html',
  styleUrl: './taskboards.component.css'
})
export class TaskboardsComponent implements OnInit {
  taskBoards: TaskBoard[] = [];
  constructor(private taskBoardService: TaskBoardsService, private router: Router) {  }
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
  onTaskBoardClick(taskBoard: TaskBoard): void {
    this.router.navigate(['/taskboard', taskBoard.pk]);
  }
}
