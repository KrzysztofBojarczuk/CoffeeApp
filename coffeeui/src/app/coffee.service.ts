import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';




@Injectable({
  providedIn: 'root'
})
export class CoffeeService {
  readonly rootURL = 'http://localhost:7161/api';


  constructor(private http:  HttpClient) { }

getRecords() {
  return this.http.get(this.rootURL + '/Coffee');
}
}
