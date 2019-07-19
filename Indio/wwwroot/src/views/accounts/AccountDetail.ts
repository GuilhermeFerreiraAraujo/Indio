import { BaseClient } from 'services/baseClient';
import { autoinject } from "aurelia-framework";
import { AccountModel } from "models/account.models";
import { Router } from 'aurelia-router';

@autoinject()
export class AccountDetail {

    public item: AccountModel;
  
    constructor(private baseClient: BaseClient,
      protected router: Router){
    }

    save() {
      this.baseClient.post('accounts/Save', this.item).then(data => {
        this.item = JSON.parse(data.response);
      }).catch(ex => {
          console.log(ex);
      });   
    }
}
