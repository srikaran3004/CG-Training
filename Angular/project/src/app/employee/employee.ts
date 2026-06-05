import { CommonModule } from '@angular/common';
import { Employeeservice } from './../employeeservice';
import { Component, inject } from '@angular/core';

@Component({
  selector: 'app-employee',
  imports: [CommonModule],
  templateUrl: './employee.html',
  styleUrl: './employee.css',
})
export class Employee {

  emp = inject(Employeeservice);

  getEmp: any;

  getDetails() {

    this.emp.get().subscribe({
      next: (data) => {
        this.getEmp = data;
        console.log(this.getEmp);
      }
    });
  }
}