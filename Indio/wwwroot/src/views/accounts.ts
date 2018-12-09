
import {HttpClient} from 'aurelia-http-client';
import { AccountModel } from 'models/account.models';


export class accounts {

    items: AccountModel[] = [];

    activate() {
       
        let client = new HttpClient();
        
        client.get('https://localhost:44307/api/accounts/get')
          .then(data => {
            this.items = JSON.parse(data.response);
          }).catch(ex => {
              console.log(ex);
            
          });      
    }
}