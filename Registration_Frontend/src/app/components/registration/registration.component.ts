import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatFormFieldModule} from '@angular/material/form-field';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';
import { MatCardModule } from '@angular/material/card';
import { AuthService } from '../../auth/auth.service';
import { BranchService } from '../../servicies/branch.service';
import { UserService } from '../../servicies/user.service';
import { uniqueUsernameValidator } from '../../validation/uniqueUsernameValidator';
import { ChangeDetectorRef, AfterViewInit } from '@angular/core';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-registration',
  standalone: true,
  imports: [MatFormFieldModule, RouterModule, FormsModule, ReactiveFormsModule, MatSelectModule, MatCardModule, CommonModule, MatInputModule, MatStepperModule, MatButtonModule, MatCheckboxModule],
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css',
  providers: [AuthService, BranchService, UserService],
})
export class RegistrationComponent {
  registrationForm: FormGroup;
  isLinear = false;
  isSuccessful = false;
  isSignUpFailed = false;
  errorMessage = '';

  branches: any[] = [];

  constructor(private fb: FormBuilder,
      private authService: AuthService,
      private userService: UserService, 
      private branchService: BranchService,
      private cdr: ChangeDetectorRef) {
    this.registrationForm = this.fb.group({
      firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    username: ['', [Validators.required], [uniqueUsernameValidator(this.userService)]],
    email: ['', Validators.email],
    password: ['', [Validators.required, Validators.minLength(6)]],
    confirmPassword: ['', Validators.required],
    company: this.fb.group({
      name: ['', Validators.required],
      branch: this.fb.group({
        name: ['', Validators.required],
      }),
    }),
    agreeWithAGB: [false, Validators.required],
    agreeWithDataProtection: [false, Validators.required],
  }, {
    validators: [this.passwordMatchValidator]});
  }

  ngOnInit(): void {
    this.loadBranches();
  }

  ngAfterViewInit(): void {
    this.cdr.detectChanges();
  }

  loadBranches(): void {
    this.branchService.getAllBranches().subscribe(
      branches => {
        this.branches = branches;
      },
      error => {
        console.error('Error loading branches:', error);
      }
    );
  }

  private passwordMatchValidator(registrationForm: FormGroup): void {
    const password = registrationForm.get('password')?.value;
    const confirmPassword = registrationForm.get('confirmPassword')?.value;
  
    if (password !== confirmPassword) {
      registrationForm.get('confirmPassword')?.setErrors({ passwordConfirm: true });
    } else {
      registrationForm.get('confirmPassword')?.setErrors(null);
    }
  }

  onSubmit() {
    if (this.registrationForm.valid) {
      this.registration();
    }
  }

  registration() {

    const { firstName, lastName, username, password, email, company} = this.registrationForm.value;

    const roles = [''];

    this.authService.register(firstName, lastName, username, password, email, company, roles).subscribe({
      next: (data) => {
        this.isSuccessful = true;
        this.isSignUpFailed = false;
      },
      error: (err) => {
        if (err && err.error && err.error.message) {
          this.errorMessage = err.error.message;
        } else {
          this.errorMessage = 'An error occurred during registration.';
        }
        this.isSignUpFailed = true;
      }
    });
  }

  isStep1Valid(): boolean {
    const step1 = this.registrationForm.get('company');
    return step1 ? step1.valid : false;
  }

  isStep2Valid(): boolean {
    const step2 = this.registrationForm.get('firstName')?.valid &&
    this.registrationForm.get('lastName')?.valid &&
    this.registrationForm.get('username')?.valid &&
    this.registrationForm.get('password')?.valid &&
    this.registrationForm.get('confirmPassword')?.valid &&
    this.registrationForm.get('email')?.valid;
  return step2 !== undefined ? step2 : false;
  }

  isStep3Valid(): boolean {
    const step3 = this.registrationForm.get('agreeWithAGB')?.value &&
    this.registrationForm.get('agreeWithDataProtection')?.value;
    return step3;
  }

  updateValidity() {
    this.cdr.detectChanges();
  }

  getErrorMessage() {
    return "Dieses Feld ist ein Pflichtfeld und muss ausgefüllt werden.";
  }

  getErrorUniqueUsernameMessage() {
    return "Dieses Username ist bereits verhandelt.";
  }

  getErrorConfirmationMessage() {
    return "Bestätigen Sie das Passwort.";
  }

  getErrorMinLengthMessage() {
    return "Das Passwort muss mindestens 6 Zeichen lang sein.";
  }

  getErrorEmailMessage() {
    return "Diese E-Mail-Adresse ist keine gültige E-Mail-Adresse.";
  }

  getCheckBoxAgreeWithAGBError() {
    if(this.registrationForm.get('agreeWithAGB')?.touched) {
      const value = this.registrationForm.get('agreeWithAGB')?.invalid;
      return value;
    }
    return false;
  }

  getCheckBoxAgreeWithDataProtectionError() {
    if(this.registrationForm.get('agreeWithDataProtection')?.touched) {
      const value = this.registrationForm.get('agreeWithDataProtection')?.invalid;
      return value;
    }
    return false;
  }

  getErrorCheckbocksMessage() {
    return "Checkbox muss angehakt werden.";
  }
}
