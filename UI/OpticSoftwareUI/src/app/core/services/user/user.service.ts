import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserEntity } from '../../entities/user/userEntity';
import { LoginRequest } from '../../models/api/user/request/loginRequest';
import { LoginResponse } from '../../models/api/user/response/loginResponse';
import { BaseService } from '../base.service';

@Injectable({
  providedIn: 'root',
})
export class UserService extends BaseService {
  login(user: UserEntity): Observable<LoginResponse> {
    let request = new LoginRequest();
    request.username = user.username;
    request.password = user.password;
    return this.httpClient.post<LoginResponse>(
      `${this.API_URL}/user/login`,
      request,
      {
        headers: this.getHeaders(),
      }
    );
  }
}
