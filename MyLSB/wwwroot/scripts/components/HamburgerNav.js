var App = App || {};

App.HamburgerNav = (function ($) {
    "use strict";

    var $hamburger,
        $toggle,
        $menu,
        focusList = [],
        focusIndex = 0,
        _isOpen;

    function init() {
        $hamburger = $('#hamburgerNav');
        $toggle = $hamburger.find('.hamburger-nav__toggle');
        $menu = $hamburger.find('.hamburger-nav__menu');

        $toggle.on('click', toggleMenu);

        $menu.on('click', '.hamburger-nav__level-1 [aria-haspopup="true"]', function (e) {
            var $this = $(this),
                $parent = $this.parent();

            if ($parent.hasClass('open')) {
                closeSubMenu($parent);
            } else {
                e.preventDefault();
                openSubMenu($parent);
            }
        });

        $menu.on('keydown', function (e) {
            //down
            if (e.keyCode === 40) {
                e.preventDefault();
                updateFocus($(':focus').first(), 1);
            }

            //up
            if (e.keyCode === 38) {
                e.preventDefault();
                updateFocus($(':focus').first(), -1);
            }

            //esc
            if (e.keyCode === 27) {
                e.preventDefault();
                closeMenu();
            }
        });

        App.$window.on('enter-lg enter-xl', closeMenu);
    }

    function updateFocus($item, i) {
        focusList = [];

        $.each($menu.find('a:visible, input:visible, button:visible'), function () {
            focusList.push(this);
        });

        focusIndex = focusList.indexOf($item[0]);
        $(focusList[focusIndex + i]).focus();
    }

    function toggleMenu() {
        _isOpen ? closeMenu() : openMenu();
    }

    function openMenu() {

        if (App.Search.isOpen()) {
            App.Search.closeSearch();
        }

        if (App.Login.isOpen()) {
            App.Login.closeLogin();
        }

        $toggle
            .addClass('hamburger-nav__toggle--open')
            .attr('aria-expanded', 'true');

        $menu
            .one('animationend', function () {
                _isOpen = true;
            })
            .addClass('animate__animated fadeInPanel')
            .show();

        App.addOverlay();
    }

    function closeMenu() {
        if (!_isOpen) {
            return;
        }

        $toggle
            .removeClass('hamburger-nav__toggle--open')
            .attr('aria-expanded', 'false');

        $menu
            .one('animationend', function () {
                $menu
                    .removeClass('animate__animated fadeOutPanel')
                    .hide();
                $toggle.focus();
                _isOpen = false;
            })
            .removeClass('fadeInPanel')
            .addClass('fadeOutPanel');

        App.removeOverlay();

        closeSubMenu($menu.find('.open'));
    }

    function openSubMenu($item) {
        $item
            .addClass('open')
            .find('> button, > a')
            .attr('aria-expanded', 'true')
            .end()
            .find('> ul, > div')
            .stop()
            .slideDown(350)
            .end()
            .siblings()
            .each(function () {
                closeSubMenu($(this));
                closeSubMenu($(this).find('.open'));
            });
    }

    function closeSubMenu($item) {
        $item
            .removeClass('open')
            .find('> button, > a')
            .attr('aria-expanded', 'false')
            .end()
            .find('> ul, > div')
            .stop()
            .slideUp(350);
    }

    return {
        init: init,
        closeMenu: closeMenu,
        isOpen: function () { return _isOpen; }
    };
})(jQuery);

$(function () {
    App.HamburgerNav.init();
});