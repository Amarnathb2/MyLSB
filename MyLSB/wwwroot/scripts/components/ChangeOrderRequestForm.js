var App = App || {};

App.ChangeOrderRequestForm = (function ($) {
    "use strict";
  
    var $changeOrderRequestForm = $("#change-order-request-form form.needs-validation");
    var $coinFields = $changeOrderRequestForm.find(".coin");
    var $currencyFields = $changeOrderRequestForm.find(".currency");
    var $totalCoinField = $changeOrderRequestForm.find("#TotalCoin");
    var $totalCurrencyField = $changeOrderRequestForm.find("#TotalCurrency");
    var $totalChangeOrderField = $changeOrderRequestForm.find("#TotalChangeOrder");

    function init() {
        window.addEventListener("load", function () {
            var validation = Array.prototype.filter.call($changeOrderRequestForm, function (form) {
                form.addEventListener("submit", function (event) {
                    event.preventDefault();
                    event.stopPropagation();

                    form.classList.add("was-validated");

                    if (form.checkValidity() === true && grecaptcha.getResponse() != "") {
                        $changeOrderRequestForm.removeClass("was-validated");
                        form.submit();
                    } else {
                        form.reportValidity();
                    }
                }, false);
            });
        });
         //disable cut,copy,paste
        $('.coin, .currency').bind('copy paste cut', function (e) {
            e.preventDefault();
        });

        //Prevent -ve and +ve signs
        $(".coin, .currency").keypress(function (e) {
            if (e.charCode == 43 || e.charCode == 45)
                e.preventDefault();
        })
        $coinFields.on("change", updateTotalCoin);
        $currencyFields.on("change", updateTotalCurrency);

        updateTotalCoin();
        updateTotalCurrency();
    }

    function updateTotalCoin() {
        var total = 0;
        $coinFields.each(function () {
            total += Number($(this).val());
        });
        $totalCoinField.val(Number(total).toFixed(2));
        $totalChangeOrderField.val((Number($totalCoinField.val()) + Number($totalCurrencyField.val())).toFixed(2));
    }

    function updateTotalCurrency() {
        var total = 0;
        $currencyFields.each(function () {
            total += Number($(this).val());
        });
        $totalCurrencyField.val(Number(total).toFixed(2));
        $totalChangeOrderField.val((Number($totalCoinField.val()) + Number($totalCurrencyField.val())).toFixed(2));
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.ChangeOrderRequestForm.init();
});