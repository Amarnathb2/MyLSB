var App = App || {};

App.PrimaryNav = (function ($) {
    "use strict";

    var $nav,
        onTimer = {},
        offTimer = {},
        focusList = [],
        focusIndex = 0,
        currentMenu = null;

    function init() {
        $nav = $('#PrimaryNav');

        App.$window.on('keydown', function (e) {
            if (currentMenu && [27, 37, 38, 39, 40].indexOf(e.keyCode) > -1) {
                e.preventDefault();

                //Escape
                if (e.keyCode === 27) {
                    closeMenu(currentMenu);
                }
            }
        });

        $nav
            .on('keydown', '.primary-nav__level-1-item--has-children > a', function (e) {
                var $this = $(this),
                    $parent = $this.parent('li');

                if (!$parent.hasClass('primary-nav__level-1-item--open') && e.keyCode === 13) {
                    e.preventDefault();
                    openMenu($parent);
                }

                //left
                if (e.keyCode === 37) {
                    e.preventDefault();
                    $parent.prev('li')
                        .find(' > a')
                        .focus();
                }

                //right
                if (e.keyCode === 39) {
                    e.preventDefault();
                    $parent.next('li')
                        .find(' > a')
                        .focus();
                }

                //down
                if ($parent.hasClass('primary-nav__level-1-item--open') && e.keyCode === 40) {
                    e.preventDefault();
                    focusList[0].focus();
                }
            });

        $nav
            .on('keydown', '.primary-nav__menu', function (e) {
                var $parent = $nav.find('.primary-nav__level-1-item--open');

                //down
                if (e.keyCode === 40) {
                    e.preventDefault();
                    if (focusIndex !== focusList.length - 1) {
                        focusIndex++;
                    }

                    focusList[focusIndex].focus();
                }

                //up
                if (e.keyCode === 38) {
                    e.preventDefault();
                    if (focusIndex !== 0) {
                        focusIndex--;
                    }
                    focusList[focusIndex].focus();
                }

                //left
                if (e.keyCode === 37) {
                    e.preventDefault();
                    $parent.prev('li').find(' > a').focus();
                }

                //right
                if (e.keyCode === 39) {
                    e.preventDefault();
                    $parent.next('li').find(' > a').focus();
                }
            });

        $nav
            .find('.primary-nav__level-1-item--has-children > a, .primary-nav__level-1-item > .primary-nav__menu')
            .on('mouseenter focusin', function () {
                var $this = $(this).parents('li'),
                    key = $this.find('> a')[0].innerText;

                clearTimeout(offTimer[key]);

                if (!$this.hasClass('primary-nav__level-1-item--open')) {
                    onTimer[key] = setTimeout(function () { openMenu($this); }, 100);
                }
            });

        $nav
            .find('.primary-nav__level-1-item--has-children')
            .on('mouseleave focusout', function () {
                var $this = $(this),
                    key = $this.find('> a')[0].innerText;

                clearTimeout(onTimer[key]);

                if ($this.hasClass('primary-nav__level-1-item--open')) {
                    offTimer[key] = setTimeout(function () { closeMenu($this); }, 450);
                }
            });

    }

    function openMenu($item) {
        var $menu = $item.find('.primary-nav__menu');

        focusList = [];
        focusIndex = 0;

        $.each($menu.find('a'), function () {
            focusList.push(this);
        });

        App.$body.trigger('click');

        if (App.Login.isOpen()) {
            App.Login.closeLogin();
        }

        if (App.Search.isOpen()) {
            App.Search.closeSearch();
        }

        App.addOverlay();

        $item
            .addClass('primary-nav__level-1-item--open')
            .find('> a')
            .attr('aria-expanded', 'true');

        $menu
            .addClass('animate__animated fadeInPanel')
            .show();

        currentMenu = $item;
    }

    function closeMenu($item) {
        var $menu = $item.find('.primary-nav__menu');

        $item
            .removeClass('primary-nav__level-1-item--open')
            .find('> a')
            .attr('aria-expanded', 'false');

        $menu
            .one('animationend', function () {
                $menu
                    .removeClass('animate__animated fadeOutPanel')
                    .hide();
            })
            .removeClass('fadeInPanel')
            .addClass('fadeOutPanel');

        if ($item.siblings('.primary-nav__level-1-item--open').length === 0) {
            currentMenu = null;
            App.removeOverlay();
        }
    }

    return {
        init: init
    };
})(jQuery);

$(function () {
    App.PrimaryNav.init();
});