import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_Services/account.service';
import { ToastrService } from 'ngx-toastr';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {}
  @Output() cancelRegister = new EventEmitter();
  registerForm!: FormGroup;


  constructor(private accountService: AccountService,
              private toast: ToastrService) { }

  ngOnInit() {
    this.initializeForm();
  }

  initializeForm(){
    this.registerForm = new FormGroup({
      username: new FormControl('', Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(8)]),
      confirmPassword: new FormControl('', [Validators.required, this.matchValues('password')])
    });
    this.registerForm.controls['password'].valueChanges.subscribe({
      next: () => this.registerForm.controls['confirmPassword'].updateValueAndValidity()
    })
  }

  matchValues(matchTo: string): ValidatorFn{
    return (control: AbstractControl) => {
      return control.value === control.parent?.get(matchTo)?.value ? null : {notMatching: true}
    }
  }

  register(){

    console.log(this.registerForm?.value);

    // this.accountService.register(this.model).subscribe({
    //   next: () => {
    //     this.cancle()
    //   },
    //   error: (error: any) => this.toast.error(error.error)
    // })
  }

  cancle(){
    this.cancelRegister.emit(false);
  }

}
