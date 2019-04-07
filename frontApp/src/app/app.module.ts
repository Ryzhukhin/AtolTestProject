import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {environment} from '../environments/environment';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/material-module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule
  ],
  providers: [{provide : 'BASE_URL' , useFactory : getBaseUrl}],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl () {
  if (environment.back_url != undefined && environment.back_url != "")
    return environment.back_url;
  return document.getElementsByTagName ('base')[0].href;
}
