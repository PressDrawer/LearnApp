import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule,HttpClient} from '@angular/common/http'
import { AppComponent } from './app.component';
import { StudentRegisterComponent } from './student/student-register/student-register.component';
import { StudentService } from './services/student.service';
import { FormsModule } from '@angular/forms';
import { StudentComponent } from './student/student/student.component';
import { Route, Router, RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import { AuthService } from './services/auth/auth.service';
import { JwtHelperService, JWT_OPTIONS  } from '@auth0/angular-jwt';
import { CoursesComponent } from './course/courses/courses.component';
import { EnrollmentComponent } from './courseEnrollment/enrollment/enrollment.component';
import { AuthGuard } from './services/auth/guard/auth.guard';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import {AuthInterceptor} from './services/auth/auth.interceptor';
import { AdminComponent } from './admin/admin/admin.component';
import { AddCourseComponent } from './admin/admin/add.courses/add-course/add-course.component';
//import { AppRoutingModule } from './app-routing.module';

const routs : Routes=[
  
  {path:'register', component:StudentRegisterComponent},
  {path:'profile', component:StudentComponent,canActivate:[AuthGuard]},
  {path:'login', component:LoginComponent},
  {path:'courses', component:CoursesComponent},
  {path:'enrollment/:courseId', component:EnrollmentComponent,canActivate:[AuthGuard]},
  {path:'', component:CoursesComponent},
  {path:'admin',component:AdminComponent,canActivate:[AuthGuard], data: { role: 'Admin'}},
  {path:'addcourses',component:AddCourseComponent},
]

@NgModule({
  declarations: [
    AppComponent,
    StudentRegisterComponent,
    StudentComponent,
    LoginComponent,
    CoursesComponent,
    EnrollmentComponent,
    AdminComponent,
    AddCourseComponent,
    
  ],
  imports: [
    BrowserModule,
    //AppRoutingModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(routs),
  ],
  providers: 
  [
    StudentService,
    AuthService,
    { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
    JwtHelperService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
