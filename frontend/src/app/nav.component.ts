import { Component } from '@angular/core';

@Component({
    selector: 'nav',
    template: `
        <mat-toolbar color="primary">
            <button mat-button routerLink="/">Blog Board</button>
            <button mat-button routerLink="/messages">Messages</button>
            <button mat-button routerLink="/register">Register</button>            
        </mat-toolbar>
    `
})
export class NavComponent {
    constructor() {}

}
