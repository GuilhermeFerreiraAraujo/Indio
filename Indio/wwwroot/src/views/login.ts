import { BaseClient } from "services/baseClient";
import { autoinject } from "aurelia-framework";

@autoinject
export class Login {

    private request: any;

    constructor(private baseClient: BaseClient){

    }

    login(){
        this.baseClient.post('users/Login', this.request).then(data => {
              
        }).catch(ex => {
            console.log(ex);
        }); 
    }

}