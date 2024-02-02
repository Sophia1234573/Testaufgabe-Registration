import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from "../models/user.model";

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = 'https://localhost:7259/api/Users';

  constructor(private http: HttpClient) { }

  checkUsernameUniqueness(value: string): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}/check-username/${encodeURIComponent(value)}`);
  }
}
