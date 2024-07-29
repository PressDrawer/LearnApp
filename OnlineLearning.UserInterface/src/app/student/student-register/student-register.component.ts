import { Component } from '@angular/core';
import { Router, RouteReuseStrategy } from '@angular/router';
import { student } from 'src/app/Models/student';
import { AuthService } from 'src/app/services/auth/auth.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-student-register',
  templateUrl: './student-register.component.html',
  styleUrls: ['./student-register.component.css']
})
export class StudentRegisterComponent {

  constructor(private studentservice:StudentService,private authservice:AuthService,private router:Router) {}
  
  get currentUser(){
    return this.authservice.currentUserroll;
    //this.authservice.
  }
    
    student:student={} as student
    submit(form:any):any{
     this.student={
      "name":form.value.name,
      "age":form.value.age,
      "gender":form.value.gender,
      "mobile":form.value.mobile,
      "email":form.value.email,
      "password":form.value.password
     }
    
     this.studentservice.registerStudent(this.student).subscribe((response:any)=>{
      console.log(response);
      this.router.navigate(['login'])
    })

    }
  
    ngOnInit(): void {
      
    }
    
  
} 
