import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { enrollModel } from 'src/app/Models/enrollModel';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CourseService } from 'src/app/services/course/course.service';
import { EnrollService } from 'src/app/services/enroll/enroll.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-enrollment',
  templateUrl: './enrollment.component.html',
  styleUrls: ['./enrollment.component.css']
})
export class EnrollmentComponent {

  constructor(private route: ActivatedRoute,
              private courseService:CourseService,
              private enrollService:EnrollService,
              private authService:AuthService) {}
  courseId:string
  courseName:any 
  enrollmodel:enrollModel
  submit(form:any){
    debugger
    this.enrollmodel={
      "courseId":this.courseId,
      "studentId":this.authService.userId,
      "downPayment":form.value.payment
    }
    /* this.enrollmodel.courseId=this.courseId
    this.enrollmodel.studentId=this.authService.userId
    this.enrollmodel=form.value.payment */
    this.enrollService.postEnroll(this.enrollmodel).subscribe((res:any)=>{
        console.log(res)

    })
  }

  getCourse(id:any){
    this.courseService.getCourse(id).subscribe((res:any)=>{
      debugger;
        console.log(res);
      this.courseName=res.courseName
    })
  }
  ngOnInit() {
    debugger
    this.courseId = this.route.snapshot.paramMap.get('courseId');
    this.getCourse(this.courseId)
    //console.log(this.courseName);
  }
}
