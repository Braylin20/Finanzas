import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  imports: [CommonModule, RouterLink, RouterLinkActive],
  templateUrl: './sidebar.html',
})
export class Sidebar {
  public isOpen = false;

  public toggle() {
    this.isOpen = !this.isOpen;
  }

  public close() {
    this.isOpen = false;
  }
}
