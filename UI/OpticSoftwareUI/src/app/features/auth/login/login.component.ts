import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserEntity } from 'src/app/core/entities/user/userEntity';
import { LoginResponse } from 'src/app/core/models/api/user/response/loginResponse';
import { UserService } from 'src/app/core/services/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  constructor(private userService: UserService, private router: Router) {}

  loginForm: FormGroup;
  submitted: boolean = false;
  errorMessage: string;

  ngOnInit(): void {
    localStorage.removeItem('token');
    this.loginForm = new FormGroup({
      username: new FormControl('', [
        Validators.required,
        Validators.maxLength(25),
      ]),
      password: new FormControl('', [
        Validators.required,
        Validators.maxLength(25),
      ]),
    });
  }

  get loginFormControl() {
    return this.loginForm.controls;
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.loginForm.valid) {
      let user = new UserEntity();
      user.username = this.loginForm.controls['username'].value;
      user.password = this.loginForm.controls['password'].value;
      this.userService.login(user).subscribe((res: LoginResponse) => {
        if (res.isSuccess) {
          localStorage.setItem('token', res.jwt);
          this.router.navigateByUrl('panel');
        } else {
          this.errorMessage = res.errorMessage;
        }
      });
    }
  }
}
