import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoffeeFormComponent } from './coffee-form/coffee-form.component';
import { CoffeeListComponent } from './coffee-list/coffee-list.component';

@NgModule({
  declarations: [
    AppComponent,
    CoffeeFormComponent,
    CoffeeListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
