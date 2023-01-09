import { NgModule } from '@angular/core';
import { RoutingComponent } from '../routing/routing.component';

import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from '../app.component';
import { ParrotComponent } from '../parrot/parrot.component';
import { PeopleComponent } from '../people/people.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

const routes: Routes = [
  { path: '', component: AppComponent },
  { path: 'parrot', component: ParrotComponent },
  { path: 'people', component: PeopleComponent },
];

@NgModule({
  declarations: [
    RoutingComponent,
    AppComponent,
    ParrotComponent,
    PeopleComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  exports: [RouterModule],
  bootstrap: [RoutingComponent]
})
export class RoutingModule { }
