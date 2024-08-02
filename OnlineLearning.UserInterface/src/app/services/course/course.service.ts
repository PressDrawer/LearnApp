import { Injectable } from '@angular/core';
import {HttpClientModule,HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { course } from 'src/app/Models/course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http:HttpClient) { }

  url = "https://localhost:7042/api/Course/courses"

  getCourse(id:any):Observable<any>{
    return this.http.get("https://localhost:7042/api/Course/"+id)
  }

  getAllcourses():Observable<any>{
    return this.http.get(this.url)
  }


  createCourse(course:course):Observable<any>{
    return this.http.post("https://localhost:7042/api/Course",course);
  }
}
