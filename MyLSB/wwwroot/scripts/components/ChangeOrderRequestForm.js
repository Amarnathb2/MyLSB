var App = App || {};

App.ChangeOrderRequestForm = (function ($) {
    "use strict";

    var $changeOrderRequestForm = $("#change-order-request-form form.needs-validation");

    function init() {
        window.addEventListener("load", function () {
            var validation = Array.prototype.filter.call($changeOrderRequestForm, function (form) {
                form.addEventListener("submit", function (event) {
                    event.preventDefault();
                    event.stopPropagation();

                    form.classList.add("was-validated");

                    if (form.checkValidity() === true) {
                        $changeOrderRequestForm.removeClass("was-validated");
                        form.submit();
                    }
                }, false);
            });
        });
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.ChangeOrderRequestForm.init();
});