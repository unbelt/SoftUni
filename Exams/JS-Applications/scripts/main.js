(function () {
    'use strict';

    $(function () {
        registerEventHandlers();
        showHomeView();
    });

    function registerEventHandlers() {
        $(".home").click(showHomeView);

        $(".login").click(showLoginView);
        $("#login-button").click(loginClicked);

        $(".register").click(showRegisterView);
        $("#register-button").click(registerClicked);

        $(".products-link").click(showProductsView);
        $(".add-product").click(showAddProductView);
        $('#add-product-button').click(addProductClicked);
        $('#edit-product-button').click(postEditedProduct);

        $('#filter').click(filterProductsClicked);
        $('.clear-filters').click(clearFilterClicked);

        $('.cancel').click(cancelClicked);
        $(".logout").click(logoutClicked);
    }

    function loadView() {

        showHomeView();

        $('.home').on('click', showHomeView);
        $('.login').on('click', showLoginView);
        $('.register').on('click', showRegisterView);

        $('.products').on('click', showProductsView);
        $('.add-product').on('click', showAddProductView);
        $('.edit-product').on('click', showEditProductView);
    }

    // Home View
    function showHomeView() {
        $('#main > *').hide();
        $('#menu > *').hide();

        if (userSession.getCurrentUser()) {
            $('#logged-menu').show();
            $('.main-header').text('Welcome, ' + userSession.getCurrentUser().username);
            $('#logged-welcome-view').show();
        } else {
            $('#guest-menu').show();
            $('#guest-welcome-view').show();
        }
    }

    // Login View
    function showLoginView() {
        $('#main > *').hide();
        $('#login-view').show();

        $("#username").val('');
        $("#password").val('');
    }

    function loginClicked() {
        var username = $('#log-username').val();
        var password = $('#log-password').val();

        ajaxRequester.login(
            username, password,
            authSuccess,
            showLoginError
        );
    }

    function authSuccess(data) {
        userSession.login(data);
        showHomeView();
    }

    // Register View
    function showRegisterView() {
        $('#main > *').hide();
        $('#register-view').show();

        $("#username").val('');
        $("#password").val('');
    }

    function registerClicked() {
        var username = $("#reg-username").val();
        var password = $("#reg-password").val();

        ajaxRequester.register(
            username, password,
            function (data) {
                data.username = username;
                ajaxRequester.login(
                    username, password,
                    authSuccess,
                    showLoginError
                );
            },
            showRegisterError
        );
    }

    // Products View
    function showProductsView() {
        $('#main > *').hide();
        $('#products-view').show();

        var sessionToken = userSession.getCurrentUser().sessionToken;

        ajaxRequester.getProducts(sessionToken, loadProductsSuccess, loadProductsError)
    }

    // Product View
    function showEditProductView(product) {
        $('#main > *').hide();
        $('#item-name').val(product.name);
        $('#category-edit').val(product.category);
        $('#price-edit').val(product.price);
        $('#edit-product-button').data('productId', product.objectId);
        $('#edit-product-view').show();

        var currentUser = userSession.getCurrentUser();
        var sessionToken = currentUser.sessionToken;
    }

    function addProductClicked() {
        var itemName = $('#name').val();
        var itemCategory = $('#category').val();
        var itemPrice = $('#price').val();

        ajaxRequester.createProduct(itemName, itemCategory,  Number(itemPrice), userSession.getCurrentUser().objectId, showProductsView, addProductError);
    }

    function postEditedProduct() {
        var itemName = $('#item-name').val();
        var itemCategory = $('#category-edit').val();
        var itemPrice = $('#price-edit').val();

        ajaxRequester.editProduct(itemName, itemCategory, Number(itemPrice), userSession.getCurrentUser().sessionToken, $(this).data('productId'), showProductsView, editProductError);
    }

    // Load Products
    function loadProductsSuccess(data) {

        var $productUl = $('<ul>');
        var categories = [];

        for (var p in data.results) {
            var product = data.results[p];
            var $productLi = $('<li>').addClass('product');

            var $productInfoDiv = $('<div>').addClass('product-info');

            var $productName = $('<p>').addClass('item-name').text(product.name);
            var $productCategory = $('<p>').addClass('category');
            var $category = $('<span>').addClass('pre').text('Category: ');

            $productCategory.append($category);
            $productCategory.append(product.category);

            var $productPrice = $('<p>').addClass('price');
            var $price = $('<span>').addClass('pre').text('Price: ');

            $productPrice.append($price);
            $productPrice.append('$' + product.price);

            $productInfoDiv.append($productName);
            $productInfoDiv.append($productCategory);
            $productInfoDiv.append($productPrice);

            $productLi.append($productInfoDiv);

            if (userSession.getCurrentUser().id === product['ACL'].userId) {
                var $productFooter = $('<footer>').addClass('product-footer');
                var $productFooterEditLink = $('<a>').attr('href', '#');
                var $productFooterDeleteLink = $('<a>').attr('href', '#');

                $productFooterEditLink.data('product', product);
                $productFooterDeleteLink.data('product', product);

                var $productFooterEditButton = $('<button>').addClass('edit-button').text('Edit');
                var $productFooterDeleteButton = $('<button>').addClass('delete-button').text('Delete');

                $productFooterEditLink.append($productFooterEditButton);
                $productFooterDeleteLink.append($productFooterDeleteButton);

                $productFooter.append($productFooterEditLink.click(editProductClicked));
                $productFooter.append($productFooterDeleteLink.click(deleteProductClicked));

                $productLi.append($productFooter);
            }

            $productUl.append($productLi);


            categories.push(product.category);
        }

        var uniqueCategories = [];

        $.each(categories, function (i, el) {
            if ($.inArray(el, uniqueCategories) === -1) uniqueCategories.push(el);
        });

        for (var cat in uniqueCategories) {
            $("#category-list").append(new Option(uniqueCategories[cat], uniqueCategories[cat]));
        }

        $('.products').html('');
        $('.products').append($productUl);
    }

    function filterProductsClicked() {

        $('.products').html('');
        var $productUl = $('<ul>');

        ajaxRequester.getProducts(userSession.getCurrentUser().sessionToken, function(data) {

            for (var p in data.results) {

                var product = data.results[p];

                if (!(product.name == $('.search-bar').val() &&
                    product.price >= $('#min-price').val() &&
                    product.price <= $('#max-price').val() &&
                    product.category == $('#category-list').val())) {

                    continue;
                }

                var $productLi = $('<li>').addClass('product');

                var $productInfoDiv = $('<div>').addClass('product-info');

                var $productName = $('<p>').addClass('item-name').text(product.name);
                var $productCategory = $('<p>').addClass('category');
                var $category = $('<span>').addClass('pre').text('Category: ');

                $productCategory.append($category);
                $productCategory.append(product.category);

                var $productPrice = $('<p>').addClass('price');
                var $price = $('<span>').addClass('pre').text('Price: ');

                $productPrice.append($price);
                $productPrice.append('$' + product.price);

                $productInfoDiv.append($productName);
                $productInfoDiv.append($productCategory);
                $productInfoDiv.append($productPrice);

                $productLi.append($productInfoDiv);

                if (userSession.getCurrentUser().id === product['ACL'].userId) {
                    var $productFooter = $('<footer>').addClass('product-footer');
                    var $productFooterEditLink = $('<a>').attr('href', '#');
                    var $productFooterDeleteLink = $('<a>').attr('href', '#');

                    $productFooterEditLink.data('product', product);
                    $productFooterDeleteLink.data('product', product);

                    var $productFooterEditButton = $('<button>').addClass('edit-button').text('Edit');
                    var $productFooterDeleteButton = $('<button>').addClass('delete-button').text('Delete');

                    $productFooterEditLink.append($productFooterEditButton);
                    $productFooterDeleteLink.append($productFooterDeleteButton);

                    $productFooter.append($productFooterEditLink.click(editProductClicked));
                    $productFooter.append($productFooterDeleteLink.click(deleteProductClicked));

                    $productLi.append($productFooter);
                }

                $productUl.append($productLi);
                $('.products').append($productUl);

            }
        }, loadProductsError);
    }

    function clearFilterClicked() {
        $('.search-bar').val('');
        $('#min-price').val('');
        $('#max-price').val('');
    }

    function editProductClicked() {
        var product = $(this).data('product');

        showEditProductView(product);

        return false;
    }

    function deleteProductClicked() {
        var product = $(this).data('product');
        var currentUser = userSession.getCurrentUser();
        var sessionToken = currentUser.sessionToken;

        noty(
            {
                text: "Delete this product?",
                type: 'confirm',
                layout: 'topCenter',
                buttons: [
                    {
                        text: "Yes",
                        onClick: function ($noty) {
                            ajaxRequester.deleteProduct(
                                sessionToken, product.objectId,
                                showProductsView, deleteProductError
                            );

                            $noty.close();
                        }
                    },
                    {
                        text: "Cancel",
                        onClick: function ($noty) {
                            $noty.close();
                        }
                    }
                ]
            }
        );

        return false;
    }

    // Add Products View
    function showAddProductView() {
        $('#main > *').hide();
        $('#add-product-view').show();
    }

    // Logout
    function logoutClicked() {
        userSession.logout();
        showHomeView();
    }

    function cancelClicked() {
        showProductsView();
    }

    function showLoginError() {
        showMessage('Login failed', 'error');
    }

    function showRegisterError() {
        showMessage('Registration failed', 'error');
    }

    function loadProductsError() {
        showMessage('Product listing filed', 'error');
    }

    function addProductError() {
        showMessage('Add product failed', 'error');
    }

    function editProductError() {
        showMessage('Edit product failed', 'error');
    }

    function deleteProductError() {
        showMessage('Failed deleting the product', 'error');
    }

    function showMessage(msg, type) {
        noty({
            text: msg,
            type: type,
            layout: 'topCenter',
            timeout: 5000
        });
    }
}());