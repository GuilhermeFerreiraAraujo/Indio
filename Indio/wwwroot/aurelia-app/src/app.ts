 import {RouterConfiguration, Router} from 'aurelia-router';

 import 'bootstrap/dist/css/bootstrap.min.css';

 import { PLATFORM } from "aurelia-framework";

  export class App {
    router: Router;
    message = "Hello World!";

    activated() {
      console.log(this.router);
    }

    configureRouter(config: RouterConfiguration, router: Router): void {
      
      config.title = 'Aurelia';
      config.map([
        { route: ['', 'accounts'],  title: "Accounts", nav:true,    name: 'Accounts',       moduleId: PLATFORM.moduleName('views/accounts') },
        { route: ['customers'],    title: "Customers", nav:true,     name: 'Customers',       moduleId: PLATFORM.moduleName('views/customers') },
        { route: ['users'],    title: "Users", nav:true,     name: 'Users',       moduleId: PLATFORM.moduleName('views/users') },

     
      ]);
      this.router = router;

    }
  }
  
