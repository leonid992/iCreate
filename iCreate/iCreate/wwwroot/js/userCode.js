"use strict";

const loadImg = document.querySelector("#loading");
const message = document.querySelector("#userCode");

window.addEventListener("load", (event) => {
  const cookie = getCookie("code");
  loadImg.style.display = "none";
  let msg = "Your have not received a code";
  if (cookie !== false) {
    msg = "Your code is: " + cookie;
  }
  message.innerHTML = msg;
});
