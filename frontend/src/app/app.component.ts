import { Component, ViewChild } from '@angular/core';
import { MessagesComponent } from './messages-component';
import { NewMessageComponent } from './new-message.component';

@Component({
  selector: 'app-root',
  template: `
  <h1>Message Board</h1>
  <new-message (onPosted)="onPosted($event)"></new-message>
  <messages></messages>
  `,
  // styleUrls: ['./app.component.css']
})
export class AppComponent {

  onPosted(message) {
    console.log(message);
  }
}
