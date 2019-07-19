import { CustomerModel } from './../../models/customer.models';
import { BaseClient } from 'services/baseClient';
import { autoinject } from "aurelia-framework";

@autoinject()
export class CustomerDetail {

  public item: CustomerModel;
  
  constructor(private baseClient: BaseClient) {

  }

  save() {
    this.baseClient.post('customers/Save', this.item).then(data => {
      this.item = JSON.parse(data.response);
    }).catch(ex => {
        console.log(ex);
    });   
  }
}
