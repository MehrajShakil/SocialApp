import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedComponent } from './shared.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { NgxSpinnerModule } from 'ngx-spinner';



@NgModule({
  imports: [
    CommonModule,
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    NgxGalleryModule,
    NgxSpinnerModule.forRoot({ type: 'line-scale-party' }),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  exports: [
    BsDropdownModule,
    ToastrModule,
    TabsModule,
    NgxGalleryModule,
    NgxSpinnerModule
  ],
  declarations: [SharedComponent]
})
export class SharedModule { }
