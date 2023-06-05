import { Component, OnInit } from '@angular/core';
import { MembersService } from 'src/app/_Services/members.service';
import { Member } from 'src/app/_models/member';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css']
})
export class MemberListComponent implements OnInit{

  members: Member[] = [];

  constructor(private memberService: MembersService){}


  ngOnInit(): void {
    this.loadMembers();
  }

  loadMembers(): any{
    this.memberService.getMembers().subscribe({
      next: (members: Member[]) => this.members = members,
      error: (error: any) => console.log(error)
    });

  }

}
