import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_Services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  currentUser$: Observable<User|any> = of(null);

  constructor(private accountService: AccountService){}




  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
  }

  Login(){
    console.log(this.model);
    this.accountService.login(this.model).subscribe({
        next: (response: any) => {
          console.log(response);
        },
        error: (error: any) => {
          console.log(error);
        }
    })
  }

  logout(){
    this.accountService.logout();
  }

}
