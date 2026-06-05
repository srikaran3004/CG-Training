import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
// Fix: Import from the public API, not node_modules
import { CommonModule } from '@angular/common'; 

@Component({
  selector: 'app-dynamicdropdown',
  standalone: true, // Optional but good practice to be explicit
  imports: [FormsModule, CommonModule], // Fix: Add CommonModule here so *ngFor works
  templateUrl: './dynamicdropdown.html',
  styleUrl: './dynamicdropdown.css',
})
export class Dynamicdropdown {
  selected = '';
  countries = ['India', 'USA', 'UK'];
}
