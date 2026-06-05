import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-evenorodd',
  imports: [FormsModule],
  templateUrl: './evenorodd.html',
  styleUrl: './evenorodd.css',
})
export class Evenorodd {
  value: string = '';
  find() {  
    const num = Number(this.value);
    if (num % 2 == 0) {
      alert("This is even Num:" + num);
    }
    else {
      alert("This is Odd Number");
    }
  }
}
