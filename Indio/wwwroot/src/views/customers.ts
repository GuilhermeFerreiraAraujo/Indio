import { CustomerModel } from 'models/customer.models';
import { BaseClient } from 'services/baseClient';
import { autoinject } from '../../node_modules/aurelia-framework';

@autoinject
export class customers {

    protected items: CustomerModel[] = [];

    constructor(private baseClient: BaseClient){

    }

    activate() {
        this.baseClient.get('customers/get').then(data => {
            this.items = JSON.parse(data.response);
          }).catch(ex => {
              console.log(ex);
          }); 
    }
}