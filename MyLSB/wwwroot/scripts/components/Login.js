var App = App || {};

App.Login = (function ($) {
    "use strict";

    var _isOpen,
        $toggle,
        $panel,
        firstFocusable,
        lastFocusable;

    function init() {
        var $loginSelect = $('#loginSelect');

        $toggle = $('#login');
        $panel = $('#loginPanel');

        $('a[href="#login"]')
            .on('click.login', openLogin);

        $toggle
            .on('click.login', toggleLogin);

        $panel
            .on('click.login', '.login__close', closeLogin)
            .on('keydown.login', function (e) {
                if (e.key === 'Tab' || e.keyCode === 9) {
                    if (e.shiftKey) { // if shift key pressed for shift + tab combination
                        if (document.activeElement === firstFocusable) {
                            $(lastFocusable).focus(); // add focus for the last focusable element
                            e.preventDefault();
                        }
                    } else { // if tab key is pressed
                        if (document.activeElement === lastFocusable) { // if focused has reached to last focusable element then focus first focusable element after pressing tab
                            $(firstFocusable).focus(); // add focus for the first focusable element
                            e.preventDefault();
                        }
                    }
                }
            });

        $loginSelect
            .on('change', function () {
                console.log($(this).val());

                $panel
                    .find('.login__account[data-account="' + $(this).val() + '"]')
                    .removeClass('d-none')
                    .siblings('.login__account')
                    .addClass('d-none');
            });

        App.$body
            .on('keydown.login', function (e) {
                if (_isOpen && e.keyCode === 27) {
                    closeLogin();
                }
            });
    }

    function toggleLogin() {
        _isOpen ? closeLogin() : openLogin();
    }

    function openLogin() {
        if (App.Search.isOpen()) {
            App.Search.closeSearch();
        }

        if (App.HamburgerNav.isOpen()) {
            App.HamburgerNav.closeMenu();
        }

        App.addOverlay();

        $panel
            .one('animationend', function () {
                $panel
                    .focus();

                updateFocusableElements();
                _isOpen = true;
            })
            .addClass('animate__animated fadeInPanel')
            .show()
            .attr('aria-hidden', 'false');

        $toggle
            .attr('aria-expanded', 'true')
            .addClass('login__toggle--open');
    }

    function closeLogin() {
        $panel
            .one('animationend', function () {
                $panel
                    .removeClass('animate__animated fadeOutPanel')
                    .hide();
                _isOpen = false;
            })
            .removeClass('fadeInPanel')
            .addClass('fadeOutPanel')
            .attr('aria-hidden', 'true');

        $toggle
            .attr('aria-expanded', 'false')
            .removeClass('login__toggle--open')
            .focus();

        App.removeOverlay();

        $toggle.focus();
    }

    function updateFocusableElements() {
        firstFocusable = $panel.find('a, button, :input, [tabindex]').first(':visible')[0];
        lastFocusable = $panel.find('a, button, :input, [tabindex]').last(':visible')[0];
    }

    return {
        init: init,
        closeLogin: closeLogin,
        isOpen: function () { return _isOpen; }
    };
})(jQuery);

$(function () {
    App.Login.init();
});