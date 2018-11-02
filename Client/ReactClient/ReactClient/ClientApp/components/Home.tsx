import * as React from 'react';
import { RouteComponentProps } from 'react-router';

//
// the values in the parens are placeholders for the state that the app will expect
// 
export class Home extends React.Component<RouteComponentProps<{}>, { username: string, pwd: string, token: string, patrollers: any[], currentState: string }> {

    constructor() {
        super();

        // initialize the state
        //
        this.state = {
            username: '',
            pwd: '',
            token: '',
            patrollers: [],
            currentState: 'Unathorized'
        };

        // this will give the functions access to the "this" operator
        // so that the state vars will be avail in the functions
        // 
        this.getOne = this.getOne.bind(this);
        this.getAll = this.getAll.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    // this function will capture the value that is typed into the textboxes
    // and load it into the appropriate state var
    // in the case of this app, only username and password are streamed into the state vars
    // 
    handleChange(e) {
        this.setState({ [e.target.name]: e.target.value });
    }

    // this function will get just a single value from the API endpoint
    // 
    getOne(this) {

        console.log("The token is: " + this.state.token);

        // needed to use "this" in the async fetch 
        var self = this;

        // setup the headers
        // the JWT uses the "Bearer" authorization with the token in the header
        // 
        const headers = new Headers({
            //"Content-Type": "application/json",
            "Authorization": "Bearer " + this.state.token
        });

        // do a GET request to the API endpoint for the patroller with a patrol number of 14170
        // 
        fetch('http://localhost/WPSPApi/api/Patroller/147170', {
            method: 'GET',
            headers,
        }).then(response => response.json())
            .then(data => {
                console.log("xxxxx: " + JSON.stringify(data));  
                self.setState({ patrollers: data });   // store the response in the patrollers state var
            }).catch((responseJson) => {
                console.log("zzzz: " + responseJson);
            });
    }

    // get all of the patrollers from the API endpoint
    // 
    getAll(this) {

        // needed to use "this" in the async fetch 
        var self = this;

        const headers = new Headers({
            //"Content-Type": "application/json",
            "Authorization": "Bearer " + this.state.token
        });

         // setup the headers
        // the JWT uses the "Bearer" authorization with the token in the header
        // 
        fetch('http://localhost/WPSPApi/api/Patroller/', {
            method: 'GET',
            headers,
        }).then(response => response.json())
            .then(data => {
                console.log("xxxxx: " + JSON.stringify(data));
                self.setState({ patrollers: data });  // store the response in the patrollers state var

            }).catch((responseJson) => {
                console.log("zzzz: " + responseJson);
            });
    }

    // this function handles the username / password submit
    // the function will try to fetch a token from the API endpoint which is then stored in the state
    // once in the state, the token is usable in the rest of the app.
    // 
    async handleSubmit(e) {

        console.log("username:: " + this.state.username + " ---  pwd:: " + this.state.pwd);

        // re-initialize the state vars before each new request
        // 
        this.setState({ 'token': '' });
        this.setState({ 'currentState': 'Unathorized' });
        this.setState({ 'patrollers': [] });

        // stop the UI default behavior and do what I tell you to do
        // 
        event.preventDefault();
        var outData = { "username": this.state.username, "password": this.state.pwd };

        var self = this;

        // https://www.tjvantoll.com/2015/09/13/fetch-and-errors/ 

        fetch('http://localhost/WPSPApi/token', {
            mode: 'cors',
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
                "Access-Control-Allow-Origin": "http://localhost/React1",
                "Access-Control-Allow-Credentials": "true"
            },
            body: JSON.stringify(outData)
        })
            .then(function (results) {
                if (!results.ok) self.setState({ 'currentState': results.statusText });
                return results.json()
            })
            .then(function (data) {
                self.setState({ 'token': data })
            })
            .then(function (data) {
                //self.doNext(self, data);
            })
            .catch(function (err) {
                console.error;
            })

        this.setState({ 'username': '' });
        this.setState({ 'pwd': '' });


    }

    public render() {
        //const { username, pwd} = this.state;

        return <div>
            <br />

            <div className="login">
                <form>
                    Username:<input type="text" name="username" onChange={this.handleChange.bind(this)} value={this.state.username} className="logininput" />
                    <br />
                    Password: <input type="text" name="pwd" onChange={this.handleChange.bind(this)} value={this.state.pwd} className="logininput" />
                    <br />
                    <input type="button" value="Submit" onClick={this.handleSubmit} />
                    <br />
                    <br />
                    Get One:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button"  value="Get One" onClick={this.getOne} />
                    <br />
                    <br />
                    Get All:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" value="Get All" onClick={this.getAll}  />

                </form>
                
            </div>
            <br /><br />
            <div>{this.state.currentState}</div>
            <p>TOKEN:</p>
            <div>{this.state.token}</div>
            <br /><br />
            <p>Respnse:</p>
            <div>{JSON.stringify(this.state.patrollers)}</div>
            <br />
            <br />
          
        </div>
    }
}






    //doNext(self, data) {

    //    console.log("I am in doNext:: " + self.state.token);


    //    //var url = "http://localhost/WPSPApi/api/Patroller/147170";
    //    //var bearer = 'Bearer ' + self.state.token;

    //    //fetch(url, {
    //    //    method: 'GET',
    //    //    credentials: 'include',
    //    //    headers: {
    //    //        'Authorization': bearer,
    //    //        'X-FP-API-KEY': 'iphone',
    //    //        'Content-Type': 'application/json'
    //    //    }
    //    //}).then((responseJson) => {
    //    //    self.setState({ patrollers: responseJson });
    //    //});


    //    const headers = new Headers({
    //        //"Content-Type": "application/json",
    //        "Authorization": "Bearer " + self.state.token
    //    });

    //    fetch('http://localhost/WPSPApi/api/Patroller/147170', {
    //        method: 'GET',
    //        headers,
    //    }).then(response => response.json())
    //        .then(data => {
    //            console.log("xxxxx: " + JSON.stringify(data));
    //            self.setState({ patrollers: data });

    //        }).catch((responseJson) => {
    //            console.log("zzzz: " + responseJson);
    //        });




    //    //fetch('http://localhost/WPSPApi/api/Patroller/147170', {
    //    //    method: 'post',
    //    //    headers: new Headers({
    //    //        'Authorization': "Bearer " + self.state.token,
    //    //        'Content-Type': 'application/x-www-form-urlencoded'
    //    //    }),
    //    //    body: ''
    //    //})
    //    //    .then(res => res.json())
    //    //    .then(json => self.setState({ patrollers: json }))


    //    console.log("Leave doNext");
    //}