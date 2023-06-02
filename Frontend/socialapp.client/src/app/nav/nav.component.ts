import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_Services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  currentUser$: Observable<User|any> = of(null);

  constructor(public accountService: AccountService,
              private router: Router,
              private toast: ToastrService){}




  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

  Login(){
    console.log(this.model);
    this.accountService.login(this.model).subscribe({
        next: () => this.router.navigateByUrl('/members'),
        error: (error: any) => this.toast.error(error.error)
    })
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

}
