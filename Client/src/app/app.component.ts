import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Client';
  user!: string | null;

  getUser() {
  }

  constructor(
  ) { }

  ngOnInit(): void {
  }
}
