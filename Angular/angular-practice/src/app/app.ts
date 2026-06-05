import { CounterApp } from './counter-app/counter-app';
import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Login } from './login/login';
import { SigninComponent } from './signin/signin';
import { Events } from './events/events';
import { GetSetValue } from './get-set-value/get-set-value';
import { Redirect } from './redirect/redirect';
import { Homepageload } from './homepageload/homepageload';

@Component({
  selector: 'app-root',
  imports: [Login, Events, GetSetValue, Homepageload, RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  // name = "Angular";
  // isTrue = false;
  // count=0;
  // username="Srikaran"
  // getUser() {
  //   return "Srikaran";
  // }
  // collegeName = signal("LPU");
  // count=0;
  // handleClick(e:any){
  //   console.log("Increment clicked"+e+this.count);
  //   this.hello();
  // }
  // hello(){
  //   console.log("Hello");
  // }
}

//Angular Components are of two types Angular 2-13 : Module based, 14 - now : Standalone component.
//datatypes in angular string,number, any, unknown, undefined, null.
//we can have multiple datatypes for a single variable like (value: string | number).
//variables declared inside class are called properties and inside functions they are called variables.
//when multiple datatypes are allowed with a variable then it is called UnionType.

//Difference between 'any' and 'unknown':
//'any' - Disables type checking, allows any operation without checks (unsafe).
//'unknown' - Type-safe alternative to 'any', requires type checking before operations.  
