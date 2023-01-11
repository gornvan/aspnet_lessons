import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CatfoodService } from './services/catfood.service';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule
  ],
  providers: [
    CatfoodService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
