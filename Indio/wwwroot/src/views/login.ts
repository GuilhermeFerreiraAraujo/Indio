import { BaseClient } from "services/baseClient";
import { autoinject } from "aurelia-framework";

@autoinject
export class Login {

    private request: any;

    constructor(private baseClient: BaseClient){

    }

    login(){
        this.baseClient.post('Users/Login', this.request).then(data => {
            console.log("Work");
        }).catch(ex => {
            console.log(ex);
        }); 
    }

}