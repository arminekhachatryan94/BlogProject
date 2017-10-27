import { Component } from '@angular/core';
import { WebService } from './web.service';
@Component({
    selector: 'new-message',
    template: `

    `
})
export class NewMessageComponent {
    constructor(private webService: WebService) {}
    
}
