var App = App || {};

App.ChangeOrderRequestForm = (function ($) {
    "use strict";

    function init() {
        var $main = $("main"),

            $forms = $("#change-order-request-form form.needs-validation"),
            $fields = $fieldsets.find("input, select, textarea"),

            $submitButton = $forms.find("button[type=submit]"),
            $spinner = $forms.find(".spinner");

        window.addEventListener("load", function () {

            var validation = Array.prototype.filter.call($forms, function (form) {
                form.addEventListener("submit", function (event) {
                    event.preventDefault();
                    event.stopPropagation();

                    form.classList.add("was-validated");

                    var invalid = $fields.filter(":invalid:visible");

                    if (invalid.length > 0) {
                        smoothScroll(invalid.first());

                        invalid
                            .first()
                            .focus();
                    }

                    if (form.checkValidity() === true) {
                        grecaptcha.execute();
                    }
                }, false);
            });

        }, false);

        function smoothScroll(anchor) {
            var offset = Math.floor(parseFloat($main.css("padding-top").split("px")[0]));

            if (ZAGFramework.GetCurrentBP() === "xl") {
                if (Math.floor(anchor.offset().top) > 230) {
                    offset -= 66;
                }
            }

            $(window)
                .stop(true)
                .scrollTo(anchor, { duration: 400, interrupt: false, offset: offset * -1 });
        }
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.ChangeOrderRequestForm.init();
});

function onSubmitChangeRequestForm() {
    return new Promise(function (resolve, reject) {
        var $forms = $("#change-request-form form.needs-validation"),
            $submitButton = $forms.find("button[type=submit]"),
            $spinner = $forms.find(".spinner");

        if (grecaptcha === undefined) {
            reject();

            $submitButton.attr("disabled", null);
            $spinner.addClass("d-none");
        }

        var response = grecaptcha.getResponse();

        if (!response) {
            reject();

            $submitButton.attr("disabled", null);
            $spinner.addClass("d-none");
        }

        resolve();

        $forms.submit();
        $submitButton.attr("disabled", "disabled");
        $spinner.removeClass("d-none");
    });
}