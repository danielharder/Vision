import { Injectable } from '@angular/core';
import { TaskBoard } from '../interfaces/TaskBoard';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskBoardsService {
  private taskBoards: TaskBoard[] = [];
  private apiUrl = 'https://localhost:7010/TaskBoard';

  constructor(private http: HttpClient) { }

  getTaskBoards(): Observable<TaskBoard[]> {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${sessionStorage.getItem('jwt')}`
    });
    return this.http.get<TaskBoard[]>(this.apiUrl, { headers });
  }

  getTaskBoard(pk: string): TaskBoard | undefined {
    return this.taskBoards.find(board => board.pk === pk);
  }

  addTaskBoard(taskBoard: TaskBoard): void {
    this.taskBoards.push(taskBoard);
  }
}
