import {Headers , Http , RequestOptions} from '@angular/http';
import {Inject , Injectable} from '@angular/core';

@Injectable ()
export class AuthClientService {

  private url : string;

  constructor (
    private http : Http ,
    @Inject ('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'api/';
  }

  public post (url : string ,) {
    return this
      .http
      .post (this.url + url , {} , this.jwt ());
  }

  public postJson (url : string , data : any) {
    let headers = new Headers ();
    headers.append ('Content-Type' , 'application/json');
    return this
      .http
      .post (this.url + url , JSON.stringify (data) , this.jwtWith (headers));
  }

  public postData (url : string , data : any) {
    let headers = new Headers ();
    console.log (data);

    return this
      .http
      .post (this.url + url , data);
  }

  public delete (url : string) {
    let headers = new Headers ();

    return this
      .http
      .delete (this.url + url);
  }

  public GetUrl () {
    return this.url;
  }

  public putJson (url : string , data : any) {
    let headers = new Headers ();
    headers.append ('Content-Type' , 'application/json');
    return this.http.put (this.url + url , JSON.stringify (data) , this.jwtWith (headers));
  }

  public get (url : string) {
    return this.http.get (this.url + url , this.jwt ());
  }

  private jwt () {
    return this.jwtWith (new Headers ());
  }

  private jwtWith (headers : Headers) {
    let user = localStorage.getItem ('currentUser');
    if (user != null) {
      // create authorization header with jwt token
      let currentUser = JSON.parse (user);
      if (currentUser && currentUser.token) {
        headers.append ('Authorization' , 'Bearer ' + currentUser.token);
      }
    }
    return new RequestOptions ({headers : headers});
  }
}
