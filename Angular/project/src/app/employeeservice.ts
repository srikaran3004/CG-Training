import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})

export class Employeeservice {
  private url = "https://localhost:7212/api/employee"
  constructor(private http: HttpClient) {
  }
  get(){
    return this.http.get(this.url);
  }
}

