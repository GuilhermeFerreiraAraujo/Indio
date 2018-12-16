import { UserModel } from "models/user.models";
import { BaseClient } from "services/baseClient";
import { autoinject } from "../../node_modules/aurelia-framework";

@autoinject
export class SignUp{

    protected item: UserModel;

    constructor(private baseClient: BaseClient){

    }

    activate(){
        this.item =  {
            id: 0,
            name: '',
            email: '',
            password: ''
        }
    }

    signup() {
        this.baseClient.post('Users/SignUps', this.item).then(data => {
          }).catch(ex => {
              console.log(ex);
          }); 
    }
}