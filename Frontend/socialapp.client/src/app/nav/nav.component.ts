import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_Services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  loggedIn = false;

  constructor(private accountService: AccountService){}




  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  Login(){
    console.log(this.model);
    this.accountService.login(this.model).subscribe({
        next: (response: any) => {
          console.log(response);
          this.loggedIn = true;
        },
        error: (error: any) => {
          console.log(error);
        }
    })
  }

}
