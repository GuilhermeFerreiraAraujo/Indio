import {HttpClient} from 'aurelia-http-client';
import { CustomerModel } from 'models/customer.models';

export class customers {

    protected items: CustomerModel[] = [];

    activate() {
       
        let client = new HttpClient();
        
        client.get('https://localhost:44307/api/customers/get')
          .then(data => {
              this.items = JSON.parse(data.response);
          }).catch(ex => {
              console.log(ex);
          });      
    }
}