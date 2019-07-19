import {RouterConfiguration, Router} from 'aurelia-router';
import 'bootstrap/dist/css/bootstrap.min.css';
import { PLATFORM, autoinject, Aurelia } from "aurelia-framework";
import { BaseClient } from 'services/baseClient';

@autoinject
export class App {
  router: Router;

  constructor(private baseClient: BaseClient, private aurelia: Aurelia){
  }

  logOut(){
    this.baseClient.get('users/logout').then(data => {
       this.aurelia.setRoot(PLATFORM.moduleName('login'))
    }).catch(ex => {
        console.log(ex);
    }); 
  }

  newUser(){
    alert("TO BE IMPLEMENTED");
  }

  openUser(id: number){
    alert("TO BE IMPLEMENTED");
  }

  configureRouter(config: RouterConfiguration, router: Router): void {
    config.title = 'Aurelia';
    config.map([
      { route: ['SignUp'],       title: "Sign Up", nav:true,    name: 'SignUp',       moduleId: PLATFORM.moduleName('views/users/signup') },
      { route: ['','accounts'],  title: "Accounts",  nav:true,    name: 'Accounts',       moduleId: PLATFORM.moduleName('views/accounts/accounts') },
      { route: 'accounts/:id',   title: "Account Detail", name: 'AccountDetail', moduleId: PLATFORM.moduleName('views/accounts/AccountDetail') },
      { route: ['customers'],    title: "Customers", nav:true,     name: 'Customers',       moduleId: PLATFORM.moduleName('views/customers/customers') },
      { route: ['users'],        title: "Users", nav:true,     name: 'Users',       moduleId: PLATFORM.moduleName('views/users/users') },
    ]);
    this.router = router;
  }
}
  
