import { Component } from '@angular/core';
import { course } from 'src/app/Models/course';
import { Courseview } from 'src/app/Models/Courseview';
import { CourseService } from 'src/app/services/course/course.service';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth/auth.service';
@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent {
  stcourses:course[]=[]

  constructor(private courseService:CourseService,private router:Router,private auth:AuthService){}

  getCourses(){
    this.courseService.getAllcourses().subscribe((res:course[])=>{
      debugger;
      this.stcourses = res
      console.log(this.stcourses);
    })
  }

  enroll(){
    if(this.auth.isLogedin){
    this.router.navigate(["enrollment"]);
    }else
    {
      this.router.navigate(["login"])
    }
    
  }

  ngOnInit(): void 
   {
    this.getCourses();
   }
}
