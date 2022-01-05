import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class BaseService {
  constructor(protected httpClient: HttpClient, protected router: Router) {}

  protected API_URL = environment.API_URL;
  protected token = localStorage.getItem('token') ?? '';

  getHeaders(): HttpHeaders {
    let headers = new HttpHeaders();
    headers = headers.append('Content-Type', 'application/json');
    headers = headers.append('Authorization', 'Bearer ' + this.token);
    return headers;
  }
}
