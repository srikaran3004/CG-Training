import { Dynamicdropdown } from './dynamicdropdown/dynamicdropdown';
import { Component, signal } from '@angular/core';
import { Searchbar } from './searchbar/searchbar';
import { Evenorodd } from './evenorodd/evenorodd';
import { Dropdown } from "./dropdown/dropdown";

@Component({
  selector: 'app-root',
  imports: [Evenorodd, Dropdown],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('project');
}
