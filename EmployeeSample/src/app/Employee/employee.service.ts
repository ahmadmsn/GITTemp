import { Injectable } from '@angular/core';
import {Http} from '@angular/http';
import {Observable} from 'rxjs/Rx';
import 'rxjs/add/operator/map';


@Injectable()
export class EmployeeService {

  constructor(private http:Http) { }
  GetEmployee1(EmpId): Observable<any>{
    // const EmpId='1';
    const url ='http://localhost:55037/api/employees/' + EmpId;
    return this.http.get(url).map(
      res =>{
        const data=res.json();
        // console.log(data);
        //return data;        
      });
  }

   GetEmployee(EmpId){
     const url ='http://localhost:55037/api/employees/' + EmpId;
        return this.http.get(url)
        .map(res => res.json())
    }
  

}
