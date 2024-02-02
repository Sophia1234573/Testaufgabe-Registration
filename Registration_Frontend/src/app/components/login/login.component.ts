import { Component, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../../auth/auth.service';
import { TokenStorageService } from '../../auth/token-storage.service';
import { AuthLoginInfo } from '../../auth/login-info';
import { Subscription } from 'rxjs';
import { MatFormFieldModule} from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, ReactiveFormsModule, CommonModule, RouterModule, MatButtonModule, MatCardModule, FormsModule, MatInputModule],
  styleUrls: ['./login.component.css'],
  templateUrl: './login.component.html',
  providers: [AuthService],
})
export class LoginComponent implements OnDestroy {
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  private loginInfo: AuthLoginInfo | undefined;
  loginForm: FormGroup;
  private formStatusSubscription: Subscription;

  constructor(
    private fb: FormBuilder,
    private authService: AuthService,
    private tokenStorage: TokenStorageService,
    private router: Router
  ) {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(6)]],
    });
    // Subscribe to form status changes
    this.formStatusSubscription = this.loginForm.statusChanges.subscribe(() => {
    });
  }

  ngOnDestroy(): void {
    // Unsubscribe from the form status changes when the component is destroyed
    this.formStatusSubscription.unsubscribe();
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.login();
    }
  }

  login() {
    this.loginInfo = new AuthLoginInfo(
      this.loginForm.get('username')?.value,
      this.loginForm.get('password')?.value
    );

    this.authService.attemptAuth(this.loginInfo).subscribe(
      (response: any) => {

        this.tokenStorage.saveToken(response.body.jwtToken);
        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.doRoute();
      },
      (error) => {
        if (error && error.error && error.error.message) {
          this.errorMessage = error.error.message;
        } else {
          this.errorMessage = 'An error occurred during registration.';
          this.isLoginFailed = true;
        }
      }
    );
  }

  doRoute() {
    if (this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
      this.router.navigate(['user']);
    }
  }

  getErrorMessage() {
    return 'Dieses Feld ist ein Pflichtfeld und muss ausgefüllt werden.';
  }

  getErrorMinLengthMessage() {
    return "Das Passwort muss mindestens 6 Zeichen lang sein.";
  }
}
