import { autoinject } from 'aurelia-framework';
import { AccountModel } from 'models/account.models';
import { BaseClient } from 'services/baseClient';


@autoinject()
export class accounts {

    items: AccountModel[] = [];

    constructor(private baseClient: BaseClient){

    }

    activate() {
        this.baseClient.get('accounts/get').then(data => {
            this.items = JSON.parse(data.response);
          }).catch(ex => {
              console.log(ex);
          });          
    }
}