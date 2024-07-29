import { Injectable } from '@angular/core';
import {HttpClientModule,HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor(private http:HttpClient) { }
  
  url = "https://localhost:7042/api/Course/courses"
  getAllcourses():Observable<any>{
    return this.http.get(this.url)
  }
}
