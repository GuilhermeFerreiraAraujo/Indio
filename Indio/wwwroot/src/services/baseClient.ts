import { HttpClient } from "../../node_modules/aurelia-http-client";
import { autoinject } from "../../node_modules/aurelia-framework";

@autoinject
export class BaseClient {

    private baseUrl: string = 'https://localhost:44307/api/';

    constructor(private client: HttpClient ){
    }

    get(url: string) {
       return this.client.get(`${this.baseUrl}${url}`);
    }

    post(url: string, content: any) {
        return this.client.post(`${this.baseUrl}${url}`, content);
    }

}
