import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskBoardsService } from '../services/taskboards.service';
import { TaskBoard } from '../interfaces/TaskBoard';

@Component({
  selector: 'app-taskboard',
  templateUrl: './taskboard.component.html',
  styleUrls: ['./taskboard.component.css']
})
export class TaskboardComponent implements OnInit {
  taskBoard: TaskBoard | undefined;
  constructor(
    private route: ActivatedRoute,
    private taskBoardService: TaskBoardsService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.taskBoardService.getTaskBoard(id).subscribe(
          (taskboardData: TaskBoard) => {
            this.taskBoard = taskboardData;
            console.log("BoardPK in Taskboard Component: " + this.taskBoard.pk);
          },
          (error) => {
            console.error('Taskboard fetch error', error);
          }
        );
      } else {
        console.error('Taskboard ID not found in route parameters');
      }
    });
  }
}
