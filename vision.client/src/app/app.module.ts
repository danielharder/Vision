import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
import { TaskboardComponent } from './taskboard/taskboard.component';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { TaskboardsComponent } from './taskboards/taskboards.component';
import { LaneComponent } from './lane/lane.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TaskboardComponent,
    TaskboardsComponent,
    LaneComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule, FormsModule, DragDropModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
