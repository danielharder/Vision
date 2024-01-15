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
  navigateToTaskBoard(taskBoard: TaskBoard): void {
    this.router.navigate(['/taskboard', taskBoard.pk]);
  }

  addTaskBoard(): void {
    const newTaskBoard = {
      name: 'New Task Board',
      description: 'Description of the new task board',
      boardMembers: [
        {
          userPK: '6d76542b-576b-49c0-0d90-08dc15833dd6',
          role: 'Owner'
        }
      ]
    };

    this.taskBoardService.addTaskBoard(newTaskBoard).subscribe(
      (response: TaskBoard) => {
        this.taskBoards.push(response);
      },
      (error) => {
        console.error('Error adding taskboard', error);
      }
    );
  }

}
