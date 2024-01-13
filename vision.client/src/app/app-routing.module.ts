import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { TaskboardsComponent } from './taskboards/taskboards.component';
import { TaskboardComponent } from './taskboard/taskboard.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'taskboards', component: TaskboardsComponent },
  { path: 'taskboard', component: TaskboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
