import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TaskBoardsService } from '../services/taskboards.service';
import { TaskBoard } from '../interfaces/TaskBoard';

@Component({
  selector: 'app-taskboard',
  templateUrl: './taskboard.component.html',
  styleUrls: ['./taskboard.component.css'] // Corrected from 'styleUrl' to 'styleUrls'
})
export class TaskboardComponent implements OnInit {
  taskBoard: TaskBoard | null = null;
  constructor(
    private route: ActivatedRoute,
    private taskBoardService: TaskBoardsService
  ) { }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.taskBoardService.getTaskBoard(id);
      } else {
        // Handle the situation where id is null
        console.error('Taskboard ID not found in route parameters');
      }
    });
  }
}
