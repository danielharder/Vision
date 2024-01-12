import { Injectable } from '@angular/core';
import { LoginToken } from '../interfaces/LoginToken';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _LoggedIn = false;

  constructor(private http: HttpClient) { }
  get isLoggedIn(): boolean {
    return this._LoggedIn;
  }

  login(email: string, password: string) {
    const loginData = { email: email, password: password };
    console.log(loginData);
    this.http.post<LoginToken>('https://localhost:7010/api/Login/authenticate', loginData).subscribe(
      response => {
        console.log(response);
        sessionStorage.setItem('jwt', response.token);
        console.log('Token stored in session storage');
        this._LoggedIn = true;
      },
      error => {
        console.log(error);
      }
    );
  }

  logout() {
    sessionStorage.removeItem('jwt');
    this._LoggedIn = false;
  }
}
