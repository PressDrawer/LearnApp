import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EnrollService {

  constructor(private http:HttpClient) { }

  url="https://localhost:7042/api/Student/Enroll"
  postEnroll(enrollCourse:any):Observable<any>{
    debugger;
    return this.http.post<any>(this.url,enrollCourse);
  }
}
