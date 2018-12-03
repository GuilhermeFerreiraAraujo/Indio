import {HttpClient} from 'aurelia-http-client';

export class customers {

    activate() {
       
        let client = new HttpClient();
        
        client.get('https://localhost:44307/api/customers/get')
          .then(data => {
            console.log(data)
          }).catch(ex => {
              console.log(ex);
            
          });      
    }
    
}