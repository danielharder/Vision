import { Injectable } from '@angular/core';
import { TaskBoard } from '../interfaces/TaskBoard';
import { Lane } from '../interfaces/Lane';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskBoardsService {
  private taskBoards: TaskBoard[] = [];
  private TaskboardUrl = 'https://localhost:7010/TaskBoard/';

  constructor(private http: HttpClient) { }

  private GenerateAuthHeader(): HttpHeaders {
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${sessionStorage.getItem('jwt')}`
    });
    return headers;
  }

  getTaskBoards(): Observable<TaskBoard[]> {
    const headers = this.GenerateAuthHeader();
    return this.http.get<TaskBoard[]>(this.TaskboardUrl, { headers });
  }

  getTaskBoard(id: string): Observable<TaskBoard> {
    const headers = this.GenerateAuthHeader();
    return this.http.get<TaskBoard>(this.TaskboardUrl + id, { headers });
  }

  //getTaskBoard(pk: string): TaskBoard | undefined {
  //  // TODO: Use to get single taskboard from HTTP
  //  return this.taskBoards.find(board => board.pk === pk);
  //}

  addTaskBoard(taskBoard: TaskBoard): void {
    // TODO: Refactor to add single taskboard from HTTP
    this.taskBoards.push(taskBoard);
  }

  getLanes(): Observable<Lane[]> {
    const headers = this.GenerateAuthHeader();
    return this.http.get<Lane[]>('https://localhost:7010/Lane', { headers });
  }
  getLaneById(id: string): Observable<Lane[]> {
    const headers = this.GenerateAuthHeader();
    return this.http.get<Lane[]>('https://localhost:7010/Lane/:id', { headers });
  }
  getLanesByBoardId(boardId: string): Observable<Lane[]> {
    const headers = this.GenerateAuthHeader();
    return this.http.get<Lane[]>('https://localhost:7010/Lane/ByBoardId/' + boardId, { headers });
  }
  addLane(laneData: { name: string, boardID: string | null }): Observable<Lane> {
    const headers = this.GenerateAuthHeader();
    return this.http.post<Lane>('https://localhost:7010/Lane', laneData, { headers });
  }
}
