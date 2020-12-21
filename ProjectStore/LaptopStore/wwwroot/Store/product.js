loadProduct(0, "", 9);

function loadProduct(currentPage, searchValue, pageSize, catelogs, price, sort) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/store/product?handler=Pagination',
        data: {
            currentPage: currentPage,
            searchValue: searchValue,
            pageSize: pageSize,
            catelogs: catelogs,
            price: price,
            sort: sort,
        },
        success: function(result) {
            var str = "";
            var pagination = "";
            $.each(result.pageOfItems, function() {
                var item = this;
                str += '<div class="col-md-4 col-xs-6">';
                str += '<div class="product">';
                str += '<div class="product-img">';
                str += '<img src="./img/product02.png" alt="">';
                str += '</div>';
                str += '<div class="product-body">';
                str += '<p class="product-category">' + item.catelog.catelogName + '</p>';
                str += '<h3 class="product-name" style="height: 37px;"><a href="javascript:void(0)" onclick="pageDetailProduct(' + item.id + ')">' + item.productName + '</a></h3>';
                str += '<h4 class="product-price">' + item.price + '<del class="product-old-price"> ' + item.priceSale + '</del></h4>';
                str += '</div>';
                str += '<div class="add-to-cart">';
                str += '<button class="add-to-cart-btn" onclick="addToCart(' + item.id + ')"><i class="fa fa-shopping-cart"></i> add to cart</button>';
                str += '</div>';
                str += '</div>';
                str += '</div>';
            })

            var firstDisabled = result.currentPage == 0 ? "disabled" : "";
            var preDisabled = result.currentPage == 0 ? "disabled" : "";
            var lastDisabled = result.currentPage == (result.totalPage - 1) ? "disabled" : "";
            var nextDisabled = result.currentPage < (result.totalPage - 1) ? "disabled" : "";

            pagination += '<li onclick="nextPage(' + (result.currentPage - 1) + ')"><a ' + preDisabled + ' href="javascript:void(0)"><i class="fa fa-angle-left"></i></a></li>';
            pagination += '<li disabled>' + result.currentPage + '</li>';
            pagination += '<li onclick="nextPage(' + (result.currentPage + 1) + ')"><a ' + nextDisabled + ' href="javascript:void(0)"><i class="fa fa-angle-right"></i></a></li>';
            $("#load-list-product").html(str);
            $("#load-pagination-priduct").html(pagination);
        }
    });
};

// $("#searchProduct").click(function() {
//     var searchValue = $("#searchProductInput").val();
//     loadProduct(0, searchValue, 10, 10000000);
// });

function nextPage(currentPage) {
    var catelogs = '';
    var searchValue = $("#searchProductInput").val();
    var pageSize = $('#pageSizeSelect').val();
    var price = $("input[name=price]:checked").val();
    var sort = $('#sortSelect').val();
    $.each($("input[name='catelog']:checked"), function() {
        catelogs += $(this).attr("id") + ',';
    });

    loadProduct(currentPage, searchValue, pageSize, catelogs, price, sort);
};

function catelogCheckBox() {
    var catelogs = '';
    var searchValue = $("#searchProductInput").val();
    var pageSize = $('#pageSizeSelect').val();
    var price = $("input[name=price]:checked").val();
    var sort = $('#sortSelect').val();
    $.each($("input[name='catelog']:checked"), function() {
        if (catelogs.length == 0) {
            catelogs += $(this).attr("id");
        } else {
            catelogs += ',' + $(this).attr("id");
        }
    });

    loadProduct(0, searchValue, pageSize, catelogs, price, sort);
};

$('.price').click(function() {
    var catelogs = '';
    var searchValue = $("#searchProductInput").val();
    var pageSize = $('#pageSizeSelect').val();
    var price = $("input[name=price]:checked").val();
    var sort = $('#sortSelect').val();
    $.each($("input[name='catelog']:checked"), function() {
        catelogs += $(this).attr("id") + ',';
    });

    loadProduct(0, searchValue, pageSize, catelogs, price, sort);
});

$('#sortSelect').change(function() {
    var catelogs = '';
    var searchValue = $("#searchProductInput").val();
    var pageSize = $('#pageSizeSelect').val();
    var price = $("input[name=price]:checked").val();
    var sort = $('#sortSelect').val();
    $.each($("input[name='catelog']:checked"), function() {
        catelogs += $(this).attr("id") + ',';
    });

    loadProduct(0, searchValue, pageSize, catelogs, price, sort);
});

$('#pageSizeSelect').change(function() {
    var catelogs = '';
    var searchValue = $("#searchProductInput").val();
    var pageSize = $('#pageSizeSelect').val();
    var price = $("input[name=price]:checked").val();
    var sort = $('#sortSelect').val();
    $.each($("input[name='catelog']:checked"), function() {
        catelogs += $(this).attr("id") + ',';
    });

    loadProduct(0, searchValue, pageSize, catelogs, price, sort);
});

function pageDetailProduct(id) {
    alert("Trang chi tiết chưa làm : " + id);
    // window.location.href = "https://localhost:5001/store/productDetail?id=" + id;
};