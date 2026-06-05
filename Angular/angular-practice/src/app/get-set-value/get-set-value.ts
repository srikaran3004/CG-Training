import { Component } from '@angular/core';

@Component({
  selector: 'app-get-set-value',
  imports: [],
  templateUrl: './get-set-value.html',
  styleUrl: './get-set-value.css',
})
export class GetSetValue {
  // name:string='';
  // handle(event:any){
  //   this.name=event.target.value;
  // }
  email:string='';
  show(e:any){
    this.email=e;
  }
}
