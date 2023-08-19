import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable, map } from 'rxjs';
import { AccountService } from '../_Services/account.service';
import { ToastrService } from 'ngx-toastr';

export const AdminGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const toastr = inject(ToastrService);
  return accountService.currentUser$.pipe(
    map(user => {
      if(!user) return false;
      if(user.roles.includes('Admin') || user.roles.includes('Moderator')){
        return true;
      } else{
        toastr.error('You cannnot enter this area');
        return false;
      }
    })
  )
}

