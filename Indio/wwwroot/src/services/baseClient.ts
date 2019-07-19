import { HttpClient } from "../../node_modules/aurelia-http-client";
import { autoinject } from "../../node_modules/aurelia-framework";

@autoinject
export class BaseClient {

    constructor(private client: HttpClient ){
        client.configure(config => {
            config.withBaseUrl('http://localhost:5000/api/');
            config.withCredentials(true);
        });

        this.client = client;
    }

    get(url: string) {
      return this.client.get(`${url}`);
    }

    post(url: string, content: any) {
        return this.client.post(`${url}`, content);
    }
}
