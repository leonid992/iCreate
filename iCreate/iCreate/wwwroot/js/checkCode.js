"use strict";

const loadImg = document.querySelector("#loading");
const msg = document.querySelector("#checkCodeMsg");
const btn = document.querySelector("#checkCode");
const inputCode = document.querySelector("#code");

btn.addEventListener("click", function (event) {
  event.preventDefault();
  loadImg.style.display = "block";
  btn.style.display = "none";
  const code = inputCode.value;
  $.ajax({
    type: "POST",
    url: "/Home/CheckCode",
    dataType: "json",
    data: { code: code },
    success: function (result) {
      msg.innerHTML = result;
    },
    error: function () {},
    complete: function () {
      loadImg.style.display = "none";
      btn.style.display = "block";
    },
  });
});
