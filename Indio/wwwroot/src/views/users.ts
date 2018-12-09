import {HttpClient} from 'aurelia-http-client';
import { UserModel } from 'models/user.models';

export class users {

    protected items: UserModel[] = [];

    activate() {
       
        let client = new HttpClient();
        
        client.get('https://localhost:44307/api/users/get')
          .then(data => {
            this.items = JSON.parse(data.response);
          }).catch(ex => {
              console.log(ex);
            
          });      
    }
}
