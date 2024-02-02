
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthLoginInfo } from './login-info';
import { Company } from '../models/company.model';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json'})
}

export const LOGIN_URL = 'https://localhost:7259/api/Auth/Login';
export const SIGNUP_URL = 'https://localhost:7259/api/Auth/Register';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  attemptAuth(credentials: AuthLoginInfo): Observable<any> {
    return this.http.post(LOGIN_URL, credentials, { ...httpOptions, observe: 'response' });
  }

  constructor(private http: HttpClient) { }

  register(firstName: string, lastName: string, username: string, password: string, email: string, company: Company, roles: string[]): Observable<any> {
    const payload = {
      firstName,
      lastName,
      username,
      password,
      email,
      company,
      roles
    };
    return this.http.post(SIGNUP_URL, payload, httpOptions);
  }
}
