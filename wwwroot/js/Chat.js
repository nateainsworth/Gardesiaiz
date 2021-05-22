"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
connection.start();

function login() {
    var email = document.getElementById("login__username").value;
    var password = document.getElementById("login__password").value;
    connection.invoke("loginUser", email, password);
}
