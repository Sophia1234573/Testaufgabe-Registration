import { AbstractControl, ValidationErrors, AsyncValidatorFn, AsyncValidator, FormControl } from '@angular/forms';
import { Observable, of, timer } from 'rxjs';
import { map, switchMap } from 'rxjs/operators';
import { UserService } from '../servicies/user.service';

export function uniqueUsernameValidator(userService: UserService): AsyncValidatorFn {
  return (control: AbstractControl): Observable<ValidationErrors | null> => {
    const value = control.value;

    if (!value) {
      return of(null);
    }

    return timer(300)
      .pipe(
        switchMap(() => userService.checkUsernameUniqueness(value)),
        map(isUnique => (isUnique ? null : { uniqueUsername: true }))
      );
  };
}

