import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  // title ='Login Page';
  // username:string="";
  // password:string=""
  imageUrl="https://images.pexels.com/photos/595808/pexels-photo-595808.jpeg?cs=srgb&dl=road-sky-trees-595808.jpg&fm=jpg";
  isDisabled=false;
  userName="Srikaran";
  isActive=false;
  count=signal(0);
}
