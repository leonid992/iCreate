"use strict";

const getCodeBtn = document.querySelector("#getCode");
const loadImg = document.querySelector("#loading");
const message = document.querySelector("#msg");

const connection = new signalR.HubConnectionBuilder()
  .withUrl("/codeHub")
  .build();

connection.on("ReceiveCode", function (code) {
  setCookie("code", code, 1);
  window.location.href = "/Home/UserCode";
});

connection
  .start()
  .then(function () {
    const cookie = getCookie("code");
    loadImg.style.display = "none";
    if (cookie === false) {
      getCodeBtn.style.display = "block";
      message.style.display = "none";
    } else {
      message.style.display = "block";
      getCodeBtn.style.display = "none";
    }
  })
  .catch(function (err) {
    return console.error(err.toString());
  });

getCodeBtn.addEventListener("click", function (event) {
  connection.invoke("AddCode").catch(function (err) {
    return console.error(err.toString());
  });
  event.preventDefault();
});
