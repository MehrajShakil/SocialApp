import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_Services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {}
  @Output() cancelRegister = new EventEmitter();


  constructor(private accountService: AccountService,
              private toast: ToastrService) { }

  ngOnInit() {
  }

  register(){
    this.accountService.register(this.model).subscribe({
      next: () => {
        this.cancle()
      },
      error: (error: any) => this.toast.error(error.error)
    })
  }

  cancle(){
    this.cancelRegister.emit(false);
  }

}
