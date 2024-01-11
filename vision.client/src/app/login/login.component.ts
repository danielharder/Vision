import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginToken } from '../interfaces/LoginToken';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  email: string = '';
  password: string = '';

  constructor(private http: HttpClient) { }

  login() {
    //console.log(`Email: ${this.email}, Password: ${this.password}`);
    const loginData = { email: this.email, password: this.password };
    console.log(loginData);
    this.http.post<LoginToken>('https://localhost:7010/api/Login/authenticate', loginData).subscribe(
      response => {
        console.log(response);        
        sessionStorage.setItem('jwt', response.token);
        console.log('Token stored in session storage');
      },
      error => {
        console.log(error);
      }
    );
  }

}
