import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-searchbar',
  imports: [FormsModule],
  templateUrl: './searchbar.html',
  styleUrl: './searchbar.css',
})
export class Searchbar {
  text: string = '';
  list = ['Apple', 'Orange', 'Banana', 'Aeroplane', 'Basket', 'Canal', 'Big boss'];
  filtered: string[] = this.list;
  search() {
    this.filtered = this.list.filter(l => l.toLowerCase().includes(this.text.toLowerCase()));
  }
}
