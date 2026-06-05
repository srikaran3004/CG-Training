import { ReversePipe } from './../reverse-pipe';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-dropdown',
  imports: [FormsModule,ReversePipe],
  templateUrl: './dropdown.html',
  styleUrl: './dropdown.css',
})
export class Dropdown {
  name: string = '';
}
