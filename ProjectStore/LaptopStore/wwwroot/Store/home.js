$('.menu-toggle > a').on('click', function(e) {
    e.preventDefault();
    $('#responsive-nav').toggleClass('active');
})

// Fix cart dropdown from closing
$('.cart-dropdown').on('click', function(e) {
    e.stopPropagation();
});

// (function($) {
loadCatelog();
loadNewProduct(100000);
loadTopSelling(100000);

function loadNewProduct(id) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/store/home?handler=NewProduct',
        data: {
            id: id
        },
        success: function(result) {
            str = '';
            $.each(result, function() {
                var item = this;
                str += '<div class="col-md-3 col-xs-4">';
                str += '<div class="product">';
                str += '<div class="product-img">';
                str += '<img src="./img/product02.png" alt="">';
                str += '</div>';
                str += '<div class="product-body">';
                str += '<p class="product-category">' + item.catelog.catelogName + '</p>';
                str += '<h3 class="product-name" style="height: 37px;"><a href="javascript:void(0)" onclick="pageDetailProduct(' + item.id + ')">' + item.productName + '</a></h3>';
                str += '<h4 class="product-price">' + item.price + '<del class="product-old-price">' + item.priceSale + '</del></h4>';
                str += '</div>';
                str += '<div class="add-to-cart">';
                str += '<button class="add-to-cart-btn" onclick="addToCart(' + item.id + ')"><i class="fa fa-shopping-cart"></i> add to cart</button>';
                str += '</div>';
                str += '</div>';
                str += '</div>';
            })
            $("#home-load-newProduct").html(str);
        }
    });
};

$(".home-catelogNewProduct").click(function() {
    var id = $(this).attr("id");
    loadNewProduct(id);
});

function loadTopSelling(id) {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/store/home?handler=TopSelling',
        data: {
            id: id
        },
        success: function(result) {
            str = '';
            $.each(result, function() {
                var item = this;
                str += '<div class="col-md-3 col-xs-4">';
                str += '<div class="product">';
                str += '<div class="product-img">';
                str += '<img src="./img/product02.png" alt="">';
                str += '</div>';
                str += '<div class="product-body">';
                str += '<p class="product-category">' + item.catelog.catelogName + '</p>';
                str += '<h3 class="product-name" style="height: 37px;"><a href="javascript:void(0)" onclick="pageDetailProduct(' + item.id + ')">' + item.productName + '</a></h3>';
                str += '<h4 class="product-price">' + item.price + '<del class="product-old-price">' + item.priceSale + '</del></h4>';
                str += '</div>';
                str += '<div class="add-to-cart">';
                str += '<button class="add-to-cart-btn" onclick="addToCart(' + item.id + ')"><i class="fa fa-shopping-cart"></i> add to cart</button>';
                str += '</div>';
                str += '</div>';
                str += '</div>';
            })
            $("#home-load-TopSelling").html(str);

            str = '';
            $.each(result, function() {
                var item = this;
                str += '<div class="product-widget">';
                str += '<div class="product-img">';
                str += '<img src="./img/product01.png" alt="">';
                str += '</div>';
                str += '<div class="product-body">';
                str += '<p class="product-category">' + item.catelog.catelogName + '</p>';
                str += '<h3 class="product-name"><a onclick="pageDetailProduct(' + item.id + ')">' + item.productName + '</a></h3>';
                str += '<h4 class="product-price">' + item.price + '<del class="product-old-price">' + item.priceSale + '</del></h4>';
                str += '</div>';
                str += '</div>';
            })
            $("#product-load-TopSelling").html(str);
        }
    });
};

$(".home-catelogTopSelling").click(function() {
    var id = $(this).attr("id");
    loadTopSelling(id);
});

function loadCatelog() {
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/store/home?handler=Catelog',
        success: function(result) {
            str = '';
            $.each(result, function() {
                var item = this;
                str += '<a href="#">' + item.catelogName + '</a>';
            })
            $("#home-load-catelog").html(str);

            str = '';
            $.each(result, function() {
                var item = this;
                str += '<div class="input-checkbox">';
                str += '<input type="checkbox" onclick="catelogCheckBox()" id="' + item.id + '" name="catelog">';
                str += '<label for="' + item.id + '">';
                str += '<span></span>' + item.catelogName;
                str += '</label>';
                str += '</div>';
            })
            $("#product-load-catelog").html(str);
        }
    });
}
// })(jQuery);