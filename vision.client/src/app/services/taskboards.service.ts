import { Injectable } from '@angular/core';
import { TaskBoard } from '../interfaces/TaskBoard';
import { Lane } from '../interfaces/Lane';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Story } from '../interfaces/Story';

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

  // TASKBOARD REQUESTS
  getTaskBoards(): Observable<TaskBoard[]> {
    const headers = this.GenerateAuthHeader();
    return this.http.get<TaskBoard[]>(this.TaskboardUrl, { headers });
  }

  getTaskBoard(id: string): Observable<TaskBoard> {
    const headers = this.GenerateAuthHeader();
    return this.http.get<TaskBoard>(this.TaskboardUrl + id, { headers });
  }

  addTaskBoard(newTaskBoard: { name: string; description: string; boardMembers: { userPK: string; role: string; }[] }): Observable<TaskBoard> {
    const headers = this.GenerateAuthHeader();
    return this.http.post<TaskBoard>('https://localhost:7010/TaskBoard', newTaskBoard, { headers });
  }

  // LANE REQUESTS
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
  deleteLane(laneId: string): Observable<any> {
    const headers = this.GenerateAuthHeader();
    return this.http.delete('https://localhost:7010/Lane/' + laneId, { headers });
  }

  // STORY REQUESTS
  getStoriesByLaneId(laneId: string): Observable<Story[]> {
    const headers = this.GenerateAuthHeader();
    return this.http.get<Story[]>('https://localhost:7010/Story/ByLaneId/' + laneId, { headers });
  }

  updateStoryPositions(storyPositions: {StoryId: string, NewPosition: number}[]): Observable<any> {
    const headers = this.GenerateAuthHeader();
    return this.http.put('https://localhost:7010/Story/UpdatePositions', storyPositions, { headers });
  }
  addStory(storyData: { title: string, description: string, status: string, laneID: string }): Observable<Story> {
    const headers = this.GenerateAuthHeader();
    return this.http.post<Story>('https://localhost:7010/story', storyData, { headers });
  }
  deleteStory(storyId: string): Observable<any> {
    return this.http.delete(`https://localhost:7010/Story/${storyId}`);
  }
}
