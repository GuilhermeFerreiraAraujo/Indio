import { BaseClient } from "services/baseClient";
import { autoinject, Aurelia, PLATFORM } from "aurelia-framework";
import 'bootstrap/dist/css/bootstrap.min.css';

@autoinject
export class Login {

    private request: any;
    login: () => void;
   
    constructor(private baseClient: BaseClient,
        private aurelia: Aurelia){

            this.baseClient.get('users/IsAuthenticated').then(d => {
                aurelia.setRoot(PLATFORM.moduleName('app'))
            });

            this.login = () => {
                this.baseClient.post('users/Login', this.request).then(data => {
                    aurelia.setRoot(PLATFORM.moduleName('app'))
                }).catch(ex => {
                    console.log(ex);
                }); 
            }
    }
}