import { Component } from '@angular/core';
import { StudentService } from 'src/app/services/student.service';
import { studentProfile } from 'src/app/Models/studentProfile';
import { Courseview } from 'src/app/Models/Courseview';
import { pipe } from 'rxjs';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Route, Router } from '@angular/router';
//import { Guid } from "guid-typescript";
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent {

  constructor(private studentService:StudentService,private authService:AuthService,private router:Router) {}
    
  //id:string="7BA238BC-3614-469B-DDC5-08DCAE07F9B2";
  studentprofile:studentProfile ={} as studentProfile
  stcourses:Courseview[]=[]
  id=this.authService.userId
  //id = JSON.parse(localStorage.getItem('userId')as any);


    public getStudent(id:string){
      this.studentService.getStudent(id).subscribe((res:any)=>{
        debugger;
        console.log(res);
        this.studentprofile.name=res.name; 
        this.studentprofile.age=res.age;
        this.studentprofile.city=res.city;
        this.studentprofile.mobile=res.mobile;
        this.studentprofile.email=res.email
      })
      this.studentService.getEnrolledCourses(id).subscribe((res:Courseview[])=>{
        debugger;
        
        this.stcourses=res;
        console.log(this.stcourses);
        
      })
    }

    logout(){
      localStorage.removeItem('token');
      this.authService.isLogedin = false;
      this.router.navigate(['login']);
    }

   ngOnInit(): void 
   {
    debugger;//=localStorage.getItem('userId')
    alert(this.id);
    this.getStudent(this.id);
   //console.log(this.stcourses);
   }

}
