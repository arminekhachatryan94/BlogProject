import { Component } from '@angular/core';
import { WebService } from './web.service';
@Component({
    selector: 'new-message',
    template: `
        <mat-card class = "card">
            <mat-card-content>
                <mat-input-container>
                    <input matInput placeholder="Name">
                </mat-input-container>
                <mat-input-container>
                    <textarea matInput placeholder="Message"></textarea>
                </mat-input-container>
                <mat-card-actions>
                    <button mat-button color="primary">POST</button>
                </mat-card-actions>
            </mat-card-content>
        </mat-card>
    `
})
export class NewMessageComponent {
    constructor(private webService: WebService) {}
}
