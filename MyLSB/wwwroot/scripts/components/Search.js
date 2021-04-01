var App = App || {};

App.Search = (function ($) {
    "use strict";

    var _isOpen,
        $toggle,
        $panel,
        firstFocusable,
        lastFocusable;

    function init() {
        $toggle = $('#searchToggle');
        $panel = $('#searchPanel');

        $toggle
            .on('click.search', toggleSearch);

        $panel
            .on('click.search', '.search__close', closeSearch)
            .on('keydown.search', function (e) {
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

        App.$window.on('keydown.Search', function (e) {
            if (_isOpen && [27, 37, 38, 39, 40].indexOf(e.keyCode) > -1) {
                e.preventDefault();

                //Escape
                if (e.keyCode === 27) {
                    closeSearch();
                }
            }
        });
    }

    function toggleSearch() {
        _isOpen ? closeSearch() : openSearch();
    }

    function openSearch() {
        if (App.Login.isOpen()) {
            App.Login.closeLogin();
        }

        if (App.HamburgerNav.isOpen()) {
            App.HamburgerNav.closeMenu();
        }

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

        App.addOverlay();

        $toggle
            .attr('aria-expanded', 'true')
            .addClass('search__toggle--open');
    }

    function closeSearch() {
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

        App.removeOverlay();

        $toggle
            .attr('aria-expanded', 'false')
            .removeClass('search__toggle--open')
            .focus();
    }

    function updateFocusableElements() {
        firstFocusable = $panel.find('a, button, :input, [tabindex]').first(':visible')[0];
        lastFocusable = $panel.find('a, button, :input, [tabindex]').last(':visible')[0];
    }

    return {
        init: init,
        closeSearch: closeSearch,
        isOpen: function () { return _isOpen; }
    };
})(jQuery);

$(function () {
    App.Search.init();
});