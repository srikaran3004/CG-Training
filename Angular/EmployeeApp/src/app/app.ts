import { CommonModule } from '@angular/common';
import { Component, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';

interface Employee {
  Id: number;
  Name: string;
  Department: string;
}

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,CommonModule,FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  name:string='';
  dept:string='';
  addEmployee(){
    this.employees.push({
      Id: this.employees.length + 1,
      Name: this.name,
      Department: this.dept
    });
    this.name = '';
    this.dept = '';
    alert('Employee added successfully!');
  }
  deleteEmployee(id: number){
    this.employees = this.employees.filter(item => item.Id !== id);
    alert('Employee deleted successfully!');
  }
  public employees: Employee[] = [
    {
      Id: 1,
      Name: 'John Doe',
      Department: 'Engineering'
    },
    {
      Id: 2,
      Name: 'Jane Smith',
      Department: 'Marketing'
    }
  ];

}
