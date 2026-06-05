import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ConcatePipe } from '../concate-pipe';

@Component({
  selector: 'app-redirect',
  imports: [FormsModule,ConcatePipe],
  templateUrl: './redirect.html',
  styleUrl: './redirect.css',
})
export class Redirect {
  selected1: string = '';
  selected2: string = '';
}
