
import {HttpClient} from 'aurelia-http-client';


export class accounts {

    activate() {
       
        let client = new HttpClient();
        
        client.get('https://localhost:44307/api/accounts/get')
          .then(data => {
            console.log(data)
          }).catch(ex => {
              console.log(ex);
            
          });      
    }
}