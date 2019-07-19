import { UserModel } from 'models/user.models';
import { BaseClient } from 'services/baseClient';
import { autoinject } from 'aurelia-framework';

@autoinject
export class users {

    protected items: UserModel[] = [];

    constructor(private baseClient: BaseClient){

    }

    activate() {
        this.baseClient.get('users/get').then(data => {
            this.items = JSON.parse(data.response);
          }).catch(ex => {
            console.log(ex);
          });       
    }
}
