import { Injectable } from '@angular/core'
import {HttpClientModule,HttpClient} from '@angular/common/http'
import { student } from '../Models/student'
import { Observable } from 'rxjs'
import { Courseview } from '../Models/Courseview';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http : HttpClient) { }

   url = "https://localhost:7042/api/Student/";
    //url2 = "https://localhost:7042/api/Student/"
  public registerStudent(student : student):Observable<any>{
    debugger;
    return this.http.post<any>(this.url+"Register",student);
  }

  public getStudent(id:string):Observable<any>{
    
    return this.http.get<any>(this.url+id);
  }

  public getEnrolledCourses(id:string):Observable<Courseview[]>{
    return this.http.get<Courseview[]>(this.url+"EnrolledCourses?studentId="+id)
  }
}
