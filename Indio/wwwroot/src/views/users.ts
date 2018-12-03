import {HttpClient} from 'aurelia-http-client';

export class users {
    activate() {
       
        let client = new HttpClient();
        
        client.get('https://localhost:44307/api/users/get')
          .then(data => {
            console.log(data)
          }).catch(ex => {
              console.log(ex);
            
          });      
    }
}
