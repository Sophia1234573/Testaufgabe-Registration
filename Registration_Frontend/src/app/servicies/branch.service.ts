import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BranchService {

  private apiUrl = 'https://localhost:7259/api/Branches';

  constructor(private http: HttpClient) { }

  getAllBranches(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}
