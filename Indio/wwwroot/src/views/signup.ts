import { UserModel } from "models/user.models";

export class SignUp{

    protected item: UserModel;

    activate(){
        this.item =  {
            id: 0,
            name: '',
            email: '',
            password: ''
        }
    }

    signup() {
        console.log(this.item);
        alert("Sign Up");
    }
}