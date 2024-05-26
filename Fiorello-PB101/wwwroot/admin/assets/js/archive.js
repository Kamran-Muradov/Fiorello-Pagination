"use strict";

let categoryArchiveBtns = document.querySelectorAll(".add-archive");

categoryArchiveBtns.forEach(item =>
    item.addEventListener("click", function () {
        let id = parseInt(this.getAttribute("data-id"));

        (async () => {
            await fetch(`category/settoarchive/${id}`, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
            }); 

            this.closest(".category-data").remove();
        })();
    })
)

let categoryUnArchiveBtns = document.querySelectorAll(".unarchive");

categoryUnArchiveBtns.forEach(item =>
    item.addEventListener("click", function () {
        console.log(this)
        let id = parseInt(this.getAttribute("data-id"));

        (async () => {
            await fetch(`restore/${id}`, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
            });

            this.closest(".category-data").remove();
        })();
    })
)