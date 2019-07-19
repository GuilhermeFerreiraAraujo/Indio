import { UserModel } from 'models/user.models';
import { BaseClient } from 'services/baseClient';
import { autoinject } from 'aurelia-framework';
import { Router } from 'aurelia-router';

@autoinject()
export class users {

    protected items: UserModel[] = [];

    constructor(private baseClient: BaseClient,
      private router: Router){

    }

    newUser() {
      this.router.navigateToRoute('SignUp', {id: 0});
    }

    activate() {
        this.baseClient.get('users/get').then(data => {
            this.items = JSON.parse(data.response);
          }).catch(ex => {
            console.log(ex);
          });       
    }
}
