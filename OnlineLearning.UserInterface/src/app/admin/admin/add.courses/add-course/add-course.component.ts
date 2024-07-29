import { Component } from '@angular/core';
import { course } from 'src/app/Models/course';
import { CourseService } from 'src/app/services/course/course.service';

@Component({
  selector: 'app-add-course',
  templateUrl: './add-course.component.html',
  styleUrls: ['./add-course.component.css']
})
export class AddCourseComponent {

  constructor(private courseService:CourseService){}

  course :course = {} as course;
  submit(form:any){
    debugger
    this.course.courseName = form.value.coursename,
    this.course.courseCategory = form.value.courseCategory,
    this.course.courseCategory = form.value.courseCategory
    this.courseService.createCourse(this.course).subscribe((res:any)=>{
      return res;
    })
  }
}
