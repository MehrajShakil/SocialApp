import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { Member } from '../_models/member';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MembersService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }


  getMembers(): any{
    return this.http.get<Member[]>(this.baseUrl + 'users');
  }

  getMember(username: string): any{
    return this.http.get<Member>(this.baseUrl + 'users/' + username)
  }

}
