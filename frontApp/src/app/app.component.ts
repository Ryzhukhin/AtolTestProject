import {Component} from '@angular/core';
import {AuthClientService} from './authClient.service';

@Component ({
  selector : 'app-root' ,
  templateUrl : './app.component.html' ,
  styleUrls : ['./app.component.css']
})
export class AppComponent {
  title = 'frontApp';
  public allUsersData : Products[];
  public displayedColumnsAllUsers : string[] = ['dateAdded' , 'title' , 'description' , 'price' , 'note'];
  public productTitle : string;
  public productDescription : string;
  public productPrice : number;
  public productNote : string;

  constructor (private client : AuthClientService) {
    this.GetAllUsers ();
  }

  public GetAllUsers () {
    this.client.get ('product/all/0/100').subscribe (result => {
        this.allUsersData = result.json () as Products[];
        console.log (this.allUsersData);
      } , error => {
        console.error (error);
      }
    );
  }

  public EmptyAll () {
    this.productTitle = undefined;
    this.productDescription = undefined;
    this.productPrice = undefined;
    this.productNote = undefined;
  }

  public SaveProduct(){
    let product = new Products();
    product.Title = this.productTitle;
    product.Description = this.productDescription;
    product.Price = this.productPrice;
    product.Note = this.productNote;

    this.client.postJson("product/addnew",product).subscribe (result => {
      this.EmptyAll()
        console.log (result);
        this.GetAllUsers();
      } , error => {
        console.error (error);
      }
    );
  }
}

export class Products {
  public Guid : string;
  public DateAdded : Date;
  public Title : string;
  public Description : string;
  public Price : number;
  public Note : string;
}

