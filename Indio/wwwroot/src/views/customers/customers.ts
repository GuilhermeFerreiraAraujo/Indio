import { CustomerModel } from 'models/customer.models';
import { BaseClient } from 'services/baseClient';
import { autoinject } from '../../../node_modules/aurelia-framework';
import { Router } from 'aurelia-router';

@autoinject()
export class customers {

    protected items: CustomerModel[] = [];

    constructor(private baseClient: BaseClient,
      private router: Router){

    }

    newCustomer(){
      this.router.navigateToRoute('CustomerDetail', {id: 0});
    }

    activate() {
        this.baseClient.get('customers/get').then(data => {
            this.items = JSON.parse(data.response);
          }).catch(ex => {
              console.log(ex);
          }); 
    }
}
