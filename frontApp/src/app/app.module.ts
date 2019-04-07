import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {environment} from '../environments/environment';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/material-module';
import {HttpClientModule} from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { AuthClientService } from './authClient.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    HttpModule,
    FormsModule
  ],
  providers: [AuthClientService,{provide : 'BASE_URL' , useFactory : getBaseUrl}],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl () {
  if (environment.back_url != undefined && environment.back_url != "")
    return environment.back_url;
  return document.getElementsByTagName ('base')[0].href;
}
