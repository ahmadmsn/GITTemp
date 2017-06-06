import { Component, OnInit } from '@angular/core';
import {EmployeeService} from '../Employee/employee.service';

@Component({
  selector: 'app-search-employee',
  templateUrl: './search-employee.component.html',
  styleUrls: ['./search-employee.component.css'],
  providers:[EmployeeService]
})
export class SearchEmployeeComponent implements OnInit  {
  ID: string;
  FIRSTNAME:string;
  LASTNAME:string;
  GENDER:string;
  SALARY:string;
  public data1:emp;

  constructor(private empService : EmployeeService) { 
  // this.ID = 'AA';
  // this.FIRSTNAME = '';
  // this.LASTNAME = '';
  // this.GENDER = '';
  // this.SALARY = '';

  this.data1={
    ID:undefined,
    FIRSTNAME:'',
    LASTNAME:'',
    GENDER:'',
    SALARY:undefined
  }
  }

  public EmpId;
  
  onKeyup(event) {
    this.EmpId = event.target.value;
  }

  GetEmployee(){
      this.empService.GetEmployee(this.EmpId).subscribe(
       res =>{
         this.data1=res;        
       } 
      );
    }

    ngOnInit() {
    
  }
}

interface emp{
  ID:number;
  FIRSTNAME:string,
  LASTNAME:string;
  GENDER:string;
  SALARY:number;
}