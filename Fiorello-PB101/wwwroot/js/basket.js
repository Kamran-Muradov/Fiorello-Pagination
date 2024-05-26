$(function () {
    $(document).on("click", "#products .add-basket", function () {
        let id = parseInt($(this).attr("data-id"));

        $.ajax({
            type: "POST",
            url: `home/addproducttobasket?id=${id}`,
            success: function (response) {
                $(".rounded-circle").text(response.count);
                $(".rounded-circle").next().text(`CART ($${response.totalPrice})`);
            }
        });
    })

    $(document).on("click", "#basket-area .delete-basket", function () {
        let id = parseInt($(this).attr("data-id"));

        $.ajax({
            type: "POST",
            url: `cart/DeleteProductFromBasket?id=${id}`,
            success: function (response) {
                $(".rounded-circle").text(response.totalCount);
                $(".rounded-circle").next().text(`CART ($${response.totalPrice})`);
                $("#basket-area .total-price span").text(`$${response.totalPrice}`);
                $("#basket-area .total-amount strong").text(`$${response.totalPrice}`);
                $(".card-header .basket-count").text(`Cart - ${response.basketCount} items`);
                $(`[data-id=${id}]`).closest(".basket-item").remove();
            }
        });
    })

    $(document).on("click", "#basket-area .increment", function () {
        let id = parseInt($(this).attr("data-id"));
        let count = parseInt($(this).parent().find('input[type=number]').val());

        $(this).parent().find('input[type=number]').val(++count)

        changeProductCount(id, count);
    })

    $(document).on("click", "#basket-area .decrement", function () {
        let id = parseInt($(this).attr("data-id"));
        let count = parseInt($(this).parent().find('input[type=number]').val());

        if (count > 1) {
            $(this).parent().find('input[type=number]').val(--count)

            changeProductCount(id, count);
        }
    })

    $(document).on("input", "#basket-area .form-control", function () {
        let id = parseInt($(this).attr("data-id"));
        let count = parseInt($(this).val());

        if (count > 0) {
            changeProductCount(id, count);
        } else if (count < 1) {
            $(this).val(1);
        }
    })

    function changeProductCount(id, count) {
        $.ajax({
            type: "POST",
            url: `cart/ChangeProductCount?id=${id}&count=${count}`,
            success: function (response) {
                $(".rounded-circle").text(response.totalCount);
                $(".rounded-circle").next().text(`CART ($${response.totalPrice})`);
                $("#basket-area .total-price span").text(`$${response.totalPrice}`);
                $("#basket-area .total-amount strong").text(`$${response.totalPrice}`);
            }
        });
    }
})



