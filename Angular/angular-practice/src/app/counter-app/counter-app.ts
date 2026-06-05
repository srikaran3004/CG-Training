import { Component } from '@angular/core';

@Component({
  selector: 'app-counter-app',
  imports: [],
  templateUrl: './counter-app.html',
  styleUrl: './counter-app.css',
})
export class CounterApp {
  count: number = 0;
  // increment(){
  //   this.count++;
  // }
  // decrement(){
  //   if(this.count>0){
  //     this.count--;
  //   }
  // }
  // reset(){
  //   this.count=0;
  // }
  handle(value: string) {
    if (value == 'plus') {
      this.count++;
    }
    else if (value == 'minus') {
      if (this.count > 0) this.count--;
    }
    else if (value == 'reset') {
      this.count = 0;
    }
  }
}
