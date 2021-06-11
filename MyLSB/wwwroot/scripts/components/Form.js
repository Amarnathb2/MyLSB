var App = App || {};

App.SharedForm = (function ($) {
    'use strict';

    function init() {
        $("form.kentico-form").each(function (e) {
            FormLoad($(this));
            FormSubmit($(this));
        });
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // FORM LOAD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function FormLoad(Form) {
        // different validation tactics
        Form.find(".zag-validation-input-text").not('.bootstrap-select').on("input", function () { ValidateText($(this)); CountErrors($(this)); });
        Form.find(".zag-validation-input-radio").on("input", function () { ValidateRadio($(this)); CountErrors($(this)); });
        Form.find(".zag-validation-input-checkboxes").on("input", function () { ValidateCheckboxes($(this)); CountErrors($(this)); });
        Form.find(".zag-validation-input-checkbox").on("input", function () { ValidateCheckbox($(this)); CountErrors($(this)); });
        Form.find(".zag-validation-input-file").on("input", function () { ValidateFile($(this)); CountErrors($(this)); });
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // FORM SUBMIT
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function FormSubmit(Form) {
        // remove kentico's update and onsubmit functions
        var KenticoSubmit = Form.attr("onsubmit") || "",
            KenticoUpdate = Form.attr("data-ktc-ajax-update") || "";

        Form.removeAttr("data-ktc-ajax-update")
            .removeAttr("onsubmit")
            .on("submit", function (e) {
            e.preventDefault();
            $(this).removeClass("kentico-form-loaded").addClass("kentico-form-submitted");

            // different validation tactics
            $(this).find(".zag-validation-input-text").not('.bootstrap-select').each(function () { ValidateText($(this)); CountErrors($(this)); });
            $(this).find(".zag-validation-input-radio").each(function () { ValidateRadio($(this)); CountErrors($(this)); });
            $(this).find(".zag-validation-input-checkboxes").each(function () { ValidateCheckboxes($(this)); CountErrors($(this)); });
            $(this).find(".zag-validation-input-checkbox").each(function () { ValidateCheckbox($(this)); CountErrors($(this)); });
            $(this).find(".zag-validation-input-recaptcha").each(function () { ValidateRecaptcha($(this)); CountErrors($(this)); });
            $(this).find(".zag-validation-input-file").each(function () { ValidateFile($(this)); CountErrors($(this)); });

            // if there are no error messages, submit the form
                if ($(this).find(".zag-validation-invalid").length > 0) {
                    console.log($(this).find(".zag-validation-invalid"));

                $(this).find(".zag-validation-invalid").first().focus();
            }
            else {
                // replace kentico's onsubmit, etc. function from attribute list and allow it to submit
                if (KenticoSubmit !== "" && KenticoUpdate !== "") {
                    $(this).attr({ "onsubmit": KenticoSubmit, "data-ktc-ajax-update": KenticoUpdate });
                }

                $(this).off("submit").submit();
            }
        });
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // VALIDATE TEXT
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function ValidateText(Component) {
        // validate individual input against required
        Component.parents(".form-group").find(".zag-validation-error[data-ruletype='required']").each(function () {
            Component.val() !== "" ? $(this).hide() : $(this).show()
        });

        // validate individual input against min-length
        Component.parents(".form-group").find(".zag-validation-error[data-ruletype='minlength']").each(function () {
            Component.val().length >= $(this).attr("data-rulemin") ? $(this).hide() : $(this).show()
        });

        // validate individual input against max-length
        Component.parents(".form-group").find(".zag-validation-error[data-ruletype='maxlength']").each(function () {
            Component.val().length <= $(this).attr("data-rulemax") ? $(this).hide() : $(this).show()
        });

        // validate individual input against compare to another field
        Component.parents(".form-group").find(".zag-validation-error[data-ruletype='compare']").each(function () {

            var Operator = $(this).attr("data-rulecomparison"),
                CompareGuid = $(this).attr("data-rulecomparisonfield"),
                CompareValue = $("[data-guid='" + CompareGuid + "']").val();

            if (Component.val() !== "" && CompareValue !== "") {
                if (Operator === "NotEqual") {
                    Component.val() !== CompareValue ? $(this).hide() : $(this).show()
                }
                else if (Operator === "Equal") {
                    Component.val() === CompareValue ? $(this).hide() : $(this).show()
                }
            }
            else {
                $(this).hide()
            }

        });

        // validate individual input against regex
        Component.parents(".form-group").find(".zag-validation-error[data-ruletype='regex']").each(function () {
            Component.val().match($(this).attr("data-ruleregex")) ? $(this).hide() : $(this).show()
        });
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // VALIDATE RADIO
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function ValidateRadio(Component) {
        // because this is structured data we can assume no validation rule other than required is needed
        var ComponentName = Component.attr("name");
        var ComponentValue = $("input[name='" + ComponentName + "']:checked").val() || "";
        var ComponentError = Component.parents(".form-group").find(".zag-validation-error[data-ruletype='required']");
        ComponentValue !== "" ? ComponentError.hide() : ComponentError.show()
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // VALIDATE CHECKBOXES
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function ValidateCheckboxes(Component) {
        // because this is structured data we can assume no validation rule other than required is needed
        var ComponentGuid = Component.attr("data-guid");
        var ComponentValue = "";

        $("input[data-guid='" + ComponentGuid + "']:checked").each(function () { ComponentValue += $(this).val() + "|"; });
        ComponentValue.trimEnd("|");

        var ComponentError = Component.parents(".form-group").find(".zag-validation-error[data-ruletype='required']");
        ComponentValue !== "" ? ComponentError.hide() : ComponentError.show()
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // VALIDATE CHECKBOX
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function ValidateCheckbox(Component) {
        // bool is set is the only kentico validation for this component
        var ComponentCheckbox = Component.parents(".form-group").find(".zag-validation-input-checkbox");
        var ComponentError = Component.parents(".form-group").find(".zag-validation-error[data-ruletype='boolisset']");
        ComponentCheckbox.is(":checked") ? ComponentError.hide() : ComponentError.show()
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // VALIDATE FILE UPLOAD
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function ValidateFile(Component) {
        Component.parents(".form-group").find(".zag-validation-error[data-ruletype='required']").each(function () {
            Component.val() !== "" ? $(this).hide() : $(this).show()
        });
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // VALIDATE RECAPTCHA
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function ValidateRecaptcha(Component) {
        var ComponentError = Component.parents(".form-group").find(".zag-validation-error[data-ruletype='recaptcha']");
        grecaptcha.getResponse().length > 0 ? ComponentError.hide() : ComponentError.show()
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // COUNT ERRORS
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    function CountErrors(Component) {
        // count error messages of individual input and update ui
        Component.parents(".form-group").find(".zag-validation-errors").show();

        var ErrorContainer = Component.parents(".form-group").find(".zag-validation-errors"),
            ErrorContainerId = ErrorContainer.attr("id"),
            ErrorCount = ErrorContainer.children(".zag-validation-error:visible").length;

        if (ErrorCount > 0) {
            Component.addClass("zag-validation-invalid").attr("aria-describedby", ErrorContainerId);
            ErrorContainer.show();
        }
        else {
            Component.removeClass("zag-validation-invalid").attr("aria-describedby", "");
            ErrorContainer.hide();
        }
    }

    return {
        init: init
    };

})(jQuery);

$(function () {
    App.SharedForm.init();
});