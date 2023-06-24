import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { AccountService } from 'src/app/_Services/account.service';
import { MembersService } from 'src/app/_Services/members.service';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editform') editForm: NgForm | undefined;
  @HostListener('window:beforeunload', ['$event']) unloadNotification($event: any){
    if(this.editForm?.dirty){
      $event.returnValue = true;
    }
  }
  member: Member | undefined;
  user: User | null = null;

  constructor(private accountService : AccountService,
              private memberService : MembersService,
              private toast: ToastrService){
                this.accountService.currentUser$.pipe(take(1)).subscribe({
                  next: user => this.user = user
                })
              }


  ngOnInit(): void {
    this.loadMember();
  }

  loadMember(): any{
    if(!this.user) return;
    this.memberService.getMember(this.user.username).subscribe({
      next: (member: Member | undefined) => this.member = member
    })
  }

  updateMember(): any{
    this.memberService.updateMember(this.editForm?.value).subscribe({
      next: (_: any) => {
        this.toast.success("Profile updated successfully!");
        this.editForm?.reset(this.member);
      }
    })

  }

}
