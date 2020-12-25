loadInvoiceDetail();
loadInvoice();

function loadInvoiceDetail() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/store/cart?handler=InvoiceDetail',
        success: function(result) {
            strDropdownCart = '';
            strCart = '';
            $.each(result, function() {
                var item = this;

                strDropdownCart += '<div class="row no-gutters">';
                strDropdownCart += '<div class="col-md-4">';
                strDropdownCart += '<img style="height: 70px;width: 70px" src="./img/product01.png" class="card-img" alt="...">';
                strDropdownCart += '</div>';
                strDropdownCart += '<div class="col-md-8">';
                strDropdownCart += '<div class="card-body">';
                strDropdownCart += '<a href="javascript:void(0)" onclick="pageDetailProduct(' + item.product.productID + ')><h5 class="card-title">' + item.product.productName + '</h5></a>';
                strDropdownCart += '<div class="row">';
                strDropdownCart += '<div class="col-md-9">';
                strDropdownCart += '<p class="card-text"><span class="qty">' + item.amount + 'x</span>' + item.price + '</p>';
                strDropdownCart += '</div>';
                strDropdownCart += '<div class="col-md-3">';
                strDropdownCart += '<button onclick="deleteInvoiceDetail(' + item.id + ')" style="padding: 2px 4px;" class="btn"><i class="fa fa-close"></i></button>';
                strDropdownCart += '</div>';
                strDropdownCart += '</div>';
                strDropdownCart += '</div>';
                strDropdownCart += '</div>';
                strDropdownCart += '</div>';

                strCart += '<div class="order-col">';
                strCart += '<div>';
                strCart += '<input type="number" value="' + item.amount + '" style="width: 50px;" onchange="changeAmountInvoiceDetail(' + item.id + ', $(this).val());"> x ' + item.product.productName + '';
                strCart += '</div>';
                strCart += '<div>' + item.price + '</div>';
                strCart += '</div>';
            })

            $("#load-invoiceDetail").html(strDropdownCart);
            $("#card-load-invoicedetail").html(strCart);
        }
    });
};


function loadInvoice() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/store/cart?handler=Invoice',
        success: function(result) {
            strDropdownCart = '<h5>Tổng tiền: ' + result.totalMoney + '</h5>';
            strCart = '<div><strong class="order-total">' + result.totalMoney + ' đ</strong></div>';
            $("#load-invoice").html(strDropdownCart);
            $("#card-load-invoice").html(strCart);
        }
    });
};


function addToCart(id) {
    $.ajax({
        type: 'Get',
        url: '/store/cart?handler=AddProductToCart',
        headers: {
            "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val()
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: {
            amount: 1,
            productID: id,
        },
        success: function(respone) {
            loadInvoiceDetail();
            loadInvoice();
            alert("Thêm vào giỏ hàng thành công");
        }
    });
}

function changeAmountInvoiceDetail(invoideDetailId, amount) {
    $.ajax({
        type: 'Get',
        url: '/store/cart?handler=ChangeAmount',
        headers: {
            "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val()
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: {
            invoideDetailId: invoideDetailId,
            amount: amount
        },
        success: function(respone) {
            loadInvoiceDetail();
            loadInvoice();
        }
    });
}

function deleteInvoiceDetail(id) {
    $.ajax({
        type: 'Get',
        url: '/store/cart?handler=DeleteInvoiceDetail',
        headers: {
            "RequestVerificationToken": $('input[name="__RequestVerificationToken"]').val()
        },
        dataType: 'json',
        contentType: 'application/json; charset=utf-8',
        data: {
            invoiceDetailId: id,
        },
        success: function(respone) {
            loadInvoiceDetail();
            loadInvoice();
        }
    });
}