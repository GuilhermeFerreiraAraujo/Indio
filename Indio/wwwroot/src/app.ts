import {RouterConfiguration, Router} from 'aurelia-router';
import 'bootstrap/dist/css/bootstrap.min.css';
import { PLATFORM, autoinject } from "aurelia-framework";
import { BaseClient } from 'services/baseClient';

@autoinject
export class App {
  router: Router;

  constructor(private baseClient: BaseClient){
  }

  logOut(){
    this.baseClient.get('users/logout').then(data => {
       
    }).catch(ex => {
        console.log(ex);
    }); 
  }

  configureRouter(config: RouterConfiguration, router: Router): void {
    config.title = 'Aurelia';
    config.map([
      { route: [''],  title: "Login", nav:true,    name: 'Login',       moduleId: PLATFORM.moduleName('views/login') },
      { route: ['SignUp'],  title: "Sign Up", nav:true,    name: 'SignUp',       moduleId: PLATFORM.moduleName('views/signup') },
      { route: ['accounts'],  title: "Accounts", nav:true,    name: 'Accounts',       moduleId: PLATFORM.moduleName('views/accounts') },
      { route: ['customers'],    title: "Customers", nav:true,     name: 'Customers',       moduleId: PLATFORM.moduleName('views/customers') },
      { route: ['users'],    title: "Users", nav:true,     name: 'Users',       moduleId: PLATFORM.moduleName('views/users') },
    ]);
    this.router = router;
  }
}
  
