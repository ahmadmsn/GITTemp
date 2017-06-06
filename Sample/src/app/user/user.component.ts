import { Component, OnInit } from '@angular/core';
import {GetUserDataService} from '../Services/get-user-data.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
  providers: [GetUserDataService]
})
export class UserComponent implements OnInit {
 name: string;
 public users;
  public users1;

  constructor(private userService : GetUserDataService) { 
    this.name = 'Admiral';
  this.userService.getUser().subscribe(
      res =>{
        this.users = res;
            console.log(this.users);

for (var i = 0; i < this.users.length; i++) {
    var counter = this.users[i];
    this.users1=counter;
    console.log(counter.USER_ID);
}
      }
    )
  }  

  ngOnInit() {    
  }

}
// interface User{
//   UserId:number;
//   Name:string;  
// }



