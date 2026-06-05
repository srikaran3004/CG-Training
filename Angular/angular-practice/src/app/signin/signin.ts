import {Component} from '@angular/core';

@Component({
    selector:'app-signin',
    imports:[],
    // template:`<h2>Sign In</h2>`,
    // styles : [`
    //     h2{
    //         color: red;
    //     }
    //     `]
    templateUrl :'./signin.html',
    styleUrl:'./signin.css'
})

export class SigninComponent{
    title="Please Sign In"
}